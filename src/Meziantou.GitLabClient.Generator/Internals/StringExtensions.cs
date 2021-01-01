using System;

namespace Meziantou.GitLabClient.Generator.Internals
{
    internal static class StringExtensions
    {
        public static string RemoveSuffix(this string str, string suffix)
        {
            if (str.EndsWith(suffix, StringComparison.Ordinal))
            {
                return str.Substring(0, str.Length - suffix.Length);
            }

            return str;
        }
    }
}
