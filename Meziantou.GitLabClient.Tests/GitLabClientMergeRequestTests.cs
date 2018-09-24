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
                var currentUser = await client.GetUserAsync();

                // Create a project
                var project = await client.CreateProjectAsync(
                    name: context.GetRandomString(),
                    issueEnabled: true,
                    visibility: ProjectVisibility.Public);

                var mergeRequest = await client.CreateMergeRequestAsync(project, assignedToMe: true);

                // Get all MR of the project
                var mergeRequests = await client.GetMergeRequestsAsync(project).ToListAsync();
                Assert.AreEqual(1, mergeRequests.Count);
                Assert.AreEqual(mergeRequest.Id, mergeRequests[0].Id);

                // Get single merge request
                var mr = await client.GetMergeRequestAsync(project, mergeRequest);
                Assert.AreEqual(mergeRequest.Id, mergeRequests[0].Id);
            }
        }

        [TestMethod]
        public async Task GetMergeRequestWithConflict()
        {
            using (var context = GetContext())
            using (var client = await context.CreateNewUserAsync())
            {
                var currentUser = await client.GetUserAsync();

                // Create a project
                var project = await client.CreateProjectAsync(
                    name: context.GetRandomString(),
                    issueEnabled: true,
                    visibility: ProjectVisibility.Public);

                var mergeRequest = await client.CreateMergeRequestAsync(project, hasConflict: true);

                Assert.AreEqual(MergeRequestStatus.CannotBeMerged, mergeRequest.MergeStatus);
            }
        }
    }
}
