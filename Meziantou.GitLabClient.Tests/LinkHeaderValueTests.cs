using Meziantou.GitLabClient.Internals;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class LinkHeaderValueTests
    {
        [DataTestMethod]
        [DataRow("<http://localhost:7965/api/customers/pagelinks?pageNo=1&pageSize=50>; rel=\"first\"", "http://localhost:7965/api/customers/pagelinks?pageNo=1&pageSize=50", "first")]
        public void Test(string headerValue, string expectedUrl, string expectedRel)
        {
            var parsed = LinkHeaderValue.TryParse(headerValue, out var value);

            Assert.IsTrue(parsed);
            Assert.AreEqual(expectedUrl, value.Url);
            Assert.AreEqual(expectedRel, value.Rel);
        }
    }
}
