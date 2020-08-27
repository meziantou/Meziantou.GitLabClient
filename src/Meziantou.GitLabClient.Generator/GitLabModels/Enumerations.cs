namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal static partial class Enumerations
    {
        public static ModelRef AccessLevel { get; private set; }
        public static ModelRef OrderByDirection { get; private set; }
        public static ModelRef Visibility { get; private set; }

        public static void Create(Project project)
        {
            OrderByDirection = project.AddEnumeration("OrderByDirection")
                .AddMember("ascending", serializationName: "asc")
                .AddMember("descending", serializationName: "desc");

            AccessLevel = project.AddEnumeration("AccessLevel")
                .AddMember("guest", 10)
                .AddMember("reporter", 20)
                .AddMember("developer", 30)
                .AddMember("maintainer", 40)
                .AddMember("owner", 50);

            Visibility = project.AddStringEnumeration("Visibility")
                .AddMembers("private", "internal", "public");
        }
    }
}
