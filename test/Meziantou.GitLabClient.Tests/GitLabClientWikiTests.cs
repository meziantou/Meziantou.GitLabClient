using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Meziantou.GitLab.Tests
{
    public class GitLabClientWikiTests : GitLabTestBase
    {
        public GitLabClientWikiTests(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public async Task Test_Wikis()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();
            var project = await client.Projects.CreateAsync(new CreateProjectRequest
            {
                Name = context.GetRandomString(),
                WikiEnabled = true,
            });
            var page = await client.ProjectWikis.CreateWikiPageAsync(new CreateWikiPageProjectWikiRequest(project, "title", "content")
            {
                Format = WikiPageFormat.Asciidoc,
            });

            Assert.Equal("title", page.Title);
            Assert.Equal("content", page.Content);
            Assert.Equal(WikiPageFormat.Asciidoc, page.Format);

            page = await client.ProjectWikis.GetWikiPageAsync(project, page.Slug);
            Assert.Equal("title", page.Title);
            Assert.Equal("content", page.Content);
            Assert.Equal(WikiPageFormat.Asciidoc, page.Format);

            var pages = await client.ProjectWikis.GetWikiPagesAsync(project);
            Assert.Equal(1, pages.Count);

            page = await client.ProjectWikis.UpdateWikiPageAsync(new UpdateWikiPageProjectWikiRequest(project, page.Slug)
            {
                Title = "title",
                Content = "content2",
                Format = WikiPageFormat.Rdoc,
            });

            Assert.Equal("title", page.Title);
            Assert.Equal("content2", page.Content);
            Assert.Equal(WikiPageFormat.Rdoc, page.Format);

            await client.ProjectWikis.DeleteWikiPageAsync(new DeleteWikiPageProjectWikiRequest(project, page.Slug));

            pages = await client.ProjectWikis.GetWikiPagesAsync(project);
            Assert.Equal(0, pages.Count);
        }
    }
}
