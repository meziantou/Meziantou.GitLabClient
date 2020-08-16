using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    [SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "This is required by MSTest")]
    public class Initialize
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            var container = new GitLabDockerContainer();
            container.Setup().Wait(context.CancellationTokenSource.Token);

            GitLabTestContext.DockerContainer = container;
        }
    }
}
