using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]

namespace Meziantou.GitLab.Tests
{
    [TestClass]
#pragma warning disable RCS1102 // Make class static.
    public class Initialize
#pragma warning restore RCS1102
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
