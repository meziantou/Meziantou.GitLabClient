using System.Threading.Tasks;

namespace Meziantou.GitLab.Tests
{
    public static class Extensions
    {
        public static async Task<MergeRequest> CreateMergeRequestAsync(this TestGitLabClient client, Project project,
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
    }
}
