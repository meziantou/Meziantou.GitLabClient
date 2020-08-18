using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Meziantou.GitLab.Serialization
{
    internal sealed class GitObjectIdJsonConverter : JsonConverter<GitObjectId>
    {
        public override GitObjectId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                if (GitObjectId.TryParse(reader.GetString(), out var result))
                    return result;
            }

            return default;
        }

        public override void Write(Utf8JsonWriter writer, GitObjectId value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
