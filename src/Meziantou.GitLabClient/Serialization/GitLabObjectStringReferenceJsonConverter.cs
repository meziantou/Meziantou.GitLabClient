using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Meziantou.GitLab.Internals;

namespace Meziantou.GitLab.Serialization
{
    internal sealed class GitLabObjectStringReferenceJsonConverter : JsonConverter<IGitLabObjectReference<string>>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(IGitLabObjectReference<string>).IsAssignableFrom(typeToConvert);
        }

        public override IGitLabObjectReference<string> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => throw new NotSupportedException();

        public override void Write(Utf8JsonWriter writer, IGitLabObjectReference<string> value, JsonSerializerOptions options)
        {
            if (value is null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(value.Value);
            }
        }
    }
}
