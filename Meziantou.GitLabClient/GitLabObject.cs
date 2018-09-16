using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Meziantou.GitLab
{
    public abstract class GitLabObject
    {
        private IDictionary<string, JToken> _additionalData = null;

        public virtual bool TryGetValue(string name, out object result)
        {
            if (AdditionalData != null && AdditionalData.TryGetValue(name, out var value))
            {
                result = value.ToObject(typeof(object), new JsonSerializer { Converters = { new JsonObjectConverter() } });
                return true;
            }

            result = default;
            return false;
        }

        [JsonExtensionData]
        internal IDictionary<string, JToken> AdditionalData
        {
            get
            {
                if (_additionalData == null)
                {
                    _additionalData = new Dictionary<string, JToken>();
                }

                return _additionalData;
            }
        }

        [JsonIgnore]
        internal IGitLabClient GitLabClient { get; set; }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            if (context.Context is IGitLabClient client)
            {
                GitLabClient = client;
            }
        }

        // Convert JToken to .NET standard types
        private class JsonObjectConverter : JsonConverter
        {
            public override bool CanRead => true;
            public override bool CanWrite => false;

            public override bool CanConvert(Type objectType)
            {
                return true;
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var token = JToken.Load(reader);
                if (token is JValue v)
                {
                    return v.Value;
                }

                if (token is JObject o)
                {
                    return ToDictionary(o);
                }

                if (token is JArray a)
                {
                    return ToArray(a);
                }

                return null;
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotSupportedException();
            }

            private static IDictionary<string, object> ToDictionary(JObject json)
            {
                var propertyValuePairs = json.ToObject<Dictionary<string, object>>();
                ProcessJObjectProperties(propertyValuePairs);
                ProcessJArrayProperties(propertyValuePairs);
                return propertyValuePairs;
            }

            private static void ProcessJObjectProperties(IDictionary<string, object> propertyValuePairs)
            {
                var objectPropertyNames = (from property in propertyValuePairs
                                           let propertyName = property.Key
                                           let value = property.Value
                                           where value is JObject
                                           select propertyName).ToList();

                objectPropertyNames.ForEach(propertyName => propertyValuePairs[propertyName] = ToDictionary((JObject)propertyValuePairs[propertyName]));
            }

            private static void ProcessJArrayProperties(IDictionary<string, object> propertyValuePairs)
            {
                var arrayPropertyNames = (from property in propertyValuePairs
                                          let propertyName = property.Key
                                          let value = property.Value
                                          where value is JArray
                                          select propertyName).ToList();

                arrayPropertyNames.ForEach(propertyName => propertyValuePairs[propertyName] = ToArray((JArray)propertyValuePairs[propertyName]));
            }

            private static object[] ToArray(JArray array)
            {
                return array.ToObject<object[]>().Select(ProcessArrayEntry).ToArray();
            }

            private static object ProcessArrayEntry(object value)
            {
                if (value is JObject obj)
                {
                    return ToDictionary(obj);
                }
                if (value is JArray array)
                {
                    return ToArray(array);
                }
                return value;
            }

        }
    }
}
