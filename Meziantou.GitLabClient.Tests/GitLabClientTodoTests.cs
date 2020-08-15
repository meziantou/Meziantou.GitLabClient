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
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
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

        [TestMethod]
        public async Task GetTodo_MergeRequestAssigned()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            var currentUser = await client.GetUserAsync();

            var todos = await client.GetTodosAsync().ToListAsync();
            Assert.AreEqual(0, todos.Count);

            // Create a project
            var project = await client.CreateProjectAsync(
                name: context.GetRandomString(),
                issueEnabled: true,
                visibility: ProjectVisibility.Public);

            // Create a merge request
            var mergeRequest = await client.CreateMergeRequestAsync(project, assignedToMe: true);

            // Should have 1 todo
            todos = await client.GetTodosAsync().ToListAsync();
            var todo = todos.Single();
            Assert.AreEqual(TodoAction.Assigned, todo.ActionName);
            Assert.AreEqual(TodoState.Pending, todo.State);
            Assert.AreEqual(TodoType.MergeRequest, todo.TargetType);
            Assert.IsInstanceOfType(todo.Target, typeof(MergeRequest));
            Assert.AreEqual(mergeRequest.Id, ((MergeRequest)todo.Target).Id);
        }

        [TestMethod]
        public async Task Todo_MarkAsDone()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
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

            // Mark as done
            todos = await client.GetTodosAsync().ToListAsync();
            var todo = todos.Single();
            await client.MarkTodoAsDoneAsync(todo.Id);
            todos = await client.GetTodosAsync().ToListAsync();
            Assert.AreEqual(0, todos.Count);
        }

        [TestMethod]
        public async Task Todo_MarkAllAsDone()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            var currentUser = await client.GetUserAsync();

            var todos = await client.GetTodosAsync().ToListAsync();
            Assert.AreEqual(0, todos.Count);

            // Create a project
            var project = await client.CreateProjectAsync(
                name: context.GetRandomString(),
                issueEnabled: true);

            for (var i = 0; i < 3; i++)
            {
                // Add an issue with a mention to me
                var issue = await client.CreateIssueAsync(project,
                    title: context.GetRandomString(),
                    description: $"Test @{currentUser.Username}");
            }

            // Mark all as done
            todos = await client.GetTodosAsync().ToListAsync();
            Assert.AreEqual(3, todos.Count);
            await client.MarkAllTodosAsDoneAsync();
            todos = await client.GetTodosAsync().ToListAsync();
            Assert.AreEqual(0, todos.Count);
        }
    }
}
