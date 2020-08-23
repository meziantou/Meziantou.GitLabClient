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

            var project = await client.Project.CreateAsync(new CreateProjectRequest { Name = "test" });

            var projects = await client.Project.Get().ToListAsync();

            var projectById_project = await client.Project.GetByIdAsync(project);
            var projectById_pathWithNamespace = await client.Project.GetByIdAsync(project.PathWithNamespace);

            Assert.AreEqual("test", project.Name);
            Assert.AreEqual(project, projectById_project);
            Assert.AreEqual(project, projectById_pathWithNamespace);
        }
    }
}
