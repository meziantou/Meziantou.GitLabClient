namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ModelRef ProjectCreationLevel { get; } = CreateEnumeration()
                .AddMember("NoOne", serializationName: "noone")
                .AddMember("developer")
                .AddMember("maintainer")
            ;
    }
}
