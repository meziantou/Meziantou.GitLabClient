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
            using (var context = GetContext())
            using (var client = await context.CreateNewUserAsync())
            {
                var projects = await client.GetProjectsAsync();
            }
        }
    }
}
