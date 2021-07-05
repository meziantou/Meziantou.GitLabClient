namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class RepositoriesClient : GitLabClientBuilder
    {
        protected override void Create(MethodGroup methodGroup)
        {
            methodGroup.AddMethod("DownloadFileArchive", MethodType.Get, "/projects/:id/repository/archive[.format]", "https://docs.gitlab.com/ee/api/repositories.html#get-file-archive")
                .WithReturnType(ModelRef.File)
                .AddRequiredParameter("id", Models.ProjectIdOrPathRef)
                .AddOptionalParameter("sha", ModelRef.String)
                .AddOptionalParameter("format", Choice("RepositoryFileArchiveFormat", new[] { "tar.gz", "tar.bz2", "tbz", "tbz2", "tb2", "bz2", "tar", "zip" }), options: MethodParameterOptions.DoNotValidate)
                ;
        }
    }
}
