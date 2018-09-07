using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class PagedResponseTests : GitLabTest
    {
        [TestMethod]
        public async Task FillProperties()
        {
            using (var handler = Substitute.ForPartsOf<MockHandler>())
            {
                handler.Send(Arg.Is(HttpMethod.Get), Arg.Is("http://dummy/"))
                    .Returns(new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                    {
                        Headers =
                        {
                            { "Link", "<http://dummy/?page=3>; rel=\"next\", <http://dummy/?page=1>; rel=\"prev\", <http://dummy/?page=1>; rel=\"first\", <http://dummy/?page=10>; rel=\"last\"" },
                            { "X-Page", "2" },
                            { "X-Per-Page", "5" },
                            { "X-Total", "50" },
                            { "X-Total-Pages", "10" },
                        },
                        Content = new JsonContent(new[] { new Dummy(), new Dummy() })
                    });

                using (var context = GetContext(handler))
                {
                    // Act
                    var page = await context.AdminClient.GetPagedAsync<Dummy>("http://dummy", CancellationToken.None);

                    // Assert
                    Assert.AreEqual(2, page.PageIndex);
                    Assert.AreEqual(5, page.PageSize);
                    Assert.AreEqual(10, page.TotalPages);
                    Assert.AreEqual(50, page.TotalItems);
                    Assert.IsFalse(page.IsFirstPage);
                    Assert.IsFalse(page.IsLastPage);
                }
            }
        }

        [TestMethod]
        public async Task AsEnumerable()
        {
            using (var handler = Substitute.ForPartsOf<MockHandler>())
            {
                handler.Send(Arg.Is(HttpMethod.Get), Arg.Is("http://dummy/"))
                    .Returns(new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                    {
                        Headers =
                        {
                            { "Link", "<http://dummy/?page=2>; rel=\"next\"" },
                        },
                        Content = new JsonContent(new[] { new Dummy(), new Dummy() })
                    });

                handler.Send(Arg.Is(HttpMethod.Get), Arg.Is("http://dummy/?page=2"))
                    .Returns(new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                    {
                        Headers =
                        {
                            { "Link", "<http://dummy/?page=2>; rel=\"current\"" },
                        },
                        Content = new JsonContent(new[] { new Dummy() })
                    });

                using (var context = GetContext(handler))
                {
                    var page = await context.AdminClient.GetPagedAsync<Dummy>("http://dummy", CancellationToken.None);

                    // Act
                    var result = page.AsEnumerable().Take(3).ToList();

                    // Assert
                    Assert.AreEqual(3, result.Count);
                }
            }
        }

        [TestMethod]
        public async Task Foreach()
        {
            using (var handler = Substitute.ForPartsOf<MockHandler>())
            {
                handler.Send(Arg.Is(HttpMethod.Get), Arg.Is("http://dummy/"))
                    .Returns(new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                    {
                        Headers =
                        {
                            { "Link", "<http://dummy/?page=2>; rel=\"next\"" },
                        },
                        Content = new JsonContent(new[] { new Dummy(), new Dummy() })
                    });

                handler.Send(Arg.Is(HttpMethod.Get), Arg.Is("http://dummy/?page=2"))
                    .Returns(new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                    {
                        Headers =
                        {
                            { "Link", "<http://dummy/?page=2>; rel=\"current\"" },
                        },
                        Content = new JsonContent(new[] { new Dummy() })
                    });

                using (var context = GetContext(handler))
                {
                    var page = await context.AdminClient.GetPagedAsync<Dummy>("http://dummy", CancellationToken.None);

                    // Act
                    var action = Substitute.For<Action<Dummy>>();
                    await page.ForEachAsync(action);

                    // Assert
                    action.ReceivedWithAnyArgs(3);
                }
            }
        }

        public abstract class MockHandler : HttpClientHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.FromResult(Send(request.Method, request.RequestUri.AbsoluteUri));
            }

            public abstract HttpResponseMessage Send(HttpMethod method, string url);
        }

        public class Dummy : GitLabObject
        {
        }
    }
}
