using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class Initialize
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            var container = new GitLabDockerContainer();
            container.Setup().Wait();

            GitLabTestContext.DockerContainer = container;
        }
    }
}
