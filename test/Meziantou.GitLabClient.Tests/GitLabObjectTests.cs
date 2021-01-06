using System;
using System.IO;
using System.Text;
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
