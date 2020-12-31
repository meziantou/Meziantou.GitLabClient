namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class VersionClient : GitLabClientBuilder
    {
        protected override void Create(MethodGroup methodGroup)
        {
            methodGroup.AddMethod("Get", MethodType.Get, "/version", "https://docs.gitlab.com/ee/api/version.html")
                .WithReturnType(Models.ServerVersion)
                ;
        }
    }
}
