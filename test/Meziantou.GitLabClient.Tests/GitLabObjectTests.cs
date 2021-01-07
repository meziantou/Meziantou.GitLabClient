using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Meziantou.GitLab.Core;
using Meziantou.GitLab.Serialization;
using Xunit;

namespace Meziantou.GitLab.Tests
{
    public class GitLabObjectTests
    {
        private static async Task<T> Deserialize<T>(string json)
        {
            using var ms = new MemoryStream();
            ms.Write(Encoding.UTF8.GetBytes(json));
            ms.Seek(0, SeekOrigin.Begin);
            return await JsonSerialization.DeserializeAsync<T>(ms, CancellationToken.None);
        }

        [Fact]
        public async Task Dynamic_Null()
        {
            dynamic obj = await Deserialize<GitLabObject>("{ \"Prop1\": null }");
            object result = obj.Prop1;
            Assert.Null(result);
        }

        [Fact]
        public async Task Dynamic_Boolean_True()
        {
            dynamic obj = await Deserialize<GitLabObject>("{ \"Prop1\": true }");
            bool result = obj.Prop1;
            Assert.True(result);
        }

        [Fact]
        public async Task Dynamic_Boolean_False()
        {
            dynamic obj = await Deserialize<GitLabObject>("{ \"Prop1\": false }");
            bool result = obj.Prop1;
            Assert.False(result);
        }

        [Fact]
        public async Task Dynamic_NullableBoolean_Null()
        {
            dynamic obj = await Deserialize<GitLabObject>("{ \"Prop1\": null }");
            bool? result = obj.Prop1;
            Assert.Null(result);
        }

        [Fact]
        public async Task Dynamic_NullableBoolean_True()
        {
            dynamic obj = await Deserialize<GitLabObject>("{ \"Prop1\": true }");
            bool? result = obj.Prop1;
            Assert.True(result);
        }

        [Fact]
        public async Task Dynamic_String()
        {
            dynamic obj = await Deserialize<GitLabObject>("{ \"Prop1\": \"test\" }");
            string result = obj.Prop1;
            Assert.Equal("test", result);
        }

        [Fact]
        public async Task Dynamic_Int16()
        {
            dynamic obj = await Deserialize<GitLabObject>("{ \"Prop1\": 42 }");
            short result = obj.Prop1;
            Assert.Equal((short)42, result);
        }

        [Fact]
        public async Task Dynamic_Int32()
        {
            dynamic obj = await Deserialize<GitLabObject>("{ \"Prop1\": 42 }");
            int result = obj.Prop1;
            Assert.Equal(42, result);
        }

        [Fact]
        public async Task Dynamic_Int64()
        {
            dynamic obj = await Deserialize<GitLabObject>("{ \"Prop1\": 42 }");
            long result = obj.Prop1;
            Assert.Equal(42, result);
        }

        [Fact]
        public async Task Dynamic_NullableInt64()
        {
            dynamic obj = await Deserialize<GitLabObject>("{ \"Prop1\": 42 }");
            long? result = obj.Prop1;
            Assert.Equal(42, result);
        }

        [Fact]
        public async Task Dynamic_NullableInt64_Null()
        {
            dynamic obj = await Deserialize<GitLabObject>("{ \"Prop1\": null }");
            long? result = obj.Prop1;
            Assert.Null(result);
        }

        [Fact]
        public async Task Dynamic_ComplexProperty()
        {
            dynamic obj = await Deserialize<GitLabObject>("{ \"Prop1\": { \"Prop2\": [ { \"Prop3\": 42 } ] } }");
            int result = obj.Prop1.Prop2[0].Prop3;
            Assert.Equal(42, result);
        }

        [Fact]
        public async Task Dynamic_ArrayLength()
        {
            dynamic obj = await Deserialize<GitLabObject>("{ \"Prop1\": { \"Prop2\": [ { \"Prop3\": 42 }, { \"Prop3\": 42 } ] } }");
            int result = obj.Prop1.Prop2.Length;
            Assert.Equal(2, result);
        }

        [Fact]
        public async Task Dynamic_ArrayCount()
        {
            dynamic obj = await Deserialize<GitLabObject>("{ \"Prop1\": { \"Prop2\": [ { \"Prop3\": 42 }, { \"Prop3\": 42 } ] } }");
            int result = obj.Prop1.Prop2.Count();
            Assert.Equal(2, result);
        }

        [Fact]
        public async Task Dynamic_JsonElement()
        {
            dynamic obj = await Deserialize<GitLabObject>("{ \"Prop1\": { \"Prop2\": [ { \"Prop3\": 42 }, { \"Prop3\": 42 } ] } }");
            JsonElement result = obj.Prop1.Prop2;
            Assert.Equal(JsonValueKind.Array, result.ValueKind);
        }

        [Fact]
        public async Task Dynamic_GitLabObject_User()
        {
            dynamic obj = await Deserialize<GitLabObject>("{ \"Prop1\": { \"id\": 21 } }");
            User result = obj.Prop1;
            Assert.Equal(21, result.Id);
        }

        [Fact]
        public async Task Dynamic_IEnumerableGitLabObject_User()
        {
            dynamic obj = await Deserialize<GitLabObject>("{ \"Prop1\": [ { \"id\": 21 }, { \"id\": 22 }, null ] }");
            IEnumerable<User> result = obj.Prop1;
            Assert.Collection(result,
                item => Assert.Equal(21, item.Id),
                item => Assert.Equal(22, item.Id),
                item => Assert.Null(item));
        }

        [Fact]
        public async Task TryGetValue_Boolean()
        {
            var obj = await Deserialize<GitLabObject>("{ \"Prop1\": true }");

            var result = obj.TryGetValue("Prop1", out bool value);
            Assert.True(result);
            Assert.True(value);
            Assert.IsType<bool>(value);
        }

        [Fact]
        public async Task TryGetValue_Double()
        {
            var obj = await Deserialize<GitLabObject>("{ \"Prop1\": 1.3 }");

            var result = obj.TryGetValue("Prop1", out double value);
            Assert.True(result);
            Assert.Equal(1.3d, value);
            Assert.IsType<double>(value);
        }

        [Fact]
        public async Task TryGetValue_Long()
        {
            var obj = await Deserialize<GitLabObject>("{ \"Prop1\": 2 }");

            var result = obj.TryGetValue("Prop1", out long value);
            Assert.True(result);
            Assert.Equal(2L, value);
            Assert.IsType<long>(value);
        }

        [Fact]
        public async Task TryGetValue_String()
        {
            var obj = await Deserialize<GitLabObject>("{ \"Prop1\": \"test\" }");

            var result = obj.TryGetValue("Prop1", out string value);
            Assert.True(result);
            Assert.Equal("test", value);
            Assert.IsType<string>(value);
        }

        [Fact]
        public async Task TryGetValue_Null()
        {
            var obj = await Deserialize<GitLabObject>("{ \"Prop1\": null }");

            var result = obj.TryGetValue("Prop1", out object value);
            Assert.True(result);
            Assert.Null(value);
        }

        [Fact]
        public async Task TryGetValue_Array()
        {
            var obj = await Deserialize<GitLabObject>("{ \"Prop1\": [1, 2] }");

            var result = obj.TryGetValue("Prop1", out int[] value);
            Assert.True(result);
            Assert.IsType<int[]>(value);

            var array = value;
            Assert.IsType<int>(array[0]);
            Assert.IsType<int>(array[1]);
        }
    }
}
