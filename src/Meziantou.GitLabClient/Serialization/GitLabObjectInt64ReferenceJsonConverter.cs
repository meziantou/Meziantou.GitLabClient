using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Meziantou.GitLab.Serialization
{
    internal sealed class GitLabObjectInt64ReferenceJsonConverter : JsonConverter<IGitLabObjectReference<long>>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(IGitLabObjectReference<long>).IsAssignableFrom(typeToConvert);
        }

        public override IGitLabObjectReference<long> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => throw new NotSupportedException();

        public override void Write(Utf8JsonWriter writer, IGitLabObjectReference<long> value, JsonSerializerOptions options)
        {
            if (value is null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteNumberValue(value.Value);
            }
        }
    }
}
