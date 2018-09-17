using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class GitLabObjectTests
    {
        [TestMethod]
        public void TryGetValue_Boolean()
        {
            var obj = JsonConvert.DeserializeObject<GitLabObject>("{ \"Prop1\": true }");

            var result = obj.TryGetValue("Prop1", out bool value);
            Assert.IsTrue(result);
            Assert.AreEqual(true, value);
            Assert.IsInstanceOfType(value, typeof(bool));
        }

        [TestMethod]
        public void TryGetValue_Double()
        {
            var obj = JsonConvert.DeserializeObject<GitLabObject>("{ \"Prop1\": 1.3 }");

            var result = obj.TryGetValue("Prop1", out double value);
            Assert.IsTrue(result);
            Assert.AreEqual(1.3d, value);
            Assert.IsInstanceOfType(value, typeof(double));
        }

        [TestMethod]
        public void TryGetValue_Long()
        {
            var obj = JsonConvert.DeserializeObject<GitLabObject>("{ \"Prop1\": 2 }");

            var result = obj.TryGetValue("Prop1", out long value);
            Assert.IsTrue(result);
            Assert.AreEqual(2L, value);
            Assert.IsInstanceOfType(value, typeof(long));
        }

        [TestMethod]
        public void TryGetValue_String()
        {
            var obj = JsonConvert.DeserializeObject<GitLabObject>("{ \"Prop1\": \"test\" }");

            var result = obj.TryGetValue("Prop1", out string value);
            Assert.IsTrue(result);
            Assert.AreEqual("test", value);
            Assert.IsInstanceOfType(value, typeof(string));
        }

        [TestMethod]
        public void TryGetValue_Null()
        {
            var obj = JsonConvert.DeserializeObject<GitLabObject>("{ \"Prop1\": null }");

            var result = obj.TryGetValue("Prop1", out object value);
            Assert.IsTrue(result);
            Assert.AreEqual(null, value);
        }

        [TestMethod]
        public void TryGetValue_Object()
        {
            var obj = JsonConvert.DeserializeObject<GitLabObject>("{ \"Prop1\": { \"SubProp1\": 1 } }");

            var result = obj.TryGetValue("Prop1", out object value);
            Assert.IsTrue(result);
            Assert.IsInstanceOfType(value, typeof(IDictionary<string, object>));

            var dict = (IDictionary<string, object>)value;
            Assert.AreEqual(1L, dict["SubProp1"]);
        }

        [TestMethod]
        public void TryGetValue_Array()
        {
            var obj = JsonConvert.DeserializeObject<GitLabObject>("{ \"Prop1\": [{ \"Prop1\": 1 }, 2, \"test\"] }");

            var result = obj.TryGetValue("Prop1", out object[] value);
            Assert.IsTrue(result);
            Assert.IsInstanceOfType(value, typeof(object[]));

            var array = value;
            Assert.IsInstanceOfType(array[0], typeof(IDictionary<string, object>));
            Assert.IsInstanceOfType(array[1], typeof(long));
            Assert.IsInstanceOfType(array[2], typeof(string));
        }

        [TestMethod]
        public void AsDynamic()
        {
            var obj = JsonConvert.DeserializeObject<GitLabObject>("{ \"Prop1\": 2 }");

            dynamic dyn = obj;
            var result = dyn.Prop1;
            Assert.AreEqual(2, (int)result);
        }
    }
}
