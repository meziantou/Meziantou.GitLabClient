﻿using System;
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
        public static GitLabDockerContainer DockerContainer { get; set; }

        public GitLabTestContext(TestContext testOutput, HttpClientHandler handler = null)
        {
            TestContext = testOutput;
            Client = CreateClient(handler);
        }

        private HttpClient _httpClient;
        private LoggingHandler _loggingHandler;

        public Random Random { get; } = new Random();
        public TestGitLabClient Client { get; }
        public string ServerUri { get; }
        public TestContext TestContext { get; }

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

        private TestGitLabClient CreateClient(HttpClientHandler handler)
        {
            _loggingHandler = new LoggingHandler() { InnerHandler = handler ?? new HttpClientHandler() };
            _httpClient = new HttpClient(_loggingHandler, disposeHandler: true);

            var client = new TestGitLabClient(_httpClient, DockerContainer.GitLabUrl, DockerContainer.AdminToken);
            client._jsonSerializerSettings.CheckAdditionalContent = true;
            client._jsonSerializerSettings.Formatting = Formatting.Indented;
            client._jsonSerializerSettings.Error = (sender, e) => TestContext.WriteLine(string.Format("{0}", e));
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

            protected override async Task<IReadOnlyList<T>> GetCollectionAsync<T>(string url, CancellationToken cancellationToken)
            {
                var readOnlyList = await base.GetCollectionAsync<T>(url, cancellationToken).ConfigureAwait(false);
                Objects.AddRange(readOnlyList);
                return readOnlyList;
            }

            protected internal override async Task<PagedResponse<T>> GetPagedAsync<T>(string url, CancellationToken cancellationToken)
            {
                var pagedResponse = await base.GetPagedAsync<T>(url, cancellationToken).ConfigureAwait(false);
                Objects.AddRange(pagedResponse.Data);
                return pagedResponse;
            }

            protected override async Task<T> PostJsonAsync<T>(string url, object data, CancellationToken cancellationToken)
            {
                var result = await base.PostJsonAsync<T>(url, data, cancellationToken).ConfigureAwait(false);
                Objects.Add(result);
                return result;
            }

            protected override async Task<T> PutJsonAsync<T>(string url, object data, CancellationToken cancellationToken)
            {
                var result = await base.PutJsonAsync<T>(url, data, cancellationToken).ConfigureAwait(false);
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
    }
}
