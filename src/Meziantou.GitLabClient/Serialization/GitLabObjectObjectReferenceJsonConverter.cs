using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Meziantou.GitLab.Internals;

namespace Meziantou.GitLab.Serialization
{
    internal sealed class GitLabObjectObjectReferenceJsonConverter : JsonConverter<IGitLabObjectReference<object>>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(IGitLabObjectReference<object>).IsAssignableFrom(typeToConvert);
        }

        public override IGitLabObjectReference<object> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => throw new NotSupportedException();

        public override void Write(Utf8JsonWriter writer, IGitLabObjectReference<object> value, JsonSerializerOptions options)
        {
            if (value is null)
            {
                writer.WriteNullValue();
            }
            else
            {
                JsonSerializer.Serialize(writer, value.Value, options);
            }
        }
    }
}
