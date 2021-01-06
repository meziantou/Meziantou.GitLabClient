using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Xunit;

namespace Meziantou.GitLab.Tests.Models
{
    public partial class EntityTests
    {
        [Fact]
        [SuppressMessage("Maintainability", "CA1508:Avoid dead conditional code", Justification = "Needed for the test")]
        public void User_Equals_Null()
        {
            User a = null;
            User b = null;

            Assert.True(a == b);
            Assert.False(a != b);
        }

        [Theory]
        [MemberData(nameof(User_Equals_Value))]
        public void User_Equals(User a, User b, bool areEquals)
        {
            Assert.Equal(areEquals, a.Equals((object)b));
            Assert.Equal(areEquals, a.Equals(b));
            Assert.Equal(areEquals, a == b);
            Assert.Equal(!areEquals, a != b);

            if (areEquals)
            {
                Assert.Equal(a.GetHashCode(), b.GetHashCode());
            }
        }

        public static IEnumerable<object[]> User_Equals_Value()
        {
            var user1 = JsonDocument.Parse(@"{ ""id"": 1, ""username"": ""test1"" }").RootElement;
            var user2 = JsonDocument.Parse(@"{ ""id"": 2, ""username"": ""test2"" }").RootElement;

            yield return new object[] { new User(user1), null, false };
            yield return new object[] { new User(user1), new User(user2), false };
            yield return new object[] { new User(user1), new User(user1), true };
        }
    }
}
