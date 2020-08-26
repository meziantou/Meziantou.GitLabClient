using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
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
        [SuppressMessage("Usage", "CA1801:Review unused parameters", Justification = "Signature expected by MSTest")]
        [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Signature expected by MSTest")]
        public static async Task AssemblyInitialize(TestContext context)
        {
            JsonSerialization.Options.WriteIndented = true;

            var container = new GitLabDockerContainer();
            await container.SetupAsync();

            GitLabTestContext.DockerContainer = container;
        }
    }
}
