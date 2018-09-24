using Newtonsoft.Json;

namespace Meziantou.GitLabClient.Generator
{
    internal partial class GitLabClientGenerator
    {
        private void CreateModel()
        {
            #region Enumeration

            var access = Project.AddModel(new Enumeration("Access")
            {
                Documentation = new Documentation
                {
                    HelpLink = "https://docs.gitlab.com/ee/api/projects.html#project-visibility-level"
                },
                SerializeAsString = false,
                Members =
                {
                    new EnumerationMember("guest", 10),
                    new EnumerationMember("reporter", 20),
                    new EnumerationMember("developer", 30),
                    new EnumerationMember("maintainer", 40),
                    new EnumerationMember("owner", 50),
                }
            });

            var importStatus = Project.AddModel(new Enumeration("ImportStatus")
            {
                Documentation = new Documentation
                {
                    HelpLink = "https://docs.gitlab.com/ee/api/project_import_export.html#import-status"
                },
                Members =
                {
                    new EnumerationMember("none"),
                    new EnumerationMember("scheduled"),
                    new EnumerationMember("failed"),
                    new EnumerationMember("started"),
                    new EnumerationMember("finished"),
                }
            });

            var mergeMethod = Project.AddModel(new Enumeration("MergeMethod")
            {
                Documentation = new Documentation
                {
                    HelpLink = "https://docs.gitlab.com/ee/api/projects.html#project-visibility-lhttps://docs.gitlab.com/ee/api/projects.html#project-merge-methodevel"
                },
                Members =
                {
                    new EnumerationMember("merge")
                    {
                        Documentation = "A merge commit is created for every merge, and merging is allowed as long as there are no conflicts."
                    },
                    new EnumerationMember("rebase_merge")
                    {
                        Documentation = "A merge commit is created for every merge, but merging is only allowed if fast-forward merge is possible. This way you could make sure that if this merge request would build, after merging to target branch it would also build."
                    },
                    new EnumerationMember("fast_forward")
                    {
                        SerializationName = "ff",
                        Documentation = "No merge commits are created and all merges are fast-forwarded, which means that merging is only allowed if the branch could be fast-forwarded."
                    }
                }
            });

            var mergeRequestScopeFilter = Project.AddModel(new Enumeration("MergeRequestScopeFilter")
            {
                Members =
                {
                    new EnumerationMember("assigned_to_me"),
                    new EnumerationMember("all"),
                }
            });

            var mergeRequestStateFilter = Project.AddModel(new Enumeration("MergeRequestStateFilter")
            {
                IsFlags = true,
                GenerateAllMember = true,
                Members =
                {
                    new EnumerationMember("default", 0x0),
                    new EnumerationMember("opened", 0x1),
                    new EnumerationMember("closed", 0x2),
                    new EnumerationMember("locked", 0x4),
                    new EnumerationMember("merged", 0x8),
                }
            });

            var mergeRequestState = Project.AddModel(new Enumeration("MergeRequestState")
            {
                Members =
                {
                    new EnumerationMember("opened"),
                    new EnumerationMember("closed"),
                    new EnumerationMember("locked"),
                    new EnumerationMember("merged"),
                }
            });

            var mergeRequestStatus = Project.AddModel(new Enumeration("MergeRequestStatus")
            {
                Members =
                {
                    new EnumerationMember("can_be_merged"),
                    new EnumerationMember("cannot_be_merged"),
                }
            });

            var projectVisibility = Project.AddModel(new Enumeration("ProjectVisibility")
            {
                Documentation = new Documentation
                {
                    HelpLink = "https://docs.gitlab.com/ee/api/projects.html#project-visibility-level"
                },
                Members =
                {
                    new EnumerationMember("private"),
                    new EnumerationMember("internal"),
                    new EnumerationMember("public"),
                }
            });

            var userState = Project.AddModel(new Enumeration("UserState")
            {
                Members =
                {
                    new EnumerationMember("active"),
                    new EnumerationMember("blocked"),
                }
            });

            var todoAction = Project.AddModel(new Enumeration("TodoAction")
            {
                Members =
                {
                    new EnumerationMember("assigned"),
                    new EnumerationMember("mentioned"),
                    new EnumerationMember("build_failed"),
                    new EnumerationMember("marked"),
                    new EnumerationMember("approval_required"),
                    new EnumerationMember("unmergeable"),
                    new EnumerationMember("directly_addressed"),
                }
            });

            var todoState = Project.AddModel(new Enumeration("TodoState")
            {
                Members =
                {
                    new EnumerationMember("pending"),
                    new EnumerationMember("done"),
                }
            });

            var todoType = Project.AddModel(new Enumeration("TodoType")
            {
                Members =
                {
                    new EnumerationMember("issue"),
                    new EnumerationMember("merge_request"),
                }
            });

            var mergeRequestView = Project.AddModel(new Enumeration("MergeRequestView")
            {
                Members =
                {
                    new EnumerationMember("default"),
                    new EnumerationMember("simple"),
                },
                SerializeAsString = true,
            });

            #endregion

            #region Entities

            var identityModel = Project.AddModel(new Entity("Identity")
            {
                Documentation = new Documentation
                {
                    HelpLink = "https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L43"
                },
                Properties =
                {
                    new EntityProperty("provider", ModelRef.String) { IsKey = true },
                    new EntityProperty("extern_uid", ModelRef.String) { IsKey = true },
                }
            });

            // https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L13
            var userSafe = Project.AddModel(new Entity("UserSafe")
            {
                Properties =
                {
                    new EntityProperty("id", ModelRef.Id) { IsKey = true },
                    new EntityProperty("name", ModelRef.String),
                    new EntityProperty("username", ModelRef.String) { IsDisplayName = true },
                }
            });

            // https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L17
            var userBasic = Project.AddModel(new Entity("UserBasic")
            {
                BaseType = userSafe,
                Properties =
                {
                    new EntityProperty("avatar_url", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("avatar_path", ModelRef.String) { Required = Required.Default },
                    new EntityProperty("state", userState),
                    new EntityProperty("web_url", ModelRef.String),
                }
            });

            // https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L32
            var user = Project.AddModel(new Entity("User")
            {
                BaseType = userBasic,
                Properties =
                {
                    new EntityProperty("bio", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("can_create_group", ModelRef.NullableBoolean) { Required = Required.Default },
                    new EntityProperty("can_create_project", ModelRef.NullableBoolean) { Required = Required.Default },
                    new EntityProperty("color_scheme_id", ModelRef.NullableId) { Required = Required.Default },
                    new EntityProperty("confirmed_at", ModelRef.NullableDateTime) { Required = Required.Default },
                    new EntityProperty("created_at", ModelRef.DateTime),
                    new EntityProperty("current_sign_in_at", ModelRef.NullableDateTime) { Required = Required.Default },
                    new EntityProperty("email", ModelRef.String) { Required = Required.Default },
                    new EntityProperty("external", ModelRef.NullableBoolean) { Required = Required.Default },
                    new EntityProperty("identities", new ModelRef(identityModel) { IsCollection = true }) { Required = Required.Default },
                    new EntityProperty("is_admin", ModelRef.NullableBoolean) { Required = Required.Default },
                    new EntityProperty("last_activity_on", ModelRef.NullableDate) { Required = Required.Default },
                    new EntityProperty("last_sign_in_at", ModelRef.NullableDateTime) { Required = Required.Default },
                    new EntityProperty("linkedin", ModelRef.String),
                    new EntityProperty("location", ModelRef.String) { Required = Required.Default },
                    new EntityProperty("organization", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("private_profile", ModelRef.Object) { Required = Required.Default },
                    new EntityProperty("projects_limit", ModelRef.NullableInt64) { Required = Required.Default },
                    new EntityProperty("shared_runners_minutes_limit", ModelRef.NullableInt64) { Required = Required.Default },
                    new EntityProperty("skype", ModelRef.String),
                    new EntityProperty("theme_id", ModelRef.NullableId) { Required = Required.Default },
                    new EntityProperty("twitter", ModelRef.String),
                    new EntityProperty("two_factor_enabled", ModelRef.NullableBoolean) { Required = Required.Default },
                    new EntityProperty("website_url", ModelRef.String),
                }
            });

            // https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L65
            var userStatus = Project.AddModel(new Entity("UserStatus")
            {
                Properties =
                {
                    new EntityProperty("emoji", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("message", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("message_html", ModelRef.String) { Required = Required.AllowNull },
                }
            });

            // https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L37
            var userActivity = Project.AddModel(new Entity("UserActivity")
            {
                Properties =
                {
                    new EntityProperty("username", ModelRef.String),
                    new EntityProperty("last_activity_on", ModelRef.Date),
                }
            });

            var sshKey = Project.AddModel(new Entity("SshKey")
            {
                Properties =
                {
                    new EntityProperty("id", ModelRef.Id) { IsKey = true },
                    new EntityProperty("title", ModelRef.String) { IsDisplayName = true },
                    new EntityProperty("key", ModelRef.String),
                    new EntityProperty("created_at", ModelRef.DateTime),
                },
                Documentation = new Documentation
                {
                    HelpLink = "https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L682"
                }
            });

            var sharedGroup = Project.AddModel(new Entity("SharedGroup")
            {
                Documentation = new Documentation
                {
                    HelpLink = "https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L88"
                },
                Properties =
                {
                    new EntityProperty("group_id", ModelRef.Id),
                    new EntityProperty("group_name", ModelRef.String),
                    new EntityProperty("group_access_level", access),
                }
            });

            var memberAccess = Project.AddModel(new Entity("MemberAccess")
            {
                Documentation = new Documentation
                {
                    HelpLink = "https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L836"
                },
                Properties =
                {
                    new EntityProperty("access_level", access),
                    new EntityProperty("notification_level", ModelRef.String),
                }
            });

            var projectAccess = Project.AddModel(new Entity("ProjectAccess")
            {
                Documentation = new Documentation
                {
                    HelpLink = "https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L845"
                },
                BaseType = memberAccess,
                Properties =
                {
                }
            });

            var groupAccess = Project.AddModel(new Entity("GroupAccess")
            {
                Documentation = new Documentation
                {
                    HelpLink = "https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L848"
                },
                BaseType = memberAccess,
                Properties =
                {
                }
            });

            var namespaceBasic = Project.AddModel(new Entity("NamespaceBasic")
            {
                Documentation = new Documentation
                {
                    HelpLink = "https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L822"
                },
                Properties =
                {
                    new EntityProperty("id", ModelRef.Id) { IsKey = true },
                    new EntityProperty("name", ModelRef.String),
                    new EntityProperty("path", ModelRef.String),
                    new EntityProperty("kind", ModelRef.String),
                    new EntityProperty("full_path", ModelRef.String) { IsDisplayName = true },
                    new EntityProperty("parent_id", ModelRef.NullableId),
                }
            });

            var projectIdentity = Project.AddModel(new Entity("ProjectIdentity")
            {
                Documentation = new Documentation
                {
                    HelpLink = "https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L96"
                },
                Properties =
                {
                    new EntityProperty("created_at", ModelRef.DateTime),
                    new EntityProperty("description", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("id", ModelRef.Id) { IsKey = true },
                    new EntityProperty("name", ModelRef.String),
                    new EntityProperty("name_with_namespace", ModelRef.String),
                    new EntityProperty("path", ModelRef.String),
                    new EntityProperty("path_with_namespace", ModelRef.String) { IsDisplayName = true },
                }
            });

            var basicProjectDetails = Project.AddModel(new Entity("BasicProjectDetails")
            {
                Documentation = new Documentation
                {
                    HelpLink = "https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L125"
                },
                BaseType = projectIdentity,
                Properties =
                {
                    new EntityProperty("avatar_url", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("default_branch", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("forks_count", ModelRef.Int64),
                    new EntityProperty("http_url_to_repo", ModelRef.String),
                    new EntityProperty("last_activity_at", ModelRef.DateTime),
                    new EntityProperty("namespace", new ModelRef(namespaceBasic)) { Required = Required.Default },
                    new EntityProperty("readme_url", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("ssh_url_to_repo", ModelRef.String),
                    new EntityProperty("star_count", ModelRef.Int64),
                    new EntityProperty("tag_list", ModelRef.StringCollection),
                    new EntityProperty("web_url", ModelRef.String),
                }
            });

            var projectLinks = Project.AddModel(new Entity("ProjectLink")
            {
                Properties =
                {
                    new EntityProperty("events", ModelRef.String),
                    new EntityProperty("issues", ModelRef.String) { Required = Required.Default },
                    new EntityProperty("labels", ModelRef.String),
                    new EntityProperty("members", ModelRef.String),
                    new EntityProperty("merge_requests", ModelRef.String) { Required = Required.Default },
                    new EntityProperty("repo_branches", ModelRef.String),
                    new EntityProperty("self", ModelRef.String),
                }
            });

            var permissions = Project.AddModel(new Entity("ProjectPermissions")
            {
                Properties =
                {
                    new EntityProperty("group_access", groupAccess),
                    new EntityProperty("project_access", projectAccess),
                }
            });

            var project = Project.AddModel(new Entity("Project")
            {
                Documentation = new Documentation
                {
                    HelpLink = "https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L158"
                },
                BaseType = basicProjectDetails,
                Properties =
                {
                    new EntityProperty("approvals_before_merge", ModelRef.NullableInt32) { Required = Required.Default },
                    new EntityProperty("archived", ModelRef.Boolean),
                    new EntityProperty("ci_config_path", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("container_registry_enabled", ModelRef.Boolean),
                    new EntityProperty("creator_id", ModelRef.Id),
                    new EntityProperty("forked_from_project", basicProjectDetails) { Required = Required.Default },
                    new EntityProperty("import_status", importStatus),
                    new EntityProperty("issues_enabled", ModelRef.Boolean),
                    new EntityProperty("jobs_enabled", ModelRef.Boolean),
                    new EntityProperty("lfs_enabled", ModelRef.Boolean),
                    new EntityProperty("links", projectLinks) { SerializationName = "_links" },
                    new EntityProperty("merge_method", mergeMethod),
                    new EntityProperty("merge_requests_enabled", ModelRef.Boolean),
                    new EntityProperty("mirror", ModelRef.Boolean),
                    new EntityProperty("mirror_user_id", ModelRef.NullableId) { Required = Required.Default },
                    new EntityProperty("mirror_trigger_builds", ModelRef.NullableBoolean) { Required = Required.Default },
                    new EntityProperty("mirror_overwrites_diverged_branches", ModelRef.NullableBoolean) { Required = Required.Default },
                    new EntityProperty("only_allow_merge_if_all_discussions_are_resolved", ModelRef.Boolean),
                    new EntityProperty("only_allow_merge_if_pipeline_succeeds", ModelRef.Boolean),
                    new EntityProperty("only_mirror_protected_branches", ModelRef.NullableBoolean) { Required = Required.Default },
                    new EntityProperty("open_issues_count", ModelRef.NullableInt32),
                    new EntityProperty("owner", userBasic) { Required = Required.Default },
                    new EntityProperty("permissions", permissions),
                    new EntityProperty("printing_merge_request_link_enabled", ModelRef.Boolean),
                    new EntityProperty("public_jobs", ModelRef.Boolean),
                    new EntityProperty("request_access_enabled", ModelRef.Boolean),
                    new EntityProperty("resolve_outdated_diff_discussions", ModelRef.NullableBoolean),
                    new EntityProperty("shared_runners_enabled", ModelRef.Boolean),
                    new EntityProperty("shared_with_groups", new ModelRef(sharedGroup) { IsCollection = true }),
                    new EntityProperty("snippets_enabled", ModelRef.Boolean),
                    new EntityProperty("visibility", projectVisibility),
                    new EntityProperty("wiki_enabled", ModelRef.Boolean),
                }
            });

            var todo = Project.AddModel(new Entity("Todo")
            {
                Properties =
                {
                    new EntityProperty("id", ModelRef.Id) { IsKey = true },
                    new EntityProperty("action_name", todoAction),
                    new EntityProperty("author", userBasic),
                    new EntityProperty("project", basicProjectDetails),
                    new EntityProperty("target_type", todoType),
                    new EntityProperty("target_url", ModelRef.String),
                    new EntityProperty("body", ModelRef.String),
                    new EntityProperty("state", todoState),
                    new EntityProperty("created_at", ModelRef.DateTime),
                }
            });

            var mergeRequest = Project.AddModel(new Entity("MergeRequest")
            {
                Properties =
                {
                    new EntityProperty("id", ModelRef.Id) { IsKey = true },
                    new EntityProperty("iid", ModelRef.Id),
                    new EntityProperty("author", userBasic),
                    new EntityProperty("assignee", userBasic),
                    new EntityProperty("title", ModelRef.String) { IsDisplayName = true },
                    new EntityProperty("description", ModelRef.String),
                    new EntityProperty("state", mergeRequestState),
                    new EntityProperty("project_id", ModelRef.Id),
                    new EntityProperty("source_project_id", ModelRef.Id),
                    new EntityProperty("target_project_id", ModelRef.Id),
                    new EntityProperty("web_url", ModelRef.String),
                    new EntityProperty("created_at", ModelRef.DateTime),
                    new EntityProperty("updated_at", ModelRef.DateTime),
                    new EntityProperty("user_notes_count", ModelRef.Int32),
                    new EntityProperty("target_branch", ModelRef.String),
                    new EntityProperty("source_branch", ModelRef.String),
                    new EntityProperty("upvotes", ModelRef.Int32),
                    new EntityProperty("downvotes", ModelRef.Int32),
                    new EntityProperty("labels", ModelRef.StringCollection),
                    new EntityProperty("work_in_progress", ModelRef.Boolean),
                    new EntityProperty("merge_when_pipeline_succeeds", ModelRef.Boolean),
                    new EntityProperty("merge_status", mergeRequestStatus),
                    new EntityProperty("sha", ModelRef.GitObjectId),
                    new EntityProperty("merge_commit_sha", ModelRef.NullableGitObjectId),
                    new EntityProperty("should_remove_source_branch", ModelRef.NullableBoolean),
                    new EntityProperty("force_remove_source_branch", ModelRef.NullableBoolean),
                    new EntityProperty("squash", ModelRef.Boolean),
                }
            });

            var issue = Project.AddModel(new Entity("Issue")
            {
                Properties =
                {
                    new EntityProperty("id", ModelRef.Id) { IsKey = true },
                    new EntityProperty("iid", ModelRef.Id),
                    new EntityProperty("author", userBasic),
                    new EntityProperty("title", ModelRef.String) { IsDisplayName = true },
                    new EntityProperty("project_id", ModelRef.Id),
                    new EntityProperty("web_url", ModelRef.String),
                    new EntityProperty("created_at", ModelRef.DateTime),
                    new EntityProperty("updated_at", ModelRef.DateTime),
                    new EntityProperty("closed_at", ModelRef.NullableDateTime),
                    new EntityProperty("closed_by", userBasic),
                }
            });

            var token = Project.AddModel(new Entity("ImpersonationToken")
            {
                Properties =
                {
                    new EntityProperty("id", ModelRef.Id) { IsKey = true },
                    new EntityProperty("revoked", ModelRef.Boolean),
                    new EntityProperty("scopes", ModelRef.StringCollection),
                    new EntityProperty("token", ModelRef.String),
                    new EntityProperty("active", ModelRef.Boolean),
                    new EntityProperty("impersonation", ModelRef.Boolean),
                    new EntityProperty("name", ModelRef.String) { IsDisplayName = true },
                    new EntityProperty("created_at", ModelRef.DateTime),
                    new EntityProperty("expires_at", ModelRef.NullableDate),
                }
            });

            var fileCreated = Project.AddModel(new Entity("FileCreated")
            {
                Properties =
                {
                    new EntityProperty("file_path", ModelRef.String),
                    new EntityProperty("branch", ModelRef.String),
                }
            });

            var fileUpdated = Project.AddModel(new Entity("FileUpdated")
            {
                Properties =
                {
                    new EntityProperty("file_path", ModelRef.String),
                    new EntityProperty("branch", ModelRef.String),
                }
            });

            var version = Project.AddModel(new Entity("ServerVersion")
            {
                Properties =
                {
                    new EntityProperty("version", ModelRef.String) { IsKey = true },
                    new EntityProperty("revision", ModelRef.String) { IsKey = true },
                }
            });

            var renderMarkdownResult = Project.AddModel(new Entity("RenderedMarkdown")
            {
                Properties =
                {
                    new EntityProperty("html", ModelRef.String) { IsKey = true },
                }
            });

            #endregion

            #region Refs

            var projectIdRef = Project.AddParameterEntity(new ParameterEntity("ProjectIdRef", ModelRef.Object)
            {
                Refs =
                {
                    new ParameterEntityRef("projectId", ModelRef.Id),
                    new ParameterEntityRef("project", projectIdentity, "id"),
                }
            });

            var projectIdOrPathRef = Project.AddParameterEntity(new ParameterEntity("ProjectIdOrPathRef", ModelRef.Object)
            {
                Refs =
                {
                    new ParameterEntityRef("projectId", ModelRef.Id),
                    new ParameterEntityRef("project", projectIdentity, "id"),
                    new ParameterEntityRef("projectPathWithNamespace", ModelRef.String),
                }
            });

            var sshKeyRef = Project.AddParameterEntity(new ParameterEntity("SshKeyRef", ModelRef.Object)
            {
                Refs =
                {
                    new ParameterEntityRef("sshKeyId", ModelRef.Id),
                    new ParameterEntityRef("sskKey", sshKey, "id"),
                }
            });

            var userRef = Project.AddParameterEntity(new ParameterEntity("UserRef", ModelRef.Object)
            {
                Refs =
                {
                    new ParameterEntityRef("userId", ModelRef.Id),
                    new ParameterEntityRef("userName", ModelRef.String),
                }
            });

            var mergeRequestIdRef = Project.AddParameterEntity(new ParameterEntity("MergeRequestIidRef", ModelRef.Object)
            {
                Refs =
                {
                    new ParameterEntityRef("mergeRequestIid", ModelRef.Id),
                    new ParameterEntityRef("mergeRequest", mergeRequest, "iid"),
                }
            });

            var todoIdRef = Project.AddParameterEntity(new ParameterEntity("TodoRef", ModelRef.Object)
            {
                Refs =
                {
                    new ParameterEntityRef("TodoId", ModelRef.Id),
                    new ParameterEntityRef("todo", todo, "id"),
                }
            });

            #endregion

            #region Methods

            Project.AddMethodGroup("Issue",
                new[]
                {
                    new Method("CreateIssue", "projects/:project/issues")
                    {
                        Documentation = new Documentation
                        {
                            Summary = "Creates a new project issue.",
                            HelpLink = "https://docs.gitlab.com/ee/api/issues.html#new-issue"
                        },
                        ReturnType = issue,
                        MethodType = MethodType.Post,
                        Parameters =
                        {
                            new MethodParameter("project", projectIdOrPathRef),
                            new MethodParameter("title", ModelRef.String),
                            new MethodParameter("description", ModelRef.String) { IsOptional = true },
                            new MethodParameter("confidential", ModelRef.NullableBoolean) { IsOptional = true },
                        }
                    }
                });

            Project.AddMethodGroup("Markdown",
                new[]
                {
                    new Method("RenderMarkdown", "markdown")
                    {
                        Documentation = new Documentation
                        {
                             HelpLink = "https://docs.gitlab.com/ee/api/markdown.html#render-an-arbitrary-markdown-document"
                        },
                        MethodType = MethodType.Post,
                        ReturnType = renderMarkdownResult,
                        Parameters =
                        {
                            new MethodParameter("text", ModelRef.String),
                            new MethodParameter("gfm", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("project", ModelRef.String) { IsOptional = true },
                        }
                    }
                });

            Project.AddMethodGroup("MergeRequest",
                new[]
                {
                    new Method("GetMergeRequests", "merge_requests")
                    {
                        Documentation = new Documentation
                        {
                            Summary = "Get all merge requests the authenticated user has access to. By default it returns only merge requests created by the current user. To get all merge requests, use parameter scope=all.",
                            HelpLink = "https://docs.gitlab.com/ee/api/merge_requests.html#list-merge-requests"
                        },
                        ReturnType = mergeRequest,
                        MethodType = MethodType.GetPaged,
                        Parameters =
                        {
                            new MethodParameter("state", new ModelRef(mergeRequestState) { IsNullable = true }) { IsOptional = true },
                            new MethodParameter("scope", new ModelRef(mergeRequestScopeFilter) { IsNullable = true }) { IsOptional = true },
                            new MethodParameter("assignee_id", new ModelRef(userRef) { IsNullable = true }) { IsOptional = true },
                            new MethodParameter("author_id", new ModelRef(userRef) { IsNullable = true }) { IsOptional = true },
                            new MethodParameter("milestone", ModelRef.String) { IsOptional = true },
                            new MethodParameter("view", new ModelRef(mergeRequestView) { IsNullable = true }) { IsOptional = true },
                            new MethodParameter("labels", ModelRef.StringCollection) { IsOptional = true },
                            new MethodParameter("created_after", ModelRef.NullableDateTime) { IsOptional = true },
                            new MethodParameter("created_before", ModelRef.NullableDateTime) { IsOptional = true },
                            new MethodParameter("updated_after", ModelRef.NullableDateTime) { IsOptional = true },
                            new MethodParameter("updated_before", ModelRef.NullableDateTime) { IsOptional = true },
                            new MethodParameter("my_reaction_emoji", ModelRef.String) { IsOptional = true },
                            new MethodParameter("source_branch", ModelRef.String) { IsOptional = true },
                            new MethodParameter("target_branch", ModelRef.String) { IsOptional = true },
                            new MethodParameter("search", ModelRef.String) { IsOptional = true },
                        }
                    },
                    new Method("GetMergeRequests", "groups/:group/merge_requests")
                    {
                        Documentation = new Documentation
                        {
                            Summary = "Get all merge requests for this group and its subgroups.",
                            HelpLink = "https://docs.gitlab.com/ee/api/merge_requests.html#list-group-merge-requests"
                        },
                        ReturnType = mergeRequest,
                        MethodType = MethodType.GetPaged,
                        Parameters =
                        {
                            new MethodParameter("group", ModelRef.Id),
                            new MethodParameter("state", new ModelRef(mergeRequestState) { IsNullable = true }) { IsOptional = true },
                            new MethodParameter("scope", new ModelRef(mergeRequestScopeFilter) { IsNullable = true }) { IsOptional = true },
                            new MethodParameter("assignee_id", new ModelRef(userRef) { IsNullable = true }) { IsOptional = true },
                            new MethodParameter("author_id", new ModelRef(userRef) { IsNullable = true }) { IsOptional = true },
                            new MethodParameter("milestone", ModelRef.String) { IsOptional = true },
                            new MethodParameter("view", new ModelRef(mergeRequestView) { IsNullable = true }) { IsOptional = true },
                            new MethodParameter("labels", ModelRef.StringCollection) { IsOptional = true },
                            new MethodParameter("created_after", ModelRef.NullableDateTime) { IsOptional = true },
                            new MethodParameter("created_before", ModelRef.NullableDateTime) { IsOptional = true },
                            new MethodParameter("updated_after", ModelRef.NullableDateTime) { IsOptional = true },
                            new MethodParameter("updated_before", ModelRef.NullableDateTime) { IsOptional = true },
                            new MethodParameter("my_reaction_emoji", ModelRef.String) { IsOptional = true },
                            new MethodParameter("source_branch", ModelRef.String) { IsOptional = true },
                            new MethodParameter("target_branch", ModelRef.String) { IsOptional = true },
                            new MethodParameter("search", ModelRef.String) { IsOptional = true },
                        }
                    },
                    new Method("GetMergeRequests", "projects/:project/merge_requests")
                    {
                        Documentation = new Documentation
                        {
                            Summary = "Get all merge requests for this project.",
                            HelpLink = "https://docs.gitlab.com/ee/api/merge_requests.html#list-project-merge-requests"
                        },
                        ReturnType = mergeRequest,
                        MethodType = MethodType.GetPaged,
                        Parameters =
                        {
                            new MethodParameter("project", projectIdOrPathRef),
                            new MethodParameter("iids", new ModelRef(ModelRef.GitObjectId) { IsCollection = true }) { IsOptional = true },
                            new MethodParameter("state", new ModelRef(mergeRequestState) { IsNullable = true }) { IsOptional = true },
                            new MethodParameter("scope", new ModelRef(mergeRequestScopeFilter) { IsNullable = true }) { IsOptional = true },
                            new MethodParameter("assignee_id", new ModelRef(userRef) { IsNullable = true }) { IsOptional = true },
                            new MethodParameter("author_id", new ModelRef(userRef) { IsNullable = true }) { IsOptional = true },
                            new MethodParameter("milestone", ModelRef.String) { IsOptional = true },
                            new MethodParameter("view", new ModelRef(mergeRequestView) { IsNullable = true }) { IsOptional = true },
                            new MethodParameter("labels", ModelRef.StringCollection) { IsOptional = true },
                            new MethodParameter("created_after", ModelRef.NullableDateTime) { IsOptional = true },
                            new MethodParameter("created_before", ModelRef.NullableDateTime) { IsOptional = true },
                            new MethodParameter("updated_after", ModelRef.NullableDateTime) { IsOptional = true },
                            new MethodParameter("updated_before", ModelRef.NullableDateTime) { IsOptional = true },
                            new MethodParameter("my_reaction_emoji", ModelRef.String) { IsOptional = true },
                            new MethodParameter("source_branch", ModelRef.String) { IsOptional = true },
                            new MethodParameter("target_branch", ModelRef.String) { IsOptional = true },
                            new MethodParameter("search", ModelRef.String) { IsOptional = true },
                        }
                    },
                    new Method("GetMergeRequest", "projects/:project/merge_requests/:merge_request")
                    {
                        Documentation = new Documentation
                        {
                            Summary = "Shows information about a single merge request.",
                            HelpLink = "https://docs.gitlab.com/ee/api/merge_requests.html#get-single-mr"
                        },
                        ReturnType = mergeRequest,
                        MethodType = MethodType.Get,
                        Parameters =
                        {
                            new MethodParameter("project", projectIdOrPathRef),
                            new MethodParameter("merge_request", mergeRequestIdRef),
                        }
                    },
                    new Method("CreateMergeRequest", "projects/:project/merge_requests")
                    {
                        Documentation = new Documentation
                        {
                            Summary = "Creates a new merge request.",
                            HelpLink = "https://docs.gitlab.com/ee/api/merge_requests.html#create-mr"
                        },
                        ReturnType = mergeRequest,
                        MethodType = MethodType.Post,
                        Parameters =
                        {
                            new MethodParameter("project", projectIdOrPathRef),
                            new MethodParameter("source_branch", ModelRef.String),
                            new MethodParameter("target_branch", ModelRef.String),
                            new MethodParameter("title", ModelRef.String),
                            new MethodParameter("description", ModelRef.String) { IsOptional = true },
                            new MethodParameter("assignee_id", new ModelRef(userRef) { IsNullable = true }) { IsOptional = true },
                            new MethodParameter("target_project_id", new ModelRef(projectIdRef) { IsNullable = true }) { IsOptional = true },
                            new MethodParameter("remove_source_branch", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("allow_collaboration", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("allow_maintainer_to_push", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("squash", ModelRef.NullableBoolean) { IsOptional = true },
                        }
                    }
                });

            Project.AddMethodGroup("Project",
                new[]
                {
                    new Method("GetProjects", "projects")
                    {
                        Documentation = new Documentation
                        {
                            Summary = "Get a list of all visible projects across GitLab for the authenticated user. When accessed without authentication, only public projects with \"simple\" fields are returned.",
                            HelpLink = "https://docs.gitlab.com/ee/api/projects.html#list-all-projects"
                        },
                        ReturnType = project,
                        MethodType = MethodType.GetPaged,
                        Parameters =
                        {
                            new MethodParameter("archived", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("visibility", new ModelRef(projectVisibility) { IsNullable = true }) { IsOptional = true },
                            new MethodParameter("search", ModelRef.String) { IsOptional = true },
                            new MethodParameter("simple", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("owned", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("membership", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("starred", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("statistics", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("with_issues_enabled", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("with_merge_requests_enabled", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("wiki_checksum_failed", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("repository_checksum_failed", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("min_access_level", new ModelRef(access) { IsNullable = true }) { IsOptional = true },
                        }
                    },
                    new Method("GetProjects", "users/:user/projects")
                    {
                        Documentation = new Documentation
                        {
                            Summary = "Get a list of visible projects for the given user. When accessed without authentication, only public projects are returned.",
                            HelpLink = "https://docs.gitlab.com/ee/api/projects.html#list-user-projects"
                        },
                        ReturnType = project,
                        MethodType = MethodType.GetPaged,
                        Parameters =
                        {
                            new MethodParameter("user", userRef),
                            new MethodParameter("archived", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("visibility", new ModelRef(projectVisibility) { IsNullable = true }) { IsOptional = true },
                            new MethodParameter("search", ModelRef.String) { IsOptional = true },
                            new MethodParameter("simple", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("owned", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("membership", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("starred", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("statistics", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("with_issues_enabled", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("with_merge_requests_enabled", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("wiki_checksum_failed", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("repository_checksum_failed", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("min_access_level", new ModelRef(access) { IsNullable = true }) { IsOptional = true },
                        }
                    },
                    new Method("GetProject", "projects/:id")
                    {
                        Documentation = new Documentation
                        {
                            Summary = "Get a specific project. This endpoint can be accessed without authentication if the project is publicly accessible.",
                            HelpLink = "https://docs.gitlab.com/ee/api/projects.html#get-single-project"
                        },
                        ReturnType = project,
                        MethodType = MethodType.Get,
                        Parameters =
                        {
                            new MethodParameter("id", projectIdOrPathRef),
                        }
                    },
                    new Method("CreateProject", "projects")
                    {
                        Documentation = new Documentation
                        {
                            Summary = "Creates a new project owned by the authenticated user.",
                            HelpLink = "https://docs.gitlab.com/ee/api/projects.html#create-project"
                        },
                        ReturnType = project,
                        MethodType = MethodType.Post,
                        Parameters =
                        {
                            new MethodParameter("name", ModelRef.String) { IsOptional = true },
                            new MethodParameter("path", ModelRef.String) { IsOptional = true },
                            new MethodParameter("namespace_id", ModelRef.NullableId) { IsOptional = true },
                            new MethodParameter("default_branch", ModelRef.String) { IsOptional = true },
                            new MethodParameter("description", ModelRef.String) { IsOptional = true },
                            new MethodParameter("issue_enabled", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("issues_enabled", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("merge_requests_enabled", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("jobs_enabled", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("wiki_enabled", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("snippets_enabled", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("resolve_outdated_diff_discussions", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("container_registry_enabled", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("shared_runners_enabled", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("public_jobs", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("only_allow_merge_if_pipeline_succeeds", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("only_allow_merge_if_all_discussions_are_resolved", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("request_access_enabled", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("lfs_enabled", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("printing_merge_request_link_enabled", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("merge_method", new ModelRef(mergeMethod) { IsNullable = true }) { IsOptional = true },
                            new MethodParameter("visibility", new ModelRef(projectVisibility) { IsNullable = true }) { IsOptional = true },
                            new MethodParameter("tag_list", ModelRef.StringCollection) { IsOptional = true },
                            new MethodParameter("ci_config_path", ModelRef.String) { IsOptional = true },
                            new MethodParameter("approvals_before_merge", ModelRef.NullableInt32) { IsOptional = true },
                        }
                    },
                });

            Project.AddMethodGroup("Repository",
                new[]
                {
                    new Method("CreateFile", "projects/:project/repository/files/:file_path")
                    {
                        Documentation = new Documentation
                        {
                            HelpLink = "https://docs.gitlab.com/ee/api/repository_files.html#create-new-file-in-repository"
                        },
                        ReturnType = fileCreated,
                        MethodType = MethodType.Post,
                        Parameters =
                        {
                            new MethodParameter("project", projectIdOrPathRef),
                            new MethodParameter("file_path", ModelRef.String),
                            new MethodParameter("branch", ModelRef.String),
                            new MethodParameter("start_branch", ModelRef.String) { IsOptional = true },
                            new MethodParameter("encoding", ModelRef.String) { IsOptional = true },
                            new MethodParameter("author_email", ModelRef.String) { IsOptional = true },
                            new MethodParameter("author_name", ModelRef.String) { IsOptional = true },
                            new MethodParameter("content", ModelRef.String),
                            new MethodParameter("commit_message", ModelRef.String),
                        }
                    },
                    new Method("UpdateFile", "projects/:project/repository/files/:file_path")
                    {
                        Documentation = new Documentation
                        {
                            HelpLink = "https://docs.gitlab.com/ee/api/repository_files.html#update-existing-file-in-repository"
                        },
                        ReturnType = fileUpdated,
                        MethodType = MethodType.Put,
                        Parameters =
                        {
                            new MethodParameter("project", projectIdOrPathRef),
                            new MethodParameter("file_path", ModelRef.String),
                            new MethodParameter("branch", ModelRef.String),
                            new MethodParameter("start_branch", ModelRef.String) { IsOptional = true },
                            new MethodParameter("encoding", ModelRef.String) { IsOptional = true },
                            new MethodParameter("author_email", ModelRef.String) { IsOptional = true },
                            new MethodParameter("author_name", ModelRef.String) { IsOptional = true },
                            new MethodParameter("last_commit_id", ModelRef.NullableGitObjectId) { IsOptional = true },
                            new MethodParameter("content", ModelRef.String),
                            new MethodParameter("commit_message", ModelRef.String),
                        }
                    },
                });

            Project.AddMethodGroup("Todo",
                new[]
                {
                    new Method("GetTodos", "todos")
                    {
                        Documentation = new Documentation
                        {
                            Summary = "Returns a list of todos. When no filter is applied, it returns all pending todos for the current user. Different filters allow the user to precise the request.",
                            HelpLink = "https://docs.gitlab.com/ee/api/todos.html#get-a-list-of-todos"
                        },
                        ReturnType = todo,
                        MethodType = MethodType.GetPaged,
                        Parameters =
                        {
                            new MethodParameter("action", new ModelRef(todoAction) { IsNullable = true }) { IsOptional = true },
                        }
                    },
                    new Method("MarkTodoAsDone", "todos/:todo/mark_as_done")
                    {
                        Documentation = new Documentation
                        {
                            Summary = "Marks a single pending todo given by its ID for the current user as done.",
                            HelpLink = "https://docs.gitlab.com/ee/api/todos.html#mark-a-todo-as-done"
                        },
                        ReturnType = todo,
                        MethodType = MethodType.Post,
                        Parameters =
                        {
                            new MethodParameter("todo", todoIdRef),
                        }
                    },
                    new Method("MarkAllTodosAsDone", "todos/mark_as_done")
                    {
                        Documentation = new Documentation
                        {
                            Summary = "Marks all pending todos for the current user as done.",
                            HelpLink = "https://docs.gitlab.com/ee/api/todos.html#mark-a-todo-as-done"
                        },
                        MethodType = MethodType.Post,
                    },
                });

            Project.AddMethodGroup("User",
                new[]
                {
                    new Method("GetUser", "user")
                    {
                        ReturnType = user,
                        Documentation = new Documentation
                        {
                            Summary = "Gets currently authenticated user.",
                            HelpLink = "https://docs.gitlab.com/ee/api/users.html#user",
                        },
                    },
                    new Method("GetUser", "users/:id")
                    {
                        ReturnType = user,
                        Parameters =
                    {
                        new MethodParameter("id", ModelRef.Id)
                    },
                        Documentation = new Documentation
                        {
                            Summary = "Get a single user.",
                            HelpLink = "https://docs.gitlab.com/ee/api/users.html#single-user",
                        },
                    },
                    new Method("GetUsers", "users")
                    {
                        MethodType = MethodType.GetPaged,
                        ReturnType = new ModelRef(userBasic),
                        Parameters =
                    {
                        new MethodParameter("username", ModelRef.String) { IsOptional = true },
                        new MethodParameter("active", ModelRef.Boolean) { IsOptional = true, MethodParameterName = "onlyActiveUsers" },
                        new MethodParameter("blocked", ModelRef.Boolean) { IsOptional = true, MethodParameterName = "onlyBlockedUsers" },
                    },
                        Documentation = new Documentation
                        {
                            Summary = "Get a list of users.",
                            HelpLink = "https://docs.gitlab.com/ee/api/users.html#list-users",
                        },
                    },
                    new Method("GetUserStatus", "user/status")
                    {
                        MethodType = MethodType.Get,
                        ReturnType = new ModelRef(userStatus),
                        Documentation = new Documentation
                        {
                            Summary = "Get the status of the currently signed in user.",
                            HelpLink = "https://docs.gitlab.com/ee/api/users.html#user-status",
                        },
                    },
                    new Method("GetUserStatus", "users/:user/status")
                    {
                        MethodType = MethodType.Get,
                        ReturnType = new ModelRef(userStatus),
                        Parameters =
                        {
                            new MethodParameter("user", userRef)
                        },
                        Documentation = new Documentation
                        {
                            Summary = "Get the status of a user.",
                            HelpLink = "https://docs.gitlab.com/ee/api/users.html#get-the-status-of-a-user"
                        },
                    },
                    new Method("SetUserStatus", "user/status")
                    {
                        MethodType = MethodType.Put,
                        ReturnType = new ModelRef(userStatus),
                        Parameters =
                        {
                            new MethodParameter("emoji", ModelRef.String) { IsOptional = true },
                            new MethodParameter("message", ModelRef.String) { IsOptional = true },
                        },
                        Documentation = new Documentation
                        {
                            Summary = "Set the status of the current user.",
                            HelpLink = "https://docs.gitlab.com/ee/api/users.html#set-user-status"
                        },
                    },
                    new Method("GetSshKeys", "user/keys")
                    {
                        MethodType = MethodType.Get,
                        ReturnType = new ModelRef(sshKey) { IsCollection = true },
                        Documentation = new Documentation
                        {
                            Summary = "Get a list of currently authenticated user's SSH keys.",
                            HelpLink = "https://docs.gitlab.com/ee/api/users.html#list-ssh-keys"
                        },
                    },
                    new Method("GetSshKeys", "users/:user/keys")
                    {
                        MethodType = MethodType.Get,
                        ReturnType = new ModelRef(sshKey) { IsCollection = true },
                        Parameters =
                        {
                            new MethodParameter("user", ModelRef.Id)
                        },
                        Documentation = new Documentation
                        {
                            Summary = "Get a list of a specified user's SSH keys. Available only for admin.",
                            HelpLink = "https://docs.gitlab.com/ee/api/users.html#list-ssh-keys-for-user"
                        },
                    },
                    new Method("GetSshKey", "user/keys/:id")
                    {
                        MethodType = MethodType.Get,
                        ReturnType = new ModelRef(sshKey),
                        Parameters =
                        {
                            new MethodParameter("id", sshKeyRef)
                            {
                                Documentation = new Documentation
                                {
                                    Summary = "The ID of an SSH key",
                                }
                            }
                        },
                        Documentation = new Documentation
                        {
                            Summary = "Get a single key.",
                            HelpLink = "https://docs.gitlab.com/ee/api/users.html#single-ssh-key"
                        },
                    },
                    new Method("AddSshKey", "user/keys")
                    {
                        MethodType = MethodType.Post,
                        ReturnType = new ModelRef(sshKey),
                        Parameters =
                        {
                            new MethodParameter("title", ModelRef.String),
                            new MethodParameter("key", ModelRef.String),
                        },
                        Documentation = new Documentation
                        {
                            Summary = "Creates a new key owned by the currently authenticated user.",
                            HelpLink = "https://docs.gitlab.com/ee/api/users.html#add-ssh-key"
                        },
                    },
                    new Method("AddSshKey", "users/:user/keys")
                    {
                        MethodType = MethodType.Post,
                        ReturnType = new ModelRef(sshKey),
                        Parameters =
                        {
                            new MethodParameter("user", userRef),
                            new MethodParameter("title", ModelRef.String),
                            new MethodParameter("key", ModelRef.String),
                        },
                        Documentation = new Documentation
                        {
                            Summary = "Creates a new key owned by the currently authenticated user.",
                            HelpLink = "https://docs.gitlab.com/ee/api/users.html#add-ssh-key"
                        },
                    },
                    new Method("DeleteSshKey", "user/keys/:id")
                    {
                        MethodType = MethodType.Delete,
                        Parameters =
                        {
                            new MethodParameter("id", sshKeyRef)
                            {
                                Documentation = "SSH key ID"
                            }
                        },
                        Documentation = new Documentation
                        {
                            Summary = "Deletes key owned by currently authenticated user.",
                            HelpLink = "https://docs.gitlab.com/ee/api/users.html#delete-ssh-key-for-current-user"
                        },
                    },
                    new Method("CreateUser", "users")
                    {
                        MethodType = MethodType.Post,
                        ReturnType = new ModelRef(user),
                        Parameters =
                        {
                            new MethodParameter("email", ModelRef.String),
                            new MethodParameter("username", ModelRef.String),
                            new MethodParameter("name", ModelRef.String),
                            new MethodParameter("password", ModelRef.String) { IsOptional = true },
                            new MethodParameter("admin", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("can_create_group", ModelRef.NullableBoolean) { IsOptional = true },
                            new MethodParameter("skip_confirmation", ModelRef.NullableBoolean) { IsOptional = true },
                        },
                        Documentation = new Documentation
                        {
                            Summary = "Creates a new user. Note only administrators can create new users.",
                            HelpLink = "https://docs.gitlab.com/ee/api/users.html#user-creation"
                        },
                    },
                    new Method("CreateImpersonationToken", "users/:user/impersonation_tokens")
                    {
                        MethodType = MethodType.Post,
                        ReturnType = new ModelRef(token),
                        Parameters =
                        {
                            new MethodParameter("user", userRef),
                            new MethodParameter("name", ModelRef.String),
                            new MethodParameter("expires_at", ModelRef.NullableDate) { IsOptional = true },
                            new MethodParameter("scopes", ModelRef.StringCollection),
                        },
                        Documentation = new Documentation
                        {
                            Summary = "It creates a new impersonation token. Note that only administrators can do this. You are only able to create impersonation tokens to impersonate the user and perform both API calls and Git reads and writes. The user will not see these tokens in their profile settings page.",
                            HelpLink = "https://docs.gitlab.com/ee/api/users.html#create-an-impersonation-token"
                        },
                    }
                }
                );

            Project.AddMethodGroup("Version",
                new[]
                {
                    new Method("GetVersion", "version")
                    {
                        Documentation = new Documentation
                        {
                            HelpLink = "https://docs.gitlab.com/ee/api/version.html"
                        },
                        ReturnType = version,
                        MethodType = MethodType.Get
                    },
                });

            #endregion
        }
    }
}
