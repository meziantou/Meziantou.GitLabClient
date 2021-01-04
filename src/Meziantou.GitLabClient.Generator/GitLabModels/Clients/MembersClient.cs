namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class MembersClient : GitLabClientBuilder
    {
        protected override void Create(MethodGroup methodGroup)
        {
            methodGroup.AddMethod("AddMemberToProject", MethodType.Post, "/projects/:id/members", "https://docs.gitlab.com/ee/api/members.html#add-a-member-to-a-group-or-project")
                .WithReturnType(Models.Member)
                .AddRequiredParameter("id", Models.ProjectIdOrPathRef)
                .AddRequiredParameter("user_id", Models.UserIdRef)
                .AddRequiredParameter("access_level", Models.AccessLevel)
                .AddOptionalParameter("expires_at", ModelRef.Date)
                ;
        }
    }
}
