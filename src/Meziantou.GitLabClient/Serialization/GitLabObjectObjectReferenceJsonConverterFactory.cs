using System;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Meziantou.GitLab.Internals;

namespace Meziantou.GitLab.Serialization
{
    internal sealed class GitLabObjectObjectReferenceJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return GetGenericType(typeToConvert) != null;
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var keyType = GetGenericType(typeToConvert);
            Debug.Assert(keyType != null);

            var converter = (JsonConverter?)Activator.CreateInstance(
               typeof(GitLabObjectObjectReferenceJsonConverter<,>).MakeGenericType(new Type[] { typeToConvert, keyType }),
               BindingFlags.Instance | BindingFlags.Public,
               binder: null,
               args: null,
               culture: null);

            return converter!;
        }


        private static Type? GetGenericType(Type typeToConvert)
        {
            foreach (var iface in typeToConvert.GetInterfaces())
            {
                if (!iface.IsGenericType)
                    continue;

                if (iface.GetGenericTypeDefinition() != typeof(IGitLabObjectReference<>))
                    continue;

                return iface.GetGenericArguments()[0];
            }

            return null;
        }

        private sealed class GitLabObjectObjectReferenceJsonConverter<T, TValue> : JsonConverter<T>
            where T : IGitLabObjectReference<TValue>
        {
            public override bool CanConvert(Type typeToConvert)
            {
                return typeof(IGitLabObjectReference<object>).IsAssignableFrom(typeToConvert);
            }

            public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => throw new NotSupportedException();

            public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
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
}
