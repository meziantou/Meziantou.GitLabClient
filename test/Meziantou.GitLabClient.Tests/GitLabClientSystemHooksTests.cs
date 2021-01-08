using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Meziantou.GitLab.Tests
{
    public class GitLabClientSystemHooksTests : GitLabTestBase
    {
        public GitLabClientSystemHooksTests(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public async Task Add_List_Remove()
        {
            using var context = await CreateContextAsync();
            var client = context.AdminClient;

            var hooks = await client.SystemHooks.GetSystemHooks().ToListAsync();
            Assert.Equal(0, hooks.Count);

            var hook = await client.SystemHooks.AddHookAsync(new Uri("http://localhost:12345/tests"), token: "test", pushEvents: true, tagPushEvents: true, mergeRequestsEvents: true, repositoryUpdateEvents: true, enableSslVerification: true);
            Assert.Equal("http://localhost:12345/tests", hook.Url.ToString());
            Assert.True(hook.PushEvents);
            Assert.True(hook.TagPushEvents);
            Assert.True(hook.MergeRequestsEvents);
            Assert.True(hook.RepositoryUpdateEvents);
            Assert.True(hook.EnableSslVerification);

            // Should have 1 todo
            hooks = await client.SystemHooks.GetSystemHooks().ToListAsync();
            Assert.Equal(1, hooks.Count);

            await client.SystemHooks.DeleteAsync(hooks[0]);
            hooks = await client.SystemHooks.GetSystemHooks().ToListAsync();
            Assert.Empty(hooks);
        }
    }
}
