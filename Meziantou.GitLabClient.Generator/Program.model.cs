using System.Linq;
using Newtonsoft.Json;

namespace Meziantou.GitLabClient.Generator
{
    internal partial class Program
    {
        private Enumeration _access;
        private Enumeration _importStatus;
        private Enumeration _mergeMethod;
        private Enumeration _mergeRequestScopeFilter;
        private Enumeration _mergeRequestState;
        private Enumeration _mergeRequestStateFilter;
        private Enumeration _projectVisibility;
        private Enumeration _userState;
        private Enumeration _todoAction;
        private Enumeration _todoState;
        private Enumeration _todoType;

        private Entity _basicProjectDetails;
        private Entity _groupAccess;
        private Entity _identityModel;
        private Entity _memberAccess;
        private Entity _mergeRequest;
        private Entity _namespaceBasic;
        private Entity _project;
        private Entity _projectAccess;
        private Entity _projectIdentity;
        private Entity _sharedGroup;
        private Entity _sshKey;
        private Entity _userActivity;
        private Entity _userBasic;
        private Entity _user;
        private Entity _userSafe;
        private Entity _userStatus;
        private Entity _todo;

        private ParameterEntity _projectIdRef;
        private ParameterEntity _projectIdOrPathRef;
        private ParameterEntity _sshKeyRef;
        private ParameterEntity _userRef;

