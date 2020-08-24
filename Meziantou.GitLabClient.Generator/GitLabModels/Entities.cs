using System;

namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal static class Entities
    {
        public static EntityBuilder IdentityModel { get; private set; }
        public static EntityBuilder UserBasic { get; private set; }
        public static EntityBuilder User { get; private set; }
        public static EntityBuilder UserStatus { get; private set; }
        public static EntityBuilder UserActivity { get; private set; }
        public static EntityBuilder SshKey { get; private set; }
        public static EntityBuilder SharedGroup { get; private set; }
        public static EntityBuilder MemberAccess { get; private set; }
        public static EntityBuilder ProjectAccess { get; private set; }
        public static EntityBuilder GroupAccess { get; private set; }
        public static EntityBuilder NamespaceBasic { get; private set; }
        public static EntityBuilder ProjectIdentity { get; private set; }
        public static EntityBuilder BasicProjectDetails { get; private set; }
        public static EntityBuilder ProjectLinks { get; private set; }
        public static EntityBuilder Permissions { get; private set; }
        public static EntityBuilder Project { get; private set; }
        public static EntityBuilder Todo { get; private set; }
        public static EntityBuilder MergeRequest { get; private set; }
        public static EntityBuilder Issue { get; private set; }
        public static EntityBuilder Token { get; private set; }
        public static EntityBuilder FileCreated { get; private set; }
        public static EntityBuilder FileUpdated { get; private set; }
        public static EntityBuilder Version { get; private set; }
        public static EntityBuilder RenderMarkdownResult { get; private set; }
        public static EntityBuilder WikiPage { get; private set; }
        public static EntityBuilder UserSafe { get; private set; }

        public static void Create(Project projectBuilder)
        {
            IdentityModel = CreateEntity("Identity", entity => entity
                .AddProperty("provider", ModelRef.String, PropertyOptions.IsKey)
                .AddProperty("extern_uid", ModelRef.String, PropertyOptions.IsKey)
            );

            UserSafe = CreateEntity("UserSafe", entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("name", ModelRef.String)
                .AddProperty("username", ModelRef.String, PropertyOptions.IsDisplayName)
            );

            UserBasic = CreateEntity("UserBasic", entity => entity
                .WithBaseType(UserSafe)
                .AddProperty("avatar_url", ModelRef.Uri)
                .AddProperty("avatar_path", ModelRef.NullableString)
                .AddProperty("state", Enumerations.UserState)
                .AddProperty("web_url", ModelRef.Uri)
            );

            User = CreateEntity("User", entity => entity
                .WithBaseType(UserBasic)
                .AddProperty("bio", ModelRef.String)
                .AddProperty("can_create_group", ModelRef.NullableBoolean)
                .AddProperty("can_create_project", ModelRef.NullableBoolean)
                .AddProperty("color_scheme_id", ModelRef.NullableNumberId)
                .AddProperty("confirmed_at", ModelRef.NullableDateTime)
                .AddProperty("created_at", ModelRef.DateTime)
                .AddProperty("current_sign_in_at", ModelRef.NullableDateTime)
                .AddProperty("email", ModelRef.NullableString)
                .AddProperty("external", ModelRef.NullableBoolean)
                .AddProperty("identities", IdentityModel.MakeCollectionNullable())
                .AddProperty("is_admin", ModelRef.NullableBoolean)
                .AddProperty("last_activity_on", ModelRef.NullableDate, PropertyOptions.IsNotUTCDate)
                .AddProperty("last_sign_in_at", ModelRef.NullableDateTime)
                .AddProperty("linkedin", ModelRef.NullableString)
                .AddProperty("location", ModelRef.NullableString)
                .AddProperty("organization", ModelRef.NullableString)
                .AddProperty("private_profile", ModelRef.NullableBoolean)
                .AddProperty("projects_limit", ModelRef.NullableNumber)
                .AddProperty("shared_runners_minutes_limit", ModelRef.NullableNumber)
                .AddProperty("skype", ModelRef.NullableString)
                .AddProperty("theme_id", ModelRef.NullableNumberId)
                .AddProperty("twitter", ModelRef.NullableString)
                .AddProperty("two_factor_enabled", ModelRef.NullableBoolean)
                .AddProperty("website_url", ModelRef.NullableUri, PropertyOptions.CanBeAbsoluteOrRelativeUri)
                );

            UserStatus = CreateEntity("UserStatus", entity => entity
                .AddProperty("emoji", ModelRef.NullableString)
                .AddProperty("message", ModelRef.NullableString)
                .AddProperty("message_html", ModelRef.String)
            );

            UserActivity = CreateEntity("UserActivity", entity => entity
                .AddProperty("username", ModelRef.String)
                .AddProperty("last_activity_on", ModelRef.Date)
            );

            SshKey = CreateEntity("SshKey", entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("title", ModelRef.String, PropertyOptions.IsDisplayName)
                .AddProperty("key", ModelRef.String)
                .AddProperty("created_at", ModelRef.DateTime)
            );

            SharedGroup = CreateEntity("SharedGroup", entity => entity
                .AddProperty("group_id", ModelRef.NumberId)
                .AddProperty("group_name", ModelRef.String)
                .AddProperty("group_access_level", Enumerations.AccessLevel)
            );

            MemberAccess = CreateEntity("MemberAccess", entity => entity
                .AddProperty("access_level", Enumerations.AccessLevel)
                .AddProperty("notification_level", ModelRef.String)
            );

            ProjectAccess = CreateEntity("ProjectAccess", entity => entity
                .WithBaseType(MemberAccess)
            );

            GroupAccess = CreateEntity("GroupAccess", entity => entity
                .WithBaseType(MemberAccess)
            );

            NamespaceBasic = CreateEntity("NamespaceBasic", entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("name", ModelRef.String)
                .AddProperty("path", ModelRef.String)
                .AddProperty("kind", ModelRef.String)
                .AddProperty("full_path", ModelRef.String, PropertyOptions.IsDisplayName)
                .AddProperty("parent_id", ModelRef.NullableNumberId)
            );

            ProjectIdentity = CreateEntity("ProjectIdentity", entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("created_at", ModelRef.DateTime)
                .AddProperty("description", ModelRef.NullableString)
                .AddProperty("name", ModelRef.String)
                .AddProperty("name_with_namespace", ModelRef.String)
                .AddProperty("path", ModelRef.String)
                .AddProperty("path_with_namespace", ModelRef.PathWithNamespace, PropertyOptions.IsDisplayName)
            );

            BasicProjectDetails = CreateEntity("BasicProjectDetails", entity => entity
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

            ProjectLinks = CreateEntity("ProjectLink", entity => entity
                .AddProperty("events", ModelRef.String)
                .AddProperty("issues", ModelRef.String)
                .AddProperty("labels", ModelRef.String)
                .AddProperty("members", ModelRef.String)
                .AddProperty("merge_requests", ModelRef.String)
                .AddProperty("repo_branches", ModelRef.String)
                .AddProperty("self", ModelRef.String)
            );

            Permissions = CreateEntity("ProjectPermissions", entity => entity
                .AddProperty("group_access", GroupAccess)
                .AddProperty("project_access", ProjectAccess)
            );

            Project = CreateEntity("Project", entity => entity
                .WithBaseType(BasicProjectDetails)
                .AddProperty("approvals_before_merge", ModelRef.NullableNumber)
                .AddProperty("archived", ModelRef.Boolean)
                .AddProperty("ci_config_path", ModelRef.NullableString)
                .AddProperty("container_registry_enabled", ModelRef.Boolean)
                .AddProperty("creator_id", ModelRef.NumberId)
                .AddProperty("forked_from_project", BasicProjectDetails.MakeNullable())
                .AddProperty("import_status", Enumerations.ImportStatus)
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
                .AddProperty("permissions", Permissions.MakeNullable())
                .AddProperty("printing_merge_request_link_enabled", ModelRef.Boolean)
                .AddProperty("public_jobs", ModelRef.Boolean)
                .AddProperty("request_access_enabled", ModelRef.Boolean)
                .AddProperty("resolve_outdated_diff_discussions", ModelRef.NullableBoolean)
                .AddProperty("shared_runners_enabled", ModelRef.Boolean)
                .AddProperty("shared_with_groups", SharedGroup.MakeCollection())
                .AddProperty("snippets_enabled", ModelRef.Boolean)
                .AddProperty("visibility", Enumerations.ProjectVisibility)
                .AddProperty("wiki_enabled", ModelRef.Boolean)
            );

            Todo = CreateEntity("Todo", entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("action_name", Enumerations.TodoAction)
                .AddProperty("author", Entities.UserBasic)
                .AddProperty("project", BasicProjectDetails)
                .AddProperty("target_type", Enumerations.TodoType)
                .AddProperty("target_url", ModelRef.Uri)
                .AddProperty("body", ModelRef.String)
                .AddProperty("state", Enumerations.TodoState)
                .AddProperty("created_at", ModelRef.DateTime)
            );

            MergeRequest = CreateEntity("MergeRequest", entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("iid", ModelRef.NumberId)
                .AddProperty("author", Entities.UserBasic)
                .AddProperty("assignee", Entities.UserBasic)
                .AddProperty("title", ModelRef.String, PropertyOptions.IsDisplayName)
                .AddProperty("description", ModelRef.String)
                .AddProperty("state", Enumerations.MergeRequestState)
                .AddProperty("project_id", ModelRef.NumberId)
                .AddProperty("source_project_id", ModelRef.NumberId)
                .AddProperty("target_project_id", ModelRef.NumberId)
                .AddProperty("web_url", ModelRef.Uri)
                .AddProperty("created_at", ModelRef.DateTime)
                .AddProperty("updated_at", ModelRef.DateTime)
                .AddProperty("user_notes_count", ModelRef.Number)
                .AddProperty("target_branch", ModelRef.String)
                .AddProperty("source_branch", ModelRef.String)
                .AddProperty("upvotes", ModelRef.Number)
                .AddProperty("downvotes", ModelRef.Number)
                .AddProperty("labels", ModelRef.StringCollection)
                .AddProperty("work_in_progress", ModelRef.Boolean)
                .AddProperty("merge_when_pipeline_succeeds", ModelRef.Boolean)
                .AddProperty("merge_status", Enumerations.MergeRequestStatus)
                .AddProperty("sha", ModelRef.GitObjectId)
                .AddProperty("merge_commit_sha", ModelRef.NullableGitObjectId)
                .AddProperty("should_remove_source_branch", ModelRef.NullableBoolean)
                .AddProperty("force_remove_source_branch", ModelRef.NullableBoolean)
                .AddProperty("squash", ModelRef.Boolean)
            );

            Issue = CreateEntity("Issue", entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("iid", ModelRef.NumberId)
                .AddProperty("author", Entities.UserBasic)
                .AddProperty("title", ModelRef.String, PropertyOptions.IsDisplayName)
                .AddProperty("project_id", ModelRef.NumberId)
                .AddProperty("web_url", ModelRef.Uri)
                .AddProperty("created_at", ModelRef.DateTime)
                .AddProperty("updated_at", ModelRef.DateTime)
                .AddProperty("closed_at", ModelRef.NullableDateTime)
                .AddProperty("closed_by", Entities.UserBasic.MakeNullable())
            );

            Token = CreateEntity("ImpersonationToken", entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("revoked", ModelRef.Boolean)
                .AddProperty("scopes", ModelRef.StringCollection)
                .AddProperty("token", ModelRef.String)
                .AddProperty("active", ModelRef.Boolean)
                .AddProperty("impersonation", ModelRef.Boolean)
                .AddProperty("name", ModelRef.String, PropertyOptions.IsDisplayName)
                .AddProperty("created_at", ModelRef.DateTime)
                .AddProperty("expires_at", ModelRef.NullableDate)
            );

            FileCreated = CreateEntity("FileCreated", entity => entity
                .AddProperty("file_path", ModelRef.String)
                .AddProperty("branch", ModelRef.String)
            );

            FileUpdated = CreateEntity("FileUpdated", entity => entity
                .AddProperty("file_path", ModelRef.String)
                .AddProperty("branch", ModelRef.String)
            );

            Version = CreateEntity("ServerVersion", entity => entity
                .AddProperty("version", ModelRef.String, PropertyOptions.IsKey)
                .AddProperty("revision", ModelRef.String, PropertyOptions.IsKey)
            );

            RenderMarkdownResult = CreateEntity("RenderedMarkdown", entity => entity
                .AddProperty("html", ModelRef.String, PropertyOptions.IsKey)
            );

            WikiPage = CreateEntity("WikiPage", entity => entity
                .AddProperty("slug", ModelRef.String, PropertyOptions.IsKey)
                .AddProperty("title", ModelRef.String)
                .AddProperty("content", ModelRef.String)
                .AddProperty("format", Enumerations.WikiPageFormat)
            );

            PostCreate(projectBuilder);
        }

        private static EntityBuilder CreateEntity(string name, Action<Entity> configure) => new EntityBuilder(name, configure);

        private static void PostCreate(Project project)
        {
            // Ensure values are created
            foreach (var property in typeof(Entities).GetProperties())
            {
                var entityBuilder = (EntityBuilder)property.GetGetMethod().Invoke(obj: null, parameters: null);
                entityBuilder.Build();
                project.AddModel<Entity>(entityBuilder.Value);
            }
        }
    }
}
