using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Meziantou.GitLab.Core;
using Meziantou.GitLab.Serialization;
using Meziantou.GitLabClient;

namespace Meziantou.GitLab
{
    public partial class GitLabClient : IGitLabClient, IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly bool _httpClientOwned;

        public Uri? ServerUri { get; }

        public IAuthenticator? Authenticator { get; set; }

        protected GitLabClient(HttpClient httpClient, bool httpClientOwned, Uri? serverUri, IAuthenticator? authenticator)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClientOwned = httpClientOwned;
            if (serverUri != null)
            {
                ServerUri = new Uri(serverUri, "api/v4/");
            }
            Authenticator = authenticator;
        }

        public static IGitLabClient Create(Uri serverUri)
        {
            return new GitLabClient(new HttpClient(), httpClientOwned: true, serverUri, authenticator: null);
        }

        public static IGitLabClient Create(Uri serverUri, string personalAccessToken)
        {
            return new GitLabClient(new HttpClient(), httpClientOwned: true, serverUri, new PersonalAccessTokenAuthenticator(personalAccessToken));
        }

        public static IGitLabClient Create(HttpClient httpClient)
        {
            return new GitLabClient(httpClient, httpClientOwned: false, serverUri: null, authenticator: null);
        }

        public static IGitLabClient Create(HttpClient httpClient, Uri serverUri, string personalAccessToken)
        {
            return new GitLabClient(httpClient, httpClientOwned: true, serverUri, new PersonalAccessTokenAuthenticator(personalAccessToken));
        }

        private async Task<HttpResponse> SendAsync(HttpRequestMessage message, RequestOptions? options, CancellationToken cancellationToken)
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

            if (ServerUri != null && !message.RequestUri.IsAbsoluteUri)
            {
                message.RequestUri = new Uri(ServerUri, message.RequestUri);
            }

            var response = await _httpClient.SendAsync(message, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
            return new HttpResponse(response);
        }

        public virtual async Task<T?> GetAsync<T>(string url, RequestOptions? options, CancellationToken cancellationToken = default)
            where T : GitLabObject
        {
            using var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url, UriKind.RelativeOrAbsolute),
            };

            using var response = await SendAsync(request, options, cancellationToken).ConfigureAwait(false);
            if (response.StatusCode == HttpStatusCode.NotFound)
                return default;

            await response.EnsureStatusCodeAsync(cancellationToken).ConfigureAwait(false);
            return await response.ToObjectAsync<T>(cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task<IReadOnlyList<T>> GetCollectionAsync<T>(string url, RequestOptions? options, CancellationToken cancellationToken = default)
            where T : GitLabObject
        {
            using var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url, UriKind.RelativeOrAbsolute),
            };

            using var response = await SendAsync(request, options, cancellationToken).ConfigureAwait(false);
            await response.EnsureStatusCodeAsync(cancellationToken).ConfigureAwait(false);
            var result = await response.ToCollectionAsync<T>(cancellationToken).ConfigureAwait(false);
            if (result is null)
                throw new GitLabException(response.RequestMethod, response.RequestUri, response.StatusCode, $"The response cannot be converted to '{typeof(T)}' because the body is null or empty");

            return result;
        }

        public virtual async Task<GitLabPageResponse<T>> GetPagedCollectionAsync<T>(string url, RequestOptions? options, CancellationToken cancellationToken = default)
            where T : GitLabObject
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, new Uri(url, UriKind.RelativeOrAbsolute));
            using var response = await SendAsync(request, options, cancellationToken).ConfigureAwait(false);
            await response.EnsureStatusCodeAsync(cancellationToken).ConfigureAwait(false);

            string? firstLink = null;
            string? lastLink = null;
            string? prevLink = null;
            string? nextLink = null;

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
                throw new GitLabException(request.Method, request.RequestUri, response.StatusCode, "The response does not contain the pagination headers.");
