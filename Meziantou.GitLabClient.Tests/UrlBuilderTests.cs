using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class UrlBuilderTests
    {
        [TestMethod]
        public void Build_ShouldReplaceSegmentValuesAtTheEnd()
        {
            var url = UrlBuilder.Get("/projects/:id")
                .WithValue("id", 10)
                .Build();

            Assert.AreEqual("/projects/10", url);
        }

        [TestMethod]
        public void Build_ShouldReplaceSegmentValuesInTheMiddle()
        {
            var url = UrlBuilder.Get("/projects/:id/pipelines")
                .WithValue("id", 10)
                .Build();

            Assert.AreEqual("/projects/10/pipelines", url);
        }

        [TestMethod]
        public void Build_ShouldAddQueryStringParameter()
        {
            var url = UrlBuilder.Get("/projects")
                .WithValue("id", 10)
                .WithValue("name", "test")
                .Build();

            Assert.AreEqual("/projects?id=10&name=test", url);
        }
    }
}
