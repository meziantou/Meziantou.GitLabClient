using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Meziantou.GitLab.Tests
{
    public class GitLabClientVersionTests : GitLabTestBase
    {
        public GitLabClientVersionTests(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public async Task GetVersion()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();
            // Act
            var version = await client.Version.GetAsync();

            // Assert
            Assert.NotNull(version.Version);
            Assert.NotNull(version.Revision);
        }
    }
}
