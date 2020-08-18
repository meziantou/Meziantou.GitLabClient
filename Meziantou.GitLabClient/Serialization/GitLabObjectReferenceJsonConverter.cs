using System;
using System.Text.Json;
using System.Text.Json.Serialization;

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
