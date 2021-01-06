using System.Net;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Meziantou.GitLab.Tests
{
    public class GitLabClientTests : GitLabTestBase
    {
        public GitLabClientTests(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public async Task OAuth2Authenticator()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();
            ((TestGitLabClient)client).Authenticator = new OAuth2TokenAuthenticator("Dummy");
            var ex = await Assert.ThrowsAsync<GitLabException>(() => client.Users.GetAll().ToListAsync());

            Assert.Equal(HttpStatusCode.Unauthorized, ex.HttpStatusCode);
        }

        [Fact]
        public async Task Pagination_PageSize_KeysetDisabled()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();
            var project1 = await client.Projects.CreateAsync(name: context.GetRandomString());
            var project2 = await client.Projects.CreateAsync(name: context.GetRandomString());
            var project3 = await client.Projects.CreateAsync(name: context.GetRandomString());

            var result = await client.Projects.GetByUser(project1.Owner).ConfigurePageOptions(pageSize: 2).EnableKeysetPagination(enabled: false).ToListAsync();
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async Task Pagination_PageSize_KeysetEnabled()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();
            var project1 = await client.Projects.CreateAsync(name: context.GetRandomString());
            var project2 = await client.Projects.CreateAsync(name: context.GetRandomString());
            var project3 = await client.Projects.CreateAsync(name: context.GetRandomString());

            var result = await client.Projects.GetByUser(project1.Owner).ConfigurePageOptions(pageSize: 1).EnableKeysetPagination(enabled: true).ToListAsync();
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async Task Pagination_PageSize_KeysetAuto()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();
            var project1 = await client.Projects.CreateAsync(name: context.GetRandomString());
            var project2 = await client.Projects.CreateAsync(name: context.GetRandomString());
            var project3 = await client.Projects.CreateAsync(name: context.GetRandomString());

            var result = await client.Projects.GetByUser(project1.Owner).ConfigurePageOptions(pageSize: 1).ToListAsync();
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async Task Pagination_PageIndex_KeysetDisabled()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();
            var project1 = await client.Projects.CreateAsync(name: context.GetRandomString());
            var project2 = await client.Projects.CreateAsync(name: context.GetRandomString());
            var project3 = await client.Projects.CreateAsync(name: context.GetRandomString());

            var result = await client.Projects.GetByUser(project1.Owner).ConfigurePageOptions(pageSize: 1, startPageIndex: 2).ToListAsync();
            Assert.Equal(2, result.Count);
        }
    }
}
