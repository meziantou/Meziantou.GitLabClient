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

            var projectById_project = await client.Projects.GetByIdAsync(project);
            var projectById_pathWithNamespace = await client.Projects.GetByIdAsync(project.PathWithNamespace);

            Assert.AreEqual("test", project.Name);
            Assert.AreEqual(project, projectById_project);
            Assert.AreEqual(project, projectById_pathWithNamespace);
        }
    }
}