#endif
            }

            var pageIndex = headers.GetHeaderValue("X-Page", -1);
            var pageSize = headers.GetHeaderValue("X-Per-Page", -1);
            var total = headers.GetHeaderValue("X-Total", -1);
            var totalPages = headers.GetHeaderValue("X-Total-Pages", -1);

            var data = await response.ToCollectionAsync<T>(cancellationToken).ConfigureAwait(false);
            if (data is null)
                throw new GitLabException(response.RequestMethod, response.RequestUri, response.StatusCode, $"The response cannot be converted to '{typeof(T)}' collection because the body is null or empty");

            return new GitLabPageResponse<T>(
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

        public virtual async Task<T> PutJsonAsync<T>(string url, object data, RequestOptions? options, CancellationToken cancellationToken = default)
            where T : GitLabObject
        {
            using var request = new HttpRequestMessage();
            using var content = new JsonContent(data, JsonSerialization.Options);
            request.Method = HttpMethod.Put;
            request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
            request.Content = content;

            using var response = await SendAsync(request, options, cancellationToken).ConfigureAwait(false);
            await response.EnsureStatusCodeAsync(cancellationToken).ConfigureAwait(false);
            var result = await response.ToObjectAsync<T>(cancellationToken).ConfigureAwait(false);
            if (result is null)
                throw new GitLabException(response.RequestMethod, response.RequestUri, response.StatusCode, $"The response cannot be converted to '{typeof(T)}' because the body is null or empty");

            return result;
        }

        public virtual async Task<T> PostJsonAsync<T>(string url, object data, RequestOptions? options, CancellationToken cancellationToken = default)
            where T : GitLabObject
        {
            using var request = new HttpRequestMessage();
            using var content = new JsonContent(data, JsonSerialization.Options);
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
            request.Content = content;

            using var response = await SendAsync(request, options, cancellationToken).ConfigureAwait(false);
            await response.EnsureStatusCodeAsync(cancellationToken).ConfigureAwait(false);
            var result = await response.ToObjectAsync<T>(cancellationToken).ConfigureAwait(false);
            if (result is null)
                throw new GitLabException(response.RequestMethod, response.RequestUri, response.StatusCode, $"The response cannot be converted to '{typeof(T)}' because the body is null or empty");

            return result;
        }

        public virtual async Task PostJsonAsync(string url, object data, RequestOptions? options, CancellationToken cancellationToken = default)
        {
            using var request = new HttpRequestMessage();
            using var content = new JsonContent(data, JsonSerialization.Options);
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
            request.Content = content;

            using var response = await SendAsync(request, options, cancellationToken).ConfigureAwait(false);
            await response.EnsureStatusCodeAsync(cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task DeleteAsync(string url, RequestOptions? options, CancellationToken cancellationToken = default)
        {
            using var request = new HttpRequestMessage(HttpMethod.Delete, new Uri(url, UriKind.RelativeOrAbsolute));
            using var response = await SendAsync(request, options, cancellationToken).ConfigureAwait(false);
            await response.EnsureStatusCodeAsync(cancellationToken).ConfigureAwait(false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_httpClientOwned)
                {
                    _httpClient.Dispose();
                }
            }
        }

        protected sealed class HttpResponse : IDisposable
        {
            public HttpResponse(HttpResponseMessage message)
            {
                ResponseMessage = message;
            }

            private HttpResponseMessage ResponseMessage { get; }

            public HttpStatusCode StatusCode => ResponseMessage.StatusCode;
            public HttpResponseHeaders ResponseHeaders => ResponseMessage.Headers;
            public HttpMethod RequestMethod => ResponseMessage.RequestMessage.Method;
            public Uri RequestUri => ResponseMessage.RequestMessage.RequestUri;

            public async Task EnsureStatusCodeAsync(CancellationToken cancellationToken)
            {
                // TODO throw more specific exception (Unauthorized, Forbidden, NotFound, ValidationException, etc.)
                if (ResponseMessage.IsSuccessStatusCode)
                    return;

                if (IsJsonResponse(ResponseMessage))
                {
                    var error = await DeserializeAsync<GitLabError>(cancellationToken).ConfigureAwait(false);
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

            public Task<T?> ToObjectAsync<T>(CancellationToken cancellationToken)
                where T : GitLabObject
            {
                return DeserializeAsync<T>(cancellationToken);
            }

            public Task<IReadOnlyList<T>?> ToCollectionAsync<T>(CancellationToken cancellationToken)
                where T : GitLabObject
            {
                return DeserializeAsync<IReadOnlyList<T>>(cancellationToken);
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

            private async Task<T?> DeserializeAsync<T>(CancellationToken cancellationToken)
                where T : class // TODO remove class constraint when updating to next roslyn version
            {
                if (!IsJsonResponse(ResponseMessage))
                    throw new InvalidOperationException($"Content type must be application/json but is {ResponseMessage.Content.Headers.ContentType?.MediaType}");

                using var s = await ResponseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
                return await JsonSerialization.DeserializeAsync<T>(s, cancellationToken).ConfigureAwait(false);
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
