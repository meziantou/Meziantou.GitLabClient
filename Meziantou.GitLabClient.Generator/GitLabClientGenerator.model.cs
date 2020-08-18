using System;

namespace Meziantou.GitLabClient.Generator
{
    internal sealed partial class GitLabClientGenerator
    {
        private static class Enumerations
        {
            public static ModelRef AccessLevel { get; private set; }
            public static ModelRef ImportStatus { get; private set; }
            public static ModelRef MergeMethod { get; private set; }
            public static ModelRef MergeRequestScopeFilter { get; private set; }
            public static ModelRef MergeRequestStateFilter { get; private set; }
            public static ModelRef MergeRequestState { get; private set; }
            public static ModelRef MergeRequestStatus { get; private set; }
            public static ModelRef MergeRequestView { get; private set; }
            public static ModelRef ProjectVisibility { get; private set; }
            public static ModelRef UserState { get; private set; }
            public static ModelRef TodoAction { get; private set; }
            public static ModelRef TodoState { get; private set; }
            public static ModelRef TodoType { get; private set; }
            public static ModelRef WikiPageFormat { get; private set; }

            public static void Create(Project project)
            {
                AccessLevel = project.AddEnumeration("AccessLevel")
                    .AddMember("guest", 10)
                    .AddMember("reporter", 20)
                    .AddMember("developer", 30)
                    .AddMember("maintainer", 40)
                    .AddMember("owner", 50);

                ImportStatus = project.AddStringEnumeration("ImportStatus")
                    .AddMembers("none", "scheduled", "failed", "started", "finished");

                MergeMethod = project.AddStringEnumeration("MergeMethod")
                    .AddMembers("merge", "rebase_merge")
                    .AddMember("fast_forward", serializationName: "ff");

                MergeRequestScopeFilter = project.AddStringEnumeration("MergeRequestScopeFilter")
                    .AddMembers("assigned_to_me", "all");

                MergeRequestState = project.AddStringEnumeration("MergeRequestState")
                    .AddMembers("opened", "closed", "locked", "merged");

                MergeRequestStatus = project.AddStringEnumeration("MergeRequestStatus")
                    .AddMembers("checking", "can_be_merged", "cannot_be_merged");

                ProjectVisibility = project.AddStringEnumeration("ProjectVisibility")
                    .AddMembers("private", "internal", "public");

                UserState = project.AddStringEnumeration("UserState")
                    .AddMembers("active", "blocked");

                TodoAction = project.AddStringEnumeration("TodoAction")
                    .AddMembers("assigned", "mentioned", "build_failed", "marked", "approval_required", "unmergeable", "directly_addressed");

                TodoState = project.AddStringEnumeration("TodoState")
                    .AddMembers("pending", "done");

                TodoType = project.AddStringEnumeration("TodoTargetType")
                    .AddMembers("Issue", "MergeRequest", "Commit");

                MergeRequestView = project.AddStringEnumeration("MergeRequestView")
                    .AddMembers("default", "simple");

                WikiPageFormat = project.AddStringEnumeration("WikiPageFormat")
                    .AddMembers("markdown", "rdoc", "asciidoc");
            }
        }

        private static class Entities
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
                    .AddProperty("avatar_url", ModelRef.String)
                    .AddProperty("avatar_path", ModelRef.String)
                    .AddProperty("state", Enumerations.UserState)
                    .AddProperty("web_url", ModelRef.String)
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
                    .AddProperty("email", ModelRef.String)
                    .AddProperty("external", ModelRef.NullableBoolean)
                    .AddProperty("identities", IdentityModel.MakeCollection())
                    .AddProperty("is_admin", ModelRef.NullableBoolean)
                    .AddProperty("last_activity_on", ModelRef.NullableDate)
                    .AddProperty("last_sign_in_at", ModelRef.NullableDateTime)
                    .AddProperty("linkedin", ModelRef.String)
                    .AddProperty("location", ModelRef.String)
                    .AddProperty("organization", ModelRef.String)
                    .AddProperty("private_profile", ModelRef.Object)
                    .AddProperty("projects_limit", ModelRef.NullableNumber)
                    .AddProperty("shared_runners_minutes_limit", ModelRef.NullableNumber)
                    .AddProperty("skype", ModelRef.String)
                    .AddProperty("theme_id", ModelRef.NullableNumberId)
                    .AddProperty("twitter", ModelRef.String)
                    .AddProperty("two_factor_enabled", ModelRef.NullableBoolean)
                    .AddProperty("website_url", ModelRef.String)
                    );

