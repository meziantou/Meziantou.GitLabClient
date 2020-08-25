using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Meziantou.GitLab.Serialization
{
    internal sealed class PathWithNamespaceConverter : JsonConverter<PathWithNamespace>
    {
        public override PathWithNamespace Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var str = reader.GetString()!;
                return new PathWithNamespace(str);
            }

            return default;
        }

        public override void Write(Utf8JsonWriter writer, PathWithNamespace value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.FullPath);
        }
    }
}
