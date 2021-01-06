using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Meziantou.GitLab.Tests
{
    public class GitLabClientTodoTests : GitLabTestBase
    {
        public GitLabClientTodoTests(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public async Task GetTodo_MentionedInIssue()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();
            var currentUser = await client.Users.GetCurrentUserAsync();

            var todos = await client.ToDos.GetTodos().ToListAsync();
            Assert.Equal(0, todos.Count);

            // Create a project
            var project = await client.Projects.CreateAsync(new CreateProjectRequest
            {
                Name = context.GetRandomString(),
                IssuesEnabled = true,
            });

            // Add an issue with a mention to me
            var issue = await client.Issues.CreateAsync(project, title: context.GetRandomString(), description: $"Test @{currentUser.Username}");

            // Should have 1 todo
            todos = await client.ToDos.GetTodos().ToListAsync();
            var todo = todos.Single();
            Assert.IsType<Issue>(todo.Target);
            Assert.Equal(issue.Id, ((Issue)todo.Target).Id);
        }

        [Fact]
        public async Task GetTodo_MergeRequestAssigned()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();
            var currentUser = await client.Users.GetCurrentUserAsync();

            var todos = await client.ToDos.GetTodos().ToListAsync();
            Assert.Equal(0, todos.Count);

            // Create a project
            var project = await client.Projects.CreateAsync(new CreateProjectRequest
            {
                Name = context.GetRandomString(),
                IssuesEnabled = true,
                Visibility = Visibility.Public,
            });

            // Create a merge request
            var mergeRequest = await context.CreateMergeRequestAsync(client, project, assignedToMe: true);

            // Should have 1 todo
            todos = await client.ToDos.GetTodos().ToListAsync();
            var todo = todos.Single();
            Assert.Equal(TodoAction.Assigned, todo.ActionName);
            Assert.Equal(TodoState.Pending, todo.State);
            Assert.Equal(TodoTargetType.MergeRequest, todo.TargetType);
            Assert.IsType<MergeRequest>(todo.Target);
            Assert.Equal(mergeRequest.Id, ((MergeRequest)todo.Target).Id);
        }

        [Fact]
        public async Task Todo_MarkAsDone()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();
            var currentUser = await client.Users.GetCurrentUserAsync();

            var todos = await client.ToDos.GetTodos().ToListAsync();
            Assert.Equal(0, todos.Count);

            // Create a project
            var project = await client.Projects.CreateAsync(new CreateProjectRequest
            {
                Name = context.GetRandomString(),
                IssuesEnabled = true,
            });

            // Add an issue with a mention to me
            var issue = await client.Issues.CreateAsync(new CreateIssueRequest(project, title: context.GetRandomString()) { Description = $"Test @{currentUser.Username}" });

            // Mark as done
            todos = await client.ToDos.GetTodos().ToListAsync();
            var todo = todos.Single();
            await client.ToDos.MarkTodoAsDoneAsync(new MarkTodoAsDoneToDoRequest(todo));
            todos = await client.ToDos.GetTodos().ToListAsync();
            Assert.Equal(0, todos.Count);
        }

        [Fact]
        public async Task Todo_MarkAllAsDone()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();
            var currentUser = await client.Users.GetCurrentUserAsync();

            var todos = await client.ToDos.GetTodos().ToListAsync();
            Assert.Equal(0, todos.Count);

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
            todos = await client.ToDos.GetTodos().ToListAsync();
            Assert.Equal(3, todos.Count);
            await client.ToDos.MarkAllTodosAsDoneAsync();
            todos = await client.ToDos.GetTodos().ToListAsync();
            Assert.Equal(0, todos.Count);
        }
    }
}
