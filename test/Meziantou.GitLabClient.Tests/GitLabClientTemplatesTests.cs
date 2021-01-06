using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Meziantou.GitLab.Tests
{
    public class GitLabClientTemplatesTests : GitLabTestBase
    {
        public GitLabClientTemplatesTests(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public async Task GetGitIgnores()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();

            var list = await client.Templates.GetGitIgnores().ToListAsync();
            var single = await client.Templates.GetGitIgnoreByKeyAsync(list[0].Key);

            Assert.NotNull(single.Name);
            Assert.NotNull(single.Content);
        }

        [Fact]
        public async Task GetGitLabCiYmls()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();

            var list = await client.Templates.GetGitLabCiYmls().ToListAsync();
            var single = await client.Templates.GetGitLabCiYmlByKeyAsync(list[0].Key);

            Assert.NotNull(single.Name);
            Assert.NotNull(single.Content);
        }

        [Fact]
        public async Task GetDockerfiles()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();

            var list = await client.Templates.GetDockerfiles().ToListAsync();
            var single = await client.Templates.GetDockerfileByKeyAsync(list[0].Key);

            Assert.NotNull(single.Name);
            Assert.NotNull(single.Content);
        }

        [Fact]
        public async Task GetLicenses()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();

            var list = await client.Templates.GetLicenses().ToListAsync();
            Assert.True(list.Count > 0);

            var single = await client.Templates.GetLicenseByKeyAsync("gpl-3.0", project: "TestProject", fullname: "TestFullName");

            Assert.NotNull(single.Name);
            Assert.Contains("TestProject", single.Content, StringComparison.Ordinal);
            Assert.Contains("TestFullName", single.Content, StringComparison.Ordinal);
        }
    }
}
