#if NETSTANDARD2_0
#pragma warning disable IDE0060
#pragma warning disable CA1801
#pragma warning disable MA0048
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System
{
    internal static class StringExtensions
    {
        public static bool Contains(this string value, char c, StringComparison stringComparison)
        {
            return value.IndexOf(c.ToString(), stringComparison) >= 0;
        }
    }

    namespace Net.Http
    {
        internal static class HttpContentExtensions
        {
            public static Task<string> ReadAsStringAsync(this HttpContent content, CancellationToken cancellationToken)
            {
                return content.ReadAsStringAsync();
            }

            public static Task<Stream> ReadAsStreamAsync(this HttpContent content, CancellationToken cancellationToken)
            {
                return content.ReadAsStreamAsync();
            }
        }
    }
}
#endif
