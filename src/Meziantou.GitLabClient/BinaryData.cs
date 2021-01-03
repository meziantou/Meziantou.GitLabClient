using System;
using System.IO;
using System.Net.Http;
using System.Text;

namespace Meziantou.GitLab
{
    public abstract class BinaryData
    {
        public static BinaryData Empty { get; } = new BytesBinaryData(Array.Empty<byte>());
        public static BinaryData FromBytes(byte[] data) => new BytesBinaryData(data);
        public static BinaryData FromString(string data, Encoding encoding) => new StringBinaryData(data, encoding);
        public static BinaryData FromStream(Stream stream) => new StreamBinaryData(stream);

        public abstract HttpContent ToHttpContent();

        private sealed class StreamBinaryData : BinaryData
        {
            private readonly Stream _stream;

            public StreamBinaryData(Stream stream)
            {
                _stream = stream;
            }

            public override HttpContent ToHttpContent()
            {
                return new StreamContent(_stream);
            }
        }

        private sealed class BytesBinaryData : BinaryData
        {
            private readonly byte[] _data;

            public BytesBinaryData(byte[] data)
            {
                _data = data;
            }

            public override HttpContent ToHttpContent()
            {
                return new ByteArrayContent(_data);
            }
        }

        private sealed class StringBinaryData : BinaryData
        {
            private readonly string _string;
            private readonly Encoding _encoding;

            public StringBinaryData(string str, Encoding encoding)
            {
                _string = str;
                _encoding = encoding;
            }

            public override HttpContent ToHttpContent()
            {
                return new StringContent(_string, _encoding);
            }
        }
    }
}
