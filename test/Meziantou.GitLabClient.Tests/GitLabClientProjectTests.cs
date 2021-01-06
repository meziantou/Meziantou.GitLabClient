using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class GitLabClientProjectTests : GitLabTest
    {
        [TestMethod]
        public async Task GetProjects()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();

            var project = await client.Projects.CreateAsync(new CreateProjectRequest { Name = "test" });
            Assert.IsNotNull(project.WebUrl);
            Assert.IsNotNull(project.SshUrlToRepo);
            Assert.IsNotNull(project.HttpUrlToRepo);

            var projects = await client.Projects.GetAll().ToListAsync();
            CollectionAssert.Contains(projects.ToList(), project);

            var projectById_project = await client.Projects.GetByIdAsync(project);
            var projectById_pathWithNamespace = await client.Projects.GetByIdAsync(project.PathWithNamespace);

            Assert.AreEqual("test", project.Name);
            Assert.AreEqual(project, projectById_project);
            Assert.AreEqual(project, projectById_pathWithNamespace);
        }

        [TestMethod]
        public async Task GetProjects_Pagination()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            var user = await client.Users.GetCurrentUserAsync();
            var project1 = await client.Projects.CreateAsync(new CreateProjectRequest { Name = "test1" });
            var project2 = await client.Projects.CreateAsync(new CreateProjectRequest { Name = "test2" });
            var project3 = await client.Projects.CreateAsync(new CreateProjectRequest { Name = "test3" });

            var projects = await client.Projects.GetByUser(user, orderBy: UsersOrderBy.Id, sort: OrderByDirection.Ascending)
                .ConfigurePageOptions(pageSize: 1, startPageIndex: 2)
                .ToListAsync();

            Assert.AreEqual(project2, projects[0]);
            Assert.AreEqual(project3, projects[1]);
            Assert.AreEqual(2, projects.Count);
        }

        [TestMethod]
        public async Task UploadFile()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            var data = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAAAAAA6fptVAAAACklEQVR4nGP6DwABBQECz6AuzQAAAABJRU5ErkJggg==");

            var project = await client.Projects.CreateAsync(new CreateProjectRequest { Name = "test1" });
            var result = await client.Projects.UploadFileAsync(project, FileUpload.FromBytes("test.png", data));

            Assert.IsNotNull(result.Url);
            Assert.IsNotNull(result.FullPath);
            var actual = await context.AdminHttpClient.GetByteArrayAsync(result.FullPath);

            CollectionAssert.AreEqual(data, actual);
        }
    }
}
