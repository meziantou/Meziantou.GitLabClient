using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class GitLabClientTemplatesTests : GitLabTest
    {
        [TestMethod]
        public async Task GetGitIgnores()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();

            var list = await client.Templates.GetGitIgnores().ToListAsync();
            var single = await client.Templates.GetGitIgnoreByKeyAsync(list[0].Key);

            Assert.IsNotNull(single.Name);
            Assert.IsNotNull(single.Content);
        }

        [TestMethod]
        public async Task GetGitLabCiYmls()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();

            var list = await client.Templates.GetGitLabCiYmls().ToListAsync();
            var single = await client.Templates.GetGitLabCiYmlByKeyAsync(list[0].Key);

            Assert.IsNotNull(single.Name);
            Assert.IsNotNull(single.Content);
        }

        [TestMethod]
        public async Task GetDockerfiles()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();

            var list = await client.Templates.GetDockerfiles().ToListAsync();
            var single = await client.Templates.GetDockerfileByKeyAsync(list[0].Key);

            Assert.IsNotNull(single.Name);
            Assert.IsNotNull(single.Content);
        }

        [TestMethod]
        public async Task GetLicenses()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();

            var list = await client.Templates.GetLicenses().ToListAsync();
            Assert.IsTrue(list.Count > 0);

            var single = await client.Templates.GetLicenseByKeyAsync("gpl-3.0", project: "TestProject", fullname: "TestFullName");

            Assert.IsNotNull(single.Name);
            StringAssert.Contains(single.Content, "TestProject");
            StringAssert.Contains(single.Content, "TestFullName");
        }
    }
}
