using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class Sha1Tests
    {
        [DataTestMethod]
        [DataRow("1d5af3e7809623aebc6644160f35accf74166375")]
        [DataRow("8b274174af7deeb18a8242de0eb590dad5345532")]
        [DataRow("8B274174AF7DEEB18A8242DE0EB590DAD5345532")]
        public void TryParse_ValidValue(string value)
        {
            var parsed = GitObjectId.TryParse(value, out var sha1);
            Assert.IsTrue(parsed);
            Assert.AreEqual(value.ToLowerInvariant(), sha1.ToString());
            Assert.AreEqual(sha1, sha1);
        }
    }
}
