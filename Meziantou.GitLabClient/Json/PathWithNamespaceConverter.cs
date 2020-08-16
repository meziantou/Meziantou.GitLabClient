using System;
using Newtonsoft.Json;

namespace Meziantou.GitLab
{
    internal sealed class PathWithNamespaceConverter : JsonConverter<PathWithNamespace>
    {
        public override bool CanRead => true;
        public override bool CanWrite => true;

        public override PathWithNamespace ReadJson(JsonReader reader, Type objectType, PathWithNamespace existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                return new PathWithNamespace((string)reader.Value);
            }

            return default;
        }

        public override void WriteJson(JsonWriter writer, PathWithNamespace value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}
