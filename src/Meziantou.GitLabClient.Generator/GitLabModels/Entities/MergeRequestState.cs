namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ModelRef MergeRequestState { get; } = CreateStringEnumeration()
                .AddMembers("opened", "closed", "locked", "merged");
    }
}
