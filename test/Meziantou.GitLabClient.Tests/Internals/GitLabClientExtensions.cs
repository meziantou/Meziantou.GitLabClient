using System.Threading.Tasks;

namespace Meziantou.GitLab.Tests
{
    public static class GitLabClientExtensions
    {
        public static async Task<MergeRequest> CreateMergeRequestAsync(this GitLabTestContext context, IGitLabClient client, ProjectIdOrPathRef project,
            bool assignedToMe = false,
            bool hasConflict = false)
        {
            var filePath = context.GetRandomString();
            var branchName = context.GetRandomString();
            var assignee = assignedToMe ? await client.Users.GetCurrentUserAsync() : null;

            await client.RepositoryFiles.CreateFileAsync(new CreateFileRepositoryFileRequest(project, filePath, "master", content: context.GetRandomString(), commitMessage: context.GetRandomString()));

            await client.RepositoryFiles.UpdateFileAsync(new UpdateFileRepositoryFileRequest(project, filePath, branchName, content: context.GetRandomString(), commitMessage: context.GetRandomString())
            {
                StartBranch = "master",
            });

            if (hasConflict)
            {
                await client.RepositoryFiles.UpdateFileAsync(new UpdateFileRepositoryFileRequest(project, filePath, "master", content: context.GetRandomString(), commitMessage: context.GetRandomString()));
            }

            // Create merge request
            var mergeRequest = await client.MergeRequests.CreateMergeRequestAsync(new CreateMergeRequestRequest(project, branchName, "master", title: context.GetRandomString())
            {
                AssigneeId = assignee,
            });

            return mergeRequest;
        }

        public static async Task<MergeRequest> WaitForStatusReadyAsync(this IGitLabClient client, MergeRequest mergeRequest)
        {
            while (mergeRequest.MergeStatus == MergeRequestStatus.Checking)
            {
                mergeRequest = await client.MergeRequests.GetMergeRequestAsync(mergeRequest.ProjectId, mergeRequest.Iid);
            }

            return mergeRequest;
        }
    }
}
