namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class ProjectsClient : GitLabClientBuilder
    {
        protected override void Create(MethodGroup methodGroup)
        {
            methodGroup.AddMethod("GetAll", MethodType.GetPaged, "/projects", "https://docs.gitlab.com/ee/api/projects.html#list-all-projects")
                .WithReturnType(Models.Project)
                .AddOptionalParameter("archived", ModelRef.Boolean)
                .AddOptionalParameter("visibility", Models.Visibility)
                .AddOptionalParameter("search", ModelRef.String)
                .AddOptionalParameter("simple", ModelRef.Boolean)
                .AddOptionalParameter("owned", ModelRef.Boolean)
                .AddOptionalParameter("membership", ModelRef.Boolean)
                .AddOptionalParameter("starred", ModelRef.Boolean)
                .AddOptionalParameter("statistics", ModelRef.Boolean)
                .AddOptionalParameter("with_issues_enabled", ModelRef.Boolean)
                .AddOptionalParameter("with_merge_requests_enabled", ModelRef.Boolean)
                .AddOptionalParameter("wiki_checksum_failed", ModelRef.Boolean)
                .AddOptionalParameter("repository_checksum_failed", ModelRef.Boolean)
                .AddOptionalParameter("min_access_level", Models.AccessLevel)
                ;

            methodGroup.AddMethod("GetByUser", MethodType.GetPaged, "/users/:user_id/projects", "https://docs.gitlab.com/ee/api/projects.html#list-user-projects")
                .WithReturnType(Models.Project)
                .AddRequiredParameter("user_id", Models.UserIdOrUserNameRef)
                .AddOptionalParameter("archived", ModelRef.Boolean)
                .AddOptionalParameter("visibility", Models.Visibility)
                .AddOptionalParameter("search", ModelRef.String)
                .AddOptionalParameter("simple", ModelRef.Boolean)
                .AddOptionalParameter("owned", ModelRef.Boolean)
                .AddOptionalParameter("membership", ModelRef.Boolean)
                .AddOptionalParameter("starred", ModelRef.Boolean)
                .AddOptionalParameter("statistics", ModelRef.Boolean)
                .AddOptionalParameter("with_issues_enabled", ModelRef.Boolean)
                .AddOptionalParameter("with_merge_requests_enabled", ModelRef.Boolean)
                .AddOptionalParameter("min_access_level", Models.AccessLevel)
                .AddOptionalParameter("order_by", ModelRef.String)
                .AddOptionalParameter("sort", Models.OrderByDirection)
                ;

            methodGroup.AddMethod("GetById", MethodType.Get, "/projects/:id", "https://docs.gitlab.com/ee/api/projects.html#get-single-project")
                .WithReturnType(Models.Project)
                .AddRequiredParameter("id", Models.ProjectIdOrPathRef)
                ;

            methodGroup.AddMethod("Create", MethodType.Post, "/projects", "https://docs.gitlab.com/ee/api/projects.html#create-project")
                .WithReturnType(Models.Project)
                .AddOptionalParameter("name", ModelRef.String)
                .AddOptionalParameter("path", ModelRef.String)
                .AddOptionalParameter("namespace_id", ModelRef.NumberId)
                .AddOptionalParameter("default_branch", ModelRef.String)
                .AddOptionalParameter("description", ModelRef.String)
                .AddOptionalParameter("issues_enabled", ModelRef.Boolean)
                .AddOptionalParameter("merge_requests_enabled", ModelRef.Boolean)
                .AddOptionalParameter("jobs_enabled", ModelRef.Boolean)
                .AddOptionalParameter("wiki_enabled", ModelRef.Boolean)
                .AddOptionalParameter("snippets_enabled", ModelRef.Boolean)
                .AddOptionalParameter("resolve_outdated_diff_discussions", ModelRef.Boolean)
                .AddOptionalParameter("container_registry_enabled", ModelRef.Boolean)
                .AddOptionalParameter("shared_runners_enabled", ModelRef.Boolean)
                .AddOptionalParameter("public_builds", ModelRef.Boolean)
                .AddOptionalParameter("only_allow_merge_if_pipeline_succeeds", ModelRef.Boolean)
                .AddOptionalParameter("only_allow_merge_if_all_discussions_are_resolved", ModelRef.Boolean)
                .AddOptionalParameter("request_access_enabled", ModelRef.Boolean)
                .AddOptionalParameter("lfs_enabled", ModelRef.Boolean)
                .AddOptionalParameter("printing_merge_request_link_enabled", ModelRef.Boolean)
                .AddOptionalParameter("merge_method", Models.MergeMethod)
                .AddOptionalParameter("visibility", Models.Visibility)
                .AddOptionalParameter("tag_list", ModelRef.StringCollection)
                .AddOptionalParameter("ci_config_path", ModelRef.String)
                .AddOptionalParameter("approvals_before_merge", ModelRef.Number)
                ;

            methodGroup.AddMethod("UploadFile", MethodType.Post, "/projects/:id/uploads", "https://docs.gitlab.com/ee/api/projects.html#upload-a-file")
                .WithReturnType(Models.RepositoryFileUploaded)
                .AddRequiredParameter("id", Models.ProjectIdOrPathRef)
                .AddRequiredParameter("file", ModelRef.FileUpload)
                ;
        }
    }
}
