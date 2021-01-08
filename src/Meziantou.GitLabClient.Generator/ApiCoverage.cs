using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Meziantou.GitLabClient.Generator.Internals;

namespace Meziantou.GitLabClient.Generator
{
    internal static class ApiCoverage
    {
        public static string GetMarkdown(Project project, IReadOnlyCollection<GitLabDocumentationResource> resources)
        {
            var sb = new StringBuilder();
            foreach (var resource in resources.OrderBy(r => r.Name))
            {
                sb.Append("# [").Append(resource.DisplayName).Append("](").Append(resource.DocumentationUrl).Append(')').AppendLine();
                foreach (var method in resource.Methods.OrderBy(m => m.Name))
                {
                    var isImplemented = GetMethod(method, project) != null ? 'x' : ' ';
                    sb.Append("- [").Append(isImplemented).Append("] [").Append(method.Name).Append("](").Append(method.DocumentationUrl).Append(") `").Append(method.HttpMethod).Append(' ').Append(method.UrlTemplate).Append('`').AppendLine();
                    foreach (var parameter in method.Parameters)
                    {
                        var isParameterImplemented = GetMethodParameter(method, parameter, project) != null ? 'x' : ' ';
                        sb.Append("    - [").Append(isParameterImplemented).Append("] `").Append(parameter.Name).Append("`: ").Append(parameter.Description).AppendLine();
                    }
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "MA0028:Optimize StringBuilder usage", Justification = "No need for performance")]
        public static string GetNotImplementedTemplate(Project project, IReadOnlyCollection<GitLabDocumentationResource> resources)
        {
            var sb = new StringBuilder();
            foreach (var resource in resources.OrderBy(r => r.Name))
            {
                var unimplementedMethods = resource.Methods.Where(m => GetMethod(m, project) == null).OrderBy(m => m.Name).ToList();
                if (unimplementedMethods.Count == 0)
                    continue;

                sb.AppendLine("namespace Meziantou.GitLabClient.Generator.GitLabModels");
                sb.AppendLine("{");
                sb.AppendLine("    internal sealed class " + resource.Name + "Client : GitLabClientBuilder");
                sb.AppendLine("    {");
                sb.AppendLine("        protected override void Create(MethodGroup methodGroup)");
                sb.AppendLine("        {");

                foreach (var method in unimplementedMethods)
                {
                    sb.AppendLine("            methodGroup.AddMethod(\"" + method.Name + "\", MethodType." + CultureInfo.InvariantCulture.TextInfo.ToTitleCase(method.HttpMethod.ToLowerInvariant()) + ", \"" + method.UrlTemplate + "\", \"" + method.DocumentationUrl + "\")");
                    sb.AppendLine("                .WithReturnType(Models.)");

                    foreach (var parameter in method.Parameters)
                    {
                        var addParameterName = parameter.Required == "yes" ? "AddRequiredParameter" : "AddOptionalParameter";
                        sb.AppendLine("                ." + addParameterName + "(\"" + parameter.Name + "\", Models.)");
                    }

                    sb.AppendLine("            ;");
                    sb.AppendLine();
                }

                sb.AppendLine("        }");
                sb.AppendLine("    }");
                sb.AppendLine("}");
            }

            return sb.ToString();
        }
        private static Method GetMethod(GitLabDocumentationMethod method, Project project)
        {
            foreach (var modelMethodGroup in project.MethodGroups)
            {
                foreach (var modelMethod in modelMethodGroup.Methods)
                {
                    if (method.Equals(modelMethod))
                        return modelMethod;
                }
            }

            return null;
        }

        private static MethodParameter GetMethodParameter(GitLabDocumentationMethod method, GitLabDocumentationMethodParameter parameter, Project project)
        {
            var m = GetMethod(method, project);
            if (m != null)
            {
                foreach (var p in m.Parameters)
                {
                    if (p.Name == parameter.Name)
                        return p;
                }
            }

            return null;
        }
    }
}
