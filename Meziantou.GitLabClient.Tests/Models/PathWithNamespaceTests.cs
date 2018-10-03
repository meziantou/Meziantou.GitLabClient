using Meziantou.GitLab;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests.Models
{
    [TestClass]
    public class PathWithNamespaceTests
    {
        [DataTestMethod]
        [DataRow("Test/Project", "Test", "Project")]
        [DataRow("Test/SubGroup/Project", "Test/SubGroup", "Project")]
        [DataRow("Project", null, "Project")]
        [DataRow("Test/", "Test", null)]
        public void ParseGroupAndPath(string pathWithNamespace, string ns, string path)
        {
            var value = new PathWithNamespace(pathWithNamespace);

            Assert.AreEqual(ns, value.Namespace);
            Assert.AreEqual(path, value.Path);
        }
    }
}
