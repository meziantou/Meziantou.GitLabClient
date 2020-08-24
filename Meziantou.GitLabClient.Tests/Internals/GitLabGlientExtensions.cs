﻿using System.Threading.Tasks;

namespace Meziantou.GitLab.Tests
{
    public static class GitLabGlientExtensions
    {
        public static async Task<MergeRequest> CreateMergeRequestAsync(this GitLabTestContext context, IGitLabClient client, ProjectIdOrPathRef project,
            bool assignedToMe = false,
            bool hasConflict = false)
        {
            var filePath = context.GetRandomString();
            var branchName = context.GetRandomString();
            var assignee = assignedToMe ? await client.Users.GetCurrentUserAsync() : null;

            await client.Repositories.CreateFileAsync(new CreateFileRepositoryRequest(project, filePath, "master", content: context.GetRandomString(), commitMessage: context.GetRandomString()));

            await client.Repositories.UpdateFileAsync(new UpdateFileRepositoryRequest(project, filePath, branchName, content: context.GetRandomString(), commitMessage: context.GetRandomString())
            {
                StartBranch = "master",
            });

            if (hasConflict)
            {
                await client.Repositories.UpdateFileAsync(new UpdateFileRepositoryRequest(project, filePath, "master", content: context.GetRandomString(), commitMessage: context.GetRandomString()));
            }

            // Create merge request
            var mergeRequest = await client.MergeRequests.CreateMergeRequestAsync(new CreateMergeRequestMergeRequestRequest(project, branchName, "master", title: context.GetRandomString())
            {
                AssigneeId = assignee,
            });

            return mergeRequest;
        }

        public static async Task<MergeRequest> WaitForStatusReady(this IGitLabClient client, MergeRequest mergeRequest)
        {
            while (mergeRequest.MergeStatus == MergeRequestStatus.Checking)
            {
                mergeRequest = await client.MergeRequests.GetMergeRequestAsync(mergeRequest.ProjectId, mergeRequest.Iid);
            }

            return mergeRequest;
        }
    }
}
