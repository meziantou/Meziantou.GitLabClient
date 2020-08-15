using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Diffing;
using AngleSharp.Html.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class GitLabClientMarkdownTests : GitLabTest
    {
        [TestMethod]
        public async Task RenderMarkdown()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            // Act
            var result = await client.RenderMarkdownAsync("# title");

            // Assert
            // data-sourcepos="1:1-1:7"
            AssertHtml("<h1>title</h1>", result.Html);
        }

        private static void AssertHtml(string expected, string actual)
        {
            var parser = new HtmlParser();
            var expectedDocument = parser.ParseDocument(expected);
            var actualDocument = parser.ParseDocument(actual);

            foreach (var element in actualDocument.All)
            {
                element.RemoveAttribute("data-sourcepos");
            }

            var result = DiffBuilder.Compare(expectedDocument.Body.InnerHtml)
                            .WithTest(actualDocument.Body.InnerHtml)
                            .Build();

            if (result.Any())
            {
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