        private void CreateEnumerations()
        {
            _access = Project.AddModel(new Enumeration("Access")
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

            _importStatus = Project.AddModel(new Enumeration("ImportStatus")
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

            _mergeMethod = Project.AddModel(new Enumeration("MergeMethod")
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

            _projectVisibility = Project.AddModel(new Enumeration("ProjectVisibility")
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

            _userState = Project.AddModel(new Enumeration("UserState")
            {
                Members =
                {
                    new EnumerationMember("active"),
                    new EnumerationMember("blocked"),
                }
            });

            _todoAction = Project.AddModel(new Enumeration("TodoAction")
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

            _todoState = Project.AddModel(new Enumeration("TodoState")
            {
                Members =
                {
                    new EnumerationMember("pending"),
                    new EnumerationMember("done"),
                }
            });

            _todoType = Project.AddModel(new Enumeration("TodoType")
            {
                Members =
                {
                    new EnumerationMember("issue"),
                    new EnumerationMember("merge_request"),
                }
            });

            _mergeRequestScopeFilter = Project.AddModel(new Enumeration("MergeRequestScopeFilter")
            {
                Members =
                {
                    new EnumerationMember("assigned_to_me"),
                    new EnumerationMember("all"),
                }
            });

            _mergeRequestStateFilter = Project.AddModel(new Enumeration("MergeRequestStateFilter")
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

            _mergeRequestState = Project.AddModel(new Enumeration("MergeRequestState")
            {
                Members =
                {
                    new EnumerationMember("opened"),
                    new EnumerationMember("closed"),
                    new EnumerationMember("locked"),
                    new EnumerationMember("merged"),
                }
            });
        }

        private void CreateUserTypes()
        {
            // https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L43
            _identityModel = Project.AddModel(new Entity("Identity")
            {
                Properties =
                {
                    new EntityProperty("provider", ModelRef.String),
                    new EntityProperty("extern_uid", ModelRef.String),
                }
            });

            // https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L13
            _userSafe = Project.AddModel(new Entity("UserSafe")
            {
                Properties =
                {
                    new EntityProperty("id", ModelRef.Id),
                    new EntityProperty("name", ModelRef.String),
                    new EntityProperty("username", ModelRef.String),
                }
            });

            // https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L17
            _userBasic = Project.AddModel(new Entity("UserBasic")
            {
                BaseType = _userSafe,
                Properties =
                {
                    new EntityProperty("avatar_url", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("avatar_path", ModelRef.String) { Required = Required.Default },
                    new EntityProperty("state", _userState),
                    new EntityProperty("web_url", ModelRef.String),
                }
            });

            // https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L32
            _user = Project.AddModel(new Entity("User")
            {
                BaseType = _userBasic,
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
                    new EntityProperty("identities", new ModelRef(_identityModel) { IsCollection = true }) { Required = Required.Default },
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
            _userStatus = Project.AddModel(new Entity("UserStatus")
            {
                Properties =
                {
                    new EntityProperty("emoji", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("message", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("message_html", ModelRef.String) { Required = Required.AllowNull },
                }
            });

            // https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L37
            _userActivity = Project.AddModel(new Entity("UserActivity")
            {
                Properties =
                {
                    new EntityProperty("username", ModelRef.String),
                    new EntityProperty("last_activity_on", ModelRef.Date),
                }
            });

            _sshKey = Project.AddModel(new Entity("SshKey")
            {
                Properties =
                {
                    new EntityProperty("id", ModelRef.Id),
                    new EntityProperty("title", ModelRef.String),
                    new EntityProperty("key", ModelRef.String),
                    new EntityProperty("created_at", ModelRef.DateTime),
                },
                Documentation = new Documentation
                {
                    HelpLink = "https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L682"
                }
            });

            _sharedGroup = Project.AddModel(new Entity("SharedGroup")
            {
                Documentation = new Documentation
                {
                    HelpLink = "https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L88"
                },
                Properties =
                {
                    new EntityProperty("group_id", ModelRef.Id),
                    new EntityProperty("group_name", ModelRef.String),
                    new EntityProperty("group_access_level", _access),
                }
            });

            _memberAccess = Project.AddModel(new Entity("MemberAccess")
            {
                Documentation = new Documentation
                {
                    HelpLink = "https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L836"
                },
                Properties =
                {
                    new EntityProperty("access_level", _access),
                    new EntityProperty("notification_level", ModelRef.String),
                }
            });

            _projectAccess = Project.AddModel(new Entity("ProjectAccess")
            {
                Documentation = new Documentation
                {
                    HelpLink = "https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L845"
                },
                BaseType = _memberAccess,
                Properties =
                {
                }
            });

            _groupAccess = Project.AddModel(new Entity("GroupAccess")
            {
                Documentation = new Documentation
                {
                    HelpLink = "https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L848"
                },
                BaseType = _memberAccess,
                Properties =
                {
                }
            });

            _namespaceBasic = Project.AddModel(new Entity("NamespaceBasic")
            {
                Documentation = new Documentation
                {
                    HelpLink = "https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L822"
                },
                Properties =
                {
                    new EntityProperty("id", ModelRef.Id),
                    new EntityProperty("name", ModelRef.String),
                    new EntityProperty("path", ModelRef.String),
                    new EntityProperty("kind", ModelRef.String),
                    new EntityProperty("full_path", ModelRef.String),
                    new EntityProperty("parent_id", ModelRef.NullableId),
                }
            });

            _projectIdentity = Project.AddModel(new Entity("ProjectIdentity")
            {
                Documentation = new Documentation
                {
                    HelpLink = "https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L96"
                },
                Properties =
                {
                    new EntityProperty("created_at", ModelRef.DateTime),
                    new EntityProperty("description", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("id", ModelRef.Id),
                    new EntityProperty("name", ModelRef.String),
                    new EntityProperty("name_with_namespace", ModelRef.String),
                    new EntityProperty("path", ModelRef.String),
                    new EntityProperty("path_with_namespace", ModelRef.String),
                }
            });

            _basicProjectDetails = Project.AddModel(new Entity("BasicProjectDetails")
            {
                Documentation = new Documentation
                {
                    HelpLink = "https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L125"
                },
                BaseType = _projectIdentity,
                Properties =
                {
                    new EntityProperty("avatar_url", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("default_branch", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("forks_count", ModelRef.Int64),
                    new EntityProperty("http_url_to_repo", ModelRef.String),
                    new EntityProperty("last_activity_at", ModelRef.DateTime),
                    new EntityProperty("namespace", new ModelRef(_namespaceBasic)) { Required = Required.Default },
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
                    new EntityProperty("group_access", _groupAccess),
                    new EntityProperty("project_access", _projectAccess),
                }
            });

            _project = Project.AddModel(new Entity("Project")
            {
                Documentation = new Documentation
                {
                    HelpLink = "https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L158"
                },
                BaseType = _basicProjectDetails,
                Properties =
                {
                    new EntityProperty("approvals_before_merge", ModelRef.NullableInt32) { Required = Required.Default },
                    new EntityProperty("archived", ModelRef.Boolean),
                    new EntityProperty("ci_config_path", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("container_registry_enabled", ModelRef.Boolean),
                    new EntityProperty("creator_id", ModelRef.Id),
                    new EntityProperty("forked_from_project", _basicProjectDetails) { Required = Required.Default },
                    new EntityProperty("import_status", _importStatus),
                    new EntityProperty("issues_enabled", ModelRef.Boolean),
                    new EntityProperty("jobs_enabled", ModelRef.Boolean),
                    new EntityProperty("lfs_enabled", ModelRef.Boolean),
                    new EntityProperty("links", projectLinks) { SerializationName = "_links" },
                    new EntityProperty("merge_method", _mergeMethod),
                    new EntityProperty("merge_requests_enabled", ModelRef.Boolean),
                    new EntityProperty("mirror", ModelRef.Boolean),
                    new EntityProperty("mirror_user_id", ModelRef.NullableId) { Required = Required.Default },
                    new EntityProperty("mirror_trigger_builds", ModelRef.NullableBoolean) { Required = Required.Default },
                    new EntityProperty("mirror_overwrites_diverged_branches", ModelRef.NullableBoolean) { Required = Required.Default },
                    new EntityProperty("only_allow_merge_if_all_discussions_are_resolved", ModelRef.Boolean),
                    new EntityProperty("only_allow_merge_if_pipeline_succeeds", ModelRef.Boolean),
                    new EntityProperty("only_mirror_protected_branches", ModelRef.NullableBoolean) { Required = Required.Default },
                    new EntityProperty("open_issues_count", ModelRef.NullableInt32),
                    new EntityProperty("owner", _userBasic) { Required = Required.Default },
                    new EntityProperty("permissions", permissions),
                    new EntityProperty("printing_merge_request_link_enabled", ModelRef.Boolean),
                    new EntityProperty("public_jobs", ModelRef.Boolean),
                    new EntityProperty("request_access_enabled", ModelRef.Boolean),
                    new EntityProperty("resolve_outdated_diff_discussions", ModelRef.NullableBoolean),
                    new EntityProperty("shared_runners_enabled", ModelRef.Boolean),
                    new EntityProperty("shared_with_groups", new ModelRef(_sharedGroup) { IsCollection = true }),
                    new EntityProperty("snippets_enabled", ModelRef.Boolean),
                    new EntityProperty("visibility", _projectVisibility),
                    new EntityProperty("wiki_enabled", ModelRef.Boolean),
                }
            });

            _todo = Project.AddModel(new Entity("Todo")
            {
                Properties =
                {
                    new EntityProperty("id", ModelRef.Id),
                    new EntityProperty("action_name", _todoAction),
                    new EntityProperty("author", _userBasic),
                    new EntityProperty("project", _basicProjectDetails),
                    new EntityProperty("target_type", _todoType),
                    new EntityProperty("target", ModelRef.GitLabObject),
                    new EntityProperty("target_url", ModelRef.String),
                    new EntityProperty("body", ModelRef.String),
                    new EntityProperty("state", _userState),
                    new EntityProperty("created_at", ModelRef.DateTime),
                }
            });

            _mergeRequest = Project.AddModel(new Entity("MergeRequest")
            {
                Properties =
                {
                    new EntityProperty("id", ModelRef.Id),
                    new EntityProperty("iid", ModelRef.Id),
                    new EntityProperty("author", _userBasic),
                    new EntityProperty("title", ModelRef.String),
                    new EntityProperty("state", _mergeRequestState),
                    new EntityProperty("project_id", ModelRef.Id),
                    new EntityProperty("web_url", ModelRef.String),
                    new EntityProperty("created_at", ModelRef.DateTime),
                    new EntityProperty("updated_at", ModelRef.DateTime),
                    new EntityProperty("merge_status", ModelRef.String),
                    new EntityProperty("user_notes_count", ModelRef.Int32),
                }
            });
        }

        private void CreateRefs()
        {
            _projectIdRef = Project.AddParameterEntity(new ParameterEntity("ProjectIdRef", ModelRef.Object)
            {
                Refs =
                {
                    new ParameterEntityRef(ModelRef.Id),
                    new ParameterEntityRef(_projectIdentity, "id"),
                }
            });

            _projectIdOrPathRef = Project.AddParameterEntity(new ParameterEntity("ProjectIdOrPathRef", ModelRef.Object)
            {
                Refs =
                {
                    new ParameterEntityRef(ModelRef.Id),
                    new ParameterEntityRef(_projectIdentity, "id"),
                    new ParameterEntityRef(ModelRef.String),
                }
            });

            _sshKeyRef = Project.AddParameterEntity(new ParameterEntity("SshKeyRef", ModelRef.Object)
            {
                Refs =
                {
                    new ParameterEntityRef(ModelRef.Id),
                    new ParameterEntityRef(_sshKey, "id"),
                }
            });

            _userRef = Project.AddParameterEntity(new ParameterEntity("UserRef", ModelRef.Object)
            {
                Refs =
                {
                    new ParameterEntityRef(ModelRef.Id),
                    new ParameterEntityRef(ModelRef.String),
                    new ParameterEntityRef(_userSafe, "id"),
                }
            });
        }

        private void CreateUserMethods()
        {
            Project.AddMethod(new Method("GetUser", "user")
            {
                ReturnType = _user,
                Documentation = new Documentation
                {
                    Summary = "Gets currently authenticated user.",
                    HelpLink = "https://docs.gitlab.com/ee/api/users.html#user",
                },
            });

            Project.AddMethod(new Method("GetUser", "users/:id")
            {
                ReturnType = _user,
                Parameters =
                {
                    new MethodParameter("id", ModelRef.Id)
                },
                Documentation = new Documentation
                {
                    Summary = "Get a single user.",
                    HelpLink = "https://docs.gitlab.com/ee/api/users.html#single-user",
                },
            });

            Project.AddMethod(new Method("GetUsers", "users")
            {
                MethodType = MethodType.GetPaged,
                ReturnType = new ModelRef(_userBasic),
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
            });

            Project.AddMethod(new Method("GetUserStatus", "user/status")
            {
                MethodType = MethodType.Get,
                ReturnType = new ModelRef(_userStatus),
                Documentation = new Documentation
                {
                    Summary = "Get the status of the currently signed in user.",
                    HelpLink = "https://docs.gitlab.com/ee/api/users.html#user-status",
                },
            });

            Project.AddMethod(new Method("GetUserStatus", "users/:user/status")
            {
                MethodType = MethodType.Get,
                ReturnType = new ModelRef(_userStatus),
                Parameters =
                {
                    new MethodParameter("user", _userRef)
                },
                Documentation = new Documentation
                {
                    Summary = "Get the status of a user.",
                    HelpLink = "https://docs.gitlab.com/ee/api/users.html#get-the-status-of-a-user"
                },
            });

            Project.AddMethod(new Method("SetUserStatus", "user/status")
            {
                MethodType = MethodType.Put,
                ReturnType = new ModelRef(_userStatus),
                Parameters =
                {
                    new MethodParameter("emoji", ModelRef.String) { IsOptional = true, Location = ParameterLocation.Body },
                    new MethodParameter("message", ModelRef.String) { IsOptional = true, Location = ParameterLocation.Body },
                },
                Documentation = new Documentation
                {
                    Summary = "Set the status of the current user.",
                    HelpLink = "https://docs.gitlab.com/ee/api/users.html#set-user-status"
                },
            });

            Project.AddMethod(new Method("GetSshKeys", "user/keys")
            {
                MethodType = MethodType.Get,
                ReturnType = new ModelRef(_sshKey) { IsCollection = true },
                Documentation = new Documentation
                {
                    Summary = "Get a list of currently authenticated user's SSH keys.",
                    HelpLink = "https://docs.gitlab.com/ee/api/users.html#list-ssh-keys"
                },
            });

            Project.AddMethod(new Method("GetSshKeys", "users/:user/keys")
            {
                MethodType = MethodType.Get,
                ReturnType = new ModelRef(_sshKey) { IsCollection = true },
                Parameters =
                {
                    new MethodParameter("user", ModelRef.Id)
                },
                Documentation = new Documentation
                {
                    Summary = "Get a list of a specified user's SSH keys. Available only for admin.",
                    HelpLink = "https://docs.gitlab.com/ee/api/users.html#list-ssh-keys-for-user"
                },
            });

            Project.AddMethod(new Method("GetSshKey", "user/keys/:id")
            {
                MethodType = MethodType.Get,
                ReturnType = new ModelRef(_sshKey),
                Parameters =
                {
                    new MethodParameter("id", _sshKeyRef)
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
            });

            var addSshKeyParameters = new MethodParameter[]
            {
                new MethodParameter("title", ModelRef.String) { Location = ParameterLocation.Body },
                new MethodParameter("key", ModelRef.String) { Location = ParameterLocation.Body },
            };

            Project.AddMethod(new Method("AddSshKey", "user/keys")
            {
                MethodType = MethodType.Post,
                ReturnType = new ModelRef(_sshKey),
                Parameters = addSshKeyParameters,
                Documentation = new Documentation
                {
                    Summary = "Creates a new key owned by the currently authenticated user.",
                    HelpLink = "https://docs.gitlab.com/ee/api/users.html#add-ssh-key"
                },
            });

            Project.AddMethod(new Method("AddSshKey", "users/:user/keys")
            {
                MethodType = MethodType.Post,
                ReturnType = new ModelRef(_sshKey),
                Parameters = new[]
                {
                    new MethodParameter("user", _userRef)
                }.Concat(addSshKeyParameters).ToList(),
                Documentation = new Documentation
                {
                    Summary = "Creates a new key owned by the currently authenticated user.",
                    HelpLink = "https://docs.gitlab.com/ee/api/users.html#add-ssh-key"
                },
            });

            Project.AddMethod(new Method("DeleteSshKey", "user/keys/:id")
            {
                MethodType = MethodType.Delete,
                Parameters =
                {
                    new MethodParameter("id", _sshKeyRef)
                    {
                        Documentation = "SSH key ID"
                    }
                },
                Documentation = new Documentation
                {
                    Summary = "Deletes key owned by currently authenticated user.",
                    HelpLink = "https://docs.gitlab.com/ee/api/users.html#delete-ssh-key-for-current-user"
                },
            });

            Project.AddMethod(new Method("CreateUser", "users")
            {
                MethodType = MethodType.Post,
                ReturnType = new ModelRef(_user),
                Parameters =
                {
                    new MethodParameter("email", ModelRef.String) { Location = ParameterLocation.Body },
                    new MethodParameter("username", ModelRef.String) { Location = ParameterLocation.Body },
                    new MethodParameter("name", ModelRef.String) { Location = ParameterLocation.Body },
                    new MethodParameter("password", ModelRef.String) { IsOptional = true, Location = ParameterLocation.Body },
                    new MethodParameter("admin", ModelRef.NullableBoolean) { IsOptional = true, Location = ParameterLocation.Body },
                    new MethodParameter("can_create_group", ModelRef.NullableBoolean) { IsOptional = true, Location = ParameterLocation.Body },
                    new MethodParameter("skip_confirmation", ModelRef.NullableBoolean) { IsOptional = true, Location = ParameterLocation.Body },
                },
                Documentation = new Documentation
                {
                    Summary = "Creates a new user. Note only administrators can create new users.",
                    HelpLink = "https://docs.gitlab.com/ee/api/users.html#user-creation"
                },
            });

            var token = Project.AddModel(new Entity("ImpersonationToken")
            {
                Properties =
                {
                    new EntityProperty("id", ModelRef.Id),
                    new EntityProperty("revoked", ModelRef.Boolean),
                    new EntityProperty("scopes", ModelRef.StringCollection),
                    new EntityProperty("token", ModelRef.String),
                    new EntityProperty("active", ModelRef.Boolean),
                    new EntityProperty("impersonation", ModelRef.Boolean),
                    new EntityProperty("name", ModelRef.String),
                    new EntityProperty("created_at", ModelRef.DateTime),
                    new EntityProperty("expires_at", ModelRef.NullableDate),
                }
            });

            Project.AddMethod(new Method("CreateImpersonationToken", "users/:user/impersonation_tokens")
            {
                MethodType = MethodType.Post,
                ReturnType = new ModelRef(token),
                Parameters =
                {
                    new MethodParameter("user", _userRef),
                    new MethodParameter("name", ModelRef.String) { Location = ParameterLocation.Body },
                    new MethodParameter("expires_at", ModelRef.NullableDate) { IsOptional = true, Location = ParameterLocation.Body },
                    new MethodParameter("scopes", ModelRef.StringCollection) { Location = ParameterLocation.Body },
                },
                Documentation = new Documentation
                {
                    Summary = "It creates a new impersonation token. Note that only administrators can do this. You are only able to create impersonation tokens to impersonate the user and perform both API calls and Git reads and writes. The user will not see these tokens in their profile settings page.",
                    HelpLink = "https://docs.gitlab.com/ee/api/users.html#create-an-impersonation-token"
                },
            });
        }

        private void CreateProjectMethods()
        {
            Project.AddMethod(new Method("GetProjects", "projects")
            {
                Documentation = new Documentation
                {
                    Summary = "Get a list of all visible projects across GitLab for the authenticated user. When accessed without authentication, only public projects with \"simple\" fields are returned.",
                    HelpLink = "https://docs.gitlab.com/ee/api/projects.html#list-all-projects"
                },
                ReturnType = _project,
                MethodType = MethodType.GetPaged,
                Parameters =
                {
                    new MethodParameter("archived", ModelRef.NullableBoolean) { IsOptional = true },
                    new MethodParameter("visibility", new ModelRef(_projectVisibility) { IsNullable = true }) { IsOptional = true },
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
                    new MethodParameter("min_access_level", new ModelRef(_access) { IsNullable = true }) { IsOptional = true },
                }
            });

            Project.AddMethod(new Method("GetProjects", "users/:user/projects")
            {
                Documentation = new Documentation
                {
                    Summary = "Get a list of visible projects for the given user. When accessed without authentication, only public projects are returned.",
                    HelpLink = "https://docs.gitlab.com/ee/api/projects.html#list-user-projects"
                },
                ReturnType = _project,
                MethodType = MethodType.GetPaged,
                Parameters =
                {
                    new MethodParameter("user", _userRef),
                    new MethodParameter("archived", ModelRef.NullableBoolean) { IsOptional = true },
                    new MethodParameter("visibility", new ModelRef(_projectVisibility) { IsNullable = true }) { IsOptional = true },
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
                    new MethodParameter("min_access_level", new ModelRef(_access) { IsNullable = true }) { IsOptional = true },
                }
            });

            Project.AddMethod(new Method("GetProject", "projects/:id")
            {
                Documentation = new Documentation
                {
                    Summary = "Get a specific project. This endpoint can be accessed without authentication if the project is publicly accessible.",
                    HelpLink = "https://docs.gitlab.com/ee/api/projects.html#get-single-project"
                },
                ReturnType = _project,
                MethodType = MethodType.Get,
                Parameters =
                {
                    new MethodParameter("id", _projectIdOrPathRef),
                }
            });
        }

        private void CreateTodoMethods()
        {
            Project.AddMethod(new Method("GetTodos", "todos")
            {
                Documentation = new Documentation
                {
                    Summary = "Returns a list of todos. When no filter is applied, it returns all pending todos for the current user. Different filters allow the user to precise the request.",
                    HelpLink = "https://docs.gitlab.com/ee/api/todos.html#get-a-list-of-todos"
                },
                ReturnType = _todo,
                MethodType = MethodType.GetPaged,
                Parameters =
                {
                    new MethodParameter("action", new ModelRef(_todoAction) { IsNullable = true }) { IsOptional = true },
                }
            });
        }

        private void CreateMergeRequestsMethods()
        {
            Project.AddMethod(new Method("GetMergeRequests", "merge_requests")
            {
                Documentation = new Documentation
                {
                    Summary = "Get all merge requests the authenticated user has access to. By default it returns only merge requests created by the current user. To get all merge requests, use parameter scope=all.",
                    HelpLink = "https://docs.gitlab.com/ee/api/merge_requests.html#list-merge-requests"
                },
                ReturnType = _mergeRequest,
                MethodType = MethodType.GetPaged,
                Parameters =
                {
                    new MethodParameter("state", new ModelRef(_mergeRequestState) { IsNullable = true }) { IsOptional = true },
                    new MethodParameter("scope", new ModelRef(_mergeRequestScopeFilter) { IsNullable = true }) { IsOptional = true },
                    new MethodParameter("assignee_id", new ModelRef(_userRef) { IsNullable = true }) { IsOptional = true },
                }
            });

            Project.AddMethod(new Method("GetMergeRequests", "projects/:project/merge_requests")
            {
                Documentation = new Documentation
                {
                    Summary = "Get all merge requests for this project.",
                    HelpLink = "https://docs.gitlab.com/ee/api/merge_requests.html#list-project-merge-requests"
                },
                ReturnType = _mergeRequest,
                MethodType = MethodType.GetPaged,
                Parameters =
                {
                    new MethodParameter("project", _projectIdOrPathRef),
                    new MethodParameter("state", new ModelRef(_mergeRequestState) { IsNullable = true }) { IsOptional = true },
                }
            });
        }
    }
}
