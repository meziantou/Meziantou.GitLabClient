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
        public static async Task<string> GetMarkdownAsync()
        {
            var project = GitLabModelBuilder.Create();

            var resources = await LoadResourcesAsync();

            var sb = new StringBuilder();
            foreach (var resource in resources.OrderBy(r => r.DisplayName))
            {
                sb.Append("# [").Append(resource.DisplayName).Append("](").Append(resource.DocumentationUrl).Append(')').AppendLine();
                foreach (var method in resource.Methods.OrderBy(m => m.DisplayName))
                {
                    var isImplemented = IsImplemented(method, project) ? 'x' : ' ';
                    sb.Append("- [").Append(isImplemented).Append("] [").Append(method.DisplayName).Append("](").Append(method.DocumentationUrl).Append(") `").Append(method.HttpMethod).Append(' ').Append(method.UrlTemplate).Append('`').AppendLine();
                }

                sb.AppendLine();
            }
            return sb.ToString();
        }

        private static async Task<IList<MethodGroup>> LoadResourcesAsync()
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
                var mainContent = d.QuerySelector("[itemprop='mainContentOfPage']");
                var headers = mainContent.QuerySelectorAll("h1, h2, h3");
                foreach (var header in headers)
                {
                    var documentationUrl = $"{d.Url}#{header.Id}";
                    if (documentationUrl == "https://docs.gitlab.com/ee/api/deploy_keys.html#adding-deploy-keys-to-multiple-projects" ||
                        documentationUrl == "https://docs.gitlab.com/ee/api/groups.html#new-subgroup" ||
                        documentationUrl == "https://docs.gitlab.com/ee/api/pages_domains.html#adding-certificate" ||
                        documentationUrl == "https://docs.gitlab.com/ee/api/pages_domains.html#enabling-lets-encrypt-integration-for-pages-custom-domains" ||
                        documentationUrl == "https://docs.gitlab.com/ee/api/pages_domains.html#removing-certificate" ||
                        documentationUrl == "https://docs.gitlab.com/ee/api/project_level_variables.html#the-filter-parameter" ||
                        documentationUrl == "https://docs.gitlab.com/ee/api/protected_branches.html#example-with-user--group-level-access-starter" ||
                        documentationUrl == "https://docs.gitlab.com/ee/api/search.html#scope-blobs" ||
                        documentationUrl == "https://docs.gitlab.com/ee/api/search.html#scope-blobs-starter-1" ||
                        documentationUrl == "https://docs.gitlab.com/ee/api/search.html#scope-commits" ||
                        documentationUrl == "https://docs.gitlab.com/ee/api/search.html#scope-issues-1" ||
                        documentationUrl == "https://docs.gitlab.com/ee/api/search.html#scope-issues-2" ||
                        documentationUrl == "https://docs.gitlab.com/ee/api/search.html#scope-merge_requests-1" ||
                        documentationUrl == "https://docs.gitlab.com/ee/api/search.html#scope-merge_requests-2" ||
                        documentationUrl == "https://docs.gitlab.com/ee/api/search.html#scope-milestones-1" ||
                        documentationUrl == "https://docs.gitlab.com/ee/api/search.html#scope-milestones-2" ||
                        documentationUrl == "https://docs.gitlab.com/ee/api/search.html#scope-notes" ||
                        documentationUrl == "https://docs.gitlab.com/ee/api/search.html#scope-projects-1" ||
                        documentationUrl == "https://docs.gitlab.com/ee/api/search.html#scope-users-1" ||
                        documentationUrl == "https://docs.gitlab.com/ee/api/search.html#scope-users-2" ||
                        documentationUrl == "https://docs.gitlab.com/ee/api/search.html#scope-wiki_blobs-starter-1" ||
                        documentationUrl == "https://docs.gitlab.com/ee/api/search.html#scope-wiki_blobs" ||
                        documentationUrl == "https://docs.gitlab.com/ee/api/search.html#scope-commits-starter-1")
                    {
                        continue;
                    }

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

                        var parsedTemplate = template;
                        if (template.StartsWith("curl ", StringComparison.Ordinal))
                        {
                            parsedTemplate = ParseCurlCommand(template);
                            if (parsedTemplate == "POST /projects/5/deploy_keys/13/enable")
                            {
                                parsedTemplate = "POST /projects/:id/deploy_keys/:key_id/enable";
                            }
                        }

                        if (!StartsWithHttpVerb(parsedTemplate))
                            continue;

                        var urlParts = parsedTemplate.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        if (urlParts.Length != 2)
                            throw new Exception();

                        if (urlParts[0].StartsWith("/api/v4/", StringComparison.Ordinal))
                        {
                            urlParts[0] = urlParts[0]["/api/v4".Length..];
                        }

                        var method = new Method
                        {
                            DisplayName = Trim(header.TextContent),
                            DocumentationUrl = documentationUrl,
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

        private static string ParseCurlCommand(string value)
        {
            // curl --request POST --header "PRIVATE-TOKEN: <your_access_token>" "https://gitlab.example.com/api/v4/projects/5/deploy_keys/13/enable"
            var parts = value.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            const string UrlPrefix = "https://gitlab.example.com/api/v4";
            var url = parts[^1].Trim('"');
            if (url.StartsWith(UrlPrefix, StringComparison.Ordinal))
            {
                url = url[UrlPrefix.Length..];
            }

            var method = "GET";
            var indexOfMethod = parts.IndexOf("--request");
            if (indexOfMethod >= 0)
            {
                method = parts[indexOfMethod + 1];
            }

            return method + ' ' + url;
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
                    _ => throw new Exception("Type not supported"),
                };
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
