using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class GitLabClientTests : GitLabTest
    {
        [TestMethod]
        public async Task CookieAuthenticator()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            ((TestGitLabClient)client).Authenticator = new CookieAuthenticator(GitLabTestContext.DockerContainer.Credentials.Cookies);
            var user = await client.Users.GetCurrentUserAsync();

            Assert.AreEqual("root", user.Username);
        }

        [TestMethod]
        public async Task OAuth2Authenticator()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            ((TestGitLabClient)client).Authenticator = new OAuth2TokenAuthenticator("Dummy");
            var ex = await Assert.ThrowsExceptionAsync<GitLabException>(() => client.Users.GetAll().ToListAsync());

            Assert.AreEqual(HttpStatusCode.Unauthorized, ex.HttpStatusCode);
        }
    }
}
