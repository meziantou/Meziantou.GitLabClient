namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class RepositoryFilesClient : GitLabClientBuilder
    {
        protected override void Create(MethodGroup methodGroup)
        {
            methodGroup.AddMethod("CreateFile", MethodType.Post, "/projects/:id/repository/files/:file_path", "https://docs.gitlab.com/ee/api/repository_files.html#create-new-file-in-repository")
                .WithReturnType(Models.FileCreated)
                .AddRequiredParameter("id", Models.ProjectIdOrPathRef)
                .AddRequiredParameter("file_path", ModelRef.String)
                .AddRequiredParameter("branch", ModelRef.String)
                .AddRequiredParameter("content", ModelRef.String)
                .AddRequiredParameter("commit_message", ModelRef.String)
                .AddOptionalParameter("start_branch", ModelRef.String)
                .AddOptionalParameter("encoding", ModelRef.String)
                .AddOptionalParameter("author_email", ModelRef.String)
                .AddOptionalParameter("author_name", ModelRef.String)
                ;
            methodGroup.AddMethod("UpdateFile", MethodType.Put, "/projects/:id/repository/files/:file_path", "https://docs.gitlab.com/ee/api/repository_files.html#update-existing-file-in-repository")
                .WithReturnType(Models.FileUpdated)
                .AddRequiredParameter("id", Models.ProjectIdOrPathRef)
                .AddRequiredParameter("file_path", ModelRef.String)
                .AddRequiredParameter("branch", ModelRef.String)
                .AddRequiredParameter("content", ModelRef.String)
                .AddRequiredParameter("commit_message", ModelRef.String)
                .AddOptionalParameter("start_branch", ModelRef.String)
                .AddOptionalParameter("encoding", ModelRef.String)
                .AddOptionalParameter("author_email", ModelRef.String)
                .AddOptionalParameter("author_name", ModelRef.String)
                .AddOptionalParameter("last_commit_id", ModelRef.NullableGitObjectId)
                ;
        }
    }
}
