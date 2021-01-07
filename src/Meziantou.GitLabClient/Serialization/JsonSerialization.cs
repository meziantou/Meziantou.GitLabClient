using System;
using System.Buffers;
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
#if DEBUG
            WriteIndented = true,
#endif
        };

        public static T? ToObject<T>(JsonElement element)
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
            return ToObject(element, type, Options);
        }

        public static object? ToObject(JsonElement element, Type type, JsonSerializerOptions? options)
        {
            var bufferWriter = new ArrayBufferWriter<byte>();
            using (var writer = new Utf8JsonWriter(bufferWriter))
            {
                element.WriteTo(writer);
            }

            return JsonSerializer.Deserialize(bufferWriter.WrittenSpan, type, options);
        }

        public static T? ToObject<T>(JsonDocument document)
        {
            return ToObject<T>(document.RootElement);
        }

        public static ValueTask<T?> DeserializeAsync<T>(Stream stream, CancellationToken cancellationToken)
        {
            return JsonSerializer.DeserializeAsync<T?>(stream, Options, cancellationToken);
        }
    }
}
