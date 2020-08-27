namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal static partial class Entities
    {
        public static EntityBuilder RenderMarkdownResult { get; private set; }

        public static void CreateMarkdown()
        {
            RenderMarkdownResult.Configure(entity => entity
                .AddProperty("html", ModelRef.String, PropertyOptions.IsKey)
            );
        }
    }

    internal sealed class ClientMarkdown : IGitLabClientDescriptor
    {
        public void Create(Project project)
        {
            var group = project.AddMethodGroup("Markdown");

            group.AddMethod("RenderMarkdown", MethodType.Post, "/markdown", "https://docs.gitlab.com/ee/api/markdown.html#render-an-arbitrary-markdown-document")
                .WithReturnType(Entities.RenderMarkdownResult)
                .AddRequiredParameter("text", ModelRef.String)
                .AddOptionalParameter("gfm", ModelRef.Boolean)
                .AddOptionalParameter("project", ModelRef.PathWithNamespace)
                ;
        }
    }
}
