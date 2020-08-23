using System;
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
            var parsed = new GitObjectId(value);
            Assert.AreEqual(value, parsed.ToString());
        }

        [DataTestMethod]
        [DataRow("1")] // Invalid length
        [DataRow("ZZ274174af7deeb18a8242de0eb590dad5345532")] // Invalid character
        public void TryParse_NotValidValue(string value)
        {
            Assert.ThrowsException<ArgumentException>(() => new GitObjectId(value));
        }
    }
}
