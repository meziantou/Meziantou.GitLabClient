using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class PagedResponseTests : GitLabTest
    {
        [TestMethod]
        public async Task FillProperties()
        {
            using var handler = new MockHandler();
            handler.AddResponse("GET http://localhost:3000/", new HttpResponseMessage(HttpStatusCode.OK)
            {
                Headers =
                {
                    { "Link", "<http://localhost:3000/?page=3>; rel=\"next\", <http://localhost:3000/?page=1>; rel=\"prev\", <http://localhost:3000/?page=1>; rel=\"first\", <http://localhost:3000/?page=10>; rel=\"last\"" },
                    { "X-Page", "2" },
                    { "X-Per-Page", "5" },
                    { "X-Total", "50" },
                    { "X-Total-Pages", "10" },
                },
                Content = new JsonContent(new[] { new object(), new object() }),
            });

            using var context = GetContext(handler);
            // Act
            var page = await context.AdminClient.GetPagedAsync<GitLabObject>("http://localhost:3000", default, CancellationToken.None);

            // Assert
            Assert.AreEqual(2, page.PageIndex);
            Assert.AreEqual(5, page.PageSize);
            Assert.AreEqual(10, page.TotalPages);
            Assert.AreEqual(50, page.TotalItems);
            Assert.IsFalse(page.IsFirstPage);
            Assert.IsFalse(page.IsLastPage);
        }

        private sealed class MockHandler : HttpClientHandler
        {
            private readonly List<(string Request, HttpResponseMessage Response)> _mocks = new List<(string request, HttpResponseMessage response)>();
            private int _index;

            public void AddResponse(string expectedRequest, HttpResponseMessage response)
            {
                _mocks.Add((expectedRequest, response));
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var (expectedRequest, response) = _mocks[_index++];
                Assert.AreEqual(expectedRequest, $"{request.Method} {request.RequestUri}");
                return Task.FromResult(response);
            }
        }
    }
}
