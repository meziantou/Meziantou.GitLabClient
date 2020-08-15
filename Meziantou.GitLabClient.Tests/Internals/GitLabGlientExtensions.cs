using System.Threading.Tasks;

namespace Meziantou.GitLab.Tests
{
    public static class GitLabGlientExtensions
    {
        public static async Task<MergeRequest> CreateMergeRequestAsync(this TestGitLabClient client, ProjectIdOrPathRef project,
            bool assignedToMe = false,
            bool hasConflict = false)
        {
            var context = client.Context;
            var filePath = context.GetRandomString();
            var branchName = context.GetRandomString();
            var assignee = assignedToMe ? await client.GetUserAsync() : null;

            await client.CreateFileAsync(project,
                 filePath: filePath,
                 branch: "master",
                 content: context.GetRandomString(),
                 commitMessage: context.GetRandomString());

            await client.UpdateFileAsync(project,
                filePath: filePath,
                branch: branchName,
                startBranch: "master",
                content: context.GetRandomString(),
                commitMessage: context.GetRandomString());

            if (hasConflict)
            {
                await client.UpdateFileAsync(project,
                    filePath: filePath,
                    branch: "master",
                    content: context.GetRandomString(),
                    commitMessage: context.GetRandomString());
            }

            // Create merge request
            var mergeRequest = await client.CreateMergeRequestAsync(
                project,
                sourceBranch: branchName,
                targetBranch: "master",
                title: context.GetRandomString(),
                assigneeId: assignee);

            return mergeRequest;
        }

        public static async Task<MergeRequest> WaitForStatusReady(this TestGitLabClient client, MergeRequest mergeRequest)
        {
            while (mergeRequest.MergeStatus == MergeRequestStatus.Checking)
            {
                mergeRequest = await client.GetMergeRequestAsync(mergeRequest.ProjectId, mergeRequest.Iid);
            }

            return mergeRequest;
        }
    }
}
