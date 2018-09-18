using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Meziantou.GitLab
{
    internal class GitLabObjectConverter : JsonConverter<GitLabObject>
    {
        public override bool CanRead => true;
        public override bool CanWrite => false;

        public override GitLabObject ReadJson(JsonReader reader, Type objectType, GitLabObject existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                var obj = JObject.Load(reader);
                var gitLabObject = (GitLabObject)Activator.CreateInstance(objectType, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, new object[] { obj }, null);

                if (serializer.Context.Context is IGitLabClient client)
                {
                    ((IGitLabObject)gitLabObject).GitLabClient = client;
                }

                return gitLabObject;
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, GitLabObject value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}
