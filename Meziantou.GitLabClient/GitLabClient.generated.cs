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

    [Newtonsoft.Json.JsonConverterAttribute(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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

    [Newtonsoft.Json.JsonConverterAttribute(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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

    [Newtonsoft.Json.JsonConverterAttribute(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum MergeRequestScopeFilter
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "assigned_to_me")]
        AssignedToMe,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "all")]
        All
    }

    [Newtonsoft.Json.JsonConverterAttribute(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
    [Newtonsoft.Json.JsonConverterAttribute(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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

    [Newtonsoft.Json.JsonConverterAttribute(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum ProjectVisibility
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "private")]
        Private,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "internal")]
        Internal,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "public")]
        Public
    }

    [Newtonsoft.Json.JsonConverterAttribute(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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

    [Newtonsoft.Json.JsonConverterAttribute(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum TodoState
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "pending")]
        Pending,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "done")]
        Done
    }

    [Newtonsoft.Json.JsonConverterAttribute(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum TodoType
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "issue")]
        Issue,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "merge_request")]
        MergeRequest
    }

    [Newtonsoft.Json.JsonConverterAttribute(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum UserState
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "active")]
        Active,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "blocked")]
        Blocked
    }

    public partial class BasicProjectDetails : ProjectIdentity
    {
        private string _avatarUrl;

        private string _defaultBranch;

        private long _forksCount;

        private string _httpUrlToRepo;

        private System.DateTime _lastActivityAt;

        private NamespaceBasic _namespace;

        private string _readmeUrl;

        private string _sshUrlToRepo;

        private long _starCount;

        private System.Collections.Generic.IReadOnlyList<string> _tagList;

        private string _webUrl;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "avatar_url")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "default_branch")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "forks_count")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "http_url_to_repo")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "last_activity_at")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "namespace")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "readme_url")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "ssh_url_to_repo")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "star_count")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "tag_list")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "web_url")]
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

    public partial class FileCreated : GitLab.GitLabObject
    {
        private string _branch;

        private string _filePath;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "branch")]
        public string Branch
        {
            get
            {
                return this._branch;
            }
            private set
            {
                this._branch = value;
            }
        }

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "file_path")]
        public string FilePath
        {
            get
            {
                return this._filePath;
            }
            private set
            {
                this._filePath = value;
            }
        }
    }

    public partial class FileUpdated : GitLab.GitLabObject
    {
        private string _branch;

        private string _filePath;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "branch")]
        public string Branch
        {
            get
            {
                return this._branch;
            }
            private set
            {
                this._branch = value;
            }
        }

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "file_path")]
        public string FilePath
        {
            get
            {
                return this._filePath;
            }
            private set
            {
                this._filePath = value;
            }
        }
    }

    public partial class GroupAccess : MemberAccess
    {
    }

    public partial class Identity : GitLab.GitLabObject
    {
        private string _externUid;

        private string _provider;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "extern_uid")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "provider")]
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
    }

    public partial class ImpersonationToken : GitLab.GitLabObject
    {
        private bool _active;

        private System.DateTime _createdAt;

        private System.Nullable<System.DateTime> _expiresAt;

        private long _id;

        private bool _impersonation;

        private string _name;

        private bool _revoked;

        private System.Collections.Generic.IReadOnlyList<string> _scopes;

        private string _token;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "active")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "created_at")]
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

        [Meziantou.GitLab.SkipUtcDateValidationAttribute("Does not contain time nor timezone (e.g. 2018-01-01)")]
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "expires_at")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "id")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "impersonation")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "name")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "revoked")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "scopes")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "token")]
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
    }

    public partial class Issue : GitLab.GitLabObject
    {
        private UserBasic _author;

        private System.Nullable<System.DateTime> _closedAt;

        private UserBasic _closedBy;

        private System.DateTime _createdAt;

        private long _id;

        private long _iid;

        private long _projectId;

        private string _title;

        private System.DateTime _updatedAt;

        private string _webUrl;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "author")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "closed_at")]
        public System.Nullable<System.DateTime> ClosedAt
        {
            get
            {
                return this._closedAt;
            }
            private set
            {
                this._closedAt = value;
            }
        }

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "closed_by")]
        public UserBasic ClosedBy
        {
            get
            {
                return this._closedBy;
            }
            private set
            {
                this._closedBy = value;
            }
        }

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "created_at")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "id")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "iid")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "project_id")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "title")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "updated_at")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "web_url")]
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

    public partial class MemberAccess : GitLab.GitLabObject
    {
        private Access _accessLevel;

        private string _notificationLevel;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "access_level")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "notification_level")]
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

    public partial class MergeRequest : GitLab.GitLabObject
    {
        private UserBasic _author;

        private System.DateTime _createdAt;

        private long _id;

        private long _iid;

        private string _mergeStatus;

        private long _projectId;

        private MergeRequestState _state;

        private string _title;

        private System.DateTime _updatedAt;

        private int _userNotesCount;

        private string _webUrl;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "author")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "created_at")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "id")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "iid")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "merge_status")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "project_id")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "state")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "title")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "updated_at")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "user_notes_count")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "web_url")]
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

    public partial class NamespaceBasic : GitLab.GitLabObject
    {
        private string _fullPath;

        private long _id;

        private string _kind;

        private string _name;

        private System.Nullable<long> _parentId;

        private string _path;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "full_path")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "id")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "kind")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "name")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "parent_id")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "path")]
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
    }

    public partial class Project : BasicProjectDetails
    {
        private System.Nullable<int> _approvalsBeforeMerge;

        private bool _archived;

        private string _ciConfigPath;

        private bool _containerRegistryEnabled;

        private long _creatorId;

        private BasicProjectDetails _forkedFromProject;

        private ImportStatus _importStatus;

        private bool _issuesEnabled;

        private bool _jobsEnabled;

        private bool _lfsEnabled;

        private ProjectLink _links;

        private MergeMethod _mergeMethod;

        private bool _mergeRequestsEnabled;

        private bool _mirror;

        private System.Nullable<bool> _mirrorOverwritesDivergedBranches;

        private System.Nullable<bool> _mirrorTriggerBuilds;

        private System.Nullable<long> _mirrorUserId;

        private bool _onlyAllowMergeIfAllDiscussionsAreResolved;

        private bool _onlyAllowMergeIfPipelineSucceeds;

        private System.Nullable<bool> _onlyMirrorProtectedBranches;

        private System.Nullable<int> _openIssuesCount;

        private UserBasic _owner;

        private ProjectPermissions _permissions;

        private bool _printingMergeRequestLinkEnabled;

        private bool _publicJobs;

        private bool _requestAccessEnabled;

        private System.Nullable<bool> _resolveOutdatedDiffDiscussions;

        private bool _sharedRunnersEnabled;

        private System.Collections.Generic.IReadOnlyList<SharedGroup> _sharedWithGroups;

        private bool _snippetsEnabled;

        private ProjectVisibility _visibility;

        private bool _wikiEnabled;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "approvals_before_merge")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "archived")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "ci_config_path")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "container_registry_enabled")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "creator_id")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "forked_from_project")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "import_status")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "issues_enabled")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "jobs_enabled")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "lfs_enabled")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "_links")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "merge_method")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "merge_requests_enabled")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "mirror")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "mirror_overwrites_diverged_branches")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "mirror_trigger_builds")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "mirror_user_id")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "only_allow_merge_if_all_discussions_are_resolved")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "only_allow_merge_if_pipeline_succeeds")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "only_mirror_protected_branches")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "open_issues_count")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "owner")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "permissions")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "printing_merge_request_link_enabled")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "public_jobs")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "request_access_enabled")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "resolve_outdated_diff_discussions")]
        public System.Nullable<bool> ResolveOutdatedDiffDiscussions
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "shared_runners_enabled")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "shared_with_groups")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "snippets_enabled")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "visibility")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "wiki_enabled")]
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

        private string _description;

        private long _id;

        private string _name;

        private string _nameWithNamespace;

        private string _path;

        private string _pathWithNamespace;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "created_at")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "description")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "id")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "name")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "name_with_namespace")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "path")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "path_with_namespace")]
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
    }

    public partial class ProjectLink : GitLab.GitLabObject
    {
        private string _events;

        private string _issues;

        private string _labels;

        private string _members;

        private string _mergeRequests;

        private string _repoBranches;

        private string _self;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "events")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "issues")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "labels")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "members")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "merge_requests")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "repo_branches")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "self")]
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

        private ProjectAccess _projectAccess;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "group_access")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "project_access")]
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

    public partial class ServerVersion : GitLab.GitLabObject
    {
        private string _revision;

        private string _version;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "revision")]
        public string Revision
        {
            get
            {
                return this._revision;
            }
            private set
            {
                this._revision = value;
            }
        }

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "version")]
        public string Version
        {
            get
            {
                return this._version;
            }
            private set
            {
                this._version = value;
            }
        }
    }

    public partial class SharedGroup : GitLab.GitLabObject
    {
        private Access _groupAccessLevel;

        private long _groupId;

        private string _groupName;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "group_access_level")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "group_id")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "group_name")]
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
    }

    public partial class SshKey : GitLab.GitLabObject
    {
        private System.DateTime _createdAt;

        private long _id;

        private string _key;

        private string _title;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "created_at")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "id")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "key")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "title")]
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
    }

    public partial class Todo : GitLab.GitLabObject
    {
        private TodoAction _actionName;

        private UserBasic _author;

        private string _body;

        private System.DateTime _createdAt;

        private long _id;

        private BasicProjectDetails _project;

        private TodoState _state;

        private GitLab.GitLabObject _target;

        private TodoType _targetType;

        private string _targetUrl;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "action_name")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "author")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "body")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "created_at")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "id")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "project")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "state")]
        public TodoState State
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "target")]
        [Newtonsoft.Json.JsonConverterAttribute(typeof(TodoTargetJsonConverter))]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "target_type")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "target_url")]
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
    }

    public partial class User : UserBasic
    {
        private string _bio;

        private System.Nullable<bool> _canCreateGroup;

        private System.Nullable<bool> _canCreateProject;

        private System.Nullable<long> _colorSchemeId;

        private System.Nullable<System.DateTime> _confirmedAt;

        private System.DateTime _createdAt;

        private System.Nullable<System.DateTime> _currentSignInAt;

        private string _email;

        private System.Nullable<bool> _external;

        private System.Collections.Generic.IReadOnlyList<Identity> _identities;

        private System.Nullable<bool> _isAdmin;

        private System.Nullable<System.DateTime> _lastActivityOn;

        private System.Nullable<System.DateTime> _lastSignInAt;

        private string _linkedin;

        private string _location;

        private string _organization;

        private object _privateProfile;

        private System.Nullable<long> _projectsLimit;

        private System.Nullable<long> _sharedRunnersMinutesLimit;

        private string _skype;

        private System.Nullable<long> _themeId;

        private string _twitter;

        private System.Nullable<bool> _twoFactorEnabled;

        private string _websiteUrl;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "bio")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "can_create_group")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "can_create_project")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "color_scheme_id")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "confirmed_at")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "created_at")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "current_sign_in_at")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "email")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "external")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "identities")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "is_admin")]
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

        [Meziantou.GitLab.SkipUtcDateValidationAttribute("Does not contain time nor timezone (e.g. 2018-01-01)")]
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "last_activity_on")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "last_sign_in_at")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "linkedin")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "location")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "organization")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "private_profile")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "projects_limit")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "shared_runners_minutes_limit")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "skype")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "theme_id")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "twitter")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "two_factor_enabled")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "website_url")]
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
        private System.DateTime _lastActivityOn;

        private string _username;

        [Meziantou.GitLab.SkipUtcDateValidationAttribute("Does not contain time nor timezone (e.g. 2018-01-01)")]
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "last_activity_on")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "username")]
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
    }

    public partial class UserBasic : UserSafe
    {
        private string _avatarPath;

        private string _avatarUrl;

        private UserState _state;

        private string _webUrl;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "avatar_path")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "avatar_url")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "state")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "web_url")]
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

        private string _name;

        private string _username;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "id")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "name")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "username")]
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
    }

    public partial class UserStatus : GitLab.GitLabObject
    {
        private string _emoji;

        private string _message;

        private string _messageHtml;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "emoji")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "message")]
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

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "message_html")]
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

    [Newtonsoft.Json.JsonConverterAttribute(typeof(Meziantou.GitLab.ReferenceJsonConverter))]
    public readonly partial struct MergeRequestIidRef : Meziantou.GitLab.IReference
    {
        private readonly object _value;

        private MergeRequestIidRef(long mergeRequestIid)
        {
            this._value = mergeRequestIid;
        }

        private MergeRequestIidRef(MergeRequest mergeRequest)
        {
            if ((mergeRequest == null))
            {
                throw new System.ArgumentNullException(nameof(mergeRequest));
            }

            this._value = mergeRequest.Iid;
        }

        public object Value
        {
            get
            {
                return this._value;
            }
        }

        public static implicit operator Meziantou.GitLab.MergeRequestIidRef(long mergeRequestIid)
        {
            return new Meziantou.GitLab.MergeRequestIidRef(mergeRequestIid);
        }

        public static implicit operator Meziantou.GitLab.MergeRequestIidRef(MergeRequest mergeRequest)
        {
            if ((mergeRequest == null))
            {
                throw new System.ArgumentNullException(nameof(mergeRequest));
            }

            return new Meziantou.GitLab.MergeRequestIidRef(mergeRequest);
        }
    }

    [Newtonsoft.Json.JsonConverterAttribute(typeof(Meziantou.GitLab.ReferenceJsonConverter))]
    public readonly partial struct ProjectIdOrPathRef : Meziantou.GitLab.IReference
    {
        private readonly object _value;

        private ProjectIdOrPathRef(long projectId)
        {
            this._value = projectId;
        }

        private ProjectIdOrPathRef(ProjectIdentity project)
        {
            if ((project == null))
            {
                throw new System.ArgumentNullException(nameof(project));
            }

            this._value = project.Id;
        }

        private ProjectIdOrPathRef(string projectPathWithNamespace)
        {
            this._value = projectPathWithNamespace;
        }

        public object Value
        {
            get
            {
                return this._value;
            }
        }

        public static implicit operator Meziantou.GitLab.ProjectIdOrPathRef(long projectId)
        {
            return new Meziantou.GitLab.ProjectIdOrPathRef(projectId);
        }

        public static implicit operator Meziantou.GitLab.ProjectIdOrPathRef(ProjectIdentity project)
        {
            if ((project == null))
            {
                throw new System.ArgumentNullException(nameof(project));
            }

            return new Meziantou.GitLab.ProjectIdOrPathRef(project);
        }

        public static implicit operator Meziantou.GitLab.ProjectIdOrPathRef(string projectPathWithNamespace)
        {
            return new Meziantou.GitLab.ProjectIdOrPathRef(projectPathWithNamespace);
        }
    }

    [Newtonsoft.Json.JsonConverterAttribute(typeof(Meziantou.GitLab.ReferenceJsonConverter))]
    public readonly partial struct ProjectIdRef : Meziantou.GitLab.IReference
    {
        private readonly object _value;

        private ProjectIdRef(long projectId)
        {
            this._value = projectId;
        }

        private ProjectIdRef(ProjectIdentity project)
        {
            if ((project == null))
            {
                throw new System.ArgumentNullException(nameof(project));
            }

            this._value = project.Id;
        }

        public object Value
        {
            get
            {
                return this._value;
            }
        }

        public static implicit operator Meziantou.GitLab.ProjectIdRef(long projectId)
        {
            return new Meziantou.GitLab.ProjectIdRef(projectId);
        }

        public static implicit operator Meziantou.GitLab.ProjectIdRef(ProjectIdentity project)
        {
            if ((project == null))
            {
                throw new System.ArgumentNullException(nameof(project));
            }

            return new Meziantou.GitLab.ProjectIdRef(project);
        }
    }

    [Newtonsoft.Json.JsonConverterAttribute(typeof(Meziantou.GitLab.ReferenceJsonConverter))]
    public readonly partial struct SshKeyRef : Meziantou.GitLab.IReference
    {
        private readonly object _value;

        private SshKeyRef(long sshKeyId)
        {
            this._value = sshKeyId;
        }

        private SshKeyRef(SshKey sskKey)
        {
            if ((sskKey == null))
            {
                throw new System.ArgumentNullException(nameof(sskKey));
            }

            this._value = sskKey.Id;
        }

        public object Value
        {
            get
            {
                return this._value;
            }
        }

        public static implicit operator Meziantou.GitLab.SshKeyRef(long sshKeyId)
        {
            return new Meziantou.GitLab.SshKeyRef(sshKeyId);
        }

        public static implicit operator Meziantou.GitLab.SshKeyRef(SshKey sskKey)
        {
            if ((sskKey == null))
            {
                throw new System.ArgumentNullException(nameof(sskKey));
            }

            return new Meziantou.GitLab.SshKeyRef(sskKey);
        }
    }

    [Newtonsoft.Json.JsonConverterAttribute(typeof(Meziantou.GitLab.ReferenceJsonConverter))]
    public readonly partial struct UserRef : Meziantou.GitLab.IReference
    {
        private readonly object _value;

        private UserRef(long userId)
        {
            this._value = userId;
        }

        private UserRef(string userName)
        {
            this._value = userName;
        }

        private UserRef(UserSafe user)
        {
            if ((user == null))
            {
                throw new System.ArgumentNullException(nameof(user));
            }

            this._value = user.Id;
        }

        public object Value
        {
            get
            {
                return this._value;
            }
        }

        public static implicit operator Meziantou.GitLab.UserRef(long userId)
        {
            return new Meziantou.GitLab.UserRef(userId);
        }

        public static implicit operator Meziantou.GitLab.UserRef(string userName)
        {
            return new Meziantou.GitLab.UserRef(userName);
        }

        public static implicit operator Meziantou.GitLab.UserRef(UserSafe user)
        {
            if ((user == null))
            {
                throw new System.ArgumentNullException(nameof(user));
            }

            return new Meziantou.GitLab.UserRef(user);
        }
    }

    partial interface IGitLabClient
    {
        /// <summary>Creates a new key owned by the currently authenticated user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<SshKey> AddSshKeyAsync(string title, string key, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Creates a new key owned by the currently authenticated user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<SshKey> AddSshKeyAsync(UserRef user, string title, string key, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<FileCreated> CreateFileAsync(ProjectIdOrPathRef project, string filePath, string branch, string content, string commitMessage, string startBranch = default(string), string encoding = default(string), string authorEmail = default(string), string authorName = default(string), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>It creates a new impersonation token. Note that only administrators can do this. You are only able to create impersonation tokens to impersonate the user and perform both API calls and Git reads and writes. The user will not see these tokens in their profile settings page.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<ImpersonationToken> CreateImpersonationTokenAsync(UserRef user, string name, System.Collections.Generic.IEnumerable<string> scopes, System.Nullable<System.DateTime> expiresAt = default(System.Nullable<System.DateTime>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Creates a new project issue.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<Issue> CreateIssueAsync(ProjectIdOrPathRef project, string title, string description = default(string), System.Nullable<bool> confidential = default(System.Nullable<bool>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Creates a new merge request.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<MergeRequest> CreateMergeRequestAsync(ProjectIdOrPathRef project, string sourceBranch, string targetBranch, string title, string description = default(string), System.Nullable<UserRef> assigneeId = default(System.Nullable<UserRef>), System.Nullable<ProjectIdRef> targetProjectId = default(System.Nullable<ProjectIdRef>), System.Nullable<bool> removeSourceBranch = default(System.Nullable<bool>), System.Nullable<bool> allowCollaboration = default(System.Nullable<bool>), System.Nullable<bool> allowMaintainerToPush = default(System.Nullable<bool>), System.Nullable<bool> squash = default(System.Nullable<bool>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Creates a new project owned by the authenticated user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<Project> CreateProjectAsync(string name = default(string), string path = default(string), System.Nullable<long> namespaceId = default(System.Nullable<long>), string defaultBranch = default(string), string description = default(string), System.Nullable<bool> issueEnabled = default(System.Nullable<bool>), System.Nullable<bool> issuesEnabled = default(System.Nullable<bool>), System.Nullable<bool> mergeRequestsEnabled = default(System.Nullable<bool>), System.Nullable<bool> jobsEnabled = default(System.Nullable<bool>), System.Nullable<bool> wikiEnabled = default(System.Nullable<bool>), System.Nullable<bool> snippetsEnabled = default(System.Nullable<bool>), System.Nullable<bool> resolveOutdatedDiffDiscussions = default(System.Nullable<bool>), System.Nullable<bool> containerRegistryEnabled = default(System.Nullable<bool>), System.Nullable<bool> sharedRunnersEnabled = default(System.Nullable<bool>), System.Nullable<bool> publicJobs = default(System.Nullable<bool>), System.Nullable<bool> onlyAllowMergeIfPipelineSucceeds = default(System.Nullable<bool>), System.Nullable<bool> onlyAllowMergeIfAllDiscussionsAreResolved = default(System.Nullable<bool>), System.Nullable<bool> requestAccessEnabled = default(System.Nullable<bool>), System.Nullable<bool> lfsEnabled = default(System.Nullable<bool>), System.Nullable<bool> printingMergeRequestLinkEnabled = default(System.Nullable<bool>), System.Nullable<MergeMethod> mergeMethod = default(System.Nullable<MergeMethod>), System.Nullable<ProjectVisibility> visibility = default(System.Nullable<ProjectVisibility>), System.Collections.Generic.IEnumerable<string> tagList = default(System.Collections.Generic.IEnumerable<string>), string ciConfigPath = default(string), System.Nullable<int> approvalsBeforeMerge = default(System.Nullable<int>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Creates a new user. Note only administrators can create new users.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<User> CreateUserAsync(string email, string username, string name, string password = default(string), System.Nullable<bool> admin = default(System.Nullable<bool>), System.Nullable<bool> canCreateGroup = default(System.Nullable<bool>), System.Nullable<bool> skipConfirmation = default(System.Nullable<bool>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Deletes key owned by currently authenticated user.</summary>
        /// <param name="id">SSH key ID</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task DeleteSshKeyAsync(SshKeyRef id, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Shows information about a single merge request.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<MergeRequest> GetMergeRequestAsync(ProjectIdOrPathRef project, MergeRequestIidRef mergeRequest, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Get all merge requests for this project.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<MergeRequest>> GetMergeRequestsAsync(ProjectIdOrPathRef project, System.Nullable<MergeRequestState> state = default(System.Nullable<MergeRequestState>), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Get all merge requests the authenticated user has access to. By default it returns only merge requests created by the current user. To get all merge requests, use parameter scope=all.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<MergeRequest>> GetMergeRequestsAsync(System.Nullable<MergeRequestState> state = default(System.Nullable<MergeRequestState>), System.Nullable<MergeRequestScopeFilter> scope = default(System.Nullable<MergeRequestScopeFilter>), System.Nullable<UserRef> assigneeId = default(System.Nullable<UserRef>), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Get a specific project. This endpoint can be accessed without authentication if the project is publicly accessible.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<Project> GetProjectAsync(ProjectIdOrPathRef id, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Get a list of all visible projects across GitLab for the authenticated user. When accessed without authentication, only public projects with "simple" fields are returned.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<Project>> GetProjectsAsync(System.Nullable<bool> archived = default(System.Nullable<bool>), System.Nullable<ProjectVisibility> visibility = default(System.Nullable<ProjectVisibility>), string search = default(string), System.Nullable<bool> simple = default(System.Nullable<bool>), System.Nullable<bool> owned = default(System.Nullable<bool>), System.Nullable<bool> membership = default(System.Nullable<bool>), System.Nullable<bool> starred = default(System.Nullable<bool>), System.Nullable<bool> statistics = default(System.Nullable<bool>), System.Nullable<bool> withIssuesEnabled = default(System.Nullable<bool>), System.Nullable<bool> withMergeRequestsEnabled = default(System.Nullable<bool>), System.Nullable<bool> wikiChecksumFailed = default(System.Nullable<bool>), System.Nullable<bool> repositoryChecksumFailed = default(System.Nullable<bool>), System.Nullable<Access> minAccessLevel = default(System.Nullable<Access>), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Get a list of visible projects for the given user. When accessed without authentication, only public projects are returned.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<Project>> GetProjectsAsync(UserRef user, System.Nullable<bool> archived = default(System.Nullable<bool>), System.Nullable<ProjectVisibility> visibility = default(System.Nullable<ProjectVisibility>), string search = default(string), System.Nullable<bool> simple = default(System.Nullable<bool>), System.Nullable<bool> owned = default(System.Nullable<bool>), System.Nullable<bool> membership = default(System.Nullable<bool>), System.Nullable<bool> starred = default(System.Nullable<bool>), System.Nullable<bool> statistics = default(System.Nullable<bool>), System.Nullable<bool> withIssuesEnabled = default(System.Nullable<bool>), System.Nullable<bool> withMergeRequestsEnabled = default(System.Nullable<bool>), System.Nullable<bool> wikiChecksumFailed = default(System.Nullable<bool>), System.Nullable<bool> repositoryChecksumFailed = default(System.Nullable<bool>), System.Nullable<Access> minAccessLevel = default(System.Nullable<Access>), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Get a single key.</summary>
        /// <param name="id">The ID of an SSH key</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<SshKey> GetSshKeyAsync(SshKeyRef id, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Get a list of currently authenticated user's SSH keys.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<SshKey>> GetSshKeysAsync(GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Get a list of a specified user's SSH keys. Available only for admin.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<SshKey>> GetSshKeysAsync(long user, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Returns a list of todos. When no filter is applied, it returns all pending todos for the current user. Different filters allow the user to precise the request.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<Todo>> GetTodosAsync(System.Nullable<TodoAction> action = default(System.Nullable<TodoAction>), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Gets currently authenticated user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<User> GetUserAsync(GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Get a single user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<User> GetUserAsync(long id, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Get the status of a user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<UserStatus> GetUserStatusAsync(UserRef user, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Get the status of the currently signed in user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<UserStatus> GetUserStatusAsync(GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Get a list of users.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<UserBasic>> GetUsersAsync(string username = default(string), bool onlyActiveUsers = default(bool), bool onlyBlockedUsers = default(bool), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<ServerVersion> GetVersionAsync(GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Set the status of the current user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<UserStatus> SetUserStatusAsync(string emoji = default(string), string message = default(string), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<FileUpdated> UpdateFileAsync(ProjectIdOrPathRef project, string filePath, string branch, string content, string commitMessage, string startBranch = default(string), string encoding = default(string), string authorEmail = default(string), string authorName = default(string), System.Nullable<GitLab.Sha1> lastCommitId = default(System.Nullable<GitLab.Sha1>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }

    partial class GitLabClient : Meziantou.GitLab.IGitLabClient
    {
        /// <summary>Creates a new key owned by the currently authenticated user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<SshKey> AddSshKeyAsync(string title, string key, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("user/keys");
            string url = urlBuilder.Build();
            System.Collections.Generic.Dictionary<string, object> body = new System.Collections.Generic.Dictionary<string, object>();
            body.Add("title", title);
            body.Add("key", key);
            return this.PostJsonAsync<SshKey>(url, body, requestOptions, cancellationToken);
        }

        /// <summary>Creates a new key owned by the currently authenticated user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<SshKey> AddSshKeyAsync(UserRef user, string title, string key, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("users/:user/keys");
            urlBuilder.WithValue("user", user.Value);
            string url = urlBuilder.Build();
            System.Collections.Generic.Dictionary<string, object> body = new System.Collections.Generic.Dictionary<string, object>();
            body.Add("title", title);
            body.Add("key", key);
            return this.PostJsonAsync<SshKey>(url, body, requestOptions, cancellationToken);
        }

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<FileCreated> CreateFileAsync(ProjectIdOrPathRef project, string filePath, string branch, string content, string commitMessage, string startBranch = default(string), string encoding = default(string), string authorEmail = default(string), string authorName = default(string), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("projects/:project/repository/files/:file_path");
            urlBuilder.WithValue("project", project.Value);
            urlBuilder.WithValue("file_path", filePath);
            string url = urlBuilder.Build();
            System.Collections.Generic.Dictionary<string, object> body = new System.Collections.Generic.Dictionary<string, object>();
            body.Add("branch", branch);
            if ((startBranch != null))
            {
                body.Add("start_branch", startBranch);
            }

            if ((encoding != null))
            {
                body.Add("encoding", encoding);
            }

            if ((authorEmail != null))
            {
                body.Add("author_email", authorEmail);
            }

            if ((authorName != null))
            {
                body.Add("author_name", authorName);
            }

            body.Add("content", content);
            body.Add("commit_message", commitMessage);
            return this.PostJsonAsync<FileCreated>(url, body, requestOptions, cancellationToken);
        }

        /// <summary>It creates a new impersonation token. Note that only administrators can do this. You are only able to create impersonation tokens to impersonate the user and perform both API calls and Git reads and writes. The user will not see these tokens in their profile settings page.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<ImpersonationToken> CreateImpersonationTokenAsync(UserRef user, string name, System.Collections.Generic.IEnumerable<string> scopes, System.Nullable<System.DateTime> expiresAt = default(System.Nullable<System.DateTime>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("users/:user/impersonation_tokens");
            urlBuilder.WithValue("user", user.Value);
            string url = urlBuilder.Build();
            System.Collections.Generic.Dictionary<string, object> body = new System.Collections.Generic.Dictionary<string, object>();
            body.Add("name", name);
            if ((expiresAt != null))
            {
                body.Add("expires_at", expiresAt);
            }

            body.Add("scopes", scopes);
            return this.PostJsonAsync<ImpersonationToken>(url, body, requestOptions, cancellationToken);
        }

        /// <summary>Creates a new project issue.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<Issue> CreateIssueAsync(ProjectIdOrPathRef project, string title, string description = default(string), System.Nullable<bool> confidential = default(System.Nullable<bool>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("projects/:project/issues");
            urlBuilder.WithValue("project", project.Value);
            string url = urlBuilder.Build();
            System.Collections.Generic.Dictionary<string, object> body = new System.Collections.Generic.Dictionary<string, object>();
            body.Add("title", title);
            if ((description != null))
            {
                body.Add("description", description);
            }

            if ((confidential != null))
            {
                body.Add("confidential", confidential);
            }

            return this.PostJsonAsync<Issue>(url, body, requestOptions, cancellationToken);
        }

        /// <summary>Creates a new merge request.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<MergeRequest> CreateMergeRequestAsync(ProjectIdOrPathRef project, string sourceBranch, string targetBranch, string title, string description = default(string), System.Nullable<UserRef> assigneeId = default(System.Nullable<UserRef>), System.Nullable<ProjectIdRef> targetProjectId = default(System.Nullable<ProjectIdRef>), System.Nullable<bool> removeSourceBranch = default(System.Nullable<bool>), System.Nullable<bool> allowCollaboration = default(System.Nullable<bool>), System.Nullable<bool> allowMaintainerToPush = default(System.Nullable<bool>), System.Nullable<bool> squash = default(System.Nullable<bool>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("projects/:project/merge_requests");
            urlBuilder.WithValue("project", project.Value);
            string url = urlBuilder.Build();
            System.Collections.Generic.Dictionary<string, object> body = new System.Collections.Generic.Dictionary<string, object>();
            body.Add("source_branch", sourceBranch);
            body.Add("target_branch", targetBranch);
            body.Add("title", title);
            if ((description != null))
            {
                body.Add("description", description);
            }

            if ((assigneeId != null))
            {
                body.Add("assignee_id", assigneeId);
            }

            if ((targetProjectId != null))
            {
                body.Add("target_project_id", targetProjectId);
            }

            if ((removeSourceBranch != null))
            {
                body.Add("remove_source_branch", removeSourceBranch);
            }

            if ((allowCollaboration != null))
            {
                body.Add("allow_collaboration", allowCollaboration);
            }

            if ((allowMaintainerToPush != null))
            {
                body.Add("allow_maintainer_to_push", allowMaintainerToPush);
            }

            if ((squash != null))
            {
                body.Add("squash", squash);
            }

            return this.PostJsonAsync<MergeRequest>(url, body, requestOptions, cancellationToken);
        }

        /// <summary>Creates a new project owned by the authenticated user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<Project> CreateProjectAsync(string name = default(string), string path = default(string), System.Nullable<long> namespaceId = default(System.Nullable<long>), string defaultBranch = default(string), string description = default(string), System.Nullable<bool> issueEnabled = default(System.Nullable<bool>), System.Nullable<bool> issuesEnabled = default(System.Nullable<bool>), System.Nullable<bool> mergeRequestsEnabled = default(System.Nullable<bool>), System.Nullable<bool> jobsEnabled = default(System.Nullable<bool>), System.Nullable<bool> wikiEnabled = default(System.Nullable<bool>), System.Nullable<bool> snippetsEnabled = default(System.Nullable<bool>), System.Nullable<bool> resolveOutdatedDiffDiscussions = default(System.Nullable<bool>), System.Nullable<bool> containerRegistryEnabled = default(System.Nullable<bool>), System.Nullable<bool> sharedRunnersEnabled = default(System.Nullable<bool>), System.Nullable<bool> publicJobs = default(System.Nullable<bool>), System.Nullable<bool> onlyAllowMergeIfPipelineSucceeds = default(System.Nullable<bool>), System.Nullable<bool> onlyAllowMergeIfAllDiscussionsAreResolved = default(System.Nullable<bool>), System.Nullable<bool> requestAccessEnabled = default(System.Nullable<bool>), System.Nullable<bool> lfsEnabled = default(System.Nullable<bool>), System.Nullable<bool> printingMergeRequestLinkEnabled = default(System.Nullable<bool>), System.Nullable<MergeMethod> mergeMethod = default(System.Nullable<MergeMethod>), System.Nullable<ProjectVisibility> visibility = default(System.Nullable<ProjectVisibility>), System.Collections.Generic.IEnumerable<string> tagList = default(System.Collections.Generic.IEnumerable<string>), string ciConfigPath = default(string), System.Nullable<int> approvalsBeforeMerge = default(System.Nullable<int>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("projects");
            string url = urlBuilder.Build();
            System.Collections.Generic.Dictionary<string, object> body = new System.Collections.Generic.Dictionary<string, object>();
            if ((name != null))
            {
                body.Add("name", name);
            }

            if ((path != null))
            {
                body.Add("path", path);
            }

            if ((namespaceId != null))
            {
                body.Add("namespace_id", namespaceId);
            }

            if ((defaultBranch != null))
            {
                body.Add("default_branch", defaultBranch);
            }

            if ((description != null))
            {
                body.Add("description", description);
            }

            if ((issueEnabled != null))
            {
                body.Add("issue_enabled", issueEnabled);
            }

            if ((issuesEnabled != null))
            {
                body.Add("issues_enabled", issuesEnabled);
            }

            if ((mergeRequestsEnabled != null))
            {
                body.Add("merge_requests_enabled", mergeRequestsEnabled);
            }

            if ((jobsEnabled != null))
            {
                body.Add("jobs_enabled", jobsEnabled);
            }

            if ((wikiEnabled != null))
            {
                body.Add("wiki_enabled", wikiEnabled);
            }

            if ((snippetsEnabled != null))
            {
                body.Add("snippets_enabled", snippetsEnabled);
            }

            if ((resolveOutdatedDiffDiscussions != null))
            {
                body.Add("resolve_outdated_diff_discussions", resolveOutdatedDiffDiscussions);
            }

            if ((containerRegistryEnabled != null))
            {
                body.Add("container_registry_enabled", containerRegistryEnabled);
            }

            if ((sharedRunnersEnabled != null))
            {
                body.Add("shared_runners_enabled", sharedRunnersEnabled);
            }

            if ((publicJobs != null))
            {
                body.Add("public_jobs", publicJobs);
            }

            if ((onlyAllowMergeIfPipelineSucceeds != null))
            {
                body.Add("only_allow_merge_if_pipeline_succeeds", onlyAllowMergeIfPipelineSucceeds);
            }

            if ((onlyAllowMergeIfAllDiscussionsAreResolved != null))
            {
                body.Add("only_allow_merge_if_all_discussions_are_resolved", onlyAllowMergeIfAllDiscussionsAreResolved);
            }

            if ((requestAccessEnabled != null))
            {
                body.Add("request_access_enabled", requestAccessEnabled);
            }

            if ((lfsEnabled != null))
            {
                body.Add("lfs_enabled", lfsEnabled);
            }

            if ((printingMergeRequestLinkEnabled != null))
            {
                body.Add("printing_merge_request_link_enabled", printingMergeRequestLinkEnabled);
            }

            if ((mergeMethod != null))
            {
                body.Add("merge_method", mergeMethod);
            }

            if ((visibility != null))
            {
                body.Add("visibility", visibility);
            }

            if ((tagList != null))
            {
                body.Add("tag_list", tagList);
            }

            if ((ciConfigPath != null))
            {
                body.Add("ci_config_path", ciConfigPath);
            }

            if ((approvalsBeforeMerge != null))
            {
                body.Add("approvals_before_merge", approvalsBeforeMerge);
            }

            return this.PostJsonAsync<Project>(url, body, requestOptions, cancellationToken);
        }

        /// <summary>Creates a new user. Note only administrators can create new users.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<User> CreateUserAsync(string email, string username, string name, string password = default(string), System.Nullable<bool> admin = default(System.Nullable<bool>), System.Nullable<bool> canCreateGroup = default(System.Nullable<bool>), System.Nullable<bool> skipConfirmation = default(System.Nullable<bool>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("users");
            string url = urlBuilder.Build();
            System.Collections.Generic.Dictionary<string, object> body = new System.Collections.Generic.Dictionary<string, object>();
            body.Add("email", email);
            body.Add("username", username);
            body.Add("name", name);
            if ((password != null))
            {
                body.Add("password", password);
            }

            if ((admin != null))
            {
                body.Add("admin", admin);
            }

            if ((canCreateGroup != null))
            {
                body.Add("can_create_group", canCreateGroup);
            }

            if ((skipConfirmation != null))
            {
                body.Add("skip_confirmation", skipConfirmation);
            }

            return this.PostJsonAsync<User>(url, body, requestOptions, cancellationToken);
        }

        /// <summary>Deletes key owned by currently authenticated user.</summary>
        /// <param name="id">SSH key ID</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task DeleteSshKeyAsync(SshKeyRef id, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("user/keys/:id");
            urlBuilder.WithValue("id", id.Value);
            string url = urlBuilder.Build();
            return this.DeleteAsync(url, requestOptions, cancellationToken);
        }

        /// <summary>Shows information about a single merge request.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<MergeRequest> GetMergeRequestAsync(ProjectIdOrPathRef project, MergeRequestIidRef mergeRequest, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("projects/:project/merge_requests/:merge_request");
            urlBuilder.WithValue("project", project.Value);
            urlBuilder.WithValue("merge_request", mergeRequest.Value);
            string url = urlBuilder.Build();
            return this.GetAsync<MergeRequest>(url, requestOptions, cancellationToken);
        }

        /// <summary>Get all merge requests for this project.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<MergeRequest>> GetMergeRequestsAsync(ProjectIdOrPathRef project, System.Nullable<MergeRequestState> state = default(System.Nullable<MergeRequestState>), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            return this.GetPagedAsync<MergeRequest>(url, requestOptions, cancellationToken);
        }

        /// <summary>Get all merge requests the authenticated user has access to. By default it returns only merge requests created by the current user. To get all merge requests, use parameter scope=all.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<MergeRequest>> GetMergeRequestsAsync(System.Nullable<MergeRequestState> state = default(System.Nullable<MergeRequestState>), System.Nullable<MergeRequestScopeFilter> scope = default(System.Nullable<MergeRequestScopeFilter>), System.Nullable<UserRef> assigneeId = default(System.Nullable<UserRef>), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            return this.GetPagedAsync<MergeRequest>(url, requestOptions, cancellationToken);
        }

        /// <summary>Get a specific project. This endpoint can be accessed without authentication if the project is publicly accessible.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<Project> GetProjectAsync(ProjectIdOrPathRef id, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("projects/:id");
            urlBuilder.WithValue("id", id.Value);
            string url = urlBuilder.Build();
            return this.GetAsync<Project>(url, requestOptions, cancellationToken);
        }

        /// <summary>Get a list of all visible projects across GitLab for the authenticated user. When accessed without authentication, only public projects with "simple" fields are returned.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<Project>> GetProjectsAsync(System.Nullable<bool> archived = default(System.Nullable<bool>), System.Nullable<ProjectVisibility> visibility = default(System.Nullable<ProjectVisibility>), string search = default(string), System.Nullable<bool> simple = default(System.Nullable<bool>), System.Nullable<bool> owned = default(System.Nullable<bool>), System.Nullable<bool> membership = default(System.Nullable<bool>), System.Nullable<bool> starred = default(System.Nullable<bool>), System.Nullable<bool> statistics = default(System.Nullable<bool>), System.Nullable<bool> withIssuesEnabled = default(System.Nullable<bool>), System.Nullable<bool> withMergeRequestsEnabled = default(System.Nullable<bool>), System.Nullable<bool> wikiChecksumFailed = default(System.Nullable<bool>), System.Nullable<bool> repositoryChecksumFailed = default(System.Nullable<bool>), System.Nullable<Access> minAccessLevel = default(System.Nullable<Access>), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            return this.GetPagedAsync<Project>(url, requestOptions, cancellationToken);
        }

        /// <summary>Get a list of visible projects for the given user. When accessed without authentication, only public projects are returned.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<Project>> GetProjectsAsync(UserRef user, System.Nullable<bool> archived = default(System.Nullable<bool>), System.Nullable<ProjectVisibility> visibility = default(System.Nullable<ProjectVisibility>), string search = default(string), System.Nullable<bool> simple = default(System.Nullable<bool>), System.Nullable<bool> owned = default(System.Nullable<bool>), System.Nullable<bool> membership = default(System.Nullable<bool>), System.Nullable<bool> starred = default(System.Nullable<bool>), System.Nullable<bool> statistics = default(System.Nullable<bool>), System.Nullable<bool> withIssuesEnabled = default(System.Nullable<bool>), System.Nullable<bool> withMergeRequestsEnabled = default(System.Nullable<bool>), System.Nullable<bool> wikiChecksumFailed = default(System.Nullable<bool>), System.Nullable<bool> repositoryChecksumFailed = default(System.Nullable<bool>), System.Nullable<Access> minAccessLevel = default(System.Nullable<Access>), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            return this.GetPagedAsync<Project>(url, requestOptions, cancellationToken);
        }

        /// <summary>Get a single key.</summary>
        /// <param name="id">The ID of an SSH key</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<SshKey> GetSshKeyAsync(SshKeyRef id, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("user/keys/:id");
            urlBuilder.WithValue("id", id.Value);
            string url = urlBuilder.Build();
            return this.GetAsync<SshKey>(url, requestOptions, cancellationToken);
        }

        /// <summary>Get a list of currently authenticated user's SSH keys.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<SshKey>> GetSshKeysAsync(GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("user/keys");
            string url = urlBuilder.Build();
            return this.GetCollectionAsync<SshKey>(url, requestOptions, cancellationToken);
        }

        /// <summary>Get a list of a specified user's SSH keys. Available only for admin.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<SshKey>> GetSshKeysAsync(long user, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("users/:user/keys");
            urlBuilder.WithValue("user", user);
            string url = urlBuilder.Build();
            return this.GetCollectionAsync<SshKey>(url, requestOptions, cancellationToken);
        }

        /// <summary>Returns a list of todos. When no filter is applied, it returns all pending todos for the current user. Different filters allow the user to precise the request.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<Todo>> GetTodosAsync(System.Nullable<TodoAction> action = default(System.Nullable<TodoAction>), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            return this.GetPagedAsync<Todo>(url, requestOptions, cancellationToken);
        }

        /// <summary>Gets currently authenticated user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<User> GetUserAsync(GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("user");
            string url = urlBuilder.Build();
            return this.GetAsync<User>(url, requestOptions, cancellationToken);
        }

        /// <summary>Get a single user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<User> GetUserAsync(long id, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("users/:id");
            urlBuilder.WithValue("id", id);
            string url = urlBuilder.Build();
            return this.GetAsync<User>(url, requestOptions, cancellationToken);
        }

        /// <summary>Get the status of a user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<UserStatus> GetUserStatusAsync(UserRef user, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("users/:user/status");
            urlBuilder.WithValue("user", user.Value);
            string url = urlBuilder.Build();
            return this.GetAsync<UserStatus>(url, requestOptions, cancellationToken);
        }

        /// <summary>Get the status of the currently signed in user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<UserStatus> GetUserStatusAsync(GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("user/status");
            string url = urlBuilder.Build();
            return this.GetAsync<UserStatus>(url, requestOptions, cancellationToken);
        }

        /// <summary>Get a list of users.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<UserBasic>> GetUsersAsync(string username = default(string), bool onlyActiveUsers = default(bool), bool onlyBlockedUsers = default(bool), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            return this.GetPagedAsync<UserBasic>(url, requestOptions, cancellationToken);
        }

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<ServerVersion> GetVersionAsync(GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("version");
            string url = urlBuilder.Build();
            return this.GetAsync<ServerVersion>(url, requestOptions, cancellationToken);
        }

        /// <summary>Set the status of the current user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<UserStatus> SetUserStatusAsync(string emoji = default(string), string message = default(string), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("user/status");
            string url = urlBuilder.Build();
            System.Collections.Generic.Dictionary<string, object> body = new System.Collections.Generic.Dictionary<string, object>();
            if ((emoji != null))
            {
                body.Add("emoji", emoji);
            }

            if ((message != null))
            {
                body.Add("message", message);
            }

            return this.PutJsonAsync<UserStatus>(url, body, requestOptions, cancellationToken);
        }

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<FileUpdated> UpdateFileAsync(ProjectIdOrPathRef project, string filePath, string branch, string content, string commitMessage, string startBranch = default(string), string encoding = default(string), string authorEmail = default(string), string authorName = default(string), System.Nullable<GitLab.Sha1> lastCommitId = default(System.Nullable<GitLab.Sha1>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("projects/:project/repository/files/:file_path");
            urlBuilder.WithValue("project", project.Value);
            urlBuilder.WithValue("file_path", filePath);
            string url = urlBuilder.Build();
            System.Collections.Generic.Dictionary<string, object> body = new System.Collections.Generic.Dictionary<string, object>();
            body.Add("branch", branch);
            if ((startBranch != null))
            {
                body.Add("start_branch", startBranch);
            }

            if ((encoding != null))
            {
                body.Add("encoding", encoding);
            }

            if ((authorEmail != null))
            {
                body.Add("author_email", authorEmail);
            }

            if ((authorName != null))
            {
                body.Add("author_name", authorName);
            }

            if ((lastCommitId != null))
            {
                body.Add("last_commit_id", lastCommitId);
            }

            body.Add("content", content);
            body.Add("commit_message", commitMessage);
            return this.PutJsonAsync<FileUpdated>(url, body, requestOptions, cancellationToken);
        }
    }

    public static partial class GitLabClientExtensions
    {
        /// <summary>Creates a new key owned by the currently authenticated user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<SshKey> AddSshKeyAsync(this UserSafe userSafe, string title, string key, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return userSafe.GitLabClient.AddSshKeyAsync(userSafe, title, key, requestOptions, cancellationToken);
        }

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<FileCreated> CreateFileAsync(this IGitLabClient client, ProjectIdOrPathRef project, string filePath, string branch, System.Byte[] content, string commitMessage, string startBranch = default(string), string authorEmail = default(string), string authorName = default(string), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return client.CreateFileAsync(project, filePath, branch, System.Convert.ToBase64String(content), commitMessage, startBranch, "base64", authorEmail, authorName, requestOptions, cancellationToken);
        }

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<FileCreated> CreateFileAsync(this ProjectIdentity projectIdentity, string filePath, string branch, string content, string commitMessage, string startBranch = default(string), string encoding = default(string), string authorEmail = default(string), string authorName = default(string), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return projectIdentity.GitLabClient.CreateFileAsync(projectIdentity, filePath, branch, content, commitMessage, startBranch, encoding, authorEmail, authorName, requestOptions, cancellationToken);
        }

        /// <summary>It creates a new impersonation token. Note that only administrators can do this. You are only able to create impersonation tokens to impersonate the user and perform both API calls and Git reads and writes. The user will not see these tokens in their profile settings page.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<ImpersonationToken> CreateImpersonationTokenAsync(this UserSafe userSafe, string name, System.Collections.Generic.IEnumerable<string> scopes, System.Nullable<System.DateTime> expiresAt = default(System.Nullable<System.DateTime>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return userSafe.GitLabClient.CreateImpersonationTokenAsync(userSafe, name, scopes, expiresAt, requestOptions, cancellationToken);
        }

        /// <summary>Creates a new project issue.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<Issue> CreateIssueAsync(this ProjectIdentity projectIdentity, string title, string description = default(string), System.Nullable<bool> confidential = default(System.Nullable<bool>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return projectIdentity.GitLabClient.CreateIssueAsync(projectIdentity, title, description, confidential, requestOptions, cancellationToken);
        }

        /// <summary>Creates a new merge request.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<MergeRequest> CreateMergeRequestAsync(this ProjectIdentity projectIdentity, string sourceBranch, string targetBranch, string title, string description = default(string), System.Nullable<UserRef> assigneeId = default(System.Nullable<UserRef>), System.Nullable<ProjectIdRef> targetProjectId = default(System.Nullable<ProjectIdRef>), System.Nullable<bool> removeSourceBranch = default(System.Nullable<bool>), System.Nullable<bool> allowCollaboration = default(System.Nullable<bool>), System.Nullable<bool> allowMaintainerToPush = default(System.Nullable<bool>), System.Nullable<bool> squash = default(System.Nullable<bool>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return projectIdentity.GitLabClient.CreateMergeRequestAsync(projectIdentity, sourceBranch, targetBranch, title, description, assigneeId, targetProjectId, removeSourceBranch, allowCollaboration, allowMaintainerToPush, squash, requestOptions, cancellationToken);
        }

        /// <summary>Creates a new merge request.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<MergeRequest> CreateMergeRequestAsync(this UserSafe userSafe, ProjectIdOrPathRef project, string sourceBranch, string targetBranch, string title, string description = default(string), System.Nullable<ProjectIdRef> targetProjectId = default(System.Nullable<ProjectIdRef>), System.Nullable<bool> removeSourceBranch = default(System.Nullable<bool>), System.Nullable<bool> allowCollaboration = default(System.Nullable<bool>), System.Nullable<bool> allowMaintainerToPush = default(System.Nullable<bool>), System.Nullable<bool> squash = default(System.Nullable<bool>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return userSafe.GitLabClient.CreateMergeRequestAsync(project, sourceBranch, targetBranch, title, description, userSafe, targetProjectId, removeSourceBranch, allowCollaboration, allowMaintainerToPush, squash, requestOptions, cancellationToken);
        }

        /// <summary>Creates a new merge request.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<MergeRequest> CreateMergeRequestAsync(this ProjectIdentity projectIdentity, ProjectIdOrPathRef project, string sourceBranch, string targetBranch, string title, string description = default(string), System.Nullable<UserRef> assigneeId = default(System.Nullable<UserRef>), System.Nullable<bool> removeSourceBranch = default(System.Nullable<bool>), System.Nullable<bool> allowCollaboration = default(System.Nullable<bool>), System.Nullable<bool> allowMaintainerToPush = default(System.Nullable<bool>), System.Nullable<bool> squash = default(System.Nullable<bool>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return projectIdentity.GitLabClient.CreateMergeRequestAsync(project, sourceBranch, targetBranch, title, description, assigneeId, projectIdentity, removeSourceBranch, allowCollaboration, allowMaintainerToPush, squash, requestOptions, cancellationToken);
        }

        /// <summary>Deletes key owned by currently authenticated user.</summary>
        /// <param name="id">SSH key ID</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task DeleteSshKeyAsync(this SshKey sshKey, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return sshKey.GitLabClient.DeleteSshKeyAsync(sshKey, requestOptions, cancellationToken);
        }

        /// <summary>Shows information about a single merge request.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<MergeRequest> GetMergeRequestAsync(this ProjectIdentity projectIdentity, MergeRequestIidRef mergeRequest, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return projectIdentity.GitLabClient.GetMergeRequestAsync(projectIdentity, mergeRequest, requestOptions, cancellationToken);
        }

        /// <summary>Shows information about a single merge request.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<MergeRequest> GetMergeRequestAsync(this MergeRequest mergeRequest, ProjectIdOrPathRef project, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return mergeRequest.GitLabClient.GetMergeRequestAsync(project, mergeRequest, requestOptions, cancellationToken);
        }

        /// <summary>Get all merge requests the authenticated user has access to. By default it returns only merge requests created by the current user. To get all merge requests, use parameter scope=all.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<MergeRequest>> GetMergeRequestsAsync(this UserSafe userSafe, System.Nullable<MergeRequestState> state = default(System.Nullable<MergeRequestState>), System.Nullable<MergeRequestScopeFilter> scope = default(System.Nullable<MergeRequestScopeFilter>), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return userSafe.GitLabClient.GetMergeRequestsAsync(state, scope, userSafe, pageOptions, requestOptions, cancellationToken);
        }

        /// <summary>Get all merge requests for this project.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<MergeRequest>> GetMergeRequestsAsync(this ProjectIdentity projectIdentity, System.Nullable<MergeRequestState> state = default(System.Nullable<MergeRequestState>), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return projectIdentity.GitLabClient.GetMergeRequestsAsync(projectIdentity, state, pageOptions, requestOptions, cancellationToken);
        }

        /// <summary>Get a specific project. This endpoint can be accessed without authentication if the project is publicly accessible.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<Project> GetProjectAsync(this ProjectIdentity projectIdentity, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return projectIdentity.GitLabClient.GetProjectAsync(projectIdentity, requestOptions, cancellationToken);
        }

        /// <summary>Get a list of visible projects for the given user. When accessed without authentication, only public projects are returned.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<Project>> GetProjectsAsync(this UserSafe userSafe, System.Nullable<bool> archived = default(System.Nullable<bool>), System.Nullable<ProjectVisibility> visibility = default(System.Nullable<ProjectVisibility>), string search = default(string), System.Nullable<bool> simple = default(System.Nullable<bool>), System.Nullable<bool> owned = default(System.Nullable<bool>), System.Nullable<bool> membership = default(System.Nullable<bool>), System.Nullable<bool> starred = default(System.Nullable<bool>), System.Nullable<bool> statistics = default(System.Nullable<bool>), System.Nullable<bool> withIssuesEnabled = default(System.Nullable<bool>), System.Nullable<bool> withMergeRequestsEnabled = default(System.Nullable<bool>), System.Nullable<bool> wikiChecksumFailed = default(System.Nullable<bool>), System.Nullable<bool> repositoryChecksumFailed = default(System.Nullable<bool>), System.Nullable<Access> minAccessLevel = default(System.Nullable<Access>), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return userSafe.GitLabClient.GetProjectsAsync(userSafe, archived, visibility, search, simple, owned, membership, starred, statistics, withIssuesEnabled, withMergeRequestsEnabled, wikiChecksumFailed, repositoryChecksumFailed, minAccessLevel, pageOptions, requestOptions, cancellationToken);
        }

        /// <summary>Get a single key.</summary>
        /// <param name="id">The ID of an SSH key</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<SshKey> GetSshKeyAsync(this SshKey sshKey, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return sshKey.GitLabClient.GetSshKeyAsync(sshKey, requestOptions, cancellationToken);
        }

        /// <summary>Get the status of a user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<UserStatus> GetUserStatusAsync(this UserSafe userSafe, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return userSafe.GitLabClient.GetUserStatusAsync(userSafe, requestOptions, cancellationToken);
        }

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<FileUpdated> UpdateFileAsync(this ProjectIdentity projectIdentity, string filePath, string branch, string content, string commitMessage, string startBranch = default(string), string encoding = default(string), string authorEmail = default(string), string authorName = default(string), System.Nullable<GitLab.Sha1> lastCommitId = default(System.Nullable<GitLab.Sha1>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return projectIdentity.GitLabClient.UpdateFileAsync(projectIdentity, filePath, branch, content, commitMessage, startBranch, encoding, authorEmail, authorName, lastCommitId, requestOptions, cancellationToken);
        }

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<FileUpdated> UpdateFileAsync(this IGitLabClient client, ProjectIdOrPathRef project, string filePath, string branch, System.Byte[] content, string commitMessage, string startBranch = default(string), string authorEmail = default(string), string authorName = default(string), System.Nullable<GitLab.Sha1> lastCommitId = default(System.Nullable<GitLab.Sha1>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return client.UpdateFileAsync(project, filePath, branch, System.Convert.ToBase64String(content), commitMessage, startBranch, "base64", authorEmail, authorName, lastCommitId, requestOptions, cancellationToken);
        }
    }
}
