using System;
using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Meziantou.GitLab.Serialization
{
    internal static class JsonSerialization
    {
        public static JsonSerializerOptions Options { get; } = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = false,
            Converters =
            {
                new GitLabObjectJsonConverter(),
            },
        };

        [return: MaybeNull]
        public static T ToObject<T>(JsonElement element)
        {
            var bufferWriter = new ArrayBufferWriter<byte>();
            using (var writer = new Utf8JsonWriter(bufferWriter))
            {
                element.WriteTo(writer);
            }

            return JsonSerializer.Deserialize<T>(bufferWriter.WrittenSpan, Options);
        }

        public static object? ToObject(JsonElement element, Type type)
        {
            var bufferWriter = new ArrayBufferWriter<byte>();
            using (var writer = new Utf8JsonWriter(bufferWriter))
            {
                element.WriteTo(writer);
            }

            return JsonSerializer.Deserialize(bufferWriter.WrittenSpan, type, Options);
        }

        [return: MaybeNull]
        public static T ToObject<T>(JsonDocument document)
        {
            return ToObject<T>(document.RootElement);
        }

        // TODO T could be null
        public static ValueTask<T> DeserializeAsync<T>(Stream stream, CancellationToken cancellationToken)
        {
            return JsonSerializer.DeserializeAsync<T>(stream, Options, cancellationToken);
        }
    }
}
