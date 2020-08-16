﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

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
            var emptyUser = JObject.Parse(@"{ }");
            var user1 = JObject.Parse(@"{ ""id"": 1 }");
            var user2 = JObject.Parse(@"{ ""id"": 2 }");

            yield return new object[] { new User(emptyUser), null, false };
            yield return new object[] { new User(user1), new User(user2), false };

            yield return new object[] { new User(emptyUser), new User(emptyUser), true };
            yield return new object[] { new User(user1), new User(user1), true };
        }
    }
}
