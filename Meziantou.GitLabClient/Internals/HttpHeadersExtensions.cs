using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;

namespace Meziantou.GitLabClient.Internals
{
    internal static class HttpHeadersExtensions
    {
        public static int GetHeaderValue(this HttpHeaders headers, string name, int defaultValue)
        {
            if (headers.TryGetValues(name, out var enumerable))
            {
                var value = enumerable.First();
                if (int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
                    return result;
            }

            return defaultValue;
        }
    }
}
