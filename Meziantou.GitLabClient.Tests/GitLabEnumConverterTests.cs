using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class GitLabEnumConverterTests
    {
        public enum Test
        {
            SampleValue1,
            SampleValue2,
            SampleValue3,
        }

        [Flags]
        public enum TestFlags
        {
            SampleValue0 = 0,
            SampleValue1 = 1,
            SampleValue2 = 2,
            SampleValue3 = 4,
        }

        [DataTestMethod]
        [DataRow("\"sample_value_1\"", Test.SampleValue1)]
        public void ReadEnumValue(string json, Test expectedValue)
        {
            var result = JsonConvert.DeserializeObject(json, typeof(Test), new GitLabEnumConverter());
            Assert.AreEqual(expectedValue, result);
        }

        [DataTestMethod]
        [DataRow("", null)]
        [DataRow("\"sample_value_1\"", Test.SampleValue1)]
        public void ReadNullableEnumValue(string json, Test? expectedValue)
        {
            var result = JsonConvert.DeserializeObject(json, typeof(Test?), new GitLabEnumConverter());
            Assert.AreEqual(expectedValue, result);
        }

        [DataTestMethod]
        [DataRow("\"sample_value_1\"", TestFlags.SampleValue1)]
        [DataRow("\"sample_value_1, sample_value_2\"", TestFlags.SampleValue1 | TestFlags.SampleValue2)]
        public void ReadFlagsEnumValue(string json, TestFlags expectedValue)
        {
            var result = JsonConvert.DeserializeObject(json, typeof(TestFlags), new GitLabEnumConverter());
            Assert.AreEqual(expectedValue, result);
        }
    }
}
