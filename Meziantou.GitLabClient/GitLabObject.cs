using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Meziantou.GitLab
{
    [JsonConverter(typeof(GitLabObjectConverter))]
    public class GitLabObject : IGitLabObject
    {
        internal GitLabObject(JObject obj)
        {
            Object = obj;
        }

        public virtual bool TryGetValue(string name, Type type, out object result)
        {
            if (Object != null && Object.TryGetValue(name, out var value))
            {
                result = value.ToObject(type, new JsonSerializer
                {
                    Converters =
                    {
                        new GitLabObjectConverter(),
                        new GitObjectIdConverter(),
                        new JsonObjectConverter(),
                    }
                });

                if (result is IGitLabObject g)
                {
                    g.GitLabClient = ((IGitLabObject)this).GitLabClient;
                }

                return true;
            }

            result = default;
            return false;
        }

        public virtual bool TryGetValue<T>(string name, out T result)
        {
            if (TryGetValue(name, typeof(T), out var r))
            {
                result = (T)r;
                return true;
            }

            result = default;
            return false;
        }

        public T GetValueOrDefault<T>(string name)
        {
            return GetValueOrDefault(name, default(T));
        }

        public T GetValueOrDefault<T>(string name, T defaultValue)
        {
            if (TryGetValue<T>(name, out var result))
            {
                return result;
            }

            return defaultValue;
        }

        public object GetValueOrDefault(string name, Type type, object defaultValue)
        {
            if (TryGetValue(name, type, out var result))
            {
                return result;
            }

            return defaultValue;
        }

        IGitLabClient IGitLabObject.GitLabClient { get; set; }

        private JObject Object { get; }

        // Convert JToken to .NET standard types
        private class JsonObjectConverter : JsonConverter
        {
            public override bool CanRead => true;
            public override bool CanWrite => false;

            public override bool CanConvert(Type objectType)
            {
                return typeof(object) == objectType || typeof(object[]) == objectType;
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
