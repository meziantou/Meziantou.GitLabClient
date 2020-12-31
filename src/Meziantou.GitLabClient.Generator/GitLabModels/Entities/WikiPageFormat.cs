namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ModelRef WikiPageFormat { get; } = CreateStringEnumeration()
                .AddMembers("markdown", "rdoc", "asciidoc");
    }
}