                UserStatus = CreateEntity("UserStatus", entity => entity
                    .AddProperty("emoji", ModelRef.String)
                    .AddProperty("message", ModelRef.String)
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
                    .AddProperty("description", ModelRef.String)
                    .AddProperty("name", ModelRef.String)
                    .AddProperty("name_with_namespace", ModelRef.String)
                    .AddProperty("path", ModelRef.String)
                    .AddProperty("path_with_namespace", ModelRef.PathWithNamespace, PropertyOptions.IsDisplayName)
                );

                BasicProjectDetails = CreateEntity("BasicProjectDetails", entity => entity
                    .WithBaseType(ProjectIdentity)
                    .AddProperty("avatar_url", ModelRef.String)
                    .AddProperty("default_branch", ModelRef.String)
                    .AddProperty("forks_count", ModelRef.Number)
                    .AddProperty("http_url_to_repo", ModelRef.String)
                    .AddProperty("last_activity_at", ModelRef.DateTime)
                    .AddProperty("namespace", NamespaceBasic)
                    .AddProperty("readme_url", ModelRef.String)
                    .AddProperty("ssh_url_to_repo", ModelRef.String)
                    .AddProperty("star_count", ModelRef.Number)
                    .AddProperty("tag_list", ModelRef.StringCollection)
                    .AddProperty("web_url", ModelRef.String)
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
                    .AddProperty("ci_config_path", ModelRef.String)
                    .AddProperty("container_registry_enabled", ModelRef.Boolean)
                    .AddProperty("creator_id", ModelRef.NumberId)
                    .AddProperty("forked_from_project", BasicProjectDetails)
                    .AddProperty("import_status", Enumerations.ImportStatus)
                    .AddProperty("issues_enabled", ModelRef.Boolean)
                    .AddProperty("jobs_enabled", ModelRef.Boolean)
                    .AddProperty("lfs_enabled", ModelRef.Boolean)
                    .AddProperty("_links", ProjectLinks)
                    .AddProperty("merge_method", Enumerations.MergeMethod)
                    .AddProperty("merge_requests_enabled", ModelRef.Boolean)
                    .AddProperty("mirror", ModelRef.Boolean)
                    .AddProperty("mirror_user_id", ModelRef.NullableNumberId)
                    .AddProperty("mirror_trigger_builds", ModelRef.NullableBoolean)
                    .AddProperty("mirror_overwrites_diverged_branches", ModelRef.NullableBoolean)
                    .AddProperty("only_allow_merge_if_all_discussions_are_resolved", ModelRef.Boolean)
                    .AddProperty("only_allow_merge_if_pipeline_succeeds", ModelRef.Boolean)
                    .AddProperty("only_mirror_protected_branches", ModelRef.NullableBoolean)
                    .AddProperty("open_issues_count", ModelRef.NullableNumber)
                    .AddProperty("owner", Entities.UserBasic)
                    .AddProperty("permissions", Permissions)
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
                    .AddProperty("target_url", ModelRef.String)
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
                    .AddProperty("web_url", ModelRef.String)
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
                    .AddProperty("web_url", ModelRef.String)
                    .AddProperty("created_at", ModelRef.DateTime)
                    .AddProperty("updated_at", ModelRef.DateTime)
                    .AddProperty("closed_at", ModelRef.NullableDateTime)
                    .AddProperty("closed_by", Entities.UserBasic)
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
                    var entityBuilder = ((EntityBuilder)property.GetGetMethod().Invoke(obj: null, parameters: null));
                    entityBuilder.Build();
                    project.AddModel<Entity>(entityBuilder.Value);
                }
            }
        }

        private static class EntityRefs
        {
            public static ParameterEntity ProjectIdRef { get; private set; }
            public static ParameterEntity ProjectIdOrPathRef { get; private set; }
            public static ParameterEntity SshKeyRef { get; private set; }
            public static ParameterEntity UserRef { get; private set; }
            public static ParameterEntity MergeRequestIdRef { get; private set; }
            public static ParameterEntity TodoIdRef { get; private set; }

            public static void Create(Project project)
            {
                ProjectIdRef = project.AddParameterEntity("ProjectIdRef",
                    ParameterEntityRef.Create("projectId", ModelRef.NumberId),
                    ParameterEntityRef.Create("project", Entities.ProjectIdentity)
                );

                ProjectIdOrPathRef = project.AddParameterEntity("ProjectIdOrPathRef",
                    ParameterEntityRef.Create("projectId", ModelRef.NumberId),
                    ParameterEntityRef.Create("project", Entities.ProjectIdentity),
                    ParameterEntityRef.Create("projectPathWithNamespace", ModelRef.PathWithNamespace),
                    ParameterEntityRef.Create("projectPathWithNamespace", ModelRef.String)
                );

                SshKeyRef = project.AddParameterEntity("SshKeyRef",
                    ParameterEntityRef.Create("sshKeyId", ModelRef.NumberId),
                    ParameterEntityRef.Create("sskKey", Entities.SshKey)
                );

                UserRef = project.AddParameterEntity("UserRef",
                    ParameterEntityRef.Create("userId", ModelRef.NumberId),
                    ParameterEntityRef.Create("userName", ModelRef.String)
                );

                MergeRequestIdRef = project.AddParameterEntity("MergeRequestIidRef",
                    ParameterEntityRef.Create("mergeRequestIid", ModelRef.NumberId),
                    ParameterEntityRef.Create("mergeRequest", Entities.MergeRequest, "iid")
                );

                TodoIdRef = project.AddParameterEntity("TodoRef",
                    ParameterEntityRef.Create("TodoId", ModelRef.NumberId),
                    ParameterEntityRef.Create("todo", Entities.Todo)
                );
            }
        }

        private static void CreateMarkdownMethods(Project project)
        {
            var group = project.AddMethodGroup("Markdown");

            group.AddMethod("RenderMarkdown", MethodType.Post, "markdown")
                .WithReturnType(Entities.RenderMarkdownResult)
                .AddRequiredParameter("text", ModelRef.String)
                .AddOptionalParameter("gfm", ModelRef.Boolean)
                .AddOptionalParameter("project", ModelRef.String) // TODO PathWithNamespace and check if id works
                ;
        }

        private static void CreateUserMethods(Project project)
        {
            var group = project.AddMethodGroup("User");

            group.AddMethod("Get", MethodType.Get, "user")
                .WithReturnType(Entities.User);

            group.AddMethod("Get", MethodType.Get, "users/:id")
                .WithReturnType(Entities.User)
                .AddRequiredParameter("id", ModelRef.NumberId)
                ;

            group.AddMethod("GetAll", MethodType.GetPaged, "users")
                .WithReturnType(Entities.UserBasic)
                .AddOptionalParameter("username", ModelRef.String)
                .AddOptionalParameter("active", ModelRef.Boolean)
                .AddOptionalParameter("blocked", ModelRef.Boolean)
                ;

            group.AddMethod("GetStatus", MethodType.Get, "user/status")
                .WithReturnType(Entities.UserStatus)
                ;

            group.AddMethod("GetStatus", MethodType.Get, "users/:user/status")
                .WithReturnType(Entities.UserStatus)
                .AddRequiredParameter("user", EntityRefs.UserRef)
                ;

            group.AddMethod("SetStatus", MethodType.Put, "users/status")
                .WithReturnType(Entities.UserStatus)
                .AddOptionalParameter("emoji", ModelRef.String)
                .AddOptionalParameter("message", ModelRef.String)
                ;

            group.AddMethod("GetSSHKeys", MethodType.GetCollection, "user/keys")
                .WithReturnType(Entities.SshKey)
                ;

            group.AddMethod("GetSSHKeys", MethodType.GetCollection, "users/:user/keys")
                .WithReturnType(Entities.SshKey)
                .AddRequiredParameter("user", EntityRefs.UserRef)
                ;

            group.AddMethod("GetSSHKey", MethodType.Get, "user/keys/:id")
                .WithReturnType(Entities.SshKey)
                .AddRequiredParameter("id", EntityRefs.SshKeyRef)
                ;

            group.AddMethod("AddSSHKey", MethodType.Post, "user/keys")
                .WithReturnType(Entities.SshKey)
                .AddRequiredParameter("title", ModelRef.String)
                .AddRequiredParameter("key", ModelRef.String)
                ;

            group.AddMethod("AddSSHKey", MethodType.Post, "users/:user/keys")
                .WithReturnType(Entities.SshKey)
                .AddRequiredParameter("user", EntityRefs.UserRef)
                .AddRequiredParameter("title", ModelRef.String)
                .AddRequiredParameter("key", ModelRef.String)
                ;

            group.AddMethod("DeleteSSHKey", MethodType.Delete, "user/keys/:id")
                .AddRequiredParameter("id", EntityRefs.SshKeyRef)
                ;

            group.AddMethod("CreateUser", MethodType.Post, "users")
                .WithReturnType(Entities.User)
                .AddRequiredParameter("email", ModelRef.String)
                .AddRequiredParameter("username", ModelRef.String)
                .AddRequiredParameter("name", ModelRef.String)
                .AddOptionalParameter("password", ModelRef.String)
                .AddOptionalParameter("admin", ModelRef.Boolean)
                .AddOptionalParameter("can_create_group", ModelRef.Boolean)
                .AddOptionalParameter("skip_confirmation", ModelRef.Boolean)
                ;

            group.AddMethod("CreateImpersonationToken", MethodType.Post, "users/:user/impersonation_tokens")
                .WithReturnType(Entities.Token)
                .AddRequiredParameter("user", EntityRefs.UserRef)
                .AddRequiredParameter("name", ModelRef.String)
                .AddOptionalParameter("expires_at", ModelRef.Date)
                .AddOptionalParameter("scopes", ModelRef.StringCollection)
                ;
        }

        private void CreateModel()
        {
            Enumerations.Create(Project);
            Entities.Create(Project);
            EntityRefs.Create(Project);

            CreateMarkdownMethods(Project);
            CreateUserMethods(Project);

            //Project.AddMethodGroup("Issue", // TODO method AddMethod
            //    new[]
            //    {
            //        new Method("CreateIssue", "projects/:project/issues")
            //        {
            //            Documentation = new Documentation
            //            {
            //                Summary = "Creates a new project issue.",
            //                HelpLink = "https://docs.gitlab.com/ee/api/issues.html#new-issue",
            //            },
            //            ReturnType = Entities.Issue,
            //            MethodType = MethodType.Post, // TODO verb in URL template
            //            Parameters =
            //            {
            //                new MethodParameter("project", EntityRefs.ProjectIdOrPathRef),
            //                new MethodParameter("title", ModelRef.String),
            //                new MethodParameter("description", ModelRef.String) { IsOptional = true }, // TODO check what IsOptional means => IsRequired
            //                new MethodParameter("confidential", ModelRef.NullableBoolean) { IsOptional = true },
            //            },
            //        },
            //    });

            //Project.AddMethodGroup("MergeRequest",
            //    new[]
            //    {
            //        new Method("GetMergeRequests", "merge_requests")
            //        {
            //            Documentation = new Documentation
            //            {
            //                Summary = "Get all merge requests the authenticated user has access to. By default it returns only merge requests created by the current user. To get all merge requests, use parameter scope=all.",
            //                HelpLink = "https://docs.gitlab.com/ee/api/merge_requests.html#list-merge-requests",
            //            },
            //            ReturnType = Entities.MergeRequest,
            //            MethodType = MethodType.GetPaged,
            //            Parameters =
            //            {
            //                new MethodParameter("state", Enumerations.MergeRequestState.MakeNullable()) { IsOptional = true },
            //                new MethodParameter("scope", Enumerations.MergeRequestScopeFilter.MakeNullable()) { IsOptional = true },
            //                new MethodParameter("assignee_id", EntityRefs.UserRef.MakeNullable()) { IsOptional = true },
            //                new MethodParameter("author_id", EntityRefs.UserRef.MakeNullable()) { IsOptional = true },
            //                new MethodParameter("milestone", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("view", Enumerations.MergeRequestView.MakeNullable()) { IsOptional = true },
            //                new MethodParameter("labels", ModelRef.StringCollection) { IsOptional = true },
            //                new MethodParameter("created_after", ModelRef.NullableDateTime) { IsOptional = true },
            //                new MethodParameter("created_before", ModelRef.NullableDateTime) { IsOptional = true },
            //                new MethodParameter("updated_after", ModelRef.NullableDateTime) { IsOptional = true },
            //                new MethodParameter("updated_before", ModelRef.NullableDateTime) { IsOptional = true },
            //                new MethodParameter("my_reaction_emoji", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("source_branch", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("target_branch", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("search", ModelRef.String) { IsOptional = true },
            //            },
            //        },
            //        new Method("GetMergeRequests", "groups/:group/merge_requests")
            //        {
            //            Documentation = new Documentation
            //            {
            //                Summary = "Get all merge requests for this group and its subgroups.",
            //                HelpLink = "https://docs.gitlab.com/ee/api/merge_requests.html#list-group-merge-requests",
            //            },
            //            ReturnType = Entities.MergeRequest,
            //            MethodType = MethodType.GetPaged,
            //            Parameters =
            //            {
            //                new MethodParameter("group", ModelRef.NumberId),
            //                new MethodParameter("state", Enumerations.MergeRequestState.MakeNullable()) { IsOptional = true },
            //                new MethodParameter("scope", Enumerations.MergeRequestScopeFilter.MakeNullable()) { IsOptional = true },
            //                new MethodParameter("assignee_id", EntityRefs.UserRef.MakeNullable()) { IsOptional = true },
            //                new MethodParameter("author_id", EntityRefs.UserRef.MakeNullable()) { IsOptional = true },
            //                new MethodParameter("milestone", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("view", Enumerations.MergeRequestView.MakeNullable()) { IsOptional = true },
            //                new MethodParameter("labels", ModelRef.StringCollection) { IsOptional = true },
            //                new MethodParameter("created_after", ModelRef.NullableDateTime) { IsOptional = true },
            //                new MethodParameter("created_before", ModelRef.NullableDateTime) { IsOptional = true },
            //                new MethodParameter("updated_after", ModelRef.NullableDateTime) { IsOptional = true },
            //                new MethodParameter("updated_before", ModelRef.NullableDateTime) { IsOptional = true },
            //                new MethodParameter("my_reaction_emoji", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("source_branch", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("target_branch", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("search", ModelRef.String) { IsOptional = true },
            //            },
            //        },
            //        new Method("GetMergeRequests", "projects/:project/merge_requests")
            //        {
            //            Documentation = new Documentation
            //            {
            //                Summary = "Get all merge requests for this project.",
            //                HelpLink = "https://docs.gitlab.com/ee/api/merge_requests.html#list-project-merge-requests",
            //            },
            //            ReturnType = Entities.MergeRequest,
            //            MethodType = MethodType.GetPaged,
            //            Parameters =
            //            {
            //                new MethodParameter("project", EntityRefs.ProjectIdOrPathRef),
            //                new MethodParameter("iids", ModelRef.GitObjectId.MakeCollection()) { IsOptional = true },
            //                new MethodParameter("state", Enumerations.MergeRequestState.MakeNullable()) { IsOptional = true },
            //                new MethodParameter("scope", Enumerations.MergeRequestScopeFilter.MakeNullable()) { IsOptional = true },
            //                new MethodParameter("assignee_id", EntityRefs.UserRef.MakeNullable()) { IsOptional = true },
            //                new MethodParameter("author_id", EntityRefs.UserRef.MakeNullable()) { IsOptional = true },
            //                new MethodParameter("milestone", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("view", Enumerations.MergeRequestView.MakeNullable()) { IsOptional = true },
            //                new MethodParameter("labels", ModelRef.StringCollection) { IsOptional = true },
            //                new MethodParameter("created_after", ModelRef.NullableDateTime) { IsOptional = true },
            //                new MethodParameter("created_before", ModelRef.NullableDateTime) { IsOptional = true },
            //                new MethodParameter("updated_after", ModelRef.NullableDateTime) { IsOptional = true },
            //                new MethodParameter("updated_before", ModelRef.NullableDateTime) { IsOptional = true },
            //                new MethodParameter("my_reaction_emoji", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("source_branch", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("target_branch", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("search", ModelRef.String) { IsOptional = true },
            //            },
            //        },
            //        new Method("GetMergeRequest", "projects/:project/merge_requests/:merge_request")
            //        {
            //            Documentation = new Documentation
            //            {
            //                Summary = "Shows information about a single merge request.",
            //                HelpLink = "https://docs.gitlab.com/ee/api/merge_requests.html#get-single-mr",
            //            },
            //            ReturnType = Entities.MergeRequest,
            //            MethodType = MethodType.Get,
            //            Parameters =
            //            {
            //                new MethodParameter("project", EntityRefs.ProjectIdOrPathRef),
            //                new MethodParameter("merge_request", EntityRefs.MergeRequestIdRef),
            //            },
            //        },
            //        new Method("CreateMergeRequest", "projects/:project/merge_requests")
            //        {
            //            Documentation = new Documentation
            //            {
            //                Summary = "Creates a new merge request.",
            //                HelpLink = "https://docs.gitlab.com/ee/api/merge_requests.html#create-mr",
            //            },
            //            ReturnType = Entities.MergeRequest,
            //            MethodType = MethodType.Post,
            //            Parameters =
            //            {
            //                new MethodParameter("project", EntityRefs.ProjectIdOrPathRef),
            //                new MethodParameter("source_branch", ModelRef.String),
            //                new MethodParameter("target_branch", ModelRef.String),
            //                new MethodParameter("title", ModelRef.String),
            //                new MethodParameter("description", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("assignee_id", EntityRefs.UserRef.MakeNullable()) { IsOptional = true },
            //                new MethodParameter("target_project_id", EntityRefs.ProjectIdRef.MakeNullable()) { IsOptional = true },
            //                new MethodParameter("remove_source_branch", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("allow_collaboration", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("allow_maintainer_to_push", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("squash", ModelRef.NullableBoolean) { IsOptional = true },
            //            },
            //        },
            //    });

            //Project.AddMethodGroup("Project",
            //    new[]
            //    {
            //        new Method("GetProjects", "projects")
            //        {
            //            Documentation = new Documentation
            //            {
            //                Summary = "Get a list of all visible projects across GitLab for the authenticated user. When accessed without authentication, only public projects with \"simple\" fields are returned.",
            //                HelpLink = "https://docs.gitlab.com/ee/api/projects.html#list-all-projects",
            //            },
            //            ReturnType = Entities.Project,
            //            MethodType = MethodType.GetPaged,
            //            Parameters =
            //            {
            //                new MethodParameter("archived", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("visibility", Enumerations.ProjectVisibility.MakeNullable()) { IsOptional = true },
            //                new MethodParameter("search", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("simple", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("owned", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("membership", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("starred", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("statistics", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("with_issues_enabled", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("with_merge_requests_enabled", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("wiki_checksum_failed", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("repository_checksum_failed", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("min_access_level", Enumerations.AccessLevel.MakeNullable()) { IsOptional = true },
            //            },
            //        },
            //        new Method("GetProjects", "users/:user/projects")
            //        {
            //            Documentation = new Documentation
            //            {
            //                Summary = "Get a list of visible projects for the given user. When accessed without authentication, only public projects are returned.",
            //                HelpLink = "https://docs.gitlab.com/ee/api/projects.html#list-user-projects",
            //            },
            //            ReturnType = Entities.Project,
            //            MethodType = MethodType.GetPaged,
            //            Parameters =
            //            {
            //                new MethodParameter("user", EntityRefs.UserRef),
            //                new MethodParameter("archived", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("visibility", Enumerations.ProjectVisibility.MakeNullable()) { IsOptional = true },
            //                new MethodParameter("search", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("simple", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("owned", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("membership", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("starred", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("statistics", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("with_issues_enabled", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("with_merge_requests_enabled", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("wiki_checksum_failed", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("repository_checksum_failed", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("min_access_level", Enumerations.AccessLevel.MakeNullable()) { IsOptional = true },
            //            },
            //        },
            //        new Method("GetProject", "projects/:id")
            //        {
            //            Documentation = new Documentation
            //            {
            //                Summary = "Get a specific project. This endpoint can be accessed without authentication if the project is publicly accessible.",
            //                HelpLink = "https://docs.gitlab.com/ee/api/projects.html#get-single-project",
            //            },
            //            ReturnType = Entities.Project,
            //            MethodType = MethodType.Get,
            //            Parameters =
            //            {
            //                new MethodParameter("id", EntityRefs.ProjectIdOrPathRef),
            //            },
            //        },
            //        new Method("CreateProject", "projects")
            //        {
            //            Documentation = new Documentation
            //            {
            //                Summary = "Creates a new project owned by the authenticated user.",
            //                HelpLink = "https://docs.gitlab.com/ee/api/projects.html#create-project",
            //            },
            //            ReturnType = Entities.Project,
            //            MethodType = MethodType.Post,
            //            Parameters =
            //            {
            //                new MethodParameter("name", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("path", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("namespace_id", ModelRef.NullableNumberId) { IsOptional = true },
            //                new MethodParameter("default_branch", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("description", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("issue_enabled", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("issues_enabled", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("merge_requests_enabled", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("jobs_enabled", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("wiki_enabled", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("snippets_enabled", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("resolve_outdated_diff_discussions", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("container_registry_enabled", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("shared_runners_enabled", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("public_jobs", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("only_allow_merge_if_pipeline_succeeds", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("only_allow_merge_if_all_discussions_are_resolved", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("request_access_enabled", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("lfs_enabled", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("printing_merge_request_link_enabled", ModelRef.NullableBoolean) { IsOptional = true },
            //                new MethodParameter("merge_method", Enumerations.MergeMethod.MakeNullable()) { IsOptional = true },
            //                new MethodParameter("visibility", Enumerations.ProjectVisibility.MakeNullable()) { IsOptional = true },
            //                new MethodParameter("tag_list", ModelRef.StringCollection) { IsOptional = true },
            //                new MethodParameter("ci_config_path", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("approvals_before_merge", ModelRef.NullableNumber) { IsOptional = true },
            //            },
            //        },
            //    });

            //Project.AddMethodGroup("Repository",
            //    new[]
            //    {
            //        new Method("CreateFile", "projects/:project/repository/files/:file_path")
            //        {
            //            Documentation = new Documentation
            //            {
            //                HelpLink = "https://docs.gitlab.com/ee/api/repository_files.html#create-new-file-in-repository",
            //            },
            //            ReturnType = Entities.FileCreated,
            //            MethodType = MethodType.Post,
            //            Parameters =
            //            {
            //                new MethodParameter("project", EntityRefs.ProjectIdOrPathRef),
            //                new MethodParameter("file_path", ModelRef.String),
            //                new MethodParameter("branch", ModelRef.String),
            //                new MethodParameter("start_branch", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("encoding", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("author_email", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("author_name", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("content", ModelRef.String),
            //                new MethodParameter("commit_message", ModelRef.String),
            //            },
            //        },
            //        new Method("UpdateFile", "projects/:project/repository/files/:file_path")
            //        {
            //            Documentation = new Documentation
            //            {
            //                HelpLink = "https://docs.gitlab.com/ee/api/repository_files.html#update-existing-file-in-repository",
            //            },
            //            ReturnType = Entities.FileUpdated,
            //            MethodType = MethodType.Put,
            //            Parameters =
            //            {
            //                new MethodParameter("project", EntityRefs.ProjectIdOrPathRef),
            //                new MethodParameter("file_path", ModelRef.String),
            //                new MethodParameter("branch", ModelRef.String),
            //                new MethodParameter("start_branch", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("encoding", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("author_email", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("author_name", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("last_commit_id", ModelRef.NullableGitObjectId) { IsOptional = true },
            //                new MethodParameter("content", ModelRef.String),
            //                new MethodParameter("commit_message", ModelRef.String),
            //            },
            //        },
            //    });

            //Project.AddMethodGroup("Todo",
            //    new[]
            //    {
            //        new Method("GetTodos", "todos")
            //        {
            //            Documentation = new Documentation
            //            {
            //                Summary = "Returns a list of todos. When no filter is applied, it returns all pending todos for the current user. Different filters allow the user to precise the request.",
            //                HelpLink = "https://docs.gitlab.com/ee/api/todos.html#get-a-list-of-todos",
            //            },
            //            ReturnType = Entities.Todo,
            //            MethodType = MethodType.GetPaged,
            //            Parameters =
            //            {
            //                new MethodParameter("action", Enumerations.TodoAction.MakeNullable()) { IsOptional = true },
            //            },
            //        },
            //        new Method("MarkTodoAsDone", "todos/:todo/mark_as_done")
            //        {
            //            Documentation = new Documentation
            //            {
            //                Summary = "Marks a single pending todo given by its ID for the current user as done.",
            //                HelpLink = "https://docs.gitlab.com/ee/api/todos.html#mark-a-todo-as-done",
            //            },
            //            ReturnType = Entities.Todo,
            //            MethodType = MethodType.Post,
            //            Parameters =
            //            {
            //                new MethodParameter("todo", EntityRefs.TodoIdRef),
            //            },
            //        },
            //        new Method("MarkAllTodosAsDone", "todos/mark_as_done")
            //        {
            //            Documentation = new Documentation
            //            {
            //                Summary = "Marks all pending todos for the current user as done.",
            //                HelpLink = "https://docs.gitlab.com/ee/api/todos.html#mark-a-todo-as-done",
            //            },
            //            MethodType = MethodType.Post,
            //        },
            //    });


            //Project.AddMethodGroup("Version",
            //    new[]
            //    {
            //        new Method("GetVersion", "version")
            //        {
            //            Documentation = new Documentation
            //            {
            //                HelpLink = "https://docs.gitlab.com/ee/api/version.html",
            //            },
            //            ReturnType = Entities.Version,
            //            MethodType = MethodType.Get,
            //        },
            //    });

            //Project.AddMethodGroup("Wiki",
            //    new[]
            //    {
            //        new Method("GetWikiPages", "projects/:project/wikis")
            //        {
            //            Documentation = new Documentation
            //            {
            //                HelpLink = "https://docs.gitlab.com/ee/api/wikis.html#list-wiki-pages",
            //            },
            //            ReturnType = Entities.WikiPage.MakeCollection(),
            //            MethodType = MethodType.Get,
            //            Parameters =
            //            {
            //                new MethodParameter("project", EntityRefs.ProjectIdOrPathRef),
            //            },
            //        },
            //        new Method("GetWikiPage", "projects/:project/wikis/:slug")
            //        {
            //            Documentation = new Documentation
            //            {
            //                HelpLink = "https://docs.gitlab.com/ee/api/wikis.html#list-wiki-pages",
            //            },
            //            ReturnType = Entities.WikiPage,
            //            MethodType = MethodType.Get,
            //            Parameters =
            //            {
            //                new MethodParameter("project", EntityRefs.ProjectIdOrPathRef),
            //                new MethodParameter("slug", ModelRef.String),
            //            },
            //        },
            //        new Method("CreateWikiPage", "projects/:project/wikis")
            //        {
            //            Documentation = new Documentation
            //            {
            //                HelpLink = "https://docs.gitlab.com/ee/api/wikis.html#list-wiki-pages",
            //            },
            //            ReturnType = Entities.WikiPage,
            //            MethodType = MethodType.Post,
            //            Parameters =
            //            {
            //                new MethodParameter("project", EntityRefs.ProjectIdOrPathRef),
            //                new MethodParameter("content", ModelRef.String),
            //                new MethodParameter("title", ModelRef.String),
            //                new MethodParameter("format", Enumerations.WikiPageFormat.MakeNullable()) { IsOptional = true },
            //            },
            //        },
            //        new Method("UpdateWikiPage", "projects/:project/wikis/:slug")
            //        {
            //            Documentation = new Documentation
            //            {
            //                HelpLink = "https://docs.gitlab.com/ee/api/wikis.html#list-wiki-pages",
            //            },
            //            ReturnType = Entities.WikiPage,
            //            MethodType = MethodType.Put,
            //            Parameters =
            //            {
            //                new MethodParameter("project", EntityRefs.ProjectIdOrPathRef),
            //                new MethodParameter("slug", ModelRef.String),
            //                new MethodParameter("content", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("title", ModelRef.String) { IsOptional = true },
            //                new MethodParameter("format", Enumerations.WikiPageFormat.MakeNullable()) { IsOptional = true },
            //            },
            //        },
            //        new Method("DeleteWikiPage", "projects/:project/wikis/:slug")
            //        {
            //            Documentation = new Documentation
            //            {
            //                HelpLink = "https://docs.gitlab.com/ee/api/wikis.html#list-wiki-pages",
            //            },
            //            ReturnType = null,
            //            MethodType = MethodType.Delete,
            //            Parameters =
            //            {
            //                new MethodParameter("project", EntityRefs.ProjectIdOrPathRef),
            //                new MethodParameter("slug", ModelRef.String),
            //            },
            //        },
            //    });
        }
    }
}
