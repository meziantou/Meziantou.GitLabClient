namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ModelRef AccessLevel { get; } = CreateEnumeration()
                .AddMember("guest", 10)
                .AddMember("reporter", 20)
                .AddMember("developer", 30)
                .AddMember("maintainer", 40)
                .AddMember("owner", 50);
    }
}
