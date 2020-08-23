namespace Meziantou.GitLabClient.Generator
{
    internal sealed partial class GitLabClientGenerator
    {
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

            group.AddMethod("GetCurrentUser", MethodType.Get, "user")
                .WithReturnType(Entities.User);

            group.AddMethod("GetById", MethodType.Get, "users/:id")
                .WithReturnType(Entities.User)
                .AddRequiredParameter("id", ModelRef.NumberId)
                ;

            group.AddMethod("GetAll", MethodType.GetPaged, "users")
                .WithReturnType(Entities.UserBasic)
                .AddOptionalParameter("username", ModelRef.String)
                .AddOptionalParameter("active", ModelRef.Boolean)
                .AddOptionalParameter("blocked", ModelRef.Boolean)
                ;

            group.AddMethod("GetCurrentUserStatus", MethodType.Get, "user/status")
                .WithReturnType(Entities.UserStatus)
                ;

            group.AddMethod("GetStatus", MethodType.Get, "users/:user/status")
                .WithReturnType(Entities.UserStatus)
                .AddRequiredParameter("user", EntityRefs.UserRef)
                ;

            group.AddMethod("SetCurrentUserStatus", MethodType.Put, "users/status")
                .WithReturnType(Entities.UserStatus)
                .AddOptionalParameter("emoji", ModelRef.String)
                .AddOptionalParameter("message", ModelRef.String)
                ;

            group.AddMethod("GetCurrentUserSSHKeys", MethodType.GetCollection, "user/keys")
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

            group.AddMethod("AddSSHKeyToCurrentUser", MethodType.Post, "user/keys")
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

            group.AddMethod("DeleteSSHKeyFromCurrentUser", MethodType.Delete, "user/keys/:key_id")
                .AddRequiredParameter("id", EntityRefs.SshKeyRef)
                ;
            
            group.AddMethod("DeleteSSHKey", MethodType.Delete, "users/:user/keys/:key")
                .AddRequiredParameter("id", EntityRefs.UserRef)
                .AddRequiredParameter("key", EntityRefs.SshKeyRef)
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

        private static void CreateProjectMethods(Project project)
        {
            var group = project.AddMethodGroup("Project");

            group.AddMethod("Get", MethodType.GetPaged, "projects")
                .WithReturnType(Entities.Project)
                .AddOptionalParameter("archived", ModelRef.Boolean)
                .AddOptionalParameter("visibility", Enumerations.ProjectVisibility)
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

            group.AddMethod("GetByUser", MethodType.GetPaged, "users/:user/projects")
                .WithReturnType(Entities.Project)
                .AddRequiredParameter("user", EntityRefs.UserRef)
                .AddOptionalParameter("archived", ModelRef.Boolean)
                .AddOptionalParameter("visibility", Enumerations.ProjectVisibility)
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

            group.AddMethod("GetById", MethodType.Get, "projects/:id")
                .WithReturnType(Entities.Project)
                .WithRequestTypeName("GetSingleProject")
                .AddRequiredParameter("id", EntityRefs.ProjectIdOrPathRef)
                ;

            group.AddMethod("Create", MethodType.Post, "projects")
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
                .AddOptionalParameter("visibility", Enumerations.ProjectVisibility)
                .AddOptionalParameter("tag_list", ModelRef.StringCollection)
                .AddOptionalParameter("ci_config_path", ModelRef.String)
                .AddOptionalParameter("approvals_before_merge", ModelRef.Number)
                ;
        }

        private void CreateModel()
        {
            Enumerations.Create(Project);
            Entities.Create(Project);
            EntityRefs.Create(Project);

            CreateMarkdownMethods(Project);
            CreateUserMethods(Project);
            CreateProjectMethods(Project);

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
