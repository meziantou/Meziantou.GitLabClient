namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ModelRef OrderByDirection { get; } = CreateStringEnumeration()
                .AddMember("ascending", serializationName: "asc")
                .AddMember("descending", serializationName: "desc");
    }
}
