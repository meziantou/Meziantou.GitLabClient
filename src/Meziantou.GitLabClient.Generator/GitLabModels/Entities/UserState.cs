namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ModelRef UserState { get; } = CreateStringEnumeration()
                .AddMembers("active", "blocked");
    }
}
