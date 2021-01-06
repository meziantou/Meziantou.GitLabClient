using System.Linq;
using System.Threading.Tasks;
using Meziantou.Framework;
using Xunit;
using Xunit.Abstractions;

namespace Meziantou.GitLab.Tests
{
    [Collection(nameof(NotThreadSafeResourceCollection))]
    public class GitLabClientUserNonParallelizableTests : GitLabTestBase
    {
        public GitLabClientUserNonParallelizableTests(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public async Task GetAllUsers()
        {
            using var context = await CreateContextAsync(parallelizable: true);
            using var client = await context.CreateNewUserAsync();
            var currentUser = await client.Users.GetCurrentUserAsync();

            // Act
            var users = await client.Users.GetAll(orderBy: UsersOrderBy.Id, sort: OrderByDirection.Ascending).EnableKeysetPagination().ToListAsync();

            // Assert
            Assert.NotNull(users);

            // There should be at least 2 users in GitLab (root and current user)
            Assert.True(users.Count >= 2);
            Assert.All(users.ToArray(), item => Assert.NotNull(item));
            Assert.Contains("root", users.Select(u => u.Username).ToList());
            Assert.Contains(currentUser.Username, users.Select(u => u.Username).ToList());
            Assert.Equal(users.Distinct().ToList(), users);
        }
    }
}
