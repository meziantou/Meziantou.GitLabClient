namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ModelRef Visibility { get; } = CreateStringEnumeration()
            .AddMembers("private", "internal", "public");
    }
}
