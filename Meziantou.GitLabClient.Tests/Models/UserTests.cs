using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests.Models
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void User_Equals_Null()
        {
            User a = null;
            User b = null;

            Assert.AreEqual(true, a == b);
            Assert.AreEqual(false, a != b);
        }

        [TestMethod]
        [DynamicData(nameof(User_Equals_Value), DynamicDataSourceType.Method)]
        public void User_Equals(User a, User b, bool areEquals)
        {
            Assert.AreEqual(areEquals, a.Equals((object)b));
            Assert.AreEqual(areEquals, a.Equals(b));
            Assert.AreEqual(areEquals, a == b);
            Assert.AreEqual(!areEquals, a != b);

            if (areEquals)
            {
                Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
            }
        }

        public static IEnumerable<object[]> User_Equals_Value()
        {
            yield return new object[] { new User(), null, false };
            yield return new object[] { new User { Id = 1 }, new User { Id = 2 }, false };

            yield return new object[] { new User(), new User(), true };
            yield return new object[] { new User { Id = 1 }, new User { Id = 1 }, true };
        }
    }
}
