namespace Meziantou.GitLab
{
    public enum Access
    {
        Guest = 10,
        Reporter = 20,
        Developer = 30,
        Maintainer = 40,
        Owner = 50
    }

    public partial class BasicProjectDetails : ProjectIdentity
    {
        private string _avatarUrl;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "avatar_url", Required = Newtonsoft.Json.Required.AllowNull)]
        public string AvatarUrl
        {
            get
            {
                return this._avatarUrl;
            }
            private set
            {
                this._avatarUrl = value;
            }
        }

        private string _defaultBranch;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "default_branch", Required = Newtonsoft.Json.Required.AllowNull)]
        public string DefaultBranch
        {
            get
            {
                return this._defaultBranch;
            }
            private set
            {
                this._defaultBranch = value;
            }
        }

        private long _forksCount;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "forks_count", Required = Newtonsoft.Json.Required.Always)]
        public long ForksCount
        {
            get
            {
                return this._forksCount;
            }
            private set
            {
                this._forksCount = value;
            }
        }

        private string _httpUrlToRepo;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "http_url_to_repo", Required = Newtonsoft.Json.Required.Always)]
        public string HttpUrlToRepo
        {
            get
            {
                return this._httpUrlToRepo;
            }
            private set
            {
                this._httpUrlToRepo = value;
            }
        }

        private System.DateTime _lastActivityAt;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "last_activity_at", Required = Newtonsoft.Json.Required.Always)]
        public System.DateTime LastActivityAt
        {
            get
            {
                return this._lastActivityAt;
            }
            private set
            {
                this._lastActivityAt = value;
            }
        }

        private NamespaceBasic _namespace;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "namespace", Required = Newtonsoft.Json.Required.AllowNull)]
        public NamespaceBasic Namespace
        {
            get
            {
                return this._namespace;
            }
            private set
            {
                this._namespace = value;
            }
        }

        private string _readmeUrl;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "readme_url", Required = Newtonsoft.Json.Required.AllowNull)]
        public string ReadmeUrl
        {
            get
            {
                return this._readmeUrl;
            }
            private set
            {
                this._readmeUrl = value;
            }
        }

        private string _sshUrlToRepo;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "ssh_url_to_repo", Required = Newtonsoft.Json.Required.Always)]
        public string SshUrlToRepo
        {
            get
            {
                return this._sshUrlToRepo;
            }
            private set
            {
                this._sshUrlToRepo = value;
            }
        }

        private long _starCount;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "star_count", Required = Newtonsoft.Json.Required.Always)]
        public long StarCount
        {
            get
            {
                return this._starCount;
            }
            private set
            {
                this._starCount = value;
            }
        }

        private System.Collections.Generic.IReadOnlyList<string> _tagList;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "tag_list", Required = Newtonsoft.Json.Required.Always)]
        public System.Collections.Generic.IReadOnlyList<string> TagList
        {
            get
            {
                return this._tagList;
            }
            private set
            {
                this._tagList = value;
            }
        }

        private string _webUrl;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "web_url", Required = Newtonsoft.Json.Required.Always)]
        public string WebUrl
        {
            get
            {
                return this._webUrl;
            }
            private set
            {
                this._webUrl = value;
            }
        }
    }

    public partial class GroupAccess : MemberAccess
    {
    }

    public partial class Identity : GitLab.GitLabObject
    {
        private string _provider;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "provider", Required = Newtonsoft.Json.Required.Always)]
        public string Provider
        {
            get
            {
                return this._provider;
            }
            private set
            {
                this._provider = value;
            }
        }

        private string _externUid;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "extern_uid", Required = Newtonsoft.Json.Required.Always)]
        public string ExternUid
        {
            get
            {
                return this._externUid;
            }
            private set
            {
                this._externUid = value;
            }
        }
    }

    public partial class ImpersonationToken : GitLab.GitLabObject
    {
        private long _id;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "id", Required = Newtonsoft.Json.Required.Always)]
        public long Id
        {
            get
            {
                return this._id;
            }
            private set
            {
                this._id = value;
            }
        }

        private bool _revoked;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "revoked", Required = Newtonsoft.Json.Required.Always)]
        public bool Revoked
        {
            get
            {
                return this._revoked;
            }
            private set
            {
                this._revoked = value;
            }
        }

        private System.Collections.Generic.IReadOnlyList<string> _scopes;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "scopes", Required = Newtonsoft.Json.Required.Always)]
        public System.Collections.Generic.IReadOnlyList<string> Scopes
        {
            get
            {
                return this._scopes;
            }
            private set
            {
                this._scopes = value;
            }
        }

        private string _token;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "token", Required = Newtonsoft.Json.Required.Always)]
        public string Token
        {
            get
            {
                return this._token;
            }
            private set
            {
                this._token = value;
            }
        }

        private bool _active;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "active", Required = Newtonsoft.Json.Required.Always)]
        public bool Active
        {
            get
            {
                return this._active;
            }
            private set
            {
                this._active = value;
            }
        }

        private bool _impersonation;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "impersonation", Required = Newtonsoft.Json.Required.Always)]
        public bool Impersonation
        {
            get
            {
                return this._impersonation;
            }
            private set
            {
                this._impersonation = value;
            }
        }

        private string _name;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "name", Required = Newtonsoft.Json.Required.Always)]
        public string Name
        {
            get
            {
                return this._name;
            }
            private set
            {
                this._name = value;
            }
        }

        private System.DateTime _createdAt;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "created_at", Required = Newtonsoft.Json.Required.Always)]
        public System.DateTime CreatedAt
        {
            get
            {
                return this._createdAt;
            }
            private set
            {
                this._createdAt = value;
            }
        }

        private System.Nullable<System.DateTime> _expiresAt;

        [Meziantou.GitLab.SkipUtcDateValidationAttribute("Does not contain time nor timezone (e.g. 2018-01-01)")]
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "expires_at", Required = Newtonsoft.Json.Required.AllowNull)]
        public System.Nullable<System.DateTime> ExpiresAt
        {
            get
            {
                return this._expiresAt;
            }
            private set
            {
                this._expiresAt = value;
            }
        }
    }

    public enum ImportStatus
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "none")]
        None,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "scheduled")]
        Scheduled,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "failed")]
        Failed,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "started")]
        Started,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "finished")]
        Finished
    }

    public partial class MemberAccess : GitLab.GitLabObject
    {
        private Access _accessLevel;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "access_level", Required = Newtonsoft.Json.Required.AllowNull)]
        public Access AccessLevel
        {
            get
            {
                return this._accessLevel;
            }
            private set
            {
                this._accessLevel = value;
            }
        }

        private string _notificationLevel;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "notification_level", Required = Newtonsoft.Json.Required.Always)]
        public string NotificationLevel
        {
            get
            {
                return this._notificationLevel;
            }
            private set
            {
                this._notificationLevel = value;
            }
        }
    }

    public enum MergeMethod
    {
        /// <summary>A merge commit is created for every merge, and merging is allowed as long as there are no conflicts.</summary>
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "merge")]
        Merge,
        /// <summary>A merge commit is created for every merge, but merging is only allowed if fast-forward merge is possible. This way you could make sure that if this merge request would build, after merging to target branch it would also build.</summary>
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "rebase_merge")]
        RebaseMerge,
        /// <summary>No merge commits are created and all merges are fast-forwarded, which means that merging is only allowed if the branch could be fast-forwarded.</summary>
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "ff")]
        FastForward
    }

    public partial class MergeRequest : GitLab.GitLabObject
    {
        private long _id;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "id", Required = Newtonsoft.Json.Required.Always)]
        public long Id
        {
            get
            {
                return this._id;
            }
            private set
            {
                this._id = value;
            }
        }

        private long _iid;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "iid", Required = Newtonsoft.Json.Required.Always)]
        public long Iid
        {
            get
            {
                return this._iid;
            }
            private set
            {
                this._iid = value;
            }
        }

        private UserBasic _author;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "author", Required = Newtonsoft.Json.Required.AllowNull)]
        public UserBasic Author
        {
            get
            {
                return this._author;
            }
            private set
            {
                this._author = value;
            }
        }

        private string _title;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "title", Required = Newtonsoft.Json.Required.Always)]
        public string Title
        {
            get
            {
                return this._title;
            }
            private set
            {
                this._title = value;
            }
        }

        private MergeRequestState _state;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "state", Required = Newtonsoft.Json.Required.AllowNull)]
        public MergeRequestState State
        {
            get
            {
                return this._state;
            }
            private set
            {
                this._state = value;
            }
        }

        private long _projectId;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "project_id", Required = Newtonsoft.Json.Required.Always)]
        public long ProjectId
        {
            get
            {
                return this._projectId;
            }
            private set
            {
                this._projectId = value;
            }
        }

        private string _webUrl;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "web_url", Required = Newtonsoft.Json.Required.Always)]
        public string WebUrl
        {
            get
            {
                return this._webUrl;
            }
            private set
            {
                this._webUrl = value;
            }
        }

        private System.DateTime _createdAt;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "created_at", Required = Newtonsoft.Json.Required.Always)]
        public System.DateTime CreatedAt
        {
            get
            {
                return this._createdAt;
            }
            private set
            {
                this._createdAt = value;
            }
        }

        private System.DateTime _updatedAt;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "updated_at", Required = Newtonsoft.Json.Required.Always)]
        public System.DateTime UpdatedAt
        {
            get
            {
                return this._updatedAt;
            }
            private set
            {
                this._updatedAt = value;
            }
        }

        private string _mergeStatus;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "merge_status", Required = Newtonsoft.Json.Required.Always)]
        public string MergeStatus
        {
            get
            {
                return this._mergeStatus;
            }
            private set
            {
                this._mergeStatus = value;
            }
        }

        private int _userNotesCount;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "user_notes_count", Required = Newtonsoft.Json.Required.Always)]
        public int UserNotesCount
        {
            get
            {
                return this._userNotesCount;
            }
            private set
            {
                this._userNotesCount = value;
            }
        }
    }

    public enum MergeRequestScopeFilter
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "assigned_to_me")]
        AssignedToMe,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "all")]
        All
    }

    public enum MergeRequestState
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "opened")]
        Opened,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "closed")]
        Closed,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "locked")]
        Locked,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "merged")]
        Merged
    }

    [System.FlagsAttribute]
    public enum MergeRequestStateFilter
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "default")]
        Default = 0,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "opened")]
        Opened = 1,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "closed")]
        Closed = 2,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "locked")]
        Locked = 4,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "merged")]
        Merged = 8,
        All = ((((Meziantou.GitLab.MergeRequestStateFilter.Default | Meziantou.GitLab.MergeRequestStateFilter.Opened) | Meziantou.GitLab.MergeRequestStateFilter.Closed) | Meziantou.GitLab.MergeRequestStateFilter.Locked) | Meziantou.GitLab.MergeRequestStateFilter.Merged)
    }

    public partial class NamespaceBasic : GitLab.GitLabObject
    {
        private long _id;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "id", Required = Newtonsoft.Json.Required.Always)]
        public long Id
        {
            get
            {
                return this._id;
            }
            private set
            {
                this._id = value;
            }
        }

        private string _name;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "name", Required = Newtonsoft.Json.Required.Always)]
        public string Name
        {
            get
            {
                return this._name;
            }
            private set
            {
                this._name = value;
            }
        }

        private string _path;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "path", Required = Newtonsoft.Json.Required.Always)]
        public string Path
        {
            get
            {
                return this._path;
            }
            private set
            {
                this._path = value;
            }
        }

        private string _kind;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "kind", Required = Newtonsoft.Json.Required.Always)]
        public string Kind
        {
            get
            {
                return this._kind;
            }
            private set
            {
                this._kind = value;
            }
        }

        private string _fullPath;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "full_path", Required = Newtonsoft.Json.Required.Always)]
        public string FullPath
        {
            get
            {
                return this._fullPath;
            }
            private set
            {
                this._fullPath = value;
            }
        }

        private System.Nullable<long> _parentId;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "parent_id", Required = Newtonsoft.Json.Required.AllowNull)]
        public System.Nullable<long> ParentId
        {
            get
            {
                return this._parentId;
            }
            private set
            {
                this._parentId = value;
            }
        }
    }

    public partial class Project : BasicProjectDetails
    {
        private System.Nullable<int> _approvalsBeforeMerge;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "approvals_before_merge", Required = Newtonsoft.Json.Required.Default)]
        public System.Nullable<int> ApprovalsBeforeMerge
        {
            get
            {
                return this._approvalsBeforeMerge;
            }
            private set
            {
                this._approvalsBeforeMerge = value;
            }
        }

        private bool _archived;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "archived", Required = Newtonsoft.Json.Required.Always)]
        public bool Archived
        {
            get
            {
                return this._archived;
            }
            private set
            {
                this._archived = value;
            }
        }

        private string _ciConfigPath;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "ci_config_path", Required = Newtonsoft.Json.Required.AllowNull)]
        public string CiConfigPath
        {
            get
            {
                return this._ciConfigPath;
            }
            private set
            {
                this._ciConfigPath = value;
            }
        }

        private bool _containerRegistryEnabled;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "container_registry_enabled", Required = Newtonsoft.Json.Required.Always)]
        public bool ContainerRegistryEnabled
        {
            get
            {
                return this._containerRegistryEnabled;
            }
            private set
            {
                this._containerRegistryEnabled = value;
            }
        }

        private long _creatorId;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "creator_id", Required = Newtonsoft.Json.Required.Always)]
        public long CreatorId
        {
            get
            {
                return this._creatorId;
            }
            private set
            {
                this._creatorId = value;
            }
        }

        private BasicProjectDetails _forkedFromProject;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "forked_from_project", Required = Newtonsoft.Json.Required.Default)]
        public BasicProjectDetails ForkedFromProject
        {
            get
            {
                return this._forkedFromProject;
            }
            private set
            {
                this._forkedFromProject = value;
            }
        }

        private ImportStatus _importStatus;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "import_status", Required = Newtonsoft.Json.Required.AllowNull)]
        public ImportStatus ImportStatus
        {
            get
            {
                return this._importStatus;
            }
            private set
            {
                this._importStatus = value;
            }
        }

        private bool _issuesEnabled;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "issues_enabled", Required = Newtonsoft.Json.Required.Always)]
        public bool IssuesEnabled
        {
            get
            {
                return this._issuesEnabled;
            }
            private set
            {
                this._issuesEnabled = value;
            }
        }

        private bool _jobsEnabled;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "jobs_enabled", Required = Newtonsoft.Json.Required.Always)]
        public bool JobsEnabled
        {
            get
            {
                return this._jobsEnabled;
            }
            private set
            {
                this._jobsEnabled = value;
            }
        }

        private bool _lfsEnabled;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "lfs_enabled", Required = Newtonsoft.Json.Required.Always)]
        public bool LfsEnabled
        {
            get
            {
                return this._lfsEnabled;
            }
            private set
            {
                this._lfsEnabled = value;
            }
        }

        private ProjectLink _links;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "_links", Required = Newtonsoft.Json.Required.AllowNull)]
        public ProjectLink Links
        {
            get
            {
                return this._links;
            }
            private set
            {
                this._links = value;
            }
        }

        private MergeMethod _mergeMethod;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "merge_method", Required = Newtonsoft.Json.Required.AllowNull)]
        public MergeMethod MergeMethod
        {
            get
            {
                return this._mergeMethod;
            }
            private set
            {
                this._mergeMethod = value;
            }
        }

        private bool _mergeRequestsEnabled;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "merge_requests_enabled", Required = Newtonsoft.Json.Required.Always)]
        public bool MergeRequestsEnabled
        {
            get
            {
                return this._mergeRequestsEnabled;
            }
            private set
            {
                this._mergeRequestsEnabled = value;
            }
        }

        private bool _mirror;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "mirror", Required = Newtonsoft.Json.Required.Always)]
        public bool Mirror
        {
            get
            {
                return this._mirror;
            }
            private set
            {
                this._mirror = value;
            }
        }

        private System.Nullable<long> _mirrorUserId;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "mirror_user_id", Required = Newtonsoft.Json.Required.Default)]
        public System.Nullable<long> MirrorUserId
        {
            get
            {
                return this._mirrorUserId;
            }
            private set
            {
                this._mirrorUserId = value;
            }
        }

        private System.Nullable<bool> _mirrorTriggerBuilds;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "mirror_trigger_builds", Required = Newtonsoft.Json.Required.Default)]
        public System.Nullable<bool> MirrorTriggerBuilds
        {
            get
            {
                return this._mirrorTriggerBuilds;
            }
            private set
            {
                this._mirrorTriggerBuilds = value;
            }
        }

        private System.Nullable<bool> _mirrorOverwritesDivergedBranches;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "mirror_overwrites_diverged_branches", Required = Newtonsoft.Json.Required.Default)]
        public System.Nullable<bool> MirrorOverwritesDivergedBranches
        {
            get
            {
                return this._mirrorOverwritesDivergedBranches;
            }
            private set
            {
                this._mirrorOverwritesDivergedBranches = value;
            }
        }

        private bool _onlyAllowMergeIfAllDiscussionsAreResolved;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "only_allow_merge_if_all_discussions_are_resolved", Required = Newtonsoft.Json.Required.Always)]
        public bool OnlyAllowMergeIfAllDiscussionsAreResolved
        {
            get
            {
                return this._onlyAllowMergeIfAllDiscussionsAreResolved;
            }
            private set
            {
                this._onlyAllowMergeIfAllDiscussionsAreResolved = value;
            }
        }

        private bool _onlyAllowMergeIfPipelineSucceeds;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "only_allow_merge_if_pipeline_succeeds", Required = Newtonsoft.Json.Required.Always)]
        public bool OnlyAllowMergeIfPipelineSucceeds
        {
            get
            {
                return this._onlyAllowMergeIfPipelineSucceeds;
            }
            private set
            {
                this._onlyAllowMergeIfPipelineSucceeds = value;
            }
        }

        private System.Nullable<bool> _onlyMirrorProtectedBranches;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "only_mirror_protected_branches", Required = Newtonsoft.Json.Required.Default)]
        public System.Nullable<bool> OnlyMirrorProtectedBranches
        {
            get
            {
                return this._onlyMirrorProtectedBranches;
            }
            private set
            {
                this._onlyMirrorProtectedBranches = value;
            }
        }

        private System.Nullable<int> _openIssuesCount;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "open_issues_count", Required = Newtonsoft.Json.Required.AllowNull)]
        public System.Nullable<int> OpenIssuesCount
        {
            get
            {
                return this._openIssuesCount;
            }
            private set
            {
                this._openIssuesCount = value;
            }
        }

        private UserBasic _owner;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "owner", Required = Newtonsoft.Json.Required.Default)]
        public UserBasic Owner
        {
            get
            {
                return this._owner;
            }
            private set
            {
                this._owner = value;
            }
        }

        private ProjectPermissions _permissions;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "permissions", Required = Newtonsoft.Json.Required.AllowNull)]
        public ProjectPermissions Permissions
        {
            get
            {
                return this._permissions;
            }
            private set
            {
                this._permissions = value;
            }
        }

        private bool _printingMergeRequestLinkEnabled;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "printing_merge_request_link_enabled", Required = Newtonsoft.Json.Required.Always)]
        public bool PrintingMergeRequestLinkEnabled
        {
            get
            {
                return this._printingMergeRequestLinkEnabled;
            }
            private set
            {
                this._printingMergeRequestLinkEnabled = value;
            }
        }

        private bool _publicJobs;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "public_jobs", Required = Newtonsoft.Json.Required.Always)]
        public bool PublicJobs
        {
            get
            {
                return this._publicJobs;
            }
            private set
            {
                this._publicJobs = value;
            }
        }

        private bool _requestAccessEnabled;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "request_access_enabled", Required = Newtonsoft.Json.Required.Always)]
        public bool RequestAccessEnabled
        {
            get
            {
                return this._requestAccessEnabled;
            }
            private set
            {
                this._requestAccessEnabled = value;
            }
        }

        private bool _resolveOutdatedDiffDiscussions;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "resolve_outdated_diff_discussions", Required = Newtonsoft.Json.Required.Always)]
        public bool ResolveOutdatedDiffDiscussions
        {
            get
            {
                return this._resolveOutdatedDiffDiscussions;
            }
            private set
            {
                this._resolveOutdatedDiffDiscussions = value;
            }
        }

        private bool _sharedRunnersEnabled;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "shared_runners_enabled", Required = Newtonsoft.Json.Required.Always)]
        public bool SharedRunnersEnabled
        {
            get
            {
                return this._sharedRunnersEnabled;
            }
            private set
            {
                this._sharedRunnersEnabled = value;
            }
        }

        private System.Collections.Generic.IReadOnlyList<SharedGroup> _sharedWithGroups;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "shared_with_groups", Required = Newtonsoft.Json.Required.AllowNull)]
        public System.Collections.Generic.IReadOnlyList<SharedGroup> SharedWithGroups
        {
            get
            {
                return this._sharedWithGroups;
            }
            private set
            {
                this._sharedWithGroups = value;
            }
        }

        private bool _snippetsEnabled;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "snippets_enabled", Required = Newtonsoft.Json.Required.Always)]
        public bool SnippetsEnabled
        {
            get
            {
                return this._snippetsEnabled;
            }
            private set
            {
                this._snippetsEnabled = value;
            }
        }

        private ProjectVisibility _visibility;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "visibility", Required = Newtonsoft.Json.Required.AllowNull)]
        public ProjectVisibility Visibility
        {
            get
            {
                return this._visibility;
            }
            private set
            {
                this._visibility = value;
            }
        }

        private bool _wikiEnabled;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "wiki_enabled", Required = Newtonsoft.Json.Required.Always)]
        public bool WikiEnabled
        {
            get
            {
                return this._wikiEnabled;
            }
            private set
            {
                this._wikiEnabled = value;
            }
        }
    }

    public partial class ProjectAccess : MemberAccess
    {
    }

    public partial class ProjectIdentity : GitLab.GitLabObject
    {
        private System.DateTime _createdAt;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "created_at", Required = Newtonsoft.Json.Required.Always)]
        public System.DateTime CreatedAt
        {
            get
            {
                return this._createdAt;
            }
            private set
            {
                this._createdAt = value;
            }
        }

        private string _description;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "description", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Description
        {
            get
            {
                return this._description;
            }
            private set
            {
                this._description = value;
            }
        }

        private long _id;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "id", Required = Newtonsoft.Json.Required.Always)]
        public long Id
        {
            get
            {
                return this._id;
            }
            private set
            {
                this._id = value;
            }
        }

        private string _name;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "name", Required = Newtonsoft.Json.Required.Always)]
        public string Name
        {
            get
            {
                return this._name;
            }
            private set
            {
                this._name = value;
            }
        }

        private string _nameWithNamespace;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "name_with_namespace", Required = Newtonsoft.Json.Required.Always)]
        public string NameWithNamespace
        {
            get
            {
                return this._nameWithNamespace;
            }
            private set
            {
                this._nameWithNamespace = value;
            }
        }

        private string _path;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "path", Required = Newtonsoft.Json.Required.Always)]
        public string Path
        {
            get
            {
                return this._path;
            }
            private set
            {
                this._path = value;
            }
        }

        private string _pathWithNamespace;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "path_with_namespace", Required = Newtonsoft.Json.Required.Always)]
        public string PathWithNamespace
        {
            get
            {
                return this._pathWithNamespace;
            }
            private set
            {
                this._pathWithNamespace = value;
            }
        }

        /// <summary>Get a specific project. This endpoint can be accessed without authentication if the project is publicly accessible.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<Project>> GetProjectAsync(Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return this.GitLabClient.GetProjectAsync(this, pageOptions, cancellationToken);
        }

        /// <summary>Get all merge requests for this project.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<MergeRequest>> GetMergeRequestsAsync(System.Nullable<MergeRequestState> state = default(System.Nullable<MergeRequestState>), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return this.GitLabClient.GetMergeRequestsAsync(this, state, pageOptions, cancellationToken);
        }
    }

    public partial class ProjectLink : GitLab.GitLabObject
    {
        private string _events;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "events", Required = Newtonsoft.Json.Required.Always)]
        public string Events
        {
            get
            {
                return this._events;
            }
            private set
            {
                this._events = value;
            }
        }

        private string _issues;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "issues", Required = Newtonsoft.Json.Required.Default)]
        public string Issues
        {
            get
            {
                return this._issues;
            }
            private set
            {
                this._issues = value;
            }
        }

        private string _labels;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "labels", Required = Newtonsoft.Json.Required.Always)]
        public string Labels
        {
            get
            {
                return this._labels;
            }
            private set
            {
                this._labels = value;
            }
        }

        private string _members;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "members", Required = Newtonsoft.Json.Required.Always)]
        public string Members
        {
            get
            {
                return this._members;
            }
            private set
            {
                this._members = value;
            }
        }

        private string _mergeRequests;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "merge_requests", Required = Newtonsoft.Json.Required.Default)]
        public string MergeRequests
        {
            get
            {
                return this._mergeRequests;
            }
            private set
            {
                this._mergeRequests = value;
            }
        }

        private string _repoBranches;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "repo_branches", Required = Newtonsoft.Json.Required.Always)]
        public string RepoBranches
        {
            get
            {
                return this._repoBranches;
            }
            private set
            {
                this._repoBranches = value;
            }
        }

        private string _self;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "self", Required = Newtonsoft.Json.Required.Always)]
        public string Self
        {
            get
            {
                return this._self;
            }
            private set
            {
                this._self = value;
            }
        }
    }

    public partial class ProjectPermissions : GitLab.GitLabObject
    {
        private GroupAccess _groupAccess;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "group_access", Required = Newtonsoft.Json.Required.AllowNull)]
        public GroupAccess GroupAccess
        {
            get
            {
                return this._groupAccess;
            }
            private set
            {
                this._groupAccess = value;
            }
        }

        private ProjectAccess _projectAccess;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "project_access", Required = Newtonsoft.Json.Required.AllowNull)]
        public ProjectAccess ProjectAccess
        {
            get
            {
                return this._projectAccess;
            }
            private set
            {
                this._projectAccess = value;
            }
        }
    }

    public enum ProjectVisibility
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "private")]
        Private,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "internal")]
        Internal,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "public")]
        Public
    }

    public partial class SharedGroup : GitLab.GitLabObject
    {
        private long _groupId;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "group_id", Required = Newtonsoft.Json.Required.Always)]
        public long GroupId
        {
            get
            {
                return this._groupId;
            }
            private set
            {
                this._groupId = value;
            }
        }

        private string _groupName;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "group_name", Required = Newtonsoft.Json.Required.Always)]
        public string GroupName
        {
            get
            {
                return this._groupName;
            }
            private set
            {
                this._groupName = value;
            }
        }

        private Access _groupAccessLevel;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "group_access_level", Required = Newtonsoft.Json.Required.AllowNull)]
        public Access GroupAccessLevel
        {
            get
            {
                return this._groupAccessLevel;
            }
            private set
            {
                this._groupAccessLevel = value;
            }
        }
    }

    public partial class SshKey : GitLab.GitLabObject
    {
        private long _id;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "id", Required = Newtonsoft.Json.Required.Always)]
        public long Id
        {
            get
            {
                return this._id;
            }
            private set
            {
                this._id = value;
            }
        }

        private string _title;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "title", Required = Newtonsoft.Json.Required.Always)]
        public string Title
        {
            get
            {
                return this._title;
            }
            private set
            {
                this._title = value;
            }
        }

        private string _key;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "key", Required = Newtonsoft.Json.Required.Always)]
        public string Key
        {
            get
            {
                return this._key;
            }
            private set
            {
                this._key = value;
            }
        }

        private System.DateTime _createdAt;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "created_at", Required = Newtonsoft.Json.Required.Always)]
        public System.DateTime CreatedAt
        {
            get
            {
                return this._createdAt;
            }
            private set
            {
                this._createdAt = value;
            }
        }

        /// <summary>Get a single key.</summary>
        /// <param name="id">The ID of an SSH key</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<SshKey> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return this.GitLabClient.GetSshKeyAsync(this, cancellationToken);
        }

        /// <summary>Deletes key owned by currently authenticated user.</summary>
        /// <param name="id">SSH key ID</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return this.GitLabClient.DeleteSshKeyAsync(this, cancellationToken);
        }
    }

    public partial class Todo : GitLab.GitLabObject
    {
        private long _id;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "id", Required = Newtonsoft.Json.Required.Always)]
        public long Id
        {
            get
            {
                return this._id;
            }
            private set
            {
                this._id = value;
            }
        }

        private TodoAction _actionName;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "action_name", Required = Newtonsoft.Json.Required.AllowNull)]
        public TodoAction ActionName
        {
            get
            {
                return this._actionName;
            }
            private set
            {
                this._actionName = value;
            }
        }

        private UserBasic _author;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "author", Required = Newtonsoft.Json.Required.AllowNull)]
        public UserBasic Author
        {
            get
            {
                return this._author;
            }
            private set
            {
                this._author = value;
            }
        }

        private BasicProjectDetails _project;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "project", Required = Newtonsoft.Json.Required.AllowNull)]
        public BasicProjectDetails Project
        {
            get
            {
                return this._project;
            }
            private set
            {
                this._project = value;
            }
        }

        private TodoType _targetType;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "target_type", Required = Newtonsoft.Json.Required.AllowNull)]
        public TodoType TargetType
        {
            get
            {
                return this._targetType;
            }
            private set
            {
                this._targetType = value;
            }
        }

        private GitLab.GitLabObject _target;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "target", Required = Newtonsoft.Json.Required.Always)]
        public GitLab.GitLabObject Target
        {
            get
            {
                return this._target;
            }
            private set
            {
                this._target = value;
            }
        }

        private string _targetUrl;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "target_url", Required = Newtonsoft.Json.Required.Always)]
        public string TargetUrl
        {
            get
            {
                return this._targetUrl;
            }
            private set
            {
                this._targetUrl = value;
            }
        }

        private string _body;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "body", Required = Newtonsoft.Json.Required.Always)]
        public string Body
        {
            get
            {
                return this._body;
            }
            private set
            {
                this._body = value;
            }
        }

        private UserState _state;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "state", Required = Newtonsoft.Json.Required.AllowNull)]
        public UserState State
        {
            get
            {
                return this._state;
            }
            private set
            {
                this._state = value;
            }
        }

        private System.DateTime _createdAt;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "created_at", Required = Newtonsoft.Json.Required.Always)]
        public System.DateTime CreatedAt
        {
            get
            {
                return this._createdAt;
            }
            private set
            {
                this._createdAt = value;
            }
        }
    }

    public enum TodoAction
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "assigned")]
        Assigned,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "mentioned")]
        Mentioned,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "build_failed")]
        BuildFailed,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "marked")]
        Marked,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "approval_required")]
        ApprovalRequired,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "unmergeable")]
        Unmergeable,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "directly_addressed")]
        DirectlyAddressed
    }

    public enum TodoState
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "pending")]
        Pending,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "done")]
        Done
    }

    public enum TodoType
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "issue")]
        Issue,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "merge_request")]
        MergeRequest
    }

    public partial class User : UserBasic
    {
        private string _bio;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "bio", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Bio
        {
            get
            {
                return this._bio;
            }
            private set
            {
                this._bio = value;
            }
        }

        private System.Nullable<bool> _canCreateGroup;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "can_create_group", Required = Newtonsoft.Json.Required.Default)]
        public System.Nullable<bool> CanCreateGroup
        {
            get
            {
                return this._canCreateGroup;
            }
            private set
            {
                this._canCreateGroup = value;
            }
        }

        private System.Nullable<bool> _canCreateProject;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "can_create_project", Required = Newtonsoft.Json.Required.Default)]
        public System.Nullable<bool> CanCreateProject
        {
            get
            {
                return this._canCreateProject;
            }
            private set
            {
                this._canCreateProject = value;
            }
        }

        private System.Nullable<long> _colorSchemeId;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "color_scheme_id", Required = Newtonsoft.Json.Required.Default)]
        public System.Nullable<long> ColorSchemeId
        {
            get
            {
                return this._colorSchemeId;
            }
            private set
            {
                this._colorSchemeId = value;
            }
        }

        private System.Nullable<System.DateTime> _confirmedAt;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "confirmed_at", Required = Newtonsoft.Json.Required.Default)]
        public System.Nullable<System.DateTime> ConfirmedAt
        {
            get
            {
                return this._confirmedAt;
            }
            private set
            {
                this._confirmedAt = value;
            }
        }

        private System.DateTime _createdAt;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "created_at", Required = Newtonsoft.Json.Required.Always)]
        public System.DateTime CreatedAt
        {
            get
            {
                return this._createdAt;
            }
            private set
            {
                this._createdAt = value;
            }
        }

        private System.Nullable<System.DateTime> _currentSignInAt;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "current_sign_in_at", Required = Newtonsoft.Json.Required.Default)]
        public System.Nullable<System.DateTime> CurrentSignInAt
        {
            get
            {
                return this._currentSignInAt;
            }
            private set
            {
                this._currentSignInAt = value;
            }
        }

        private string _email;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "email", Required = Newtonsoft.Json.Required.Default)]
        public string Email
        {
            get
            {
                return this._email;
            }
            private set
            {
                this._email = value;
            }
        }

        private System.Nullable<bool> _external;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "external", Required = Newtonsoft.Json.Required.Default)]
        public System.Nullable<bool> External
        {
            get
            {
                return this._external;
            }
            private set
            {
                this._external = value;
            }
        }

        private System.Collections.Generic.IReadOnlyList<Identity> _identities;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "identities", Required = Newtonsoft.Json.Required.Default)]
        public System.Collections.Generic.IReadOnlyList<Identity> Identities
        {
            get
            {
                return this._identities;
            }
            private set
            {
                this._identities = value;
            }
        }

        private System.Nullable<bool> _isAdmin;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "is_admin", Required = Newtonsoft.Json.Required.Default)]
        public System.Nullable<bool> IsAdmin
        {
            get
            {
                return this._isAdmin;
            }
            private set
            {
                this._isAdmin = value;
            }
        }

        private System.Nullable<System.DateTime> _lastActivityOn;

        [Meziantou.GitLab.SkipUtcDateValidationAttribute("Does not contain time nor timezone (e.g. 2018-01-01)")]
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "last_activity_on", Required = Newtonsoft.Json.Required.Default)]
        public System.Nullable<System.DateTime> LastActivityOn
        {
            get
            {
                return this._lastActivityOn;
            }
            private set
            {
                this._lastActivityOn = value;
            }
        }

        private System.Nullable<System.DateTime> _lastSignInAt;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "last_sign_in_at", Required = Newtonsoft.Json.Required.Default)]
        public System.Nullable<System.DateTime> LastSignInAt
        {
            get
            {
                return this._lastSignInAt;
            }
            private set
            {
                this._lastSignInAt = value;
            }
        }

        private string _linkedin;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "linkedin", Required = Newtonsoft.Json.Required.Always)]
        public string Linkedin
        {
            get
            {
                return this._linkedin;
            }
            private set
            {
                this._linkedin = value;
            }
        }

        private string _location;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "location", Required = Newtonsoft.Json.Required.Default)]
        public string Location
        {
            get
            {
                return this._location;
            }
            private set
            {
                this._location = value;
            }
        }

        private string _organization;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "organization", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Organization
        {
            get
            {
                return this._organization;
            }
            private set
            {
                this._organization = value;
            }
        }

        private object _privateProfile;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "private_profile", Required = Newtonsoft.Json.Required.Default)]
        public object PrivateProfile
        {
            get
            {
                return this._privateProfile;
            }
            private set
            {
                this._privateProfile = value;
            }
        }

        private System.Nullable<long> _projectsLimit;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "projects_limit", Required = Newtonsoft.Json.Required.Default)]
        public System.Nullable<long> ProjectsLimit
        {
            get
            {
                return this._projectsLimit;
            }
            private set
            {
                this._projectsLimit = value;
            }
        }

        private System.Nullable<long> _sharedRunnersMinutesLimit;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "shared_runners_minutes_limit", Required = Newtonsoft.Json.Required.Default)]
        public System.Nullable<long> SharedRunnersMinutesLimit
        {
            get
            {
                return this._sharedRunnersMinutesLimit;
            }
            private set
            {
                this._sharedRunnersMinutesLimit = value;
            }
        }

        private string _skype;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "skype", Required = Newtonsoft.Json.Required.Always)]
        public string Skype
        {
            get
            {
                return this._skype;
            }
            private set
            {
                this._skype = value;
            }
        }

        private System.Nullable<long> _themeId;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "theme_id", Required = Newtonsoft.Json.Required.Default)]
        public System.Nullable<long> ThemeId
        {
            get
            {
                return this._themeId;
            }
            private set
            {
                this._themeId = value;
            }
        }

        private string _twitter;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "twitter", Required = Newtonsoft.Json.Required.Always)]
        public string Twitter
        {
            get
            {
                return this._twitter;
            }
            private set
            {
                this._twitter = value;
            }
        }

        private System.Nullable<bool> _twoFactorEnabled;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "two_factor_enabled", Required = Newtonsoft.Json.Required.Default)]
        public System.Nullable<bool> TwoFactorEnabled
        {
            get
            {
                return this._twoFactorEnabled;
            }
            private set
            {
                this._twoFactorEnabled = value;
            }
        }

        private string _websiteUrl;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "website_url", Required = Newtonsoft.Json.Required.Always)]
        public string WebsiteUrl
        {
            get
            {
                return this._websiteUrl;
            }
            private set
            {
                this._websiteUrl = value;
            }
        }
    }

    public partial class UserActivity : GitLab.GitLabObject
    {
        private string _username;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "username", Required = Newtonsoft.Json.Required.Always)]
        public string Username
        {
            get
            {
                return this._username;
            }
            private set
            {
                this._username = value;
            }
        }

        private System.DateTime _lastActivityOn;

        [Meziantou.GitLab.SkipUtcDateValidationAttribute("Does not contain time nor timezone (e.g. 2018-01-01)")]
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "last_activity_on", Required = Newtonsoft.Json.Required.Always)]
        public System.DateTime LastActivityOn
        {
            get
            {
                return this._lastActivityOn;
            }
            private set
            {
                this._lastActivityOn = value;
            }
        }
    }

    public partial class UserBasic : UserSafe
    {
        private string _avatarUrl;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "avatar_url", Required = Newtonsoft.Json.Required.AllowNull)]
        public string AvatarUrl
        {
            get
            {
                return this._avatarUrl;
            }
            private set
            {
                this._avatarUrl = value;
            }
        }

        private string _avatarPath;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "avatar_path", Required = Newtonsoft.Json.Required.Default)]
        public string AvatarPath
        {
            get
            {
                return this._avatarPath;
            }
            private set
            {
                this._avatarPath = value;
            }
        }

        private UserState _state;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "state", Required = Newtonsoft.Json.Required.AllowNull)]
        public UserState State
        {
            get
            {
                return this._state;
            }
            private set
            {
                this._state = value;
            }
        }

        private string _webUrl;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "web_url", Required = Newtonsoft.Json.Required.Always)]
        public string WebUrl
        {
            get
            {
                return this._webUrl;
            }
            private set
            {
                this._webUrl = value;
            }
        }
    }

    public partial class UserSafe : GitLab.GitLabObject
    {
        private long _id;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "id", Required = Newtonsoft.Json.Required.Always)]
        public long Id
        {
            get
            {
                return this._id;
            }
            private set
            {
                this._id = value;
            }
        }

        private string _name;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "name", Required = Newtonsoft.Json.Required.Always)]
        public string Name
        {
            get
            {
                return this._name;
            }
            private set
            {
                this._name = value;
            }
        }

        private string _username;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "username", Required = Newtonsoft.Json.Required.Always)]
        public string Username
        {
            get
            {
                return this._username;
            }
            private set
            {
                this._username = value;
            }
        }

        /// <summary>Get the status of a user.</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<UserStatus> GetUserStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return this.GitLabClient.GetUserStatusAsync(this, cancellationToken);
        }

        /// <summary>Creates a new key owned by the currently authenticated user.</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<SshKey> AddSshKeyAsync(string title, string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return this.GitLabClient.AddSshKeyAsync(this, title, key, cancellationToken);
        }

        /// <summary>It creates a new impersonation token. Note that only administrators can do this. You are only able to create impersonation tokens to impersonate the user and perform both API calls and Git reads and writes. The user will not see these tokens in their profile settings page.</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<ImpersonationToken> CreateImpersonationTokenAsync(string name, System.Collections.Generic.IEnumerable<string> scopes, System.Nullable<System.DateTime> expiresAt = default(System.Nullable<System.DateTime>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return this.GitLabClient.CreateImpersonationTokenAsync(this, name, scopes, expiresAt, cancellationToken);
        }

        /// <summary>Get a list of visible projects for the given user. When accessed without authentication, only public projects are returned.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<Project>> GetProjectsAsync(System.Nullable<bool> archived = default(System.Nullable<bool>), System.Nullable<ProjectVisibility> visibility = default(System.Nullable<ProjectVisibility>), string search = default(string), System.Nullable<bool> simple = default(System.Nullable<bool>), System.Nullable<bool> owned = default(System.Nullable<bool>), System.Nullable<bool> membership = default(System.Nullable<bool>), System.Nullable<bool> starred = default(System.Nullable<bool>), System.Nullable<bool> statistics = default(System.Nullable<bool>), System.Nullable<bool> withIssuesEnabled = default(System.Nullable<bool>), System.Nullable<bool> withMergeRequestsEnabled = default(System.Nullable<bool>), System.Nullable<bool> wikiChecksumFailed = default(System.Nullable<bool>), System.Nullable<bool> repositoryChecksumFailed = default(System.Nullable<bool>), System.Nullable<Access> minAccessLevel = default(System.Nullable<Access>), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return this.GitLabClient.GetProjectsAsync(this, archived, visibility, search, simple, owned, membership, starred, statistics, withIssuesEnabled, withMergeRequestsEnabled, wikiChecksumFailed, repositoryChecksumFailed, minAccessLevel, pageOptions, cancellationToken);
        }

        /// <summary>Get all merge requests the authenticated user has access to. By default it returns only merge requests created by the current user. To get all merge requests, use parameter scope=all.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<MergeRequest>> GetMergeRequestsAsync(System.Nullable<MergeRequestState> state = default(System.Nullable<MergeRequestState>), System.Nullable<MergeRequestScopeFilter> scope = default(System.Nullable<MergeRequestScopeFilter>), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return this.GitLabClient.GetMergeRequestsAsync(state, scope, this, pageOptions, cancellationToken);
        }
    }

    public enum UserState
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "active")]
        Active,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "blocked")]
        Blocked
    }

    public partial class UserStatus : GitLab.GitLabObject
    {
        private string _emoji;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "emoji", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Emoji
        {
            get
            {
                return this._emoji;
            }
            private set
            {
                this._emoji = value;
            }
        }

        private string _message;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "message", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Message
        {
            get
            {
                return this._message;
            }
            private set
            {
                this._message = value;
            }
        }

        private string _messageHtml;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "message_html", Required = Newtonsoft.Json.Required.AllowNull)]
        public string MessageHtml
        {
            get
            {
                return this._messageHtml;
            }
            private set
            {
                this._messageHtml = value;
            }
        }
    }

    public readonly struct ProjectIdOrPathRef
    {
        private readonly object _value;

        public object Value
        {
            get
            {
                return this._value;
            }
        }

        public ProjectIdOrPathRef(long value)
        {
            this._value = value;
        }

        public static implicit operator Meziantou.GitLab.ProjectIdOrPathRef(long value)
        {
            return new Meziantou.GitLab.ProjectIdOrPathRef(value);
        }

        public ProjectIdOrPathRef(ProjectIdentity value)
        {
            if ((value == null))
            {
                throw new System.ArgumentNullException(nameof(value));
            }

            this._value = value.Id;
        }

        public static implicit operator Meziantou.GitLab.ProjectIdOrPathRef(ProjectIdentity value)
        {
            if ((value == null))
            {
                throw new System.ArgumentNullException(nameof(value));
            }

            return new Meziantou.GitLab.ProjectIdOrPathRef(value);
        }

        public ProjectIdOrPathRef(string value)
        {
            this._value = value;
        }

        public static implicit operator Meziantou.GitLab.ProjectIdOrPathRef(string value)
        {
            return new Meziantou.GitLab.ProjectIdOrPathRef(value);
        }
    }

    public readonly struct ProjectIdRef
    {
        private readonly object _value;

        public object Value
        {
            get
            {
                return this._value;
            }
        }

        public ProjectIdRef(long value)
        {
            this._value = value;
        }

        public static implicit operator Meziantou.GitLab.ProjectIdRef(long value)
        {
            return new Meziantou.GitLab.ProjectIdRef(value);
        }

        public ProjectIdRef(ProjectIdentity value)
        {
            if ((value == null))
            {
                throw new System.ArgumentNullException(nameof(value));
            }

            this._value = value.Id;
        }

        public static implicit operator Meziantou.GitLab.ProjectIdRef(ProjectIdentity value)
        {
            if ((value == null))
            {
                throw new System.ArgumentNullException(nameof(value));
            }

            return new Meziantou.GitLab.ProjectIdRef(value);
        }
    }

    public readonly struct SshKeyRef
    {
        private readonly object _value;

        public object Value
        {
            get
            {
                return this._value;
            }
        }

        public SshKeyRef(long value)
        {
            this._value = value;
        }

        public static implicit operator Meziantou.GitLab.SshKeyRef(long value)
        {
            return new Meziantou.GitLab.SshKeyRef(value);
        }

        public SshKeyRef(SshKey value)
        {
            if ((value == null))
            {
                throw new System.ArgumentNullException(nameof(value));
            }

            this._value = value.Id;
        }

        public static implicit operator Meziantou.GitLab.SshKeyRef(SshKey value)
        {
            if ((value == null))
            {
                throw new System.ArgumentNullException(nameof(value));
            }

            return new Meziantou.GitLab.SshKeyRef(value);
        }
    }

    public readonly struct UserRef
    {
        private readonly object _value;

        public object Value
        {
            get
            {
                return this._value;
            }
        }

        public UserRef(long value)
        {
            this._value = value;
        }

        public static implicit operator Meziantou.GitLab.UserRef(long value)
        {
            return new Meziantou.GitLab.UserRef(value);
        }

        public UserRef(string value)
        {
            this._value = value;
        }

        public static implicit operator Meziantou.GitLab.UserRef(string value)
        {
            return new Meziantou.GitLab.UserRef(value);
        }

        public UserRef(UserSafe value)
        {
            if ((value == null))
            {
                throw new System.ArgumentNullException(nameof(value));
            }

            this._value = value.Id;
        }

        public static implicit operator Meziantou.GitLab.UserRef(UserSafe value)
        {
            if ((value == null))
            {
                throw new System.ArgumentNullException(nameof(value));
            }

            return new Meziantou.GitLab.UserRef(value);
        }
    }

    partial class GitLabClient
    {
        /// <summary>Gets currently authenticated user.</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<User> GetUserAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("user");

            string url = urlBuilder.Build();

            return this.GetAsync<User>(url, cancellationToken);
        }

        /// <summary>Get a single user.</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<User> GetUserAsync(long id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("users/:id");

            urlBuilder.WithValue("id", id);

            string url = urlBuilder.Build();

            return this.GetAsync<User>(url, cancellationToken);
        }

        /// <summary>Get a list of users.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<UserBasic>> GetUsersAsync(string username = default(string), bool onlyActiveUsers = default(bool), bool onlyBlockedUsers = default(bool), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("users");

            urlBuilder.WithValue("username", username);

            urlBuilder.WithValue("active", onlyActiveUsers);

            urlBuilder.WithValue("blocked", onlyBlockedUsers);

            if ((pageOptions != null))
            {
                if ((pageOptions.PageIndex > 0))
                {
                    urlBuilder.WithValue("page", pageOptions.PageIndex);
                }

                if ((pageOptions.PageSize > 0))
                {
                    urlBuilder.WithValue("per_page", pageOptions.PageSize);
                }

                if ((string.IsNullOrEmpty(pageOptions.OrderBy.Name) == false))
                {
                    urlBuilder.WithValue("order_by", pageOptions.OrderBy.Name);

                    urlBuilder.WithValue("sort", pageOptions.OrderBy.Direction);
                }
            }

            string url = urlBuilder.Build();

            return this.GetPagedAsync<UserBasic>(url, cancellationToken);
        }

        /// <summary>Get the status of the currently signed in user.</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<UserStatus> GetUserStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("user/status");

            string url = urlBuilder.Build();

            return this.GetAsync<UserStatus>(url, cancellationToken);
        }

        /// <summary>Get the status of a user.</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<UserStatus> GetUserStatusAsync(UserRef user, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("users/:user/status");

            urlBuilder.WithValue("user", user.Value);

            string url = urlBuilder.Build();

            return this.GetAsync<UserStatus>(url, cancellationToken);
        }

        /// <summary>Set the status of the current user.</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<UserStatus> SetUserStatusAsync(string emoji = default(string), string message = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("user/status");

            string url = urlBuilder.Build();

            System.Collections.Generic.Dictionary<string, object> body = new System.Collections.Generic.Dictionary<string, object>();

            body.Add("emoji", emoji);

            body.Add("message", message);

            return this.PutJsonAsync<UserStatus>(url, body, cancellationToken);
        }

        /// <summary>Get a list of currently authenticated user's SSH keys.</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<SshKey>> GetSshKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("user/keys");

            string url = urlBuilder.Build();

            return this.GetCollectionAsync<SshKey>(url, cancellationToken);
        }

        /// <summary>Get a list of a specified user's SSH keys. Available only for admin.</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<SshKey>> GetSshKeysAsync(long user, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("users/:user/keys");

            urlBuilder.WithValue("user", user);

            string url = urlBuilder.Build();

            return this.GetCollectionAsync<SshKey>(url, cancellationToken);
        }

        /// <summary>Get a single key.</summary>
        /// <param name="id">The ID of an SSH key</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<SshKey> GetSshKeyAsync(SshKeyRef id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("user/keys/:id");

            urlBuilder.WithValue("id", id.Value);

            string url = urlBuilder.Build();

            return this.GetAsync<SshKey>(url, cancellationToken);
        }

        /// <summary>Creates a new key owned by the currently authenticated user.</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<SshKey> AddSshKeyAsync(string title, string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("user/keys");

            string url = urlBuilder.Build();

            System.Collections.Generic.Dictionary<string, object> body = new System.Collections.Generic.Dictionary<string, object>();

            body.Add("title", title);

            body.Add("key", key);

            return this.PostJsonAsync<SshKey>(url, body, cancellationToken);
        }

        /// <summary>Creates a new key owned by the currently authenticated user.</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<SshKey> AddSshKeyAsync(UserRef user, string title, string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("users/:user/keys");

            urlBuilder.WithValue("user", user.Value);

            string url = urlBuilder.Build();

            System.Collections.Generic.Dictionary<string, object> body = new System.Collections.Generic.Dictionary<string, object>();

            body.Add("title", title);

            body.Add("key", key);

            return this.PostJsonAsync<SshKey>(url, body, cancellationToken);
        }

        /// <summary>Deletes key owned by currently authenticated user.</summary>
        /// <param name="id">SSH key ID</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task DeleteSshKeyAsync(SshKeyRef id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("user/keys/:id");

            urlBuilder.WithValue("id", id.Value);

            string url = urlBuilder.Build();

            return this.DeleteAsync(url, cancellationToken);
        }

        /// <summary>Creates a new user. Note only administrators can create new users.</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<User> CreateUserAsync(string email, string username, string name, string password = default(string), System.Nullable<bool> admin = default(System.Nullable<bool>), System.Nullable<bool> canCreateGroup = default(System.Nullable<bool>), System.Nullable<bool> skipConfirmation = default(System.Nullable<bool>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("users");

            string url = urlBuilder.Build();

            System.Collections.Generic.Dictionary<string, object> body = new System.Collections.Generic.Dictionary<string, object>();

            body.Add("email", email);

            body.Add("username", username);

            body.Add("name", name);

            body.Add("password", password);

            body.Add("admin", admin);

            body.Add("can_create_group", canCreateGroup);

            body.Add("skip_confirmation", skipConfirmation);

            return this.PostJsonAsync<User>(url, body, cancellationToken);
        }

        /// <summary>It creates a new impersonation token. Note that only administrators can do this. You are only able to create impersonation tokens to impersonate the user and perform both API calls and Git reads and writes. The user will not see these tokens in their profile settings page.</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<ImpersonationToken> CreateImpersonationTokenAsync(UserRef user, string name, System.Collections.Generic.IEnumerable<string> scopes, System.Nullable<System.DateTime> expiresAt = default(System.Nullable<System.DateTime>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("users/:user/impersonation_tokens");

            urlBuilder.WithValue("user", user.Value);

            string url = urlBuilder.Build();

            System.Collections.Generic.Dictionary<string, object> body = new System.Collections.Generic.Dictionary<string, object>();

            body.Add("name", name);

            body.Add("expires_at", expiresAt);

            body.Add("scopes", scopes);

            return this.PostJsonAsync<ImpersonationToken>(url, body, cancellationToken);
        }

        /// <summary>Get a list of all visible projects across GitLab for the authenticated user. When accessed without authentication, only public projects with "simple" fields are returned.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<Project>> GetProjectsAsync(System.Nullable<bool> archived = default(System.Nullable<bool>), System.Nullable<ProjectVisibility> visibility = default(System.Nullable<ProjectVisibility>), string search = default(string), System.Nullable<bool> simple = default(System.Nullable<bool>), System.Nullable<bool> owned = default(System.Nullable<bool>), System.Nullable<bool> membership = default(System.Nullable<bool>), System.Nullable<bool> starred = default(System.Nullable<bool>), System.Nullable<bool> statistics = default(System.Nullable<bool>), System.Nullable<bool> withIssuesEnabled = default(System.Nullable<bool>), System.Nullable<bool> withMergeRequestsEnabled = default(System.Nullable<bool>), System.Nullable<bool> wikiChecksumFailed = default(System.Nullable<bool>), System.Nullable<bool> repositoryChecksumFailed = default(System.Nullable<bool>), System.Nullable<Access> minAccessLevel = default(System.Nullable<Access>), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("projects");

            urlBuilder.WithValue("archived", archived);

            urlBuilder.WithValue("visibility", visibility);

            urlBuilder.WithValue("search", search);

            urlBuilder.WithValue("simple", simple);

            urlBuilder.WithValue("owned", owned);

            urlBuilder.WithValue("membership", membership);

            urlBuilder.WithValue("starred", starred);

            urlBuilder.WithValue("statistics", statistics);

            urlBuilder.WithValue("with_issues_enabled", withIssuesEnabled);

            urlBuilder.WithValue("with_merge_requests_enabled", withMergeRequestsEnabled);

            urlBuilder.WithValue("wiki_checksum_failed", wikiChecksumFailed);

            urlBuilder.WithValue("repository_checksum_failed", repositoryChecksumFailed);

            urlBuilder.WithValue("min_access_level", minAccessLevel);

            if ((pageOptions != null))
            {
                if ((pageOptions.PageIndex > 0))
                {
                    urlBuilder.WithValue("page", pageOptions.PageIndex);
                }

                if ((pageOptions.PageSize > 0))
                {
                    urlBuilder.WithValue("per_page", pageOptions.PageSize);
                }

                if ((string.IsNullOrEmpty(pageOptions.OrderBy.Name) == false))
                {
                    urlBuilder.WithValue("order_by", pageOptions.OrderBy.Name);

                    urlBuilder.WithValue("sort", pageOptions.OrderBy.Direction);
                }
            }

            string url = urlBuilder.Build();

            return this.GetPagedAsync<Project>(url, cancellationToken);
        }

        /// <summary>Get a list of visible projects for the given user. When accessed without authentication, only public projects are returned.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<Project>> GetProjectsAsync(UserRef user, System.Nullable<bool> archived = default(System.Nullable<bool>), System.Nullable<ProjectVisibility> visibility = default(System.Nullable<ProjectVisibility>), string search = default(string), System.Nullable<bool> simple = default(System.Nullable<bool>), System.Nullable<bool> owned = default(System.Nullable<bool>), System.Nullable<bool> membership = default(System.Nullable<bool>), System.Nullable<bool> starred = default(System.Nullable<bool>), System.Nullable<bool> statistics = default(System.Nullable<bool>), System.Nullable<bool> withIssuesEnabled = default(System.Nullable<bool>), System.Nullable<bool> withMergeRequestsEnabled = default(System.Nullable<bool>), System.Nullable<bool> wikiChecksumFailed = default(System.Nullable<bool>), System.Nullable<bool> repositoryChecksumFailed = default(System.Nullable<bool>), System.Nullable<Access> minAccessLevel = default(System.Nullable<Access>), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("users/:user/projects");

            urlBuilder.WithValue("user", user.Value);

            urlBuilder.WithValue("archived", archived);

            urlBuilder.WithValue("visibility", visibility);

            urlBuilder.WithValue("search", search);

            urlBuilder.WithValue("simple", simple);

            urlBuilder.WithValue("owned", owned);

            urlBuilder.WithValue("membership", membership);

            urlBuilder.WithValue("starred", starred);

            urlBuilder.WithValue("statistics", statistics);

            urlBuilder.WithValue("with_issues_enabled", withIssuesEnabled);

            urlBuilder.WithValue("with_merge_requests_enabled", withMergeRequestsEnabled);

            urlBuilder.WithValue("wiki_checksum_failed", wikiChecksumFailed);

            urlBuilder.WithValue("repository_checksum_failed", repositoryChecksumFailed);

            urlBuilder.WithValue("min_access_level", minAccessLevel);

            if ((pageOptions != null))
            {
                if ((pageOptions.PageIndex > 0))
                {
                    urlBuilder.WithValue("page", pageOptions.PageIndex);
                }

                if ((pageOptions.PageSize > 0))
                {
                    urlBuilder.WithValue("per_page", pageOptions.PageSize);
                }

                if ((string.IsNullOrEmpty(pageOptions.OrderBy.Name) == false))
                {
                    urlBuilder.WithValue("order_by", pageOptions.OrderBy.Name);

                    urlBuilder.WithValue("sort", pageOptions.OrderBy.Direction);
                }
            }

            string url = urlBuilder.Build();

            return this.GetPagedAsync<Project>(url, cancellationToken);
        }

        /// <summary>Get a specific project. This endpoint can be accessed without authentication if the project is publicly accessible.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<Project>> GetProjectAsync(ProjectIdOrPathRef id, Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("projects/:id");

            urlBuilder.WithValue("id", id.Value);

            if ((pageOptions != null))
            {
                if ((pageOptions.PageIndex > 0))
                {
                    urlBuilder.WithValue("page", pageOptions.PageIndex);
                }

                if ((pageOptions.PageSize > 0))
                {
                    urlBuilder.WithValue("per_page", pageOptions.PageSize);
                }

                if ((string.IsNullOrEmpty(pageOptions.OrderBy.Name) == false))
                {
                    urlBuilder.WithValue("order_by", pageOptions.OrderBy.Name);

                    urlBuilder.WithValue("sort", pageOptions.OrderBy.Direction);
                }
            }

            string url = urlBuilder.Build();

            return this.GetPagedAsync<Project>(url, cancellationToken);
        }

        /// <summary>Returns a list of todos. When no filter is applied, it returns all pending todos for the current user. Different filters allow the user to precise the request.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<Todo>> GetTodosAsync(System.Nullable<TodoAction> action = default(System.Nullable<TodoAction>), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("todos");

            urlBuilder.WithValue("action", action);

            if ((pageOptions != null))
            {
                if ((pageOptions.PageIndex > 0))
                {
                    urlBuilder.WithValue("page", pageOptions.PageIndex);
                }

                if ((pageOptions.PageSize > 0))
                {
                    urlBuilder.WithValue("per_page", pageOptions.PageSize);
                }

                if ((string.IsNullOrEmpty(pageOptions.OrderBy.Name) == false))
                {
                    urlBuilder.WithValue("order_by", pageOptions.OrderBy.Name);

                    urlBuilder.WithValue("sort", pageOptions.OrderBy.Direction);
                }
            }

            string url = urlBuilder.Build();

            return this.GetPagedAsync<Todo>(url, cancellationToken);
        }

        /// <summary>Get all merge requests the authenticated user has access to. By default it returns only merge requests created by the current user. To get all merge requests, use parameter scope=all.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<MergeRequest>> GetMergeRequestsAsync(System.Nullable<MergeRequestState> state = default(System.Nullable<MergeRequestState>), System.Nullable<MergeRequestScopeFilter> scope = default(System.Nullable<MergeRequestScopeFilter>), System.Nullable<UserRef> assigneeId = default(System.Nullable<UserRef>), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("merge_requests");

            urlBuilder.WithValue("state", state);

            urlBuilder.WithValue("scope", scope);

            if (assigneeId.HasValue)
            {
                urlBuilder.WithValue("assignee_id", assigneeId.Value.Value);
            }

            if ((pageOptions != null))
            {
                if ((pageOptions.PageIndex > 0))
                {
                    urlBuilder.WithValue("page", pageOptions.PageIndex);
                }

                if ((pageOptions.PageSize > 0))
                {
                    urlBuilder.WithValue("per_page", pageOptions.PageSize);
                }

                if ((string.IsNullOrEmpty(pageOptions.OrderBy.Name) == false))
                {
                    urlBuilder.WithValue("order_by", pageOptions.OrderBy.Name);

                    urlBuilder.WithValue("sort", pageOptions.OrderBy.Direction);
                }
            }

            string url = urlBuilder.Build();

            return this.GetPagedAsync<MergeRequest>(url, cancellationToken);
        }

        /// <summary>Get all merge requests for this project.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<MergeRequest>> GetMergeRequestsAsync(ProjectIdOrPathRef project, System.Nullable<MergeRequestState> state = default(System.Nullable<MergeRequestState>), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("projects/:project/merge_requests");

            urlBuilder.WithValue("project", project.Value);

            urlBuilder.WithValue("state", state);

            if ((pageOptions != null))
            {
                if ((pageOptions.PageIndex > 0))
                {
                    urlBuilder.WithValue("page", pageOptions.PageIndex);
                }

                if ((pageOptions.PageSize > 0))
                {
                    urlBuilder.WithValue("per_page", pageOptions.PageSize);
                }

                if ((string.IsNullOrEmpty(pageOptions.OrderBy.Name) == false))
                {
                    urlBuilder.WithValue("order_by", pageOptions.OrderBy.Name);

                    urlBuilder.WithValue("sort", pageOptions.OrderBy.Direction);
                }
            }

            string url = urlBuilder.Build();

            return this.GetPagedAsync<MergeRequest>(url, cancellationToken);
        }
    }
}
