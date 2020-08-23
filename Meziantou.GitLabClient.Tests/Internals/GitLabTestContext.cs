using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Meziantou.Framework;
using Meziantou.Framework.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Meziantou.GitLab.Tests
{
    public sealed class GitLabTestContext : IDisposable
    {
        public static GitLabDockerContainer DockerContainer { get; set; }

        private readonly HttpClient _httpClient;
        private readonly LoggingHandler _loggingHandler;
        private readonly List<TestGitLabClient> _clients = new List<TestGitLabClient>();

        public GitLabTestContext(TestContext testOutput, HttpClientHandler handler = null)
        {
            TestContext = testOutput;

            _loggingHandler = new LoggingHandler(this)
            {
                InnerHandler = handler ?? new HttpClientHandler(),
            };

            _httpClient = new HttpClient(_loggingHandler, disposeHandler: true);
            AdminClient = CreateClient(DockerContainer.AdminUserToken);
        }

        public Random Random { get; } = new Random();
        public TestGitLabClient AdminClient { get; }
        public TestContext TestContext { get; }

        public async Task<TestGitLabClient> CreateNewUserAsync()
        {
            var username = "user_" + DateTime.Now.ToString("yyyyMMdd-HHmmss", CultureInfo.InvariantCulture) + "_" + Guid.NewGuid().ToString("N");
            var email = username + "@dummy.com";
            var password = "Pa$$w0rd";
            var client = AdminClient;

            var user = await client.User.CreateUserAsync(new CreateUserUserRequest(email, username, username)
            {
                Password = password,
                Admin = false,
                CanCreateGroup = true,
                SkipConfirmation = true,
            });

            var token = await client.User.CreateImpersonationTokenAsync(new CreateImpersonationTokenUserRequest(user, "UnitTest")
            {
                Scopes = new[] { "api", "read_user" },
            });
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
            Span<byte> buffer = stackalloc byte[16];
            Random.NextBytes(buffer);
            return "GitLabClientTests_" + ((ReadOnlySpan<byte>)buffer).ToHexa(HexaOptions.LowerCase);
        }

        private TestGitLabClient CreateClient(string token)
        {
            var client = new TestGitLabClient(this, _httpClient, DockerContainer.GitLabUrl, token)
            {
                ProfileToken = DockerContainer.ProfileToken,
            };
            _clients.Add(client);
            return client;
        }

        public void Dispose()
        {
            TestContext.WriteLine(string.Join("\n--------\n", _loggingHandler.Logs));
            var objects = _clients.SelectMany(c => c.Objects).ToList();

            _httpClient?.Dispose();
            _loggingHandler?.Dispose();

            var errorMessages = new HashSet<string>(StringComparer.Ordinal);
            objects.ForEach(o =>
            {
                GitLabObjectAssertions.DoesNotContainUnmappedProperties(errorMessages, o);
                GitLabObjectAssertions.DoesContainOnlyUtcDates(errorMessages, o);
            });

            if (errorMessages.Count > 0)
            {
                Assert.Fail(string.Join("\n", errorMessages));
            }
        }

        private sealed class LoggingHandler : DelegatingHandler
        {
            private readonly GitLabTestContext _gitLabTestContext;

            public LoggingHandler(GitLabTestContext gitLabTestContext)
            {
                _gitLabTestContext = gitLabTestContext;
            }

            public IList<string> Logs { get; } = new SynchronizedList<string>();

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                // TODO remove
                _gitLabTestContext.TestContext.WriteLine(request.RequestUri.ToString());

                // Fix url: http://container_name/ => http://localhost:48624/
                if (request.RequestUri.Port == 80 || request.RequestUri.Port == 443)
                {
                    var builder = new UriBuilder(request.RequestUri) { Host = "localhost", Port = DockerContainer.HttpPort };
                    request.RequestUri = builder.Uri;
                }

                var sb = new StringBuilder();
                sb.Append(request.Method).Append(' ').Append(request.RequestUri).AppendLine();
                LogHeaders(request.Headers, sb);

                if (request.Content != null)
                {
                    LogHeaders(request.Content.Headers, sb);

                    var requestBody = await request.Content.ReadAsStringAsync().ConfigureAwait(false);
                    sb.AppendLine().AppendLine(requestBody);
                }

                try
                {
                    var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

                    sb.AppendLine("--------");
                    sb.Append((int)response.StatusCode).Append(' ').AppendLine(response.ReasonPhrase);
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

                    return response;
                }
                finally
                {
                    Logs.Add(sb.ToString());
                }
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
    }
}
