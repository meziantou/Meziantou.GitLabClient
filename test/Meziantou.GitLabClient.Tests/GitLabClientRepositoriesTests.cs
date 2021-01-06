using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class GitLabClientRepositoriesTests : GitLabTest
    {
        [TestMethod]
        public async Task GetArchive()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();

            var project = await client.Projects.CreateAsync(new CreateProjectRequest { Name = "test" });
            await client.RepositoryFiles.CreateFileAsync(project, "test.txt", "main", TextOrBinaryData.FromString("abc"), "Add test file");

            await using var file1 = await client.Repositories.DownloadFileArchiveAsync(project);
            await using var file2 = await client.Repositories.DownloadFileArchiveAsync(project, format: RepositoryFileArchiveFormat.Zip);

            StringAssert.EndsWith(file1.FileName, ".tar.gz");
            StringAssert.EndsWith(file2.FileName, ".zip");
        }
    }
}
