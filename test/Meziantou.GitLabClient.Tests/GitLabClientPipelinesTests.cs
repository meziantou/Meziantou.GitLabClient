using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Meziantou.GitLab.Tests
{
    public class GitLabClientPipelinesTests : GitLabTestBase
    {
        public GitLabClientPipelinesTests(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public async Task CreatePipeline()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();
            var project = await client.Projects.CreateAsync("test", defaultBranch: "main");

            await client.RepositoryFiles.CreateFileAsync(project, ".gitlab-ci.yml", "main", TextOrBinaryData.FromString(@"
build1:
  stage: build
  script:
    - echo test
"), "add gitlab-ci");

            var pipelines = await RetryUntilAsync(() => client.Pipelines.GetPipelines(project).ToListAsync(), pipelines => pipelines.Count != 0, TimeSpan.FromSeconds(60));

            var pipeline = await client.Pipelines.CreatePipelineAsync(project, "main", new[] { new PipelineVariableCreate("test", "value") });
            var variables = await client.Pipelines.GetPipelineVariablesAsync(project, pipeline);

            Assert.Collection(variables, variable => Assert.Equal(("test", "value"), (variable.Key, variable.Value)));
        }
    }
}
