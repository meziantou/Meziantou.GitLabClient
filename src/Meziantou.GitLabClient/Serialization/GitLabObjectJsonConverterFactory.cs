using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Meziantou.GitLab.Core;

namespace Meziantou.GitLab.Serialization
{
    internal sealed class GitLabObjectJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(GitLabObject).IsAssignableFrom(typeToConvert);
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var converter = (JsonConverter?)Activator.CreateInstance(
               typeof(GitLabObjectJsonConverter<>).MakeGenericType(new Type[] { typeToConvert }),
               BindingFlags.Instance | BindingFlags.Public,
               binder: null,
               args: null,
               culture: null);

            return converter!;
        }

        private sealed class GitLabObjectJsonConverter<T> : JsonConverter<T>
            where T : GitLabObject
        {
            public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null)
                    return null;

                using var document = JsonDocument.ParseValue(ref reader);
                var jsonElement = document.RootElement.Clone();
                return (T?)Activator.CreateInstance(typeof(T), BindingFlags.NonPublic | BindingFlags.Instance, binder: null, new object[] { jsonElement }, culture: null);
            }

            public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
            {
                value._jsonObject.WriteTo(writer);
            }
        }
    }
}
