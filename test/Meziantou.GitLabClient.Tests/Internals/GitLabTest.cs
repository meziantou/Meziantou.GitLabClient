using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    public abstract class GitLabTest
    {
        public TestContext TestContext { get; set; }

        protected GitLabTestContext GetContext(HttpClientHandler handler = null)
        {
            return new GitLabTestContext(TestContext, handler);
        }
    }
}
