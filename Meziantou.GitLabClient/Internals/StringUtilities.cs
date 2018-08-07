using System.Linq;

namespace Meziantou.GitLabClient.Internals
{
    internal static class StringUtilities
    {
        public static string SnakeCase(string value)
        {
            return string.Concat(value.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }
    }
}
