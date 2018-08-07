using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Meziantou.GitLab
{
    internal class JsonContent : StringContent
    {
        public JsonContent(object content)
            : base(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json")
        {
        }

        public JsonContent(object content, JsonSerializerSettings settings)
            : base(JsonConvert.SerializeObject(content, settings), Encoding.UTF8, "application/json")
        {
        }
    }
}
