namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ModelRef MergeMethod { get; } = CreateStringEnumeration()
                .AddMembers("merge", "rebase_merge")
                .AddMember("fast_forward", serializationName: "ff");
    }
}
