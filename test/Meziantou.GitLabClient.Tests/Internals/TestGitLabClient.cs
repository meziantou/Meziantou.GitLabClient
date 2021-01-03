using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Meziantou.GitLab.Tests
{
    public class TestGitLabClient : GitLabClient
    {
        public IList<object> Objects { get; } = new List<object>();

        public GitLabTestContext Context { get; set; }

        public string ProfileToken { get; set; }

        public TestGitLabClient(GitLabTestContext context, HttpClient client, Uri serverUri, string token)
            : base(client, httpClientOwned: false, serverUri, new PersonalAccessTokenAuthenticator(token))
        {
            Context = context;
        }

        protected override async Task<HttpResponse> SendAsync(HttpRequestMessage message, RequestOptions options, CancellationToken cancellationToken)
        {
            var result = await base.SendAsync(message, options, cancellationToken);
            return new TestHttpResponse(this, result.ResponseMessage);
        }

        private sealed class TestHttpResponse : HttpResponse
        {
            private readonly TestGitLabClient _client;

            public TestHttpResponse(TestGitLabClient client, HttpResponseMessage message) : base(client, message)
            {
                _client = client;
            }

            private void AddObject(object obj)
            {
                if (obj == null)
                    return;

                lock (_client.Objects)
                {
                    if (obj is IEnumerable enumerable)
                    {
                        foreach (var item in enumerable)
                        {
                            _client.Objects.Add(item);
                        }
                    }
                    else
                    {
                        _client.Objects.Add(obj);
                    }
                }
            }

            protected override async Task<T> DeserializeAsync<T>(CancellationToken cancellationToken)
            {
                var result = await base.DeserializeAsync<T>(cancellationToken);
                AddObject(result);
                return result;
            }
        }
    }
}
