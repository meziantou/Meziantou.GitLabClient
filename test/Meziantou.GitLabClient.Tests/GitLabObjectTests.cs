using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Meziantou.GitLab.Core;
using Meziantou.GitLab.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class GitLabObjectTests
    {
        private static async Task<T> Deserialize<T>(string json)
        {
            using var ms = new MemoryStream();
            ms.Write(Encoding.UTF8.GetBytes(json));
            ms.Seek(0, SeekOrigin.Begin);
            return await JsonSerialization.DeserializeAsync<T>(ms, CancellationToken.None);
        }

        [TestMethod]
        public async Task TryGetValue_Boolean()
        {
            var obj = await Deserialize<GitLabObject>("{ \"Prop1\": true }");

            var result = obj.TryGetValue("Prop1", out bool value);
            Assert.IsTrue(result);
            Assert.AreEqual(true, value);
            Assert.IsInstanceOfType(value, typeof(bool));
        }

        [TestMethod]
        public async Task TryGetValue_Double()
        {
            var obj = await Deserialize<GitLabObject>("{ \"Prop1\": 1.3 }");

            var result = obj.TryGetValue("Prop1", out double value);
            Assert.IsTrue(result);
            Assert.AreEqual(1.3d, value);
            Assert.IsInstanceOfType(value, typeof(double));
        }

        [TestMethod]
        public async Task TryGetValue_Long()
        {
            var obj = await Deserialize<GitLabObject>("{ \"Prop1\": 2 }");

            var result = obj.TryGetValue("Prop1", out long value);
            Assert.IsTrue(result);
            Assert.AreEqual(2L, value);
            Assert.IsInstanceOfType(value, typeof(long));
        }

        [TestMethod]
        public async Task TryGetValue_String()
        {
            var obj = await Deserialize<GitLabObject>("{ \"Prop1\": \"test\" }");

            var result = obj.TryGetValue("Prop1", out string value);
            Assert.IsTrue(result);
            Assert.AreEqual("test", value);
            Assert.IsInstanceOfType(value, typeof(string));
        }

        [TestMethod]
        public async Task TryGetValue_Null()
        {
            var obj = await Deserialize<GitLabObject>("{ \"Prop1\": null }");

            var result = obj.TryGetValue("Prop1", out object value);
            Assert.IsTrue(result);
            Assert.AreEqual(null, value);
        }

        [TestMethod]
        public async Task TryGetValue_Array()
        {
            var obj = await Deserialize<GitLabObject>("{ \"Prop1\": [1, 2] }");

            var result = obj.TryGetValue("Prop1", out int[] value);
            Assert.IsTrue(result);
            Assert.IsInstanceOfType(value, typeof(int[]));

            var array = value;
            Assert.IsInstanceOfType(array[0], typeof(int));
            Assert.IsInstanceOfType(array[1], typeof(int));
        }
    }
}
