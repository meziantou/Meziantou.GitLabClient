using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class GitLabClientTests : GitLabTest
    {
        [TestMethod]
        public async Task OAuth2Authenticator()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            ((TestGitLabClient)client).Authenticator = new OAuth2TokenAuthenticator("Dummy");
            var ex = await Assert.ThrowsExceptionAsync<GitLabException>(() => client.Users.GetAll().ToListAsync());

            Assert.AreEqual(HttpStatusCode.Unauthorized, ex.HttpStatusCode);
        }

        [TestMethod]
        public async Task Pagination_PageSize_KeysetDisabled()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            var project1 = await client.Projects.CreateAsync(name: context.GetRandomString());
            var project2 = await client.Projects.CreateAsync(name: context.GetRandomString());
            var project3 = await client.Projects.CreateAsync(name: context.GetRandomString());

            var result = await client.Projects.GetByUser(project1.Owner).ConfigurePageOptions(pageSize: 2).EnableKeysetPagination(enabled: false).ToListAsync();
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public async Task Pagination_PageSize_KeysetEnabled()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            var project1 = await client.Projects.CreateAsync(name: context.GetRandomString());
            var project2 = await client.Projects.CreateAsync(name: context.GetRandomString());
            var project3 = await client.Projects.CreateAsync(name: context.GetRandomString());

            var result = await client.Projects.GetByUser(project1.Owner).ConfigurePageOptions(pageSize: 1).EnableKeysetPagination(enabled: true).ToListAsync();
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public async Task Pagination_PageSize_KeysetAuto()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            var project1 = await client.Projects.CreateAsync(name: context.GetRandomString());
            var project2 = await client.Projects.CreateAsync(name: context.GetRandomString());
            var project3 = await client.Projects.CreateAsync(name: context.GetRandomString());

            var result = await client.Projects.GetByUser(project1.Owner).ConfigurePageOptions(pageSize: 1).ToListAsync();
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public async Task Pagination_PageIndex_KeysetDisabled()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            var project1 = await client.Projects.CreateAsync(name: context.GetRandomString());
            var project2 = await client.Projects.CreateAsync(name: context.GetRandomString());
            var project3 = await client.Projects.CreateAsync(name: context.GetRandomString());

            var result = await client.Projects.GetByUser(project1.Owner).ConfigurePageOptions(pageSize: 1, startPageIndex: 2).ToListAsync();
            Assert.AreEqual(2, result.Count);
        }
    }
}
