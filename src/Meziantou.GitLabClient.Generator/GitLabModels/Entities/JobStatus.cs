namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ModelRef JobStatus { get; } = CreateStringEnumeration()
                .AddMember("created")
                .AddMember("pending")
                .AddMember("running")
                .AddMember("failed")
                .AddMember("success")
                .AddMember("canceled")
                .AddMember("skipped")
                .AddMember("manual")
            ;
    }
}
