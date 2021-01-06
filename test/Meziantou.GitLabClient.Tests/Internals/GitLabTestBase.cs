using System.Net.Http;
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
    }
}
