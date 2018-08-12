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
            {
                var projects = await context.Client.GetProjectsAsync();


            }
        }
    }
}
