namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ModelRef MergeRequestScopeFilter { get; } = CreateStringEnumeration()
            .AddMembers("assigned_to_me", "all");
    }
}
