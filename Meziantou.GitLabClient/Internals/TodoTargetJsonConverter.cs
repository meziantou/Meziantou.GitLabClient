using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Meziantou.GitLab
{
    internal class TodoTargetJsonConverter : JsonConverter
    {
        public override bool CanRead => true;
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType) => typeof(GitLabObject).IsAssignableFrom(objectType);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var o = JObject.Load(reader);
            var actualType = typeof(object);
            if (o.ContainsKey("source_branch"))
            {
                actualType = typeof(MergeRequest);
            }
            else
            {
                actualType = typeof(Issue);
            }

            using (var objectReader = o.CreateReader())
            {
                return serializer.Deserialize(objectReader, actualType);
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}
