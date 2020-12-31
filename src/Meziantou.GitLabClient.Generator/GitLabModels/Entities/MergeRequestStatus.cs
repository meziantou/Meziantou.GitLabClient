namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ModelRef MergeRequestStatus { get; } = CreateStringEnumeration()
                .AddMembers("checking", "can_be_merged", "cannot_be_merged");
    }
}
