using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Meziantou.GitLabClient.Internals;
using Newtonsoft.Json;

namespace Meziantou.GitLab
{
    public partial class GitLabClient : IGitLabClient, IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly bool _httpClientOwned;
        private readonly StreamingContext _streamingContext;
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
            _streamingContext = new StreamingContext(StreamingContextStates.All, this);
        }

        protected virtual Task<HttpResponseMessage> SendAsync(HttpRequestMessage message, RequestOptions options, CancellationToken cancellationToken)
        {
            return SendAsync(message, options, null, cancellationToken);
        }

        protected virtual async Task<HttpResponseMessage> SendAsync(HttpRequestMessage message, RequestOptions options, Func<HttpResponseMessage, bool> isValidResponse, CancellationToken cancellationToken)
        {
            var authenticator = Authenticator;
            if (authenticator != null)
            {
                await authenticator.AuthenticateAsync(message, cancellationToken).ConfigureAwait(false);
            }

            if (options != null)
            {
                if (options.ProfileToken != null)
                {
                    message.Headers.Add("X-Profile-Token", options.ProfileToken);
                }

                if (options.Sudo != null)
                {
                    message.Headers.Add("Sudo", options.Sudo.Value.ValueAsString);
                }
            }

            var response = await _httpClient.SendAsync(message, cancellationToken).ConfigureAwait(false);
            if (isValidResponse != null)
            {
                var isValid = isValidResponse(response);
                if (isValid)
                {
                    return response;
                }
            }

            await EnsureStatusCodeAsync(response).ConfigureAwait(false);
            return response;
        }

        public virtual async Task<T> GetAsync<T>(string url, RequestOptions options, CancellationToken cancellationToken) where T : GitLabObject
        {
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Get;
                request.RequestUri = BuildUri(url);

                using (var response = await SendAsync(request, options, IsValid, cancellationToken).ConfigureAwait(false))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                        return default;

                    return await Deserialize<T>(response).ConfigureAwait(false);
                }
            }

            bool IsValid(HttpResponseMessage message)
            {
                return message.IsSuccessStatusCode || message.StatusCode == System.Net.HttpStatusCode.NotFound;
            }
        }

        public virtual async Task<IReadOnlyList<T>> GetCollectionAsync<T>(string url, RequestOptions options, CancellationToken cancellationToken) where T : GitLabObject
        {
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Get;
                request.RequestUri = BuildUri(url);

                using (var response = await SendAsync(request, options, cancellationToken).ConfigureAwait(false))
                {
                    return await Deserialize<IReadOnlyList<T>>(response).ConfigureAwait(false);
                }
            }
        }

        public virtual async Task<PagedResponse<T>> GetPagedAsync<T>(string url, RequestOptions options, CancellationToken cancellationToken) where T : GitLabObject
        {
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Get;
                request.RequestUri = BuildUri(url);

                using (var response = await SendAsync(request, options, cancellationToken).ConfigureAwait(false))
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
                    else
                    {
#if DEBUG
                        throw new GitLabException("The response does not contain page information.");
#endif
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

        public virtual async Task<T> PutJsonAsync<T>(string url, object data, RequestOptions options, CancellationToken cancellationToken) where T : GitLabObject
        {
            using (var request = new HttpRequestMessage())
            using (var content = new JsonContent(data, _jsonSerializerSettings))
            {
                request.Method = HttpMethod.Put;
                request.RequestUri = BuildUri(url);
                request.Content = content;

                using (var response = await SendAsync(request, options, cancellationToken).ConfigureAwait(false))
                {
                    return await Deserialize<T>(response).ConfigureAwait(false);
                }
            }
        }

        public virtual async Task<T> PostJsonAsync<T>(string url, object data, RequestOptions options, CancellationToken cancellationToken) where T : GitLabObject
        {
            using (var request = new HttpRequestMessage())
            using (var content = new JsonContent(data, _jsonSerializerSettings))
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = BuildUri(url);
                request.Content = content;

                using (var response = await SendAsync(request, options, cancellationToken).ConfigureAwait(false))
                {
                    return await Deserialize<T>(response).ConfigureAwait(false);
                }
            }
        }

        public virtual async Task PostJsonAsync(string url, object data, RequestOptions options, CancellationToken cancellationToken)
        {
            using (var request = new HttpRequestMessage())
            using (var content = new JsonContent(data, _jsonSerializerSettings))
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = BuildUri(url);
                request.Content = content;

                using (var response = await SendAsync(request, options, cancellationToken).ConfigureAwait(false))
                {
                    // TODO ensure no content
                }
            }
        }

        public virtual async Task DeleteAsync(string url, RequestOptions options, CancellationToken cancellationToken)
        {
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Delete;
                request.RequestUri = BuildUri(url);

                using (var response = await SendAsync(request, options, cancellationToken).ConfigureAwait(false))
                {
                    // TODO ensure there is no body
                }
            }
        }

        private async Task<T> Deserialize<T>(HttpResponseMessage message)
        {
            if (!IsJsonResponse(message))
                throw new ArgumentException($"Content type must be application/json but is {message.Content.Headers.ContentType?.MediaType}", nameof(message));

            using (var s = await message.Content.ReadAsStreamAsync().ConfigureAwait(false))
            using (var sr = new StreamReader(s))
            using (var reader = new JsonTextReader(sr))
            {
                var jsonSerializer = JsonSerializer.Create(_jsonSerializerSettings);
                jsonSerializer.Context = _streamingContext;

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
            return new JsonSerializerSettings()
            {
                CheckAdditionalContent = false,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
            };
        }

        private async Task EnsureStatusCodeAsync(HttpResponseMessage responseMessage)
        {
            // TODO throw more specific exception (Unauthorized, Forbidden, NotFound, ValidationException, etc.)
            if (responseMessage.IsSuccessStatusCode)
                return;

            if (IsJsonResponse(responseMessage))
            {
                var error = await Deserialize<GitLabError>(responseMessage).ConfigureAwait(false);
                var request = responseMessage.RequestMessage;
                throw new GitLabException(request.Method, request.RequestUri, responseMessage.StatusCode, error);
            }
            else
            {
                var error = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                var request = responseMessage.RequestMessage;
                throw new GitLabException(request.Method, request.RequestUri, responseMessage.StatusCode, error);
            }
        }

        private static bool IsJsonResponse(HttpResponseMessage message)
        {
            if (message.Content == null)
                return false;

            return string.Equals(message.Content.Headers.ContentType?.MediaType, "application/json", StringComparison.OrdinalIgnoreCase);
        }
    }
}
