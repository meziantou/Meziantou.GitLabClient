using System;
using System.Text.RegularExpressions;

namespace Meziantou.GitLab
{
    // http://www.rfc-editor.org/rfc/rfc5988.txt
    internal sealed class LinkHeaderValue
    {
        public string Url { get; }
        public string Rel { get; }

        public LinkHeaderValue(string url, string rel)
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));
            Rel = rel ?? throw new ArgumentNullException(nameof(rel));
        }

        public static bool TryParse(string value, out LinkHeaderValue result)
        {
            if (string.IsNullOrEmpty(value))
            {
                result = null;
                return false;
            }

            var match = Regex.Match(value, "^\\s*<(?<url>[^>]*)>\\s*;\\s*rel\\s*=\\s*\"(?<rel>[^\"]*)\"\\s*$", RegexOptions.ExplicitCapture | RegexOptions.CultureInvariant, TimeSpan.FromSeconds(1));
            if (match.Success)
            {
                var url = match.Groups["url"].Value;
                var rel = match.Groups["rel"].Value;
                result = new LinkHeaderValue(url, rel);
                return true;
            }

            result = null;
            return false;
        }
    }
}
