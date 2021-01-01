using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Io;
using Humanizer;
using Meziantou.Framework;
using Meziantou.Framework.Collections;

namespace Meziantou.GitLabClient.Generator.Internals
{
    internal sealed class GitLabDocumentationResource
    {
        public string Name { get; set; }
        public string DocumentationUrl { get; set; }
        public IList<GitLabDocumentationMethod> Methods { get; } = new List<GitLabDocumentationMethod>();

        public static async Task<IReadOnlyCollection<GitLabDocumentationResource>> LoadResourcesAsync(bool noCache)
        {
            var result = new SynchronizedList<GitLabDocumentationResource>();

            var configuration = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(configuration);
            var document = await GetDocumentAsync(context, "https://docs.gitlab.com/ee/api/api_resources.html", noCache);

            var resources = document.QuerySelector(".global-nav-link.active").ParentElement.NextElementSibling.QuerySelectorAll("a").Cast<IHtmlAnchorElement>().ToList();
            if (resources.Count == 0)
                throw new InvalidOperationException("Cannot find resources from documentation");

            await resources.ForEachAsync(async anchor =>
            {
                var url = anchor.Href;
                var d = await GetDocumentAsync(context, url, noCache);

                var name = Trim(d.QuerySelector("h1.article-title").TextContent)[0..^4]; // Remove API suffix
                name = name switch
                {
                    ".gitignore" => "Templates",
                    "Dockerfiles" => "Templates",
                    "Licenses" => "Templates",
                    "GitLab CI YMLs" => "Templates",
                    _ => name,
                };

                name = name.Dehumanize();
                var group = result.FirstOrDefault(g => g.Name == name);
                if (group == null)
                {
                    group = new GitLabDocumentationResource
                    {
                        Name = name,
                        DocumentationUrl = url,
                    };
                    result.Add(group);
                }

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
                        documentationUrl == "https://docs.gitlab.com/ee/api/runners.html#pause-a-runner" ||
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
                    var parameters = new List<GitLabDocumentationMethodParameter>();
                    while (element != null)
                    {
                        var code = element.QuerySelector("code");
                        if (code != null && element is IHtmlDivElement && element.ClassList.Any(c => c.StartsWith("language-", StringComparison.Ordinal)))
                        {
                            urlTemplate = Trim(code.TextContent);
                            LoadParameters();
                            break;
                        }

                        // h2 followed by h2
                        if (element is IHtmlHeadingElement)
                        {
                            urlTemplate = null;
                            break;
                        }

                        element = element.NextElementSibling;

                        void LoadParameters()
                        {
                            var parametersTable = FindParameters();
                            if (parametersTable != null)
                            {
                                foreach (var row in parametersTable.Bodies[0].Rows)
                                {
                                    var parameter = new GitLabDocumentationMethodParameter
                                    {
                                        Name = Trim(row.Cells[0].TextContent).RemoveSuffix("[]"),
                                        Type = Trim(row.Cells[1].TextContent),
                                        Required = Trim(row.Cells[2].TextContent),
                                        Description = Trim(row.Cells[3].TextContent),
                                    };

                                    parameters.Add(parameter);
                                }
                            }
                        }

                        IHtmlTableElement FindParameters()
                        {
                            var currentElement = element.NextElementSibling;
                            while (currentElement != null)
                            {
                                if (currentElement is IHtmlHeadingElement)
                                    return null;

                                if (currentElement is IHtmlTableElement table && table.Head.Rows[0].ChildElementCount >= 4) // Some has empty additionnal columns...
                                    return table;

                                currentElement = currentElement.NextElementSibling;
                            }

                            return null;
                        }
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
                            throw new InvalidOperationException($"Template is invalid '{template}'");

                        // TODO fix GitLab documentation
                        if (urlParts[1].StartsWith("/api/v4/", StringComparison.Ordinal))
                        {
                            urlParts[1] = urlParts[1]["/api/v4".Length..];
                        }

                        // TODO extract summary
                        var method = new GitLabDocumentationMethod
                        {
                            Name = Trim(header.TextContent),
                            DocumentationUrl = documentationUrl,
                            HttpMethod = urlParts[0],
                            UrlTemplate = RemoveQueryString(urlParts[1]),
                        };

                        method.Parameters.AddRange(parameters);

                        // Do not add duplicate
                        if (group.Methods.Any(m => m.HttpMethod == method.HttpMethod && m.UrlTemplate == method.UrlTemplate))
                            continue;

                        group.Methods.Add(method);
                    }
                }
            });

            return result;
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

        private static async Task<IDocument> GetDocumentAsync(IBrowsingContext context, string url, bool noCache)
        {
            var path = FullPath.GetTempPath() / "gitlab-gen" / "cache" / Convert.ToBase64String(Encoding.UTF8.GetBytes(url));
            if (!noCache && File.Exists(path))
            {
                var text = await File.ReadAllTextAsync(path);
                using IResponse response = VirtualResponse.Create(response => response.Address(url).Content(text));
                return await context.OpenAsync(response);
            }

            var document = await context.OpenAsync(url);
            IOUtilities.PathCreateDirectory(path);
            await File.WriteAllTextAsync(path, document.ToHtml());
            return document;
        }
    }
}
