using System.Diagnostics.CodeAnalysis;
using Meziantou.GitLab.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    [SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "This is required by MSTest")]
    [SuppressMessage("Design", "MA0048:File name must match type name", Justification = "Easier to find in Solution Explorer")]
    public class Initialize
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            JsonSerialization.Options.WriteIndented = true;

            var container = new GitLabDockerContainer();
            container.Setup().Wait(context.CancellationTokenSource.Token);

            GitLabTestContext.DockerContainer = container;
        }
    }
}
