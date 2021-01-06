using Meziantou.GitLab;
using Xunit;

namespace Meziantou.GitLab.Tests.Models
{
    public class PathWithNamespaceTests
    {
        [Theory]
        [InlineData("Test/Project", "Test", "Project")]
        [InlineData("Test/SubGroup/Project", "Test/SubGroup", "Project")]
        [InlineData("Project", null, "Project")]
        [InlineData("Test/", "Test", "")]
        public void ParseGroupAndPath(string pathWithNamespace, string ns, string path)
        {
            var value = new PathWithNamespace(pathWithNamespace);

            Assert.Equal(ns, value.Namespace);
            Assert.Equal(path, value.Name);
        }
    }
}
