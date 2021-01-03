using System.IO;
using System.Net.Http;
using System.Text;

namespace Meziantou.GitLab
{
    public abstract class FileUpload
    {
        protected FileUpload(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; }

        public static FileUpload FromBytes(string fileName, byte[] data) => new BytesBinaryData(fileName, data);
        public static FileUpload FromString(string fileName, string data, Encoding encoding) => new StringBinaryData(fileName, data, encoding);
        public static FileUpload FromStream(string fileName, Stream stream) => new StreamBinaryData(fileName, stream);
        public static FileUpload FromPath(string path) => new StreamBinaryData(Path.GetFileName(path), File.OpenRead(path));

        public abstract HttpContent ToHttpContent();

        private sealed class StreamBinaryData : FileUpload
        {
            private readonly Stream _stream;

            public StreamBinaryData(string fileName, Stream stream)
                : base(fileName)
            {
                _stream = stream;
            }

            public override HttpContent ToHttpContent()
            {
                return new StreamContent(_stream);
            }
        }

        private sealed class BytesBinaryData : FileUpload
        {
            private readonly byte[] _data;

            public BytesBinaryData(string fileName, byte[] data)
                : base(fileName)
            {
                _data = data;
            }

            public override HttpContent ToHttpContent()
            {
                return new ByteArrayContent(_data);
            }
        }

        private sealed class StringBinaryData : FileUpload
        {
            private readonly string _string;
            private readonly Encoding _encoding;

            public StringBinaryData(string fileName, string str, Encoding encoding)
                : base(fileName)
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
