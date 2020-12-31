namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class ClientMarkdown : IGitLabClientDescriptor
    {
        public void Create(Project project)
        {
            var group = project.AddMethodGroup("Markdown");

            group.AddMethod("RenderMarkdown", MethodType.Post, "/markdown", "https://docs.gitlab.com/ee/api/markdown.html#render-an-arbitrary-markdown-document")
                .WithReturnType(Models.RenderMarkdownResult)
                .AddRequiredParameter("text", ModelRef.String)
                .AddOptionalParameter("gfm", ModelRef.Boolean)
                .AddOptionalParameter("project", ModelRef.PathWithNamespace)
                ;
        }
    }
}
