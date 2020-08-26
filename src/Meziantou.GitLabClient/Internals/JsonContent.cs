using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Meziantou.GitLab
{
    internal sealed class JsonContent : HttpContent
    {
        private static readonly MediaTypeHeaderValue s_header = new MediaTypeHeaderValue("application/json") { CharSet = Encoding.UTF8.WebName };

        private readonly object? _content;
        private readonly JsonSerializerOptions? _settings;

        public JsonContent(object? content, JsonSerializerOptions? settings)
        {
            Headers.ContentType = s_header;
            _content = content;
            _settings = settings;
        }

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext? context)
        {
            return JsonSerializer.SerializeAsync(stream, _content, _settings);
        }

        protected override bool TryComputeLength(out long length)
        {
            length = 0;
            return false;
        }
    }
}
