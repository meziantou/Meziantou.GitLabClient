using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Meziantou.GitLab.Serialization
{
    internal sealed class GitObjectIdJsonConverter : JsonConverter<GitObjectId>
    {
        public override GitObjectId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (value != null)
                return new GitObjectId(value);

            return GitObjectId.Empty;
        }

        public override void Write(Utf8JsonWriter writer, GitObjectId value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
