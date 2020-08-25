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
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();

            // Create a project
            var project = await client.Projects.CreateAsync(new CreateProjectRequest
            {
                Name = context.GetRandomString(),
                MergeRequestsEnabled = true,
                Visibility = ProjectVisibility.Public,
            });

            var mergeRequest = await context.CreateMergeRequestAsync(client, project, assignedToMe: true);

            // Get all MR of the project
            var mergeRequests = await client.MergeRequests.GetProjectMergeRequests(project).ToListAsync();
            Assert.AreEqual(1, mergeRequests.Count);
            Assert.AreEqual(mergeRequest.Id, mergeRequests[0].Id);

            // Get single merge request
            var mr = await client.MergeRequests.GetMergeRequestAsync(project, mergeRequest);
            Assert.AreEqual(mergeRequest.Id, mergeRequests[0].Id);
        }

        [TestMethod]
        public async Task CreateMergeRequests()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();

            // Create a project
            var project = await client.Projects.CreateAsync(new CreateProjectRequest
            {
                Name = context.GetRandomString(),
                MergeRequestsEnabled = true,
                Visibility = ProjectVisibility.Public,
            });

            var mergeRequest1 = await context.CreateMergeRequestAsync(client, project.PathWithNamespace, assignedToMe: true);
            var mergeRequest2 = await context.CreateMergeRequestAsync(client, project.Id, assignedToMe: true);
        }

        [TestMethod]
        public async Task GetMergeRequestWithConflict()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();

            // Create a project
            var project = await client.Projects.CreateAsync(new CreateProjectRequest
            {
                Name = context.GetRandomString(),
                MergeRequestsEnabled = true,
                Visibility = ProjectVisibility.Public,
            });

            var mergeRequest = await context.CreateMergeRequestAsync(client, project, hasConflict: true);
            mergeRequest = await client.WaitForStatusReady(mergeRequest);

            Assert.AreEqual(MergeRequestStatus.CannotBeMerged, mergeRequest.MergeStatus);
        }
    }
}
