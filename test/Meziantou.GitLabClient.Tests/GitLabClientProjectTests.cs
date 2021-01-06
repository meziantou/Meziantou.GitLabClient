using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Meziantou.GitLab.Tests
{
    public class GitLabClientProjectTests : GitLabTestBase
    {
        public GitLabClientProjectTests(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public async Task GetProjects()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();

            var project = await client.Projects.CreateAsync(new CreateProjectRequest { Name = "test" });
            Assert.NotNull(project.WebUrl);
            Assert.NotNull(project.SshUrlToRepo);
            Assert.NotNull(project.HttpUrlToRepo);

            var projects = await client.Projects.GetAll().ToListAsync();
            Assert.Contains(project, projects.ToList());

            var projectById_project = await client.Projects.GetByIdAsync(project);
            var projectById_pathWithNamespace = await client.Projects.GetByIdAsync(project.PathWithNamespace);

            Assert.Equal("test", project.Name);
            Assert.Equal(project, projectById_project);
            Assert.Equal(project, projectById_pathWithNamespace);
        }

        [Fact]
        public async Task GetProjects_Pagination()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();
            var user = await client.Users.GetCurrentUserAsync();
            var project1 = await client.Projects.CreateAsync(new CreateProjectRequest { Name = "test1" });
            var project2 = await client.Projects.CreateAsync(new CreateProjectRequest { Name = "test2" });
            var project3 = await client.Projects.CreateAsync(new CreateProjectRequest { Name = "test3" });

            var projects = await client.Projects.GetByUser(user, orderBy: UsersOrderBy.Id, sort: OrderByDirection.Ascending)
                .ConfigurePageOptions(pageSize: 1, startPageIndex: 2)
                .ToListAsync();

            Assert.Equal(project2, projects[0]);
            Assert.Equal(project3, projects[1]);
            Assert.Equal(2, projects.Count);
        }

        [Fact]
        public async Task UploadFile()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();
            var data = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAAAAAA6fptVAAAACklEQVR4nGP6DwABBQECz6AuzQAAAABJRU5ErkJggg==");

            var project = await client.Projects.CreateAsync(new CreateProjectRequest { Name = "test1" });
            var result = await client.Projects.UploadFileAsync(project, FileUpload.FromBytes("test.png", data));

            Assert.NotNull(result.Url);
            Assert.NotNull(result.FullPath);
            var actual = await context.AdminHttpClient.GetByteArrayAsync(result.FullPath);

            Assert.Equal(data, actual);
        }
    }
}
