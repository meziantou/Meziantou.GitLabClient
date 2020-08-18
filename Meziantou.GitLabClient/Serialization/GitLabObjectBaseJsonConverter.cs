using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Meziantou.GitLab.Core;

namespace Meziantou.GitLab.Serialization
{
    internal abstract class GitLabObjectBaseJsonConverter<T> : JsonConverter<T>
        where T : GitLabObject
    {
        [return: MaybeNull]
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return null;

            using var document = JsonDocument.ParseValue(ref reader);
            var jsonElement = document.RootElement.Clone();
            return CreateInstance(jsonElement);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            value._jsonObject.WriteTo(writer);
        }

        protected abstract T CreateInstance(JsonElement jsonElement);
    }

    internal sealed class GitLabObjectJsonConverter : GitLabObjectBaseJsonConverter<GitLabObject>
    {
        protected override GitLabObject CreateInstance(JsonElement jsonElement)
        {
            return new GitLabObject(jsonElement);
        }
    }
    internal sealed class GitLabErrorJsonConverter : GitLabObjectBaseJsonConverter<GitLabError>
    {
        protected override GitLabError CreateInstance(JsonElement jsonElement)
        {
            return new GitLabError(jsonElement);
        }
    }
}
