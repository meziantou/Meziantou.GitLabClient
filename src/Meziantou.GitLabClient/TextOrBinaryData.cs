using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Meziantou.GitLab
{
    [JsonConverter(typeof(TextOrBinaryDataJsonConverter))]
    public sealed class TextOrBinaryData
    {
        private readonly string? _str;
        private readonly ReadOnlyMemory<byte> _bytes;

        private TextOrBinaryData(string str) => _str = str;

        private TextOrBinaryData(ReadOnlyMemory<byte> bytes) => _bytes = bytes;

        [return: NotNullIfNotNull("bytes")]
        public static TextOrBinaryData? FromBytes(byte[]? bytes) => bytes == null ? null : new(bytes);

        public static TextOrBinaryData FromBytes(ReadOnlyMemory<byte> bytes) => new(bytes);

        [return: NotNullIfNotNull("str")]
        public static TextOrBinaryData? FromString(string? str) => str == null ? null : new(str);

        [return: NotNullIfNotNull("str")]
        public static TextOrBinaryData? FromString(string? str, Encoding encoding) => str == null ? null : new(encoding.GetBytes(str));

        public static async Task<TextOrBinaryData> FromStreamAsync(Stream stream)
        {
            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms).ConfigureAwait(false);
            return new TextOrBinaryData(ms.ToArray());
        }

        [return: NotNullIfNotNull("str")]
        public static implicit operator TextOrBinaryData?(string? str) => FromString(str);

        [return: NotNullIfNotNull("bytes")]
        [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "Use FromBytes")]
        public static implicit operator TextOrBinaryData?(byte[]? bytes) => FromBytes(bytes);

        [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "Use FromBytes")]
        public static implicit operator TextOrBinaryData(ReadOnlyMemory<byte> bytes) => FromBytes(bytes);

        private sealed class TextOrBinaryDataJsonConverter : JsonConverter<TextOrBinaryData>
        {
            public override TextOrBinaryData? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                throw new NotSupportedException();
            }

            public override void Write(Utf8JsonWriter writer, TextOrBinaryData value, JsonSerializerOptions options)
            {
                if (value._str != null)
                {
                    writer.WriteStringValue(value._str);
                }
                else
                {
                    writer.WriteBase64StringValue(value._bytes.Span);
                    writer.WriteString("encoding", "base64");
                }
            }
        }
    }
}
