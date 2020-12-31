namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ModelRef TodoTargetType { get; } = CreateStringEnumeration()
                .AddMembers("Issue", "MergeRequest", "Commit");
    }
}
