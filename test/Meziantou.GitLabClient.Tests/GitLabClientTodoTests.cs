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
            var currentUser = await client.Users.GetCurrentUserAsync();

            var todos = await client.Todos.GetTodos().ToListAsync();
            Assert.AreEqual(0, todos.Count);

            // Create a project
            var project = await client.Projects.CreateAsync(new CreateProjectRequest
            {
                Name = context.GetRandomString(),
                IssuesEnabled = true,
            });

            // Add an issue with a mention to me
            var issue = await client.Issues.CreateAsync(project, title: context.GetRandomString(), description: $"Test @{currentUser.Username}");

            // Should have 1 todo
            todos = await client.Todos.GetTodos().ToListAsync();
            var todo = todos.Single();
            Assert.IsInstanceOfType(todo.Target, typeof(Issue));
            Assert.AreEqual(issue.Id, ((Issue)todo.Target).Id);
        }

        [TestMethod]
        public async Task GetTodo_MergeRequestAssigned()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            var currentUser = await client.Users.GetCurrentUserAsync();

            var todos = await client.Todos.GetTodos().ToListAsync();
            Assert.AreEqual(0, todos.Count);

            // Create a project
            var project = await client.Projects.CreateAsync(new CreateProjectRequest
            {
                Name = context.GetRandomString(),
                IssuesEnabled = true,
                Visibility = ProjectVisibility.Public,
            });

            // Create a merge request
            var mergeRequest = await context.CreateMergeRequestAsync(client, project, assignedToMe: true);

            // Should have 1 todo
            todos = await client.Todos.GetTodos().ToListAsync();
            var todo = todos.Single();
            Assert.AreEqual(TodoAction.Assigned, todo.ActionName);
            Assert.AreEqual(TodoState.Pending, todo.State);
            Assert.AreEqual(TodoTargetType.MergeRequest, todo.TargetType);
            Assert.IsInstanceOfType(todo.Target, typeof(MergeRequest));
            Assert.AreEqual(mergeRequest.Id, ((MergeRequest)todo.Target).Id);
        }

        [TestMethod]
        public async Task Todo_MarkAsDone()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            var currentUser = await client.Users.GetCurrentUserAsync();

            var todos = await client.Todos.GetTodos().ToListAsync();
            Assert.AreEqual(0, todos.Count);

            // Create a project
            var project = await client.Projects.CreateAsync(new CreateProjectRequest
            {
                Name = context.GetRandomString(),
                IssuesEnabled = true,
            });

            // Add an issue with a mention to me
            var issue = await client.Issues.CreateAsync(new CreateIssueRequest(project, title: context.GetRandomString()) { Description = $"Test @{currentUser.Username}" });

            // Mark as done
            todos = await client.Todos.GetTodos().ToListAsync();
            var todo = todos.Single();
            await client.Todos.MarkTodoAsDoneAsync(new MarkTodoAsDoneRequest(todo));
            todos = await client.Todos.GetTodos().ToListAsync();
            Assert.AreEqual(0, todos.Count);
        }

        [TestMethod]
        public async Task Todo_MarkAllAsDone()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            var currentUser = await client.Users.GetCurrentUserAsync();

            var todos = await client.Todos.GetTodos().ToListAsync();
            Assert.AreEqual(0, todos.Count);

            // Create a project
            var project = await client.Projects.CreateAsync(new CreateProjectRequest
            {
                Name = context.GetRandomString(),
                IssuesEnabled = true,
            });

            for (var i = 0; i < 3; i++)
            {
                // Add an issue with a mention to me
                var issue = await client.Issues.CreateAsync(new CreateIssueRequest(project, title: context.GetRandomString()) { Description = $"Test @{currentUser.Username}" });
            }

            // Mark all as done
            todos = await client.Todos.GetTodos().ToListAsync();
            Assert.AreEqual(3, todos.Count);
            await client.Todos.MarkAllTodosAsDoneAsync();
            todos = await client.Todos.GetTodos().ToListAsync();
            Assert.AreEqual(0, todos.Count);
        }
    }
}
