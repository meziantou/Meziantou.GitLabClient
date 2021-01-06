using System.Text.Json;
using Meziantou.GitLab.Serialization;
using Xunit;

namespace Meziantou.GitLab.Tests.Models
{
    public class EntityRefSerializationTests
    {
        [Fact]
        public void SerializeSingleValue()
        {
            var item = UserIdOrUserNameRef.FromUserName("test");
            _ = JsonSerializer.Serialize(item, JsonSerialization.Options);
        }

        [Fact]
        public void SerializeCollection()
        {
            var item = UserIdOrUserNameRef.FromUserName("test");
            _ = JsonSerializer.Serialize(new[] { item, item }, JsonSerialization.Options);
        }
    }
}
