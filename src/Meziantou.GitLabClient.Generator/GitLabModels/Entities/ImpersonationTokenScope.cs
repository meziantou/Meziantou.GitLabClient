namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        // https://docs.gitlab.com/ee/api/members.html#valid-access-levels
        public static ModelRef ImpersonationTokenScope { get; } = CreateStringEnumeration()
            .AddMembers("api", "read_user");
    }
}
