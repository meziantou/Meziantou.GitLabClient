using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Meziantou.GitLab.Tests
{
    public class GitLabClientAvatarTests : GitLabTestBase
    {
        public GitLabClientAvatarTests(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public async Task GetAvatar()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();
            var user = await client.Users.GetCurrentUserAsync();

            // Act
            var result = await client.Avatar.GetUserAvatarAsync(user.Email);

            // Assert
            Assert.NotNull(result.AvatarUrl);
        }
    }
}
