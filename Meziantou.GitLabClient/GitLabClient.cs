using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Meziantou.GitLabClient.Internals;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Meziantou.GitLab
{
    public partial class GitLabClient : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly bool _httpClientOwned;
        // internal for testing purpose
        internal readonly JsonSerializerSettings _jsonSerializerSettings;

        public Uri ServerUri { get; }

        public IAuthenticator Authenticator { get; set; }

        public GitLabClient(string serverUri, string token)
            : this(new HttpClient(), true, new Uri(serverUri, UriKind.Absolute), new TokenAuthenticator(token))
        {
        }

        public GitLabClient(string serverUri)
            : this(new HttpClient(), true, new Uri(serverUri, UriKind.Absolute), null)
        {
        }

        public GitLabClient(HttpClient httpClient)
            : this(httpClient, false, null, null)
        {
        }

        public GitLabClient(HttpClient httpClient, string serverUri, string token)
            : this(httpClient, true, new Uri(serverUri, UriKind.Absolute), new TokenAuthenticator(token))
        {
        }

        private GitLabClient(HttpClient httpClient, bool httpClientOwned, Uri serverUri, IAuthenticator authenticator)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClientOwned = httpClientOwned;
            ServerUri = new Uri(serverUri, "api/v4/");
            Authenticator = authenticator;
            _jsonSerializerSettings = CreateJsonSerializerSettings();
        }

        protected virtual async Task<HttpResponseMessage> SendAsync(HttpRequestMessage message, CancellationToken cancellationToken)
        {
            var authenticator = Authenticator;
            if (authenticator != null)
            {
                await authenticator.AuthenticateAsync(message, cancellationToken).ConfigureAwait(false);
            }

            var response = await _httpClient.SendAsync(message, cancellationToken).ConfigureAwait(false);
            await EnsureStatusCodeAsync(response).ConfigureAwait(false);
            return response;
        }

        protected virtual async Task<T> GetAsync<T>(string url, CancellationToken cancellationToken) where T : GitLabObject
        {
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Get;
                request.RequestUri = BuildUri(url);

                using (var response = await SendAsync(request, cancellationToken).ConfigureAwait(false))
                {
                    return await Deserialize<T>(response).ConfigureAwait(false);
                }
            }
        }

        protected internal virtual async Task<PagedResponse<T>> GetPagedAsync<T>(string url, CancellationToken cancellationToken) where T : GitLabObject
        {
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Get;
                request.RequestUri = BuildUri(url);

                using (var response = await SendAsync(request, cancellationToken).ConfigureAwait(false))
                {
                    string firstLink = null;
                    string lastLink = null;
                    string prevLink = null;
                    string nextLink = null;

                    if (response.Headers.TryGetValues("link", out var values))
                    {
                        foreach (var value in values)
                        {
                            foreach (var linkValue in value.Split(','))
                            {
                                if (LinkHeaderValue.TryParse(linkValue, out var headerValue))
                                {
                                    if (string.Equals(headerValue.Rel, "first", StringComparison.OrdinalIgnoreCase))
                                    {
                                        firstLink = headerValue.Url;
                                    }
                                    else if (string.Equals(headerValue.Rel, "last", StringComparison.OrdinalIgnoreCase))
                                    {
                                        lastLink = headerValue.Url;
                                    }
                                    else if (string.Equals(headerValue.Rel, "next", StringComparison.OrdinalIgnoreCase))
                                    {
                                        nextLink = headerValue.Url;
                                    }
                                    else if (string.Equals(headerValue.Rel, "prev", StringComparison.OrdinalIgnoreCase))
                                    {
                                        prevLink = headerValue.Url;
                                    }
                                }
                            }
                        }
                    }

                    var pageIndex = response.Headers.GetHeaderValue("X-Page", -1);
                    var pageSize = response.Headers.GetHeaderValue("X-Per-Page", -1);
                    var total = response.Headers.GetHeaderValue("X-Total", -1);
                    var totalPages = response.Headers.GetHeaderValue("X-Total-Pages", -1);

                    var data = await Deserialize<IReadOnlyList<T>>(response).ConfigureAwait(false);

                    return new PagedResponse<T>(
                        client: this,
                        data: data,
                        pageIndex: pageIndex,
                        pageSize: pageSize,
                        totalItems: total,
                        totalPages: totalPages,
                        firstUrl: firstLink,
                        previousUrl: prevLink,
                        nextUrl: nextLink,
                        lastUrl: lastLink);
                }
            }
        }

        protected virtual async Task<T> PutJsonAsync<T>(string url, object data, CancellationToken cancellationToken) where T : GitLabObject
        {
            using (var request = new HttpRequestMessage())
            using (var content = new JsonContent(data, _jsonSerializerSettings))
            {
                request.Method = HttpMethod.Put;
                request.RequestUri = BuildUri(url);
                request.Content = content;

                using (var response = await SendAsync(request, cancellationToken).ConfigureAwait(false))
                {
                    return await Deserialize<T>(response).ConfigureAwait(false);
                }
            }
        }

        protected virtual async Task<T> PostJsonAsync<T>(string url, object data, CancellationToken cancellationToken) where T : GitLabObject
        {
            using (var request = new HttpRequestMessage())
            using (var content = new JsonContent(data, _jsonSerializerSettings))
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = BuildUri(url);
                request.Content = content;

                using (var response = await SendAsync(request, cancellationToken).ConfigureAwait(false))
                {
                    return await Deserialize<T>(response).ConfigureAwait(false);
                }
            }
        }

        private async Task<T> Deserialize<T>(HttpResponseMessage message)
        {
            using (var s = await message.Content.ReadAsStreamAsync().ConfigureAwait(false))
            using (var sr = new StreamReader(s))
            using (var reader = new JsonTextReader(sr))
            {
                var jsonSerializer = JsonSerializer.Create(_jsonSerializerSettings);
                jsonSerializer.Context = new System.Runtime.Serialization.StreamingContext(System.Runtime.Serialization.StreamingContextStates.All, this);

                return (T)jsonSerializer.Deserialize(reader, typeof(T));
            }
        }

        private Uri BuildUri(string relativeUrl)
        {
            return new Uri(ServerUri, relativeUrl);
        }

        public void Dispose()
        {
            if (_httpClientOwned)
            {
                _httpClient.Dispose();
            }
        }

        private JsonSerializerSettings CreateJsonSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy(),
                },
                Converters =
                {
                    //new GitLabObjectConverter(this),
                    new GitLabEnumConverter(),
                }
            };
        }

        private async Task EnsureStatusCodeAsync(HttpResponseMessage responseMessage)
        {
            if (responseMessage.IsSuccessStatusCode)
                return;

            GitLabError error = null;
            if (IsJsonResponse(responseMessage))
            {
                error = await Deserialize<GitLabError>(responseMessage).ConfigureAwait(false);
            }

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new NotFoundException(error);
            }

            throw new GitLabClientException(error, error.ErrorDescription);
        }

        private static bool IsJsonResponse(HttpResponseMessage message)
        {
            if (message.Content == null)
                return false;

            return string.Equals(message.Content.Headers.ContentType?.MediaType, "application/json", StringComparison.OrdinalIgnoreCase);
        }
    }
}
