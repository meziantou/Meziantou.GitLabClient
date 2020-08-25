namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class ClientIssue : IGitLabClientDescriptor
    {
        public void Create(Project project)
        {
            var group = project.AddMethodGroup("Issues");

            group.AddMethod("Create", MethodType.Post, "/projects/:project_id/issues", "https://docs.gitlab.com/ee/api/issues.html#new-issue")
                .WithReturnType(Entities.Issue)
                .AddRequiredParameter("project_id", EntityRefs.ProjectIdOrPathRef)
                .AddRequiredParameter("title", ModelRef.String)
                .AddOptionalParameter("description", ModelRef.String)
                .AddOptionalParameter("confidential", ModelRef.Boolean)
                ;
        }
    }
}
