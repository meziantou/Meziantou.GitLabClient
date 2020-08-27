namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal static partial class Enumerations
    {
        public static ModelRef ProjectImportStatus { get; private set; }
        public static ModelRef MergeMethod { get; private set; }

        public static void CreateProject(Project project)
        {
            ProjectImportStatus = project.AddStringEnumeration("ProjectImportStatus")
                .AddMembers("none", "scheduled", "failed", "started", "finished");

            MergeMethod = project.AddStringEnumeration("MergeMethod")
                .AddMembers("merge", "rebase_merge")
                .AddMember("fast_forward", serializationName: "ff");
        }
    }

    internal static partial class Entities
    {
        public static EntityBuilder SharedGroup { get; private set; }
        public static EntityBuilder MemberAccess { get; private set; }
        public static EntityBuilder ProjectAccess { get; private set; }
        public static EntityBuilder GroupAccess { get; private set; }
        public static EntityBuilder NamespaceBasic { get; private set; }
        public static EntityBuilder ProjectIdentity { get; private set; }
        public static EntityBuilder BasicProjectDetails { get; private set; }
        public static EntityBuilder ProjectLinks { get; private set; }
        public static EntityBuilder ProjectPermissions { get; private set; }
        public static EntityBuilder Project { get; private set; }

        public static void CreateProject()
        {
            SharedGroup.Configure(entity => entity
                .AddProperty("group_id", ModelRef.NumberId)
                .AddProperty("group_name", ModelRef.String)
                .AddProperty("group_access_level", Enumerations.AccessLevel)
            );

            MemberAccess.Configure(entity => entity
                .AddProperty("access_level", Enumerations.AccessLevel)
                .AddProperty("notification_level", ModelRef.String)
            );

            ProjectAccess.Configure(entity => entity
                .WithBaseType(MemberAccess)
            );

            GroupAccess.Configure(entity => entity
                .WithBaseType(MemberAccess)
            );

            NamespaceBasic.Configure(entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("name", ModelRef.String)
                .AddProperty("path", ModelRef.String)
                .AddProperty("kind", ModelRef.String)
                .AddProperty("full_path", ModelRef.String, PropertyOptions.IsDisplayName)
                .AddProperty("parent_id", ModelRef.NullableNumberId)
            );

            ProjectIdentity.Configure(entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("created_at", ModelRef.DateTime)
                .AddProperty("description", ModelRef.NullableString)
                .AddProperty("name", ModelRef.String)
                .AddProperty("name_with_namespace", ModelRef.String)
                .AddProperty("path", ModelRef.String)
                .AddProperty("path_with_namespace", ModelRef.PathWithNamespace, PropertyOptions.IsDisplayName)
            );

            BasicProjectDetails.Configure(entity => entity
                .WithBaseType(ProjectIdentity)
                .AddProperty("avatar_url", ModelRef.NullableUri)
                .AddProperty("default_branch", ModelRef.NullableString)
                .AddProperty("forks_count", ModelRef.Number)
                .AddProperty("http_url_to_repo", ModelRef.Uri)
                .AddProperty("last_activity_at", ModelRef.DateTime)
                .AddProperty("namespace", NamespaceBasic)
                .AddProperty("readme_url", ModelRef.NullableUri)
                .AddProperty("ssh_url_to_repo", ModelRef.NullableUri, PropertyOptions.CanBeAbsoluteOrRelativeUri)
                .AddProperty("star_count", ModelRef.Number)
                .AddProperty("tag_list", ModelRef.StringCollection)
                .AddProperty("web_url", ModelRef.NullableUri)
            );

            ProjectLinks.Configure(entity => entity
                .AddProperty("events", ModelRef.String)
                .AddProperty("issues", ModelRef.String)
                .AddProperty("labels", ModelRef.String)
                .AddProperty("members", ModelRef.String)
                .AddProperty("merge_requests", ModelRef.String)
                .AddProperty("repo_branches", ModelRef.String)
                .AddProperty("self", ModelRef.String)
            );

            ProjectPermissions.Configure(entity => entity
                .AddProperty("group_access", GroupAccess)
                .AddProperty("project_access", ProjectAccess)
            );

            Project.Configure(entity => entity
                .WithBaseType(BasicProjectDetails)
                .AddProperty("approvals_before_merge", ModelRef.NullableNumber)
                .AddProperty("archived", ModelRef.Boolean)
                .AddProperty("ci_config_path", ModelRef.NullableString)
                .AddProperty("container_registry_enabled", ModelRef.Boolean)
                .AddProperty("creator_id", ModelRef.NumberId)
                .AddProperty("forked_from_project", BasicProjectDetails.MakeNullable())
                .AddProperty("import_status", Enumerations.ProjectImportStatus)
                .AddProperty("issues_enabled", ModelRef.Boolean)
                .AddProperty("jobs_enabled", ModelRef.Boolean)
                .AddProperty("lfs_enabled", ModelRef.Boolean)
                .AddProperty("_links", ProjectLinks)
                .AddProperty("merge_method", Enumerations.MergeMethod)
                .AddProperty("merge_requests_enabled", ModelRef.Boolean)
                .AddProperty("mirror", ModelRef.NullableBoolean)
                .AddProperty("mirror_user_id", ModelRef.NullableNumberId)
                .AddProperty("mirror_trigger_builds", ModelRef.NullableBoolean)
                .AddProperty("mirror_overwrites_diverged_branches", ModelRef.NullableBoolean)
                .AddProperty("only_allow_merge_if_all_discussions_are_resolved", ModelRef.Boolean)
                .AddProperty("only_allow_merge_if_pipeline_succeeds", ModelRef.Boolean)
                .AddProperty("only_mirror_protected_branches", ModelRef.NullableBoolean)
                .AddProperty("open_issues_count", ModelRef.NullableNumber)
                .AddProperty("owner", Entities.UserBasic)
                .AddProperty("permissions", ProjectPermissions.MakeNullable())
                .AddProperty("printing_merge_request_link_enabled", ModelRef.Boolean)
                .AddProperty("public_jobs", ModelRef.Boolean)
                .AddProperty("request_access_enabled", ModelRef.Boolean)
                .AddProperty("resolve_outdated_diff_discussions", ModelRef.NullableBoolean)
                .AddProperty("shared_runners_enabled", ModelRef.Boolean)
                .AddProperty("shared_with_groups", SharedGroup.MakeCollection())
                .AddProperty("snippets_enabled", ModelRef.Boolean)
                .AddProperty("visibility", Enumerations.Visibility)
                .AddProperty("wiki_enabled", ModelRef.Boolean)
            );
        }
    }

    internal sealed class ClientProject : IGitLabClientDescriptor
    {
        public void Create(Project project)
        {
            var group = project.AddMethodGroup("Projects");

            group.AddMethod("GetAll", MethodType.GetPaged, "/projects", "https://docs.gitlab.com/ee/api/projects.html#list-all-projects")
                .WithReturnType(Entities.Project)
                .AddOptionalParameter("archived", ModelRef.Boolean)
                .AddOptionalParameter("visibility", Enumerations.Visibility)
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
                .AddOptionalParameter("min_access_level", Enumerations.AccessLevel)
                ;

            group.AddMethod("GetByUser", MethodType.GetPaged, "/users/:user_id/projects", "https://docs.gitlab.com/ee/api/projects.html#list-user-projects")
                .WithReturnType(Entities.Project)
                .AddRequiredParameter("user_id", EntityRefs.UserRef)
                .AddOptionalParameter("archived", ModelRef.Boolean)
                .AddOptionalParameter("visibility", Enumerations.Visibility)
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
                .AddOptionalParameter("min_access_level", Enumerations.AccessLevel, version: 2)
                ;

            group.AddMethod("GetById", MethodType.Get, "/projects/:project_id", "https://docs.gitlab.com/ee/api/projects.html#get-single-project")
                .WithReturnType(Entities.Project)
                .AddRequiredParameter("project_id", EntityRefs.ProjectIdOrPathRef)
                ;

            group.AddMethod("Create", MethodType.Post, "/projects", "https://docs.gitlab.com/ee/api/projects.html#create-project")
                .WithReturnType(Entities.Project)
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
                .AddOptionalParameter("public_jobs", ModelRef.Boolean)
                .AddOptionalParameter("only_allow_merge_if_pipeline_succeeds", ModelRef.Boolean)
                .AddOptionalParameter("only_allow_merge_if_all_discussions_are_resolved", ModelRef.Boolean)
                .AddOptionalParameter("request_access_enabled", ModelRef.Boolean)
                .AddOptionalParameter("lfs_enabled", ModelRef.Boolean)
                .AddOptionalParameter("printing_merge_request_link_enabled", ModelRef.Boolean)
                .AddOptionalParameter("merge_method", Enumerations.MergeMethod)
                .AddOptionalParameter("visibility", Enumerations.Visibility)
                .AddOptionalParameter("tag_list", ModelRef.StringCollection)
                .AddOptionalParameter("ci_config_path", ModelRef.String)
                .AddOptionalParameter("approvals_before_merge", ModelRef.Number)
                ;
        }
    }
}
