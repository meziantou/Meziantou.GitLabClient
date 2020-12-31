namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ModelRef ProjectImportStatus { get; } = CreateStringEnumeration()
                .AddMembers("none", "scheduled", "failed", "started", "finished");
    }
}
