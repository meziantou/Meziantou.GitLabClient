using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class GitLabClientMergeRequestTests : GitLabTest
    {
        [TestMethod]
        public async Task GetMergeRequests()
        {
            using (var context = GetContext())
            using (var client = await context.CreateNewUserAsync())
            {
                var mr = await client.GetMergeRequestsAsync();
            }
        }
    }
}
