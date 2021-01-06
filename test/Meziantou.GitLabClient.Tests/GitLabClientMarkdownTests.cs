using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Diffing;
using AngleSharp.Html.Parser;
using Meziantou.Framework;
using Xunit;
using Xunit.Abstractions;

namespace Meziantou.GitLab.Tests
{
    public class GitLabClientMarkdownTests : GitLabTestBase
    {
        public GitLabClientMarkdownTests(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public async Task RenderMarkdown()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();

            // Act
            var result = await client.Markdown.RenderMarkdownAsync(new RenderMarkdownRequest("# title\n\nIssue #1"));

            // Assert
            AssertHtml("<h1>title</h1><p>Issue #1</p>", result.Html);
        }

        [Fact]
        public async Task RenderMarkdown_ProjectSpecific()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();

            var project = await client.Projects.CreateAsync(new CreateProjectRequest { Name = "test" });
            var issue = await client.Issues.CreateAsync(new CreateIssueRequest(project, "my issue"));

            // Act
            var result = await client.Markdown.RenderMarkdownAsync(new RenderMarkdownRequest("# title\n\nIssue #" + issue.Iid.ToStringInvariant())
            {
                Gfm = true,
                Project = project.PathWithNamespace,
            });

            // Assert
            Assert.Contains("test/-/issues/1", issue.WebUrl.ToString(), System.StringComparison.Ordinal);
            Assert.Contains(issue.WebUrl.ToString(), result.Html, System.StringComparison.Ordinal);
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
                Assert.Equal(expected, actual);
            }
        }
    }
}
