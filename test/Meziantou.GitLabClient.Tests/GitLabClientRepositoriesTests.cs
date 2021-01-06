using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Meziantou.GitLab.Tests
{
    public class GitLabClientRepositoriesTests : GitLabTestBase
    {
        public GitLabClientRepositoriesTests(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public async Task GetArchive()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();

            var project = await client.Projects.CreateAsync(new CreateProjectRequest { Name = "test" });
            await client.RepositoryFiles.CreateFileAsync(project, "test.txt", "main", TextOrBinaryData.FromString("abc"), "Add test file");

            await using var file1 = await client.Repositories.DownloadFileArchiveAsync(project);
            await using var file2 = await client.Repositories.DownloadFileArchiveAsync(project, format: RepositoryFileArchiveFormat.Zip);

            Assert.EndsWith(".tar.gz", file1.FileName, System.StringComparison.Ordinal);
            Assert.EndsWith(".zip", file2.FileName, System.StringComparison.Ordinal);
        }
    }
}
