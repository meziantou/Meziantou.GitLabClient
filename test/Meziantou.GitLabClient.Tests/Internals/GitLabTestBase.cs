using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Meziantou.GitLab.Tests
{
    public abstract class GitLabTestBase
    {
        private readonly ITestOutputHelper _testOutputHelper;

        protected GitLabTestBase(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        protected Task<GitLabTestContext> CreateContextAsync(bool parallelizable = true, HttpClientHandler handler = null)
        {
            return GitLabTestContext.CreateAsync(_testOutputHelper, parallelizable, handler);
        }

        protected static async Task<T> RetryUntilAsync<T>(Func<Task<T>> action, Func<T, bool> predicate, TimeSpan timeSpan)
        {
            using var cts = new CancellationTokenSource(timeSpan);
            return await RetryUntilAsync(action, predicate, cts.Token);
        }

        protected static async Task<T> RetryUntilAsync<T>(Func<Task<T>> action, Func<T, bool> predicate, CancellationToken cancellationToken)
        {
            var result = await action();
            while (!predicate(result))
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Delay(1000, cancellationToken).ConfigureAwait(false);

                result = await action();
            }

            return result;
        }
    }
}
