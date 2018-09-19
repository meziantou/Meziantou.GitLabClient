using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Meziantou.GitLabClient;
using Newtonsoft.Json;

namespace Meziantou.GitLab
{
    public partial class GitLabClient : IGitLabClient, IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly bool _httpClientOwned;
        internal StreamingContext StreamingContext { get; }
        internal JsonSerializerSettings JsonSerializerSettings { get; } = new JsonSerializerSettings();

        public Uri ServerUri { get; }

        public IAuthenticator Authenticator { get; set; }

        public GitLabClient(string serverUri, string personalAccessToken)
            : this(new HttpClient(), true, new Uri(serverUri, UriKind.Absolute), new PersonalAccessTokenAuthenticator(personalAccessToken))
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

        public GitLabClient(HttpClient httpClient, string serverUri, string personalAccessToken)
            : this(httpClient, true, new Uri(serverUri, UriKind.Absolute), new PersonalAccessTokenAuthenticator(personalAccessToken))
        {
        }

        private GitLabClient(HttpClient httpClient, bool httpClientOwned, Uri serverUri, IAuthenticator authenticator)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClientOwned = httpClientOwned;
            ServerUri = new Uri(serverUri, "api/v4/");
            Authenticator = authenticator;
            StreamingContext = new StreamingContext(StreamingContextStates.All, this);
        }

        protected virtual async Task<HttpResponse> SendAsync(HttpRequestMessage message, RequestOptions options, CancellationToken cancellationToken)
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

            if (!message.RequestUri.IsAbsoluteUri)
            {
                message.RequestUri = new Uri(ServerUri, message.RequestUri);
            }

            var response = await _httpClient.SendAsync(message, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
            return new HttpResponse(response, this);
        }

        public virtual async Task<T> GetAsync<T>(string url, RequestOptions options, CancellationToken cancellationToken) where T : GitLabObject
        {
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);

                using (var response = await SendAsync(request, options, cancellationToken).ConfigureAwait(false))
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        return default;

                    await response.EnsureStatusCodeAsync().ConfigureAwait(false);
                    return await response.ToObjectAsync<T>().ConfigureAwait(false);
                }
            }
        }

        public virtual async Task<IReadOnlyList<T>> GetCollectionAsync<T>(string url, RequestOptions options, CancellationToken cancellationToken) where T : GitLabObject
        {
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);

                using (var response = await SendAsync(request, options, cancellationToken).ConfigureAwait(false))
                {
                    await response.EnsureStatusCodeAsync().ConfigureAwait(false);
                    return await response.ToObjectAsync<IReadOnlyList<T>>().ConfigureAwait(false);
                }
            }
        }

        public virtual async Task<PagedResponse<T>> GetPagedAsync<T>(string url, RequestOptions options, CancellationToken cancellationToken) where T : GitLabObject
        {
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);

                using (var response = await SendAsync(request, options, cancellationToken).ConfigureAwait(false))
                {
                    await response.EnsureStatusCodeAsync().ConfigureAwait(false);

                    string firstLink = null;
                    string lastLink = null;
                    string prevLink = null;
                    string nextLink = null;

                    var headers = response.ResponseHeaders;
                    if (headers.TryGetValues("link", out var values))
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

                    var pageIndex = headers.GetHeaderValue("X-Page", -1);
                    var pageSize = headers.GetHeaderValue("X-Per-Page", -1);
                    var total = headers.GetHeaderValue("X-Total", -1);
                    var totalPages = headers.GetHeaderValue("X-Total-Pages", -1);

                    var data = await response.ToObjectAsync<IReadOnlyList<T>>().ConfigureAwait(false);

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
            using (var content = new JsonContent(data, JsonSerializerSettings))
            {
                request.Method = HttpMethod.Put;
                request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                request.Content = content;

                using (var response = await SendAsync(request, options, cancellationToken).ConfigureAwait(false))
                {
                    await response.EnsureStatusCodeAsync().ConfigureAwait(false);
                    return await response.ToObjectAsync<T>().ConfigureAwait(false);
                }
            }
        }

        public virtual async Task<T> PostJsonAsync<T>(string url, object data, RequestOptions options, CancellationToken cancellationToken) where T : GitLabObject
        {
            using (var request = new HttpRequestMessage())
            using (var content = new JsonContent(data, JsonSerializerSettings))
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                request.Content = content;

                using (var response = await SendAsync(request, options, cancellationToken).ConfigureAwait(false))
                {
                    await response.EnsureStatusCodeAsync().ConfigureAwait(false);
                    return await response.ToObjectAsync<T>().ConfigureAwait(false);
                }
            }
        }

        public virtual async Task PostJsonAsync(string url, object data, RequestOptions options, CancellationToken cancellationToken)
        {
            using (var request = new HttpRequestMessage())
            using (var content = new JsonContent(data, JsonSerializerSettings))
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                request.Content = content;

                using (var response = await SendAsync(request, options, cancellationToken).ConfigureAwait(false))
                {
                    await response.EnsureStatusCodeAsync().ConfigureAwait(false);
                }
            }
        }

        public virtual async Task DeleteAsync(string url, RequestOptions options, CancellationToken cancellationToken)
        {
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Delete;
                request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);

                using (var response = await SendAsync(request, options, cancellationToken).ConfigureAwait(false))
                {
                    await response.EnsureStatusCodeAsync().ConfigureAwait(false);
                }
            }
        }

        public void Dispose()
        {
            if (_httpClientOwned)
            {
                _httpClient.Dispose();
            }
        }

        protected class HttpResponse : IDisposable
        {
            public HttpResponse(HttpResponseMessage message, GitLabClient client)
            {
                ResponseMessage = message;
                Client = client;
            }

            private HttpResponseMessage ResponseMessage { get; }
            private GitLabClient Client { get; }

            public HttpStatusCode StatusCode => ResponseMessage.StatusCode;
            public HttpResponseHeaders ResponseHeaders => ResponseMessage.Headers;

            public async Task EnsureStatusCodeAsync()
            {
                // TODO throw more specific exception (Unauthorized, Forbidden, NotFound, ValidationException, etc.)
                if (ResponseMessage.IsSuccessStatusCode)
                    return;

                if (IsJsonResponse(ResponseMessage))
                {
                    var error = await DeserializeAsync<GitLabError>().ConfigureAwait(false);
                    var request = ResponseMessage.RequestMessage;
                    throw new GitLabException(request.Method, request.RequestUri, ResponseMessage.StatusCode, error);
                }
                else
                {
                    var error = await ResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var request = ResponseMessage.RequestMessage;
                    throw new GitLabException(request.Method, request.RequestUri, ResponseMessage.StatusCode, error);
                }
            }

            public Task<T> ToObjectAsync<T>()
            {
                return DeserializeAsync<T>();
            }

            public async Task<Stream> ToStreamAsync()
            {
                var stream = await ResponseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
                return new StreamWithDisposableObject(stream, this);
            }

            public void Dispose()
            {
                ResponseMessage.Dispose();
            }

            private async Task<T> DeserializeAsync<T>()
            {
                if (!IsJsonResponse(ResponseMessage))
                    throw new InvalidOperationException($"Content type must be application/json but is {ResponseMessage.Content.Headers.ContentType?.MediaType}");

                using (var s = await ResponseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false))
                using (var sr = new StreamReader(s))
                using (var reader = new JsonTextReader(sr))
                {
                    var jsonSerializer = JsonSerializer.Create(Client.JsonSerializerSettings);
                    jsonSerializer.Context = Client.StreamingContext;

                    return (T)jsonSerializer.Deserialize(reader, typeof(T));
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
}
