namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ModelRef TodoAction { get; } = CreateStringEnumeration()
                .AddMembers("assigned", "mentioned", "build_failed", "marked", "approval_required", "unmergeable", "directly_addressed");
    }
}
