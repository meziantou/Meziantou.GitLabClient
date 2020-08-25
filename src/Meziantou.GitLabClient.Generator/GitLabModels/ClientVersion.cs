namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class ClientVersion : IGitLabClientDescriptor
    {
        public void Create(Project project)
        {
            var group = project.AddMethodGroup("Version");

            group.AddMethod("Get", MethodType.Get, "/version", "https://docs.gitlab.com/ee/api/version.html")
                .WithReturnType(Entities.Version)
                ;
        }
    }
}
