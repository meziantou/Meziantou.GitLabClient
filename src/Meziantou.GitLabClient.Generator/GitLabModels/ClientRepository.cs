namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class ClientRepository : IGitLabClientDescriptor
    {
        public void Create(Project project)
        {
            var group = project.AddMethodGroup("Repositories");

            group.AddMethod("CreateFile", MethodType.Post, "/projects/:project_id/repository/files/:file_path", "https://docs.gitlab.com/ee/api/repository_files.html#create-new-file-in-repository")
                .WithReturnType(Entities.FileCreated)
                .AddRequiredParameter("project_id", EntityRefs.ProjectIdOrPathRef)
                .AddRequiredParameter("file_path", ModelRef.String)
                .AddRequiredParameter("branch", ModelRef.String)
                .AddRequiredParameter("content", ModelRef.String)
                .AddRequiredParameter("commit_message", ModelRef.String)
                .AddOptionalParameter("start_branch", ModelRef.String)
                .AddOptionalParameter("encoding", ModelRef.String)
                .AddOptionalParameter("author_email", ModelRef.String)
                .AddOptionalParameter("author_name", ModelRef.String)
                ;
            group.AddMethod("UpdateFile", MethodType.Put, "/projects/:project_id/repository/files/:file_path", "https://docs.gitlab.com/ee/api/repository_files.html#update-existing-file-in-repository")
                .WithReturnType(Entities.FileUpdated)
                .AddRequiredParameter("project_id", EntityRefs.ProjectIdOrPathRef)
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
