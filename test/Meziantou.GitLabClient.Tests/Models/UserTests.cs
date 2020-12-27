using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests.Models
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        [SuppressMessage("Maintainability", "CA1508:Avoid dead conditional code", Justification = "Needed for the test")]
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
            var user1 = JsonDocument.Parse(@"{ ""id"": 1 }").RootElement;
            var user2 = JsonDocument.Parse(@"{ ""id"": 2 }").RootElement;

            yield return new object[] { new User(user1), null, false };
            yield return new object[] { new User(user1), new User(user2), false };
            yield return new object[] { new User(user1), new User(user1), true };
        }
    }
}
