using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class UrlBuilderTests
    {
        [TestMethod]
        public void Build_ShouldReplaceSegmentValuesAtTheEnd()
        {
            var urlBuilder = UrlBuilder.Get("/projects/:id");
            urlBuilder.SetValue("id", 10);
            var url = urlBuilder.Build();

            Assert.AreEqual("/projects/10", url);
        }

        [TestMethod]
        public void Build_ShouldReplaceSegmentValuesInTheMiddle()
        {
            var urlBuilder = UrlBuilder.Get("/projects/:id/pipelines");
            urlBuilder.SetValue("id", 10);
            var url = urlBuilder.Build();

            Assert.AreEqual("/projects/10/pipelines", url);
        }

        [TestMethod]
        public void Build_ShouldAddQueryStringParameter()
        {
            var urlBuilder = UrlBuilder.Get("/projects");
            urlBuilder.SetValue("id", 10);
            urlBuilder.SetValue("name", "test");
            var url = urlBuilder.Build();

            Assert.AreEqual("/projects?id=10&name=test", url);
        }
    }
}
