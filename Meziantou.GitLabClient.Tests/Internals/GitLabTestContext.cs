using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Meziantou.GitLab.Tests
{
    public class GitLabTestContext : IDisposable
    {
        public GitLabTestContext(TestContext testOutput, HttpClientHandler handler = null)
        {
            TestContext = testOutput;
            Client = CreateClient(handler);
        }

        private HttpClient _httpClient;
        private LoggingHandler _loggingHandler;

        public TestGitLabClient Client { get; }
        public string ServerUri { get; }
        public TestContext TestContext { get; }

        private TestGitLabClient CreateClient(HttpClientHandler handler)
        {
            const string EnvironmentVariablePrefix = "GitLabClient_Test";

            var serverUrl = Environment.GetEnvironmentVariable(EnvironmentVariablePrefix + "ServerUrl");
            if (string.IsNullOrEmpty(serverUrl))
            {
                Assert.Inconclusive("Environment variable '" + EnvironmentVariablePrefix + "ServerUrl' not set.");
            }

            var accessToken = Environment.GetEnvironmentVariable(EnvironmentVariablePrefix + "AccessToken");
            if (string.IsNullOrEmpty(accessToken))
            {
                Assert.Inconclusive("Environment variable '" + EnvironmentVariablePrefix + "AccessToken' not set.");
            }

            _loggingHandler = new LoggingHandler() { InnerHandler = handler ?? new HttpClientHandler() };
            _httpClient = new HttpClient(_loggingHandler, disposeHandler: true);

            var client = new TestGitLabClient(_httpClient, serverUrl, accessToken);
            client._jsonSerializerSettings.CheckAdditionalContent = true;
            client._jsonSerializerSettings.Formatting = Formatting.Indented;
            client._jsonSerializerSettings.Error = (sender, e) => { TestContext.WriteLine(string.Format("{0}", e)); };
            return client;
        }

        public void Dispose()
        {
            TestContext.WriteLine(string.Join("\n--------\n", _loggingHandler.Logs));
            var objects = Client.Objects;

            Client?.Dispose();
            _httpClient?.Dispose();

            objects.ForEach(o =>
            {
                GitLabObjectAssertions.DoesNotContainUnmappedProperties(o);
                GitLabObjectAssertions.DoesContainOnlyUtcDates(o);
                GitLabObjectAssertions.DoesContainGitLabClient(o);
            });
        }

        public class TestGitLabClient : GitLabClient
        {
            public List<object> Objects { get; } = new List<object>();

            public TestGitLabClient(HttpClient client, string serverUri, string token)
                : base(client, serverUri, token)
            {
            }

            protected override async Task<T> GetAsync<T>(string url, CancellationToken cancellationToken)
            {
                var result = await base.GetAsync<T>(url, cancellationToken);
                Objects.Add(result);
                return result;
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

                    string requestBody = await request.Content.ReadAsStringAsync().ConfigureAwait(false);
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
    }
}
