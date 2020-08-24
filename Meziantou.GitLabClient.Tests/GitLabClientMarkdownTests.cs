using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Diffing;
using AngleSharp.Html.Parser;
using Meziantou.Framework;
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
            var result = await client.Markdown.RenderMarkdownAsync(new RenderMarkdownMarkdownRequest("# title\n\nIssue #1"));

            // Assert
            AssertHtml("<h1>title</h1><p>Issue #1</p>", result.Html);
        }

        [TestMethod]
        public async Task RenderMarkdown_ProjectSpecific()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();

            var project = await client.Project.CreateAsync(new CreateProjectRequest { Name = "test" });
            var issue = await client.Issue.CreateAsync(new CreateIssueRequest(project, "my issue"));

            // Act
            var result = await client.Markdown.RenderMarkdownAsync(new RenderMarkdownMarkdownRequest("# title\n\nIssue #" + issue.Iid.ToStringInvariant())
            {
                Gfm = true,
                Project = project.PathWithNamespace,
            });

            // Assert
            StringAssert.Contains(issue.WebUrl.ToString(), "test/-/issues/1");
            StringAssert.Contains(result.Html, issue.WebUrl.ToString());
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
