using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Meziantou.GitLabClient.Generator.Internals
{
    internal sealed class GitLabDocumentationMethod
    {
        public string Name { get; set; }
        public string DocumentationUrl { get; set; }
        public string Summary { get; set; }
        public string HttpMethod { get; set; }
        public string UrlTemplate { get; set; }

        public IList<GitLabDocumentationMethodParameter> Parameters { get; } = new List<GitLabDocumentationMethodParameter>();

        public bool Equals(Method method)
        {
            if (GetMethod(method.MethodType) != HttpMethod)
                return false;

            if (GetUrlForComparison('/' + method.UrlTemplate) != GetUrlForComparison(UrlTemplate))
                return false;

            return true;

            static string GetUrlForComparison(string url)
            {
                // Remove parameters /:test/
                return Regex.Replace(url, "(?!/):[a-z_-]+", ":", RegexOptions.CultureInvariant, TimeSpan.FromSeconds(1));
            }

            static string GetMethod(MethodType type)
            {
                return type switch
                {
                    MethodType.Get or MethodType.GetCollection or MethodType.GetPaged => "GET",
                    MethodType.Put => "PUT",
                    MethodType.Post => "POST",
                    MethodType.Delete => "DELETE",
                    _ => throw new InvalidOperationException($"Type '{type}' not supported"),
                };
            }
        }
    }
}
