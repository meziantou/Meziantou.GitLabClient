using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class GitLabClientWikiTests : GitLabTest
    {
        [TestMethod]
        public async Task Test_Wikis()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            var project = await client.Projects.CreateAsync(new CreateProjectRequest
            {
                Name = context.GetRandomString(),
                WikiEnabled = true,
            });
            var page = await client.Wikis.CreateWikiPageAsync(new CreateWikiPageWikiRequest(project, "title", "content")
            {
                Format = WikiPageFormat.Asciidoc,
            });

            Assert.AreEqual("title", page.Title);
            Assert.AreEqual("content", page.Content);
            Assert.AreEqual(WikiPageFormat.Asciidoc, page.Format);

            page = await client.Wikis.GetWikiPageAsync(project, page.Slug);
            Assert.AreEqual("title", page.Title);
            Assert.AreEqual("content", page.Content);
            Assert.AreEqual(WikiPageFormat.Asciidoc, page.Format);

            var pages = await client.Wikis.GetWikiPagesAsync(project);
            Assert.AreEqual(1, pages.Count);

            page = await client.Wikis.UpdateWikiPageAsync(new UpdateWikiPageWikiRequest(project, page.Slug)
            {
                Title = "title",
                Content = "content2",
                Format = WikiPageFormat.Rdoc,
            });

            Assert.AreEqual("title", page.Title);
            Assert.AreEqual("content2", page.Content);
            Assert.AreEqual(WikiPageFormat.Rdoc, page.Format);

            await client.Wikis.DeleteWikiPageAsync(new DeleteWikiPageWikiRequest(project, page.Slug));

            pages = await client.Wikis.GetWikiPagesAsync(project);
            Assert.AreEqual(0, pages.Count);
        }
    }
}
