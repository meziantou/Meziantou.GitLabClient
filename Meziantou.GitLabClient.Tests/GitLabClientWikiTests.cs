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
            var project = await client.CreateProjectAsync(
                name: context.GetRandomString(),
                wikiEnabled: true);

            var page = await client.CreateWikiPageAsync(project,
                title: "title",
                content: "content",
                format: WikiPageFormat.Asciidoc);

            Assert.AreEqual("title", page.Title);
            Assert.AreEqual("content", page.Content);
            Assert.AreEqual(WikiPageFormat.Asciidoc, page.Format);

            page = await client.GetWikiPageAsync(project, page.Slug);
            Assert.AreEqual("title", page.Title);
            Assert.AreEqual("content", page.Content);
            Assert.AreEqual(WikiPageFormat.Asciidoc, page.Format);

            var pages = await client.GetWikiPagesAsync(project);
            Assert.AreEqual(1, pages.Count);

            page = await client.UpdateWikiPageAsync(project, page.Slug,
                title: "title",
                content: "content2",
                format: WikiPageFormat.Rdoc);

            Assert.AreEqual("title", page.Title);
            Assert.AreEqual("content2", page.Content);
            Assert.AreEqual(WikiPageFormat.Rdoc, page.Format);

            await client.DeleteWikiPageAsync(project, page.Slug);

            pages = await client.GetWikiPagesAsync(project);
            Assert.AreEqual(0, pages.Count);
        }
    }
}
