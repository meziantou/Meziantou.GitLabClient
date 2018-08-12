using Newtonsoft.Json;

namespace Meziantou.GitLabClient.Generator
{
    partial class Program
    {
        private Enumeration _access;
        private Enumeration _importStatus;
        private Enumeration _mergeMethod;
        private Enumeration _projectVisibility;
        private Enumeration _userState;

        private Entity _basicProjectDetails;
        private Entity _groupAccess;
        private Entity _identityModel;
        private Entity _memberAccess;
        private Entity _namespaceBasic;
        private Entity _project;
        private Entity _projectAccess;
        private Entity _projectIdentity;
        private Entity _sharedGroup;
        private Entity _sshKey;
        private Entity _userActivity;
        private Entity _userBasicModel;
        private Entity _userModel;
        private Entity _userSafeModel;
        private Entity _userStatus;

        private ParameterEntity _projectRef;
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
                    new EnumerationMember("Guest", 10),
                    new EnumerationMember("Reporter", 20),
                    new EnumerationMember("Developer", 30),
                    new EnumerationMember("Maintainer", 40),
                    new EnumerationMember("Owner", 50),
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
                    new EnumerationMember("None"),
                    new EnumerationMember("Scheduled"),
                    new EnumerationMember("Failed"),
                    new EnumerationMember("Started"),
                    new EnumerationMember("Finished"),
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
                    new EnumerationMember("Merge")
                    {
                        Documentation = "A merge commit is created for every merge, and merging is allowed as long as there are no conflicts."
                    },
                    new EnumerationMember("RebaseMerge")
                    {
                        Documentation = "A merge commit is created for every merge, but merging is only allowed if fast-forward merge is possible. This way you could make sure that if this merge request would build, after merging to target branch it would also build."
                    },
                    new EnumerationMember("FastForward")
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
                    new EnumerationMember("Private"),
                    new EnumerationMember("Internal"),
                    new EnumerationMember("Public"),
                }
            });

            _userState = Project.AddModel(new Enumeration("UserState")
            {
                Members =
                {
                    new EnumerationMember("Active"),
                    new EnumerationMember("Blocked"),
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
                    new EntityProperty("Provider", ModelRef.String),
                    new EntityProperty("ExternUid", ModelRef.String),
                }
            });

            // https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L13
            _userSafeModel = Project.AddModel(new Entity("UserSafe")
            {
                Properties =
                {
                    new EntityProperty("Id", ModelRef.Id),
                    new EntityProperty("Name", ModelRef.String),
                    new EntityProperty("Username", ModelRef.String),
                }
            });

            // https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L17
            _userBasicModel = Project.AddModel(new Entity("UserBasic")
            {
                BaseType = _userSafeModel,
                Properties =
                {
                    new EntityProperty("AvatarUrl", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("AvatarPath", ModelRef.String) { Required = Required.Default },
                    new EntityProperty("State", _userState),
                    new EntityProperty("WebUrl", ModelRef.String),
                }
            });

            // https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L32
            _userModel = Project.AddModel(new Entity("User")
            {
                BaseType = _userBasicModel,
                Properties =
                {
                    new EntityProperty("Bio", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("CanCreateGroup", ModelRef.NullableBoolean) { Required = Required.Default },
                    new EntityProperty("CanCreateProject", ModelRef.NullableBoolean) { Required = Required.Default },
                    new EntityProperty("ColorSchemeId", ModelRef.NullableId) { Required = Required.Default },
                    new EntityProperty("ConfirmedAt", ModelRef.NullableDateTime) { Required = Required.Default },
                    new EntityProperty("CreatedAt", ModelRef.DateTime),
                    new EntityProperty("CurrentSignInAt", ModelRef.NullableDateTime) { Required = Required.Default },
                    new EntityProperty("Email", ModelRef.String) { Required = Required.Default },
                    new EntityProperty("External", ModelRef.NullableBoolean) { Required = Required.Default },
                    new EntityProperty("Identities", new ModelRef(_identityModel) { IsCollection = true }) { Required = Required.Default },
                    new EntityProperty("IsAdmin", ModelRef.NullableBoolean) { Required = Required.Default },
                    new EntityProperty("LastActivityOn", ModelRef.NullableDate) { Required = Required.Default },
                    new EntityProperty("LastSignInAt", ModelRef.NullableDateTime) { Required = Required.Default },
                    new EntityProperty("Linkedin", ModelRef.String),
                    new EntityProperty("Location", ModelRef.String) { Required = Required.Default },
                    new EntityProperty("Organization", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("PrivateProfile", ModelRef.Object) { Required = Required.Default },
                    new EntityProperty("ProjectsLimit", ModelRef.NullableInt64) { Required = Required.Default },
                    new EntityProperty("SharedRunnersMinutesLimit", ModelRef.NullableInt64) { Required = Required.Default },
                    new EntityProperty("Skype", ModelRef.String),
                    new EntityProperty("ThemeId", ModelRef.NullableId) { Required = Required.Default },
                    new EntityProperty("Twitter", ModelRef.String),
                    new EntityProperty("TwoFactorEnabled", ModelRef.NullableBoolean) { Required = Required.Default },
                    new EntityProperty("WebsiteUrl", ModelRef.String),
                }
            });

            // https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L65
            _userStatus = Project.AddModel(new Entity("UserStatus")
            {
                Properties =
                {
                    new EntityProperty("Emoji", ModelRef.String),
                    new EntityProperty("Message", ModelRef.String),
                    new EntityProperty("MessageHtml", ModelRef.String),
                }
            });

            // https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L37
            _userActivity = Project.AddModel(new Entity("UserActivity")
            {
                Properties =
                {
                    new EntityProperty("Username", ModelRef.String),
                    new EntityProperty("LastActivityOn", ModelRef.Date),
                }
            });

            _sshKey = Project.AddModel(new Entity("SshKey")
            {
                Properties =
                {
                    new EntityProperty("Id", ModelRef.Id),
                    new EntityProperty("Title", ModelRef.String),
                    new EntityProperty("Key", ModelRef.String),
                    new EntityProperty("CreatedAt", ModelRef.DateTime),
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
                    new EntityProperty("GroupId", ModelRef.Id),
                    new EntityProperty("GroupName", ModelRef.String),
                    new EntityProperty("GroupAccessLevel", _access),
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
                    new EntityProperty("AccessLevel", _access),
                    new EntityProperty("NotificationLevel", ModelRef.String),
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
                    new EntityProperty("Id", ModelRef.Id),
                    new EntityProperty("Name", ModelRef.String),
                    new EntityProperty("Path", ModelRef.String),
                    new EntityProperty("Kind", ModelRef.String),
                    new EntityProperty("FullPath", ModelRef.String),
                    new EntityProperty("ParentId", ModelRef.NullableId),
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
                    new EntityProperty("CreatedAt", ModelRef.DateTime),
                    new EntityProperty("Description", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("Id", ModelRef.Id),
                    new EntityProperty("Name", ModelRef.String),
                    new EntityProperty("NameWithNamespace", ModelRef.String),
                    new EntityProperty("Path", ModelRef.String),
                    new EntityProperty("PathWithNamespace", ModelRef.String),
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
                    new EntityProperty("AvatarUrl", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("DefaultBranch", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("ForksCount", ModelRef.Int64),
                    new EntityProperty("HttpUrlToRepo", ModelRef.String),
                    new EntityProperty("LastActivityAt", ModelRef.DateTime),
                    new EntityProperty("Namespace", _namespaceBasic),
                    new EntityProperty("ReadmeUrl", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("SshUrlToRepo", ModelRef.String),
                    new EntityProperty("StarCount", ModelRef.Int64),
                    new EntityProperty("TagList", ModelRef.StringCollection),
                    new EntityProperty("WebUrl", ModelRef.String),
                }
            });

            var projectLinks = Project.AddModel(new Entity("ProjectLink")
            {
                Properties =
                {
                    new EntityProperty("Events", ModelRef.String),
                    new EntityProperty("Issues", ModelRef.String) { Required = Required.Default },
                    new EntityProperty("Labels", ModelRef.String),
                    new EntityProperty("Members", ModelRef.String),
                    new EntityProperty("MergeRequests", ModelRef.String) { Required = Required.Default },
                    new EntityProperty("RepoBranches", ModelRef.String),
                    new EntityProperty("Self", ModelRef.String),
                }
            });

            var permissions = Project.AddModel(new Entity("ProjectPermissions")
            {
                Properties =
                {
                    new EntityProperty("GroupAccess", _groupAccess),
                    new EntityProperty("ProjectAccess", _projectAccess),
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
                    new EntityProperty("ApprovalsBeforeMerge", ModelRef.NullableInt32) { Required = Required.Default },
                    new EntityProperty("Archived", ModelRef.Boolean),
                    new EntityProperty("CiConfigPath", ModelRef.String) { Required = Required.AllowNull },
                    new EntityProperty("ContainerRegistryEnabled", ModelRef.Boolean),
                    new EntityProperty("CreatorId", ModelRef.Id),
                    new EntityProperty("ForkedFromProject", _basicProjectDetails) { Required = Required.Default },
                    new EntityProperty("ImportStatus", _importStatus),
                    new EntityProperty("IssuesEnabled", ModelRef.Boolean),
                    new EntityProperty("JobsEnabled", ModelRef.Boolean),
                    new EntityProperty("LfsEnabled", ModelRef.Boolean),
                    new EntityProperty("Links", projectLinks) { SerializationName = "_links" },
                    new EntityProperty("MergeMethod", _mergeMethod),
                    new EntityProperty("MergeRequestsEnabled", ModelRef.Boolean),
                    new EntityProperty("Mirror", ModelRef.Boolean),
                    new EntityProperty("MirrorUserId", ModelRef.NullableId) { Required = Required.Default },
                    new EntityProperty("MirrorTriggerBuilds", ModelRef.NullableBoolean) { Required = Required.Default },
                    new EntityProperty("MirrorOverwritesDivergedBranches", ModelRef.NullableBoolean) { Required = Required.Default },
                    new EntityProperty("OnlyAllowMergeIfAllDiscussionsAreResolved", ModelRef.Boolean),
                    new EntityProperty("OnlyAllowMergeIfPipelineSucceeds", ModelRef.Boolean),
                    new EntityProperty("OnlyMirrorProtectedBranches", ModelRef.NullableBoolean) { Required = Required.Default },
                    new EntityProperty("OpenIssuesCount", ModelRef.NullableInt32),
                    new EntityProperty("Owner", _userBasicModel) { Required = Required.Default },
                    new EntityProperty("Permissions", permissions),
                    new EntityProperty("PrintingMergeRequestLinkEnabled", ModelRef.Boolean),
                    new EntityProperty("PublicJobs", ModelRef.Boolean),
                    new EntityProperty("RequestAccessEnabled", ModelRef.Boolean),
                    new EntityProperty("ResolveOutdatedDiffDiscussions", ModelRef.Boolean),
                    new EntityProperty("SharedRunnersEnabled", ModelRef.Boolean),
                    new EntityProperty("SharedWithGroups", new ModelRef(_sharedGroup) { IsCollection = true }),
                    new EntityProperty("SnippetsEnabled", ModelRef.Boolean),
                    new EntityProperty("Visibility", _projectVisibility),
                    new EntityProperty("WikiEnabled", ModelRef.Boolean),
                }
            });

        }

        private void CreateRefs()
        {
            _projectRef = Project.AddParameterEntity(new ParameterEntity("ProjectRef", ModelRef.Object)
            {
                Refs =
                {
                    new ParameterEntityRef(ModelRef.Id),
                    new ParameterEntityRef(_projectIdentity, "Id"),
                }
            });

            _sshKeyRef = Project.AddParameterEntity(new ParameterEntity("SshKeyRef", ModelRef.Object)
            {
                Refs =
                {
                    new ParameterEntityRef(ModelRef.Id),
                    new ParameterEntityRef(_sshKey, "Id"),
                }
            });

            _userRef = Project.AddParameterEntity(new ParameterEntity("UserRef", ModelRef.Object)
            {
                Refs =
                {
                    new ParameterEntityRef(ModelRef.Id),
                    new ParameterEntityRef(ModelRef.String),
                    new ParameterEntityRef(_userSafeModel, "Id"),
                }
            });
        }

        private void CreateUserMethods()
        {
            Project.AddMethod(new Method("GetUser", "user")
            {
                ReturnType = _userModel,
                Documentation = new Documentation
                {
                    Summary = "Gets currently authenticated user.",
                    HelpLink = "https://docs.gitlab.com/ee/api/users.html#user",
                },
            });

            Project.AddMethod(new Method("GetUser", "users/:id")
            {
                ReturnType = _userModel,
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
                ReturnType = new ModelRef(_userBasicModel),
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

            var setUserStatus = Project.AddRequestPayload(new Entity("SetUserStatus")
            {
                Properties =
                {
                    new EntityProperty("Emoji", ModelRef.String)
                    {
                        Documentation = new Documentation
                        {
                            Summary = "The name of the emoji to use as status, if omitted speech_balloon is used. Emoji name can be one of the specified names in the Gemojione index."
                        }
                    },
                    new EntityProperty("Message", ModelRef.String)
                    {
                        Documentation = new Documentation
                        {
                            Summary = "The message to set as a status. It can also contain emoji codes."
                        }
                    },
                }
            });

            Project.AddMethod(new Method("SetUserStatus", "user/status")
            {
                MethodType = MethodType.Put,
                ReturnType = new ModelRef(_userStatus),
                Parameters =
                {
                    new MethodParameter("status", setUserStatus) { Location = ParameterLocation.Body }
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

            var addSshKey = Project.AddRequestPayload(new Entity("AddSshKey")
            {
                Properties =
                {
                    new EntityProperty("Title", ModelRef.String)
                    {
                        Documentation = new Documentation
                        {
                            Summary = "new SSH Key's title"
                        }
                    },
                    new EntityProperty("Key", ModelRef.String)
                    {
                        Documentation = new Documentation
                        {
                            Summary = "new SSH key"
                        }
                    },
                }
            });

            Project.AddMethod(new Method("AddSshKey", "user/keys")
            {
                MethodType = MethodType.Post,
                ReturnType = new ModelRef(_sshKey),
                Parameters =
                {
                    new MethodParameter("sshKey", addSshKey) { Location = ParameterLocation.Body }
                },
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
                Parameters =
                {
                    new MethodParameter("user", ModelRef.String)
                    {
                        Documentation = "new SSH Key's title"
                    },
                    new MethodParameter("sshKey", addSshKey)
                    {
                        Location = ParameterLocation.Body
                    }
                },
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
                MethodType = MethodType.GetPaged,
                Parameters =
                {
                    new MethodParameter("id", _projectRef),
                }
            });
        }
    }
}
