using System;
using System.Threading.Tasks;
using Meziantou.GitLab.Models;
using Xunit;
using Xunit.Abstractions;

namespace Meziantou.GitLab.Tests
{
    public class GitLabClientJobsTests : GitLabTestBase
    {
        public GitLabClientJobsTests(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public void IsCompleted()
        {
            // Ensure all values are handled
            foreach (var value in Enum.GetValues<JobStatus>())
            {
                value.IsCompleted();
            }

            Assert.True(JobStatus.Failed.IsCompleted());
            Assert.True(JobStatus.Success.IsCompleted());
            Assert.True(JobStatus.Canceled.IsCompleted());
            Assert.True(JobStatus.Skipped.IsCompleted());
            Assert.True(JobStatus.Manual.IsCompleted());

            Assert.False(JobStatus.Created.IsCompleted());
            Assert.False(JobStatus.Pending.IsCompleted());
            Assert.False(JobStatus.Running.IsCompleted());
        }

        [Fact]
        public async Task GetJob()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();
            var project = await client.Projects.CreateAsync("test");

            await client.RepositoryFiles.CreateFileAsync(project, ".gitlab-ci.yml", "master", TextOrBinaryData.FromString(@"
build1:
  stage: build
  script:
    - echo test
"), "add gitlab-ci");

            var jobs = await RetryUntilAsync(() => client.Jobs.GetJobs(project).ToListAsync(), jobs => jobs.Count != 0, TimeSpan.FromSeconds(60));
            Assert.Single(jobs);
            Assert.Null(jobs[0].StartedAt);

            using (await context.StartRunnerForOneJobAsync(project))
            {
                var job = await RetryUntilAsync(() => client.Jobs.GetJobAsync(project, jobs[0]), job => job.Status.IsCompleted(), TimeSpan.FromSeconds(60));
                Assert.NotNull(job);
                Assert.NotNull(job.FinishedAt);
            }
        }
    }
}
