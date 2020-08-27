namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal static partial class Entities
    {
        public static EntityBuilder Issue { get; private set; }

        public static void CreateIssue()
        {
            Issue.Configure(entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("iid", ModelRef.NumberId)
                .AddProperty("author", Entities.UserBasic)
                .AddProperty("title", ModelRef.String, PropertyOptions.IsDisplayName)
                .AddProperty("project_id", ModelRef.NumberId)
                .AddProperty("web_url", ModelRef.Uri)
                .AddProperty("created_at", ModelRef.DateTime)
                .AddProperty("updated_at", ModelRef.DateTime)
                .AddProperty("closed_at", ModelRef.NullableDateTime)
                .AddProperty("closed_by", Entities.UserBasic.MakeNullable())
            );
        }
    }

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
