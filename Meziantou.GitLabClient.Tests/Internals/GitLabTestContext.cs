using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Nito.AsyncEx;
using Polly;

namespace Meziantou.GitLab.Tests
{
    public class GitLabTestContext : IDisposable
    {
        public static GitLabDockerContainer DockerContainer { get; set; }

        private readonly HttpClient _httpClient;
        private readonly LoggingHandler _loggingHandler;
        private readonly RetryHandler _retryHandler;
        private readonly List<TestGitLabClient> _clients = new List<TestGitLabClient>();

        public GitLabTestContext(TestContext testOutput, HttpClientHandler handler = null)
        {
            TestContext = testOutput;

            _retryHandler = new RetryHandler();
            _loggingHandler = new LoggingHandler();

            _loggingHandler.InnerHandler = handler ?? new HttpClientHandler();
            _retryHandler.InnerHandler = _loggingHandler;

            _httpClient = new HttpClient(_retryHandler, disposeHandler: true);
            AdminClient = CreateClient(DockerContainer.AdminUserToken);
        }

        public Random Random { get; } = new Random();
        public TestGitLabClient AdminClient { get; }
        public string ServerUri { get; }
        public TestContext TestContext { get; }

        public async Task<TestGitLabClient> CreateNewUserAsync()
        {
            var username = "user_" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + "_" + Guid.NewGuid().ToString("N");
            var email = username + "@dummy.com";
            var password = "Pa$$w0rd";
            var client = AdminClient;
            var users = await client.GetUsersAsync(username: username);
            var user = await client.CreateUserAsync(
                email: email,
                username: username,
                password: password,
                name: username,
                admin: false,
                canCreateGroup: true,
                skipConfirmation: true);

            var token = await client.CreateImpersonationTokenAsync(user, "UnitTest", new[] { "api", "read_user" });
            return CreateClient(token.Token);
        }

        public string GetRandomEmojiName()
        {
            var fields = typeof(Emoji).GetFields();
            var index = Random.Next(0, fields.Length);
            return (string)fields[index].GetValue(null);
        }

        public string GetRandomString()
        {
            return "GitLabClientTests" + Guid.NewGuid().ToString("N");
        }

        private TestGitLabClient CreateClient(string token)
        {
            var client = new TestGitLabClient(_httpClient, DockerContainer.GitLabUrl, token);
            //client.ProfileToken = DockerContainer.ProfileToken;
            client.JsonSerializerSettings.CheckAdditionalContent = true;
            client.JsonSerializerSettings.Formatting = Formatting.Indented;
            client.JsonSerializerSettings.Error = (sender, e) => TestContext.WriteLine(string.Format("{0}", e));
            _clients.Add(client);
            return client;
        }

        public void Dispose()
        {
            TestContext.WriteLine(string.Join("\n--------\n", _loggingHandler.Logs));
            var objects = _clients.SelectMany(c => c.Objects).ToList();

            _httpClient?.Dispose();

            objects.ForEach(o =>
            {
#if VALIDATE_UNMAPPED_PROPERTIES
                GitLabObjectAssertions.DoesNotContainUnmappedProperties(o);
#endif
                GitLabObjectAssertions.DoesContainOnlyUtcDates(o);
                GitLabObjectAssertions.DoesContainGitLabClient(o);
            });
        }

        public class TestGitLabClient : GitLabClient
        {
            private static readonly AsyncReaderWriterLock _readerWriterLockSlim = new AsyncReaderWriterLock();

            public List<object> Objects { get; } = new List<object>();

            public TestGitLabClient(HttpClient client, string serverUri, string token)
                : base(client, serverUri, token)
            {
            }

            public override async Task<T> GetAsync<T>(string url, RequestOptions options, CancellationToken cancellationToken)
            {
                using (await ReaderLockAsync())
                {
                    var result = await base.GetAsync<T>(url, options, cancellationToken);
                    Objects.Add(result);
                    return result;
                }
            }

            public override async Task<IReadOnlyList<T>> GetCollectionAsync<T>(string url, RequestOptions options, CancellationToken cancellationToken)
            {
                using (await ReaderLockAsync())
                {
                    var readOnlyList = await base.GetCollectionAsync<T>(url, options, cancellationToken).ConfigureAwait(false);
                    Objects.AddRange(readOnlyList);
                    return readOnlyList;
                }
            }

