using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Meziantou.Framework;
using Meziantou.Framework.Collections;
using Meziantou.Framework.Threading;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace Meziantou.GitLab.Tests
{
    public sealed class GitLabTestContext : IDisposable
    {
        private static readonly HashSet<string> s_generatedValues = new(StringComparer.Ordinal);
        private static readonly AsyncReaderWriterLock s_gitLabLock = new();

        private readonly LoggingHandler _loggingHandler;
        private readonly ConcurrencyLimiterAndRetryHandler _retryHandler;
        private readonly HttpClient _clientHttpClient;
        private readonly List<TestGitLabClient> _clients = new();
        private readonly AsyncReaderWriterLock.Releaser _lockReleaser;

        public GitLabDockerContainer DockerContainer { get; set; }

        private GitLabTestContext(ITestOutputHelper testOutputHelper, GitLabDockerContainer container, HttpClientHandler handler, AsyncReaderWriterLock.Releaser lockReleaser)
        {
            TestOutputHelper = testOutputHelper;
            DockerContainer = container;
            _lockReleaser = lockReleaser;
            _loggingHandler = new LoggingHandler()
            {
                InnerHandler = handler ?? new HttpClientHandler(),
            };

            _retryHandler = new ConcurrencyLimiterAndRetryHandler(_loggingHandler);
            _clientHttpClient = new HttpClient(_retryHandler, disposeHandler: true);
            AdminClient = CreateClient(DockerContainer.Credentials.AdminUserToken);

            HttpClient = new HttpClient(_retryHandler, disposeHandler: true)
            {
                BaseAddress = DockerContainer.GitLabUrl,
            };

            AdminHttpClient = new HttpClient(_retryHandler, disposeHandler: true)
            {
                BaseAddress = DockerContainer.GitLabUrl,
                DefaultRequestHeaders =
                {
                    { "Cookie", "_gitlab_session=" +  DockerContainer.Credentials.Cookies },
                },
            };
        }

        public static async Task<GitLabTestContext> CreateAsync(ITestOutputHelper testOutputHelper, bool parallelizable, HttpClientHandler handler)
        {
            var container = await GitLabDockerContainer.GetOrCreateInstance();
            var releaser = await (parallelizable ? s_gitLabLock.ReaderLockAsync() : s_gitLabLock.WriterLockAsync());
            return new GitLabTestContext(testOutputHelper, container, handler, releaser);
        }

        public HttpClient HttpClient { get; }
        public HttpClient AdminHttpClient { get; }
        public IGitLabClient AdminClient { get; }
        public ITestOutputHelper TestOutputHelper { get; }

        private static bool IsUnique(string str)
        {
            lock (s_generatedValues)
            {
                return s_generatedValues.Add(str);
            }
        }

        public async Task<IGitLabClient> CreateNewUserAsync()
        {
            var username = "user_" + DateTime.Now.ToString("yyyyMMdd-HHmmss", CultureInfo.InvariantCulture) + "_" + Guid.NewGuid().ToString("N");
            var email = username + "@dummy.com";
            var password = "Pa$$w0rd";
            var client = AdminClient;

            var user = await client.Users.CreateUserAsync(new CreateUserRequest(email, username, username)
            {
                Password = password,
                Admin = false,
                CanCreateGroup = true,
                SkipConfirmation = true,
            });

            var token = await client.Users.CreateImpersonationTokenAsync(new CreateImpersonationTokenUserRequest(user, "UnitTest")
            {
                Scopes = new[] { ImpersonationTokenScope.Api, ImpersonationTokenScope.ReadUser },
            });
            return CreateClient(token.Token);
        }

        [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "By design")]
        public string GetRandomEmojiName()
        {
            var fields = typeof(Emoji).GetFields();
            var index = RandomNumberGenerator.GetInt32(0, fields.Length);
            return (string)fields[index].GetValue(null);
        }

        [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "By design")]
        public string GetRandomString()
        {
            Span<byte> buffer = stackalloc byte[16];
            for (var i = 0; i < 1000; i++)
            {
                RandomNumberGenerator.Fill(buffer);
                var result = "GitLabClientTests_" + Convert.ToHexString(buffer);
                if (IsUnique(result))
                    return result;
            }

            throw new InvalidOperationException("Cannot generate a new random unique string");
        }

        private TestGitLabClient CreateClient(string token)
        {
            var client = new TestGitLabClient(this, _clientHttpClient, DockerContainer.GitLabUrl, token)
            {
                ProfileToken = DockerContainer.Credentials.ProfileToken,
            };
            _clients.Add(client);
            return client;
        }

        public void Dispose()
        {
            _lockReleaser.Dispose();

            var separator = "\n" + new string('=', 120) + "\n";
            TestOutputHelper.WriteLine(separator + string.Join(separator, _loggingHandler.Logs));
            var objects = _clients.SelectMany(c => c.Objects).ToList();

            _clientHttpClient?.Dispose();
            _loggingHandler?.Dispose();
            _retryHandler?.Dispose();

            var errorMessages = new HashSet<string>(StringComparer.Ordinal);
            objects.ForEach(o =>
            {
                GitLabObjectAssertions.DoesNotContainUnmappedProperties(errorMessages, o);
                GitLabObjectAssertions.DoesContainOnlyUtcDates(errorMessages, o);
                GitLabObjectAssertions.DoesContainOnlyAbsoluteUri(errorMessages, o);
            });

            if (errorMessages.Count > 0)
            {
                Assert.True(false, string.Join("\n", errorMessages));
            }
        }

        private sealed class LoggingHandler : DelegatingHandler
        {
            public LoggingHandler()
            {
            }

            public LoggingHandler(HttpMessageHandler innerHandler) : base(innerHandler)
            {
            }

            public IList<string> Logs { get; } = new SynchronizedList<string>();

            protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                throw new NotSupportedException();
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var stopwatch = ValueStopwatch.StartNew();
                var sb = new StringBuilder();
                sb.Append(request.Method).Append(' ').Append(request.RequestUri).AppendLine();
                LogHeaders(request.Headers, sb);

                if (request.Content != null)
                {
                    LogHeaders(request.Content.Headers, sb);

                    var requestBody = await request.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                    sb.AppendLine().AppendLine(requestBody);
                }

                try
                {
                    var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

                    sb.AppendLine(new string('-', 60));
                    sb.Append((int)response.StatusCode).Append(' ').AppendLine(response.ReasonPhrase);
                    LogHeaders(response.Headers, sb);
                    if (response.Content != null)
                    {
                        LogHeaders(response.Content.Headers, sb);
                        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
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
                    sb.Append("Executed in ").Append(stopwatch.GetElapsedTime()).AppendLine();
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
                            // As it uses a local container and not an actual production instance, there is no need to hide the token
                            // This could help when debugging an issue
                            //sb.Append(header.Key).Append(": ").AppendLine("********");
                            sb.Append(header.Key).Append(": ").AppendLine(headerValue);
                        }
                        else
                        {
                            sb.Append(header.Key).Append(": ").AppendLine(headerValue);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// GitLab sometimes returns 502 after initializing the Docker container. Retrying may help reducing flaky tests.
        /// </summary>
        private sealed class ConcurrencyLimiterAndRetryHandler : DelegatingHandler
        {
            private static readonly AsyncReaderWriterLock s_concurrencyLimiter = new();

            public ConcurrencyLimiterAndRetryHandler()
            {
            }

            public ConcurrencyLimiterAndRetryHandler(HttpMessageHandler innerHandler)
                : base(innerHandler)
            {
            }

            protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                throw new NotSupportedException();
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                // Multiple concurrent GET should be ok
                using (await (request.Method == HttpMethod.Get ? s_concurrencyLimiter.ReaderLockAsync() : s_concurrencyLimiter.WriterLockAsync()).ConfigureAwait(false))
                {
                    var retries = 10;
                    while (true)
                    {
                        try
                        {
                            var response = await base.SendAsync(request, cancellationToken);
                            if (retries == 0 || (int)response.StatusCode < 500)
                                return response;
                        }
                        catch (HttpRequestException) when (retries > 0)
                        {
                        }

                        await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken).ConfigureAwait(false);
                        retries--;
                    }
                }
            }
        }
    }
}
