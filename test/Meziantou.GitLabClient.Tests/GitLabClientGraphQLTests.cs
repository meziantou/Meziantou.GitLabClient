#pragma warning disable CA1812
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Meziantou.Framework;
using Meziantou.GitLab.Core;
using Meziantou.GitLab.Internals;
using Xunit;
using Xunit.Abstractions;

namespace Meziantou.GitLab.Tests
{
    public class GitLabClientGraphQLTests : GitLabTestBase
    {
        public GitLabClientGraphQLTests(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public async Task GetProjects()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();

            var project = await client.Projects.CreateAsync(new CreateProjectRequest { Name = "test" });

            var result = await client.GraphQL.ExecuteAsync<GitLabObject>(new GraphQLRequest("{ projects { nodes { id, name } } }"));
            Assert.NotEmpty((IEnumerable<object>)((dynamic)result.Data).projects.nodes);
            Assert.Null(result.Errors);
            Assert.False(result.HasErrors);
        }

        [Fact]
        public async Task GetProjectWithParameter()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();

            var project = await client.Projects.CreateAsync(new CreateProjectRequest { Name = "test" });

            var query = @"query sample($projectPath: ID!)
{
  project(fullPath: $projectPath) {
    id
    name
  }
}
";

            var result = await client.GraphQL.ExecuteAsync<GraphQLProjectResponse>(new GraphQLRequest(query)
            {
                Variables = new UnsafeListDictionary<string, object> { { "projectPath", project.PathWithNamespace } },
            });

            Assert.Equal("gid://gitlab/Project/" + project.Id.ToStringInvariant(), result.Data.Project.Id);
            Assert.Equal("test", result.Data.Project.Name);
            Assert.Null(result.Errors);
            Assert.False(result.HasErrors);
        }

        [Fact]
        public async Task InvalidQuery()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();

            var project = await client.Projects.CreateAsync(new CreateProjectRequest { Name = "test" });

            var result = await client.GraphQL.ExecuteAsync<GitLabObject>(new GraphQLRequest("{ projects { id, name } }"));
            Assert.Null(result.Data);
            Assert.True(result.HasErrors);
            Assert.NotEmpty(result.Errors);
        }

        private sealed class GraphQLProjectResponse
        {
            [JsonPropertyName("project")]
            public GraphQLProject Project { get; set; }
        }

        private sealed class GraphQLProject
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }
            [JsonPropertyName("name")]
            public string Name { get; set; }
        }
    }
}
