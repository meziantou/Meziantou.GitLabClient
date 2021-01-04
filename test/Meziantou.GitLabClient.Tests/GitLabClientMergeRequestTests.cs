using System;
using System.Threading.Tasks;
using Meziantou.Framework;
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
                Visibility = Visibility.Public,
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
                Visibility = Visibility.Public,
            });

            var mergeRequest1 = await context.CreateMergeRequestAsync(client, project.PathWithNamespace, assignedToMe: true);
            var mergeRequest2 = await context.CreateMergeRequestAsync(client, project.Id, assignedToMe: true);
        }

        [TestMethod]
        public async Task CreateMergeRequests_MultipleAssignees()
        {
            // TOOD add require specific license
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            using var clientOtherUser = await context.CreateNewUserAsync();

            // Create a project
            var project = await client.Projects.CreateAsync(new CreateProjectRequest
            {
                Name = context.GetRandomString(),
                MergeRequestsEnabled = true,
                Visibility = Visibility.Public,
            });

            var (user1, user2) = await (client.Users.GetCurrentUserAsync(), clientOtherUser.Users.GetCurrentUserAsync());
            await client.Members.AddMemberToProjectAsync(project, user2, AccessLevel.Maintainer, expiresAt: DateTime.UtcNow.AddDays(2));

            var mergeRequest = await context.CreateMergeRequestAsync(client, project.PathWithNamespace,
                configure: request => request.AssigneeIds = new UserIdOrUserNameRef[] { user1.Id, user2 });

            Assert.AreEqual(user1.Id, mergeRequest.Assignees[0].Id);
            Assert.AreEqual(user2.Id, mergeRequest.Assignees[1].Id);
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
                Visibility = Visibility.Public,
            });

            var mergeRequest = await context.CreateMergeRequestAsync(client, project, hasConflict: true);
            mergeRequest = await client.MergeRequests.WaitForStatusReadyAsync(mergeRequest);

            Assert.AreEqual(MergeRequestStatus.CannotBeMerged, mergeRequest.MergeStatus);
        }
    }
}
