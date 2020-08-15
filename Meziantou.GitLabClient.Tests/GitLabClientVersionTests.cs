using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class GitLabClientVersionTests : GitLabTest
    {
        [TestMethod]
        public async Task GetVersion()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            // Act
            var version = await client.GetVersionAsync();

            // Assert
            Assert.IsNotNull(version.Version);
            Assert.IsNotNull(version.Revision);
        }
    }
}
