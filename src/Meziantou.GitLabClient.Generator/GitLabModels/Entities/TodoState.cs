namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ModelRef TodoState { get; } = CreateStringEnumeration()
                .AddMembers("pending", "done");
    }
}
