namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class AvatarClient : GitLabClientBuilder
    {
        protected override void Create(MethodGroup methodGroup)
        {
            methodGroup.AddMethod("GetUserAvatar", MethodType.Get, "/avatar", "https://docs.gitlab.com/ee/api/avatar.html#get-a-single-avatar-url")
                .WithReturnType(Models.UserAvatar)
                .AddRequiredParameter("email", ModelRef.String)
                .AddOptionalParameter("size", ModelRef.Number)
            ;
        }
    }
}
