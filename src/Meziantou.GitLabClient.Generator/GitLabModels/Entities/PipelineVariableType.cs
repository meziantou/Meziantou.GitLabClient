namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ModelRef PipelineVariableType { get; } = CreateStringEnumeration()
                .AddMember("env_var")
                .AddMember("file")
            ;
    }
}
