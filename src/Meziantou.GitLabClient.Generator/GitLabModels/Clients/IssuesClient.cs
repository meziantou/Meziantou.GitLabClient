namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class IssuesClient : GitLabClientBuilder
    {
        protected override void Create(MethodGroup methodGroup)
        {
            methodGroup.AddMethod("Create", MethodType.Post, "/projects/:id/issues", "https://docs.gitlab.com/ee/api/issues.html#new-issue")
                .WithReturnType(Models.Issue)
                .AddRequiredParameter("id", Models.ProjectIdOrPathRef)
                .AddRequiredParameter("title", ModelRef.String)
                .AddOptionalParameter("description", ModelRef.String)
                .AddOptionalParameter("confidential", ModelRef.Boolean)
                ;
        }
    }
}
