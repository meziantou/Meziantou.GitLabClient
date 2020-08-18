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
            client.Authenticator = new CookieAuthenticator(GitLabTestContext.DockerContainer.Cookies);
            var user = await client.User.GetAsync();

            Assert.AreEqual("root", user.Username);
        }

        [TestMethod]
        public async Task OAuth2Authenticator()
        {
            // TODO Find a way to generate an OAuth2 token from the test
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            client.Authenticator = new OAuth2TokenAuthenticator("Dummy");
            var ex = await Assert.ThrowsExceptionAsync<GitLabException>(() => client.User.GetAsync());

            Assert.AreEqual(HttpStatusCode.Unauthorized, ex.HttpStatusCode);
        }
    }
}
