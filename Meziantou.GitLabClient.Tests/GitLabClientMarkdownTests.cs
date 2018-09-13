using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class GitLabClientMarkdownTests : GitLabTest
    {
        [TestMethod]
        public async Task RenderMarkdown()
        {
            using (var context = GetContext())
            using (var client = await context.CreateNewUserAsync())
            {
                // Act
                var result = await client.RenderMarkdownAsync("# title");

                // Assert
                Assert.AreEqual("<h1>title</h1>", result.Html);
            }
        }
    }
}
