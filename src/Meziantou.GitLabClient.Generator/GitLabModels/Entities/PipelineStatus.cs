namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ModelRef PipelineStatus { get; } = CreateStringEnumeration()
                .AddMember("created")
                .AddMember("pending")
                .AddMember("running")
                .AddMember("failed")
                .AddMember("success")
                .AddMember("canceled")
                .AddMember("skipped")
            ;
    }
}
