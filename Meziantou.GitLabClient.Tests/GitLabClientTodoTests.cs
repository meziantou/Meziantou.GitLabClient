using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class GitLabClientTodoTests : GitLabTest
    {
        [TestMethod]
        public async Task GetTodo_MentionedInIssue()
        {
            using (var context = GetContext())
            using (var client = await context.CreateNewUserAsync())
            {
                var currentUser = await client.GetUserAsync();

                var todos = await client.GetTodosAsync().ToListAsync();
                Assert.AreEqual(0, todos.Count);

                // Create a project
                var project = await client.CreateProjectAsync(
                    name: context.GetRandomString(),
                    issueEnabled: true);

                // Add an issue with a mention to me
                var issue = await client.CreateIssueAsync(project,
                    title: context.GetRandomString(),
                    description: $"Test @{currentUser.Username}");

                // Should have 1 todo
                todos = await client.GetTodosAsync().ToListAsync();
                var todo = todos.Single();
                Assert.IsInstanceOfType(todo.Target, typeof(Issue));
                Assert.AreEqual(issue.Id, ((Issue)todo.Target).Id);
            }
        }

        [TestMethod]
        public async Task GetTodo_MergeRequestAssigned()
        {
            using (var context = GetContext())
            using (var client = await context.CreateNewUserAsync())
            {
                var currentUser = await client.GetUserAsync();

                var todos = await client.GetTodosAsync().ToListAsync();
                Assert.AreEqual(0, todos.Count);

                // Create a project
                var project = await client.CreateProjectAsync(
                    name: context.GetRandomString(),
                    issueEnabled: true,
                    visibility: ProjectVisibility.Public);

                // Add a file
                await client.CreateFileAsync(project,
                    filePath: "readme.md",
                    branch: "master",
                    content: context.GetRandomString(),
                    commitMessage: context.GetRandomString());

                await client.UpdateFileAsync(project,
                    filePath: "readme.md",
                    branch: "new_branch",
                    startBranch: "master",
                    content: context.GetRandomString(),
                    commitMessage: context.GetRandomString());

                // Create merge request
                var mergeRequest = await client.CreateMergeRequestAsync(
                    project,
                    sourceBranch: "new_branch",
                    targetBranch: "master",
                    title: context.GetRandomString(),
                    assigneeId: currentUser);

                // Should have 1 todo
                todos = await client.GetTodosAsync().ToListAsync();
                var todo = todos.Single();
                Assert.AreEqual(TodoAction.Assigned, todo.ActionName);
                Assert.AreEqual(TodoState.Pending, todo.State);
                Assert.AreEqual(TodoType.MergeRequest, todo.TargetType);
                Assert.IsInstanceOfType(todo.Target, typeof(MergeRequest));
                Assert.AreEqual(mergeRequest.Id, ((MergeRequest)todo.Target).Id);
            }
        }
    }
}
