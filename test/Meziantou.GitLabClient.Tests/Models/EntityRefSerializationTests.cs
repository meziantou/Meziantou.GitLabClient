using System.Text.Json;
using Meziantou.GitLab.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests.Models
{
    [TestClass]
    public class EntityRefSerializationTests
    {
        [TestMethod]
        public void SerializeSingleValue()
        {
            var item = UserIdOrUserNameRef.FromUserName("test");
            _ = JsonSerializer.Serialize(item, JsonSerialization.Options);
        }

        [TestMethod]
        public void SerializeCollection()
        {
            var item = UserIdOrUserNameRef.FromUserName("test");
            _ = JsonSerializer.Serialize(new[] { item, item }, JsonSerialization.Options);
        }
    }
}
