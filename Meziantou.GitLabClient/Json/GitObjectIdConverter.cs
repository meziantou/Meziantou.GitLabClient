using System;
using Newtonsoft.Json;

namespace Meziantou.GitLab
{
    internal sealed class GitObjectIdConverter : JsonConverter<GitObjectId>
    {
        public override bool CanRead => true;
        public override bool CanWrite => true;

        public override GitObjectId ReadJson(JsonReader reader, Type objectType, GitObjectId existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                if (GitObjectId.TryParse((string)reader.Value, out var sha1))
                    return sha1;
            }

            return default;
        }

        public override void WriteJson(JsonWriter writer, GitObjectId value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}
