namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        // https://docs.gitlab.com/ee/api/members.html#valid-access-levels
        public static ModelRef AccessLevel { get; } = CreateEnumeration()
                .AddMember("no_access", 0)
                .AddMember("minimal_access", 5)
                .AddMember("guest", 10)
                .AddMember("reporter", 20)
                .AddMember("developer", 30)
                .AddMember("maintainer", 40)
                .AddMember("owner", 50);
    }
}
