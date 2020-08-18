using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Meziantou.GitLab.Serialization
{
    internal abstract class EnumBaseJsonConverter<T> : JsonConverter<T>
        where T : struct, Enum
    {
        [return: MaybeNull]
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var value = reader.GetString();
                return FromString(value);
            }

            return default;
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(ToString(value));
        }

        protected abstract string ToString(T value);
        protected abstract T FromString(string value);
    }
}
