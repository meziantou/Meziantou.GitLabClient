namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal static partial class Entities
    {
        public static EntityBuilder ServerVersion { get; private set; }

        public static void CreateVersion()
        {
            ServerVersion.Configure(entity => entity
                .AddProperty("version", ModelRef.String, PropertyOptions.IsKey)
                .AddProperty("revision", ModelRef.String, PropertyOptions.IsKey)
            );
        }
    }

    internal sealed class ClientVersion : IGitLabClientDescriptor
    {
        public void Create(Project project)
        {
            var group = project.AddMethodGroup("Version");

            group.AddMethod("Get", MethodType.Get, "/version", "https://docs.gitlab.com/ee/api/version.html")
                .WithReturnType(Entities.ServerVersion)
                ;
        }
    }
}