            public override async Task<PagedResponse<T>> GetPagedAsync<T>(string url, RequestOptions options, CancellationToken cancellationToken)
            {
                using (await ReaderLockAsync())
                {
                    var pagedResponse = await base.GetPagedAsync<T>(url, options, cancellationToken).ConfigureAwait(false);
                    Objects.AddRange(pagedResponse.Data);
                    return pagedResponse;
                }
            }

            public override async Task<T> PostJsonAsync<T>(string url, object data, RequestOptions options, CancellationToken cancellationToken)
            {
                using (await WriterLockAsync())
                {
                    var result = await base.PostJsonAsync<T>(url, data, options, cancellationToken).ConfigureAwait(false);
                    Objects.Add(result);
                    return result;
                }
            }

            public override async Task PostJsonAsync(string url, object data, RequestOptions options, CancellationToken cancellationToken)
            {
                using (await WriterLockAsync())
                {
                    await base.PostJsonAsync(url, data, options, cancellationToken).ConfigureAwait(false);
                }
            }

            public override async Task<T> PutJsonAsync<T>(string url, object data, RequestOptions options, CancellationToken cancellationToken)
            {
                using (await WriterLockAsync())
                {
                    var result = await base.PutJsonAsync<T>(url, data, options, cancellationToken).ConfigureAwait(false);
                    Objects.Add(result);
                    return result;
                }
            }

            public override async Task DeleteAsync(string url, RequestOptions options, CancellationToken cancellationToken)
            {
                using (await WriterLockAsync())
                {
                    await base.DeleteAsync(url, options, cancellationToken);
                }
            }

            private Task<IDisposable> ReaderLockAsync()
            {
                return _readerWriterLockSlim.ReaderLockAsync();
            }

            private Task<IDisposable> WriterLockAsync()
            {
                return _readerWriterLockSlim.WriterLockAsync();
            }
        }

        public class LoggingHandler : DelegatingHandler
        {
            public List<string> Logs { get; } = new List<string>();

            protected override async Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request,
                CancellationToken cancellationToken)
            {
                var sb = new StringBuilder();
                sb.Append(request.Method).Append(' ').Append(request.RequestUri).AppendLine();
                LogHeaders(request.Headers, sb);

                if (request.Content != null)
                {
                    LogHeaders(request.Content.Headers, sb);

                    var requestBody = await request.Content.ReadAsStringAsync().ConfigureAwait(false);
                    sb.AppendLine().AppendLine(requestBody);
                }

                var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

                sb.AppendLine("--------");
                sb.Append((int)response.StatusCode).Append(" ").AppendLine(response.ReasonPhrase);
                LogHeaders(response.Headers, sb);
                if (response.Content != null)
                {
                    LogHeaders(response.Content.Headers, sb);
                    var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (string.Equals(response.Content.Headers.ContentType?.MediaType, "application/json", StringComparison.OrdinalIgnoreCase))
                    {
                        sb.AppendLine().AppendLine(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(responseContent), Formatting.Indented));
                    }
                    else
                    {
                        sb.AppendLine().AppendLine(responseContent);
                    }
                }

                Logs.Add(sb.ToString());
                return response;
            }

            private static void LogHeaders(HttpHeaders headers, StringBuilder sb)
            {
                foreach (var header in headers)
                {
                    foreach (var headerValue in header.Value)
                    {
                        if (!string.IsNullOrEmpty(headerValue) && string.Equals(header.Key, "Private-Token", StringComparison.OrdinalIgnoreCase))
                        {
                            sb.Append(header.Key).Append(": ").AppendLine("********");
                        }
                        else
                        {
                            sb.Append(header.Key).Append(": ").AppendLine(headerValue);
                        }
                    }
                }
            }
        }

        public class RetryHandler : DelegatingHandler
        {
            private readonly IAsyncPolicy<HttpResponseMessage> _policy;

            public RetryHandler()
            {
                _policy = Policy<HttpResponseMessage>
                    .HandleResult(response => (int)response.StatusCode >= 500)
                    .WaitAndRetryAsync(3, count => TimeSpan.FromSeconds(2));
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return _policy.ExecuteAsync(() => base.SendAsync(request, cancellationToken));
            }
        }
    }
}
