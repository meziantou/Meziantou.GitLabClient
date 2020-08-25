using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Html.Dom;
using Meziantou.Framework;
using Meziantou.Framework.Collections;
using Meziantou.GitLabClient.Generator.GitLabModels;

namespace Meziantou.GitLabClient.Generator
{
    internal static class ApiCoverage
    {
        public static async Task<string> GetMarkdown()
        {
            var project = GitLabModelBuilder.Create();

            var resources = await LoadResources();

            var sb = new StringBuilder();
            foreach (var resource in resources)
            {
                sb.Append("# [").Append(resource.DisplayName).Append("](").Append(resource.DocumentationUrl).Append(')').AppendLine();
                foreach (var method in resource.Methods)
                {
                    var isImplemented = IsImplemented(method, project) ? 'x' : ' ';
                    sb.Append("- [").Append(isImplemented).Append("] [").Append(method.DisplayName).Append("](").Append(method.DocumentationUrl).Append(") `").Append(method.HttpMethod).Append(' ').Append(method.UrlTemplate).Append('`').AppendLine();
                }

                sb.AppendLine();
            }
            return sb.ToString();
        }

        private static async Task<IList<MethodGroup>> LoadResources()
        {
            var result = new SynchronizedList<MethodGroup>();

            var configuration = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(configuration);
            var document = await context.OpenAsync("https://docs.gitlab.com/ee/api/api_resources.html");

            var resources = document.QuerySelectorAll("#Resources a").Cast<IHtmlAnchorElement>();
            await resources.ForEachAsync(degreeOfParallelism: 32, async anchor =>
            {
                var name = Trim(anchor.TextContent);
                var url = anchor.Href;

                var group = new MethodGroup
                {
                    DisplayName = name,
                    DocumentationUrl = url,
                };
                result.Add(group);

                var d = await context.OpenAsync(url);
                var mainContent = d.QuerySelector("[itemprop=mainContentOfPage]");
                var headers = mainContent.QuerySelectorAll("h1, h2, h3");
                foreach (var header in headers)
                {
                    var element = header.NextElementSibling;
                    string urlTemplate = null;
                    while (element != null)
                    {
                        var code = element.QuerySelector("code");
                        if (code != null && element is IHtmlDivElement && element.ClassList.Any(c => c.StartsWith("language-", StringComparison.Ordinal)))
                        {
                            urlTemplate = Trim(code.TextContent);
                            break;
                        }

                        // h2 followed by h2
                        if (element is IHtmlHeadingElement)
                        {
                            urlTemplate = null;
                            break;
                        }

                        element = element.NextElementSibling;
                    }

                    if (urlTemplate == null)
                        continue;

                    foreach (var template in urlTemplate.Split('\n').Select(Trim))
                    {
                        if (string.IsNullOrEmpty(template))
                            continue;

                        // TODO improve that case 
                        // curl --request POST --header "PRIVATE-TOKEN: <your_access_token>" "https://gitlab.example.com/api/v4/projects/5/deploy_keys/13/enable"
                        if (template.StartsWith("curl ", StringComparison.Ordinal))
                            continue;

                        if (!StartsWithHttpVerb(template))
                            continue;

                        var urlParts = template.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        if (urlParts.Length != 2)
                            throw new Exception();

                        var method = new Method
                        {
                            DisplayName = Trim(header.TextContent),
                            DocumentationUrl = $"{d.Url}#{header.Id}",
                            HttpMethod = urlParts[0],
                            UrlTemplate = RemoveQueryString(urlParts[1]),
                        };

                        // Do not add duplicate
                        if (group.Methods.Any(m => m.HttpMethod == method.HttpMethod && m.UrlTemplate == method.UrlTemplate))
                            continue;

                        group.Methods.Add(method);
                    }
                }
            });

            return result;
        }

        private static bool StartsWithHttpVerb(string url)
        {
            var methods = new string[] { "GET", "POST", "PUT", "DELETE", "PATCH" };
            foreach (var method in methods)
            {
                if (url.StartsWith(method, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        private static bool IsImplemented(Method method, Project project)
        {
            foreach (var modelMethodGroup in project.MethodGroups)
            {
                foreach (var modelMethod in modelMethodGroup.Methods)
                {
                    if (GetMethod(modelMethod.MethodType) != method.HttpMethod)
                        continue;

                    if (GetUrlForComparison('/' + modelMethod.UrlTemplate) != GetUrlForComparison(method.UrlTemplate))
                        continue;

                    return true;
                }
            }

            return false;

            static string GetUrlForComparison(string url)
            {
                // Remove /:test/
                return Regex.Replace(url, "(?!/):[a-z_-]+", ":", RegexOptions.CultureInvariant, TimeSpan.FromSeconds(1));
            }

            static string GetMethod(MethodType type)
            {
                switch (type)
                {
                    case MethodType.Get:
                    case MethodType.GetCollection:
                    case MethodType.GetPaged:
                        return "GET";
                    case MethodType.Put:
                        return "PUT";
                    case MethodType.Post:
                        return "POST";
                    case MethodType.Delete:
                        return "DELETE";
                    default:
                        throw new System.Exception("Type not supported");
                }
            }
        }

        private static string RemoveQueryString(string url)
        {
            var index = url.IndexOf('?', StringComparison.Ordinal);
            if (index > 0)
                return url[0..index];

            return url;
        }

        private static string Trim(string text)
        {
            return text.Trim('\n', ' ', '\t');
        }

        private sealed class MethodGroup
        {
            public string DisplayName { get; set; }
            public string DocumentationUrl { get; set; }
            public IList<Method> Methods { get; } = new List<Method>();
        }

        private sealed class Method
        {
            public string DisplayName { get; set; }
            public string DocumentationUrl { get; set; }
            public string HttpMethod { get; set; }
            public string UrlTemplate { get; set; }
        }
    }
}
