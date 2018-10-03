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
    public enum MergeRequestStatus
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "can_be_merged")]
        CanBeMerged,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "cannot_be_merged")]
        CannotBeMerged
    }

    [Newtonsoft.Json.JsonConverterAttribute(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum MergeRequestView
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "default")]
        Default,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "simple")]
        Simple
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

    [Newtonsoft.Json.JsonConverterAttribute(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum WikiPageFormat
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "markdown")]
        Markdown,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "rdoc")]
        Rdoc,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "asciidoc")]
        Asciidoc
    }

    public partial class BasicProjectDetails : ProjectIdentity
    {
        internal BasicProjectDetails(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal BasicProjectDetails()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("avatar_url")]
        public string AvatarUrl
        {
            get
            {
                return this.GetValueOrDefault<string>("avatar_url", default(string));
            }
            internal set
            {
                this.SetValue("avatar_url", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("default_branch")]
        public string DefaultBranch
        {
            get
            {
                return this.GetValueOrDefault<string>("default_branch", default(string));
            }
            internal set
            {
                this.SetValue("default_branch", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("forks_count")]
        public long ForksCount
        {
            get
            {
                return this.GetValueOrDefault<long>("forks_count", default(long));
            }
            internal set
            {
                this.SetValue("forks_count", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("http_url_to_repo")]
        public string HttpUrlToRepo
        {
            get
            {
                return this.GetValueOrDefault<string>("http_url_to_repo", default(string));
            }
            internal set
            {
                this.SetValue("http_url_to_repo", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("last_activity_at")]
        public System.DateTime LastActivityAt
        {
            get
            {
                return this.GetValueOrDefault<System.DateTime>("last_activity_at", default(System.DateTime));
            }
            internal set
            {
                this.SetValue("last_activity_at", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("namespace")]
        public NamespaceBasic Namespace
        {
            get
            {
                return this.GetValueOrDefault<NamespaceBasic>("namespace", default(NamespaceBasic));
            }
            internal set
            {
                this.SetValue("namespace", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("readme_url")]
        public string ReadmeUrl
        {
            get
            {
                return this.GetValueOrDefault<string>("readme_url", default(string));
            }
            internal set
            {
                this.SetValue("readme_url", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("ssh_url_to_repo")]
        public string SshUrlToRepo
        {
            get
            {
                return this.GetValueOrDefault<string>("ssh_url_to_repo", default(string));
            }
            internal set
            {
                this.SetValue("ssh_url_to_repo", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("star_count")]
        public long StarCount
        {
            get
            {
                return this.GetValueOrDefault<long>("star_count", default(long));
            }
            internal set
            {
                this.SetValue("star_count", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("tag_list")]
        public System.Collections.Generic.IReadOnlyList<string> TagList
        {
            get
            {
                return this.GetValueOrDefault<System.Collections.Generic.IReadOnlyList<string>>("tag_list", default(System.Collections.Generic.IReadOnlyList<string>));
            }
            internal set
            {
                this.SetValue("tag_list", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("web_url")]
        public string WebUrl
        {
            get
            {
                return this.GetValueOrDefault<string>("web_url", default(string));
            }
            internal set
            {
                this.SetValue("web_url", value);
            }
        }
    }

    public partial class FileCreated : GitLab.GitLabObject
    {
        internal FileCreated(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal FileCreated()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("branch")]
        public string Branch
        {
            get
            {
                return this.GetValueOrDefault<string>("branch", default(string));
            }
            internal set
            {
                this.SetValue("branch", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("file_path")]
        public string FilePath
        {
            get
            {
                return this.GetValueOrDefault<string>("file_path", default(string));
            }
            internal set
            {
                this.SetValue("file_path", value);
            }
        }
    }

    public partial class FileUpdated : GitLab.GitLabObject
    {
        internal FileUpdated(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal FileUpdated()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("branch")]
        public string Branch
        {
            get
            {
                return this.GetValueOrDefault<string>("branch", default(string));
            }
            internal set
            {
                this.SetValue("branch", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("file_path")]
        public string FilePath
        {
            get
            {
                return this.GetValueOrDefault<string>("file_path", default(string));
            }
            internal set
            {
                this.SetValue("file_path", value);
            }
        }
    }

    public partial class GroupAccess : MemberAccess
    {
        internal GroupAccess(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal GroupAccess()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }
    }

    public partial class Identity : GitLab.GitLabObject, System.IEquatable<Meziantou.GitLab.Identity>
    {
        internal Identity(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal Identity()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("extern_uid")]
        public string ExternUid
        {
            get
            {
                return this.GetValueOrDefault<string>("extern_uid", default(string));
            }
            internal set
            {
                this.SetValue("extern_uid", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("provider")]
        public string Provider
        {
            get
            {
                return this.GetValueOrDefault<string>("provider", default(string));
            }
            internal set
            {
                this.SetValue("provider", value);
            }
        }

        public override bool Equals(object obj)
        {
            Meziantou.GitLab.Identity a = (obj as Meziantou.GitLab.Identity);
            return this.Equals(a);
        }

        public virtual bool Equals(Meziantou.GitLab.Identity obj)
        {
            return (((obj != null) && (this.Provider == obj.Provider)) && (this.ExternUid == obj.ExternUid));
        }

        public override int GetHashCode()
        {
            int hashCode = 574293967;
            hashCode = ((hashCode * -1521134295) + System.Collections.Generic.EqualityComparer<string>.Default.GetHashCode("Provider"));
            hashCode = ((hashCode * -1521134295) + System.Collections.Generic.EqualityComparer<string>.Default.GetHashCode("ExternUid"));
            return hashCode;
        }

        public static bool operator !=(Meziantou.GitLab.Identity a, Meziantou.GitLab.Identity b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.Identity a, Meziantou.GitLab.Identity b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.Identity>.Default.Equals(a, b);
        }
    }

    [System.Diagnostics.DebuggerDisplayAttribute("{GetType().Name,nq} Name={Name}, Id={Id}")]
    public partial class ImpersonationToken : GitLab.GitLabObject, System.IEquatable<Meziantou.GitLab.ImpersonationToken>
    {
        internal ImpersonationToken(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal ImpersonationToken()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("active")]
        public bool Active
        {
            get
            {
                return this.GetValueOrDefault<bool>("active", default(bool));
            }
            internal set
            {
                this.SetValue("active", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("created_at")]
        public System.DateTime CreatedAt
        {
            get
            {
                return this.GetValueOrDefault<System.DateTime>("created_at", default(System.DateTime));
            }
            internal set
            {
                this.SetValue("created_at", value);
            }
        }

        [Meziantou.GitLab.SkipUtcDateValidationAttribute("Does not contain time nor timezone (e.g. 2018-01-01)")]
        [Meziantou.GitLab.MappedPropertyAttribute("expires_at")]
        public System.Nullable<System.DateTime> ExpiresAt
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<System.DateTime>>("expires_at", default(System.Nullable<System.DateTime>));
            }
            internal set
            {
                this.SetValue("expires_at", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("id")]
        public long Id
        {
            get
            {
                return this.GetValueOrDefault<long>("id", default(long));
            }
            internal set
            {
                this.SetValue("id", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("impersonation")]
        public bool Impersonation
        {
            get
            {
                return this.GetValueOrDefault<bool>("impersonation", default(bool));
            }
            internal set
            {
                this.SetValue("impersonation", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("name")]
        public string Name
        {
            get
            {
                return this.GetValueOrDefault<string>("name", default(string));
            }
            internal set
            {
                this.SetValue("name", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("revoked")]
        public bool Revoked
        {
            get
            {
                return this.GetValueOrDefault<bool>("revoked", default(bool));
            }
            internal set
            {
                this.SetValue("revoked", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("scopes")]
        public System.Collections.Generic.IReadOnlyList<string> Scopes
        {
            get
            {
                return this.GetValueOrDefault<System.Collections.Generic.IReadOnlyList<string>>("scopes", default(System.Collections.Generic.IReadOnlyList<string>));
            }
            internal set
            {
                this.SetValue("scopes", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("token")]
        public string Token
        {
            get
            {
                return this.GetValueOrDefault<string>("token", default(string));
            }
            internal set
            {
                this.SetValue("token", value);
            }
        }

        public override bool Equals(object obj)
        {
            Meziantou.GitLab.ImpersonationToken a = (obj as Meziantou.GitLab.ImpersonationToken);
            return this.Equals(a);
        }

        public virtual bool Equals(Meziantou.GitLab.ImpersonationToken obj)
        {
            return ((obj != null) && (this.Id == obj.Id));
        }

        public override int GetHashCode()
        {
            int hashCode = 574293967;
            hashCode = ((hashCode * -1521134295) + this.Id.GetHashCode());
            return hashCode;
        }

        public static bool operator !=(Meziantou.GitLab.ImpersonationToken a, Meziantou.GitLab.ImpersonationToken b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.ImpersonationToken a, Meziantou.GitLab.ImpersonationToken b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.ImpersonationToken>.Default.Equals(a, b);
        }
    }

    [System.Diagnostics.DebuggerDisplayAttribute("{GetType().Name,nq} Title={Title}, Id={Id}")]
    public partial class Issue : GitLab.GitLabObject, System.IEquatable<Meziantou.GitLab.Issue>
    {
        internal Issue(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal Issue()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("author")]
        public UserBasic Author
        {
            get
            {
                return this.GetValueOrDefault<UserBasic>("author", default(UserBasic));
            }
            internal set
            {
                this.SetValue("author", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("closed_at")]
        public System.Nullable<System.DateTime> ClosedAt
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<System.DateTime>>("closed_at", default(System.Nullable<System.DateTime>));
            }
            internal set
            {
                this.SetValue("closed_at", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("closed_by")]
        public UserBasic ClosedBy
        {
            get
            {
                return this.GetValueOrDefault<UserBasic>("closed_by", default(UserBasic));
            }
            internal set
            {
                this.SetValue("closed_by", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("created_at")]
        public System.DateTime CreatedAt
        {
            get
            {
                return this.GetValueOrDefault<System.DateTime>("created_at", default(System.DateTime));
            }
            internal set
            {
                this.SetValue("created_at", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("id")]
        public long Id
        {
            get
            {
                return this.GetValueOrDefault<long>("id", default(long));
            }
            internal set
            {
                this.SetValue("id", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("iid")]
        public long Iid
        {
            get
            {
                return this.GetValueOrDefault<long>("iid", default(long));
            }
            internal set
            {
                this.SetValue("iid", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("project_id")]
        public long ProjectId
        {
            get
            {
                return this.GetValueOrDefault<long>("project_id", default(long));
            }
            internal set
            {
                this.SetValue("project_id", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("title")]
        public string Title
        {
            get
            {
                return this.GetValueOrDefault<string>("title", default(string));
            }
            internal set
            {
                this.SetValue("title", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("updated_at")]
        public System.DateTime UpdatedAt
        {
            get
            {
                return this.GetValueOrDefault<System.DateTime>("updated_at", default(System.DateTime));
            }
            internal set
            {
                this.SetValue("updated_at", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("web_url")]
        public string WebUrl
        {
            get
            {
                return this.GetValueOrDefault<string>("web_url", default(string));
            }
            internal set
            {
                this.SetValue("web_url", value);
            }
        }

        public override bool Equals(object obj)
        {
            Meziantou.GitLab.Issue a = (obj as Meziantou.GitLab.Issue);
            return this.Equals(a);
        }

        public virtual bool Equals(Meziantou.GitLab.Issue obj)
        {
            return ((obj != null) && (this.Id == obj.Id));
        }

        public override int GetHashCode()
        {
            int hashCode = 574293967;
            hashCode = ((hashCode * -1521134295) + this.Id.GetHashCode());
            return hashCode;
        }

        public static bool operator !=(Meziantou.GitLab.Issue a, Meziantou.GitLab.Issue b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.Issue a, Meziantou.GitLab.Issue b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.Issue>.Default.Equals(a, b);
        }
    }

    public partial class MemberAccess : GitLab.GitLabObject
    {
        internal MemberAccess(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal MemberAccess()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("access_level")]
        public Access AccessLevel
        {
            get
            {
                return this.GetValueOrDefault<Access>("access_level", default(Access));
            }
            internal set
            {
                this.SetValue("access_level", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("notification_level")]
        public string NotificationLevel
        {
            get
            {
                return this.GetValueOrDefault<string>("notification_level", default(string));
            }
            internal set
            {
                this.SetValue("notification_level", value);
            }
        }
    }

    [System.Diagnostics.DebuggerDisplayAttribute("{GetType().Name,nq} Title={Title}, Id={Id}")]
    public partial class MergeRequest : GitLab.GitLabObject, System.IEquatable<Meziantou.GitLab.MergeRequest>
    {
        internal MergeRequest(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal MergeRequest()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("assignee")]
        public UserBasic Assignee
        {
            get
            {
                return this.GetValueOrDefault<UserBasic>("assignee", default(UserBasic));
            }
            internal set
            {
                this.SetValue("assignee", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("author")]
        public UserBasic Author
        {
            get
            {
                return this.GetValueOrDefault<UserBasic>("author", default(UserBasic));
            }
            internal set
            {
                this.SetValue("author", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("created_at")]
        public System.DateTime CreatedAt
        {
            get
            {
                return this.GetValueOrDefault<System.DateTime>("created_at", default(System.DateTime));
            }
            internal set
            {
                this.SetValue("created_at", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("description")]
        public string Description
        {
            get
            {
                return this.GetValueOrDefault<string>("description", default(string));
            }
            internal set
            {
                this.SetValue("description", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("downvotes")]
        public int Downvotes
        {
            get
            {
                return this.GetValueOrDefault<int>("downvotes", default(int));
            }
            internal set
            {
                this.SetValue("downvotes", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("force_remove_source_branch")]
        public System.Nullable<bool> ForceRemoveSourceBranch
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<bool>>("force_remove_source_branch", default(System.Nullable<bool>));
            }
            internal set
            {
                this.SetValue("force_remove_source_branch", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("id")]
        public long Id
        {
            get
            {
                return this.GetValueOrDefault<long>("id", default(long));
            }
            internal set
            {
                this.SetValue("id", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("iid")]
        public long Iid
        {
            get
            {
                return this.GetValueOrDefault<long>("iid", default(long));
            }
            internal set
            {
                this.SetValue("iid", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("labels")]
        public System.Collections.Generic.IReadOnlyList<string> Labels
        {
            get
            {
                return this.GetValueOrDefault<System.Collections.Generic.IReadOnlyList<string>>("labels", default(System.Collections.Generic.IReadOnlyList<string>));
            }
            internal set
            {
                this.SetValue("labels", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("merge_commit_sha")]
        public System.Nullable<GitLab.GitObjectId> MergeCommitSha
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<GitLab.GitObjectId>>("merge_commit_sha", default(System.Nullable<GitLab.GitObjectId>));
            }
            internal set
            {
                this.SetValue("merge_commit_sha", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("merge_status")]
        public MergeRequestStatus MergeStatus
        {
            get
            {
                return this.GetValueOrDefault<MergeRequestStatus>("merge_status", default(MergeRequestStatus));
            }
            internal set
            {
                this.SetValue("merge_status", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("merge_when_pipeline_succeeds")]
        public bool MergeWhenPipelineSucceeds
        {
            get
            {
                return this.GetValueOrDefault<bool>("merge_when_pipeline_succeeds", default(bool));
            }
            internal set
            {
                this.SetValue("merge_when_pipeline_succeeds", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("project_id")]
        public long ProjectId
        {
            get
            {
                return this.GetValueOrDefault<long>("project_id", default(long));
            }
            internal set
            {
                this.SetValue("project_id", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("sha")]
        public GitLab.GitObjectId Sha
        {
            get
            {
                return this.GetValueOrDefault<GitLab.GitObjectId>("sha", default(GitLab.GitObjectId));
            }
            internal set
            {
                this.SetValue("sha", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("should_remove_source_branch")]
        public System.Nullable<bool> ShouldRemoveSourceBranch
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<bool>>("should_remove_source_branch", default(System.Nullable<bool>));
            }
            internal set
            {
                this.SetValue("should_remove_source_branch", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("source_branch")]
        public string SourceBranch
        {
            get
            {
                return this.GetValueOrDefault<string>("source_branch", default(string));
            }
            internal set
            {
                this.SetValue("source_branch", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("source_project_id")]
        public long SourceProjectId
        {
            get
            {
                return this.GetValueOrDefault<long>("source_project_id", default(long));
            }
            internal set
            {
                this.SetValue("source_project_id", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("squash")]
        public bool Squash
        {
            get
            {
                return this.GetValueOrDefault<bool>("squash", default(bool));
            }
            internal set
            {
                this.SetValue("squash", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("state")]
        public MergeRequestState State
        {
            get
            {
                return this.GetValueOrDefault<MergeRequestState>("state", default(MergeRequestState));
            }
            internal set
            {
                this.SetValue("state", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("target_branch")]
        public string TargetBranch
        {
            get
            {
                return this.GetValueOrDefault<string>("target_branch", default(string));
            }
            internal set
            {
                this.SetValue("target_branch", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("target_project_id")]
        public long TargetProjectId
        {
            get
            {
                return this.GetValueOrDefault<long>("target_project_id", default(long));
            }
            internal set
            {
                this.SetValue("target_project_id", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("title")]
        public string Title
        {
            get
            {
                return this.GetValueOrDefault<string>("title", default(string));
            }
            internal set
            {
                this.SetValue("title", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("updated_at")]
        public System.DateTime UpdatedAt
        {
            get
            {
                return this.GetValueOrDefault<System.DateTime>("updated_at", default(System.DateTime));
            }
            internal set
            {
                this.SetValue("updated_at", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("upvotes")]
        public int Upvotes
        {
            get
            {
                return this.GetValueOrDefault<int>("upvotes", default(int));
            }
            internal set
            {
                this.SetValue("upvotes", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("user_notes_count")]
        public int UserNotesCount
        {
            get
            {
                return this.GetValueOrDefault<int>("user_notes_count", default(int));
            }
            internal set
            {
                this.SetValue("user_notes_count", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("web_url")]
        public string WebUrl
        {
            get
            {
                return this.GetValueOrDefault<string>("web_url", default(string));
            }
            internal set
            {
                this.SetValue("web_url", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("work_in_progress")]
        public bool WorkInProgress
        {
            get
            {
                return this.GetValueOrDefault<bool>("work_in_progress", default(bool));
            }
            internal set
            {
                this.SetValue("work_in_progress", value);
            }
        }

        public override bool Equals(object obj)
        {
            Meziantou.GitLab.MergeRequest a = (obj as Meziantou.GitLab.MergeRequest);
            return this.Equals(a);
        }

        public virtual bool Equals(Meziantou.GitLab.MergeRequest obj)
        {
            return ((obj != null) && (this.Id == obj.Id));
        }

        public override int GetHashCode()
        {
            int hashCode = 574293967;
            hashCode = ((hashCode * -1521134295) + this.Id.GetHashCode());
            return hashCode;
        }

        public static bool operator !=(Meziantou.GitLab.MergeRequest a, Meziantou.GitLab.MergeRequest b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.MergeRequest a, Meziantou.GitLab.MergeRequest b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.MergeRequest>.Default.Equals(a, b);
        }
    }

    [System.Diagnostics.DebuggerDisplayAttribute("{GetType().Name,nq} FullPath={FullPath}, Id={Id}")]
    public partial class NamespaceBasic : GitLab.GitLabObject, System.IEquatable<Meziantou.GitLab.NamespaceBasic>
    {
        internal NamespaceBasic(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal NamespaceBasic()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("full_path")]
        public string FullPath
        {
            get
            {
                return this.GetValueOrDefault<string>("full_path", default(string));
            }
            internal set
            {
                this.SetValue("full_path", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("id")]
        public long Id
        {
            get
            {
                return this.GetValueOrDefault<long>("id", default(long));
            }
            internal set
            {
                this.SetValue("id", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("kind")]
        public string Kind
        {
            get
            {
                return this.GetValueOrDefault<string>("kind", default(string));
            }
            internal set
            {
                this.SetValue("kind", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("name")]
        public string Name
        {
            get
            {
                return this.GetValueOrDefault<string>("name", default(string));
            }
            internal set
            {
                this.SetValue("name", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("parent_id")]
        public System.Nullable<long> ParentId
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<long>>("parent_id", default(System.Nullable<long>));
            }
            internal set
            {
                this.SetValue("parent_id", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("path")]
        public string Path
        {
            get
            {
                return this.GetValueOrDefault<string>("path", default(string));
            }
            internal set
            {
                this.SetValue("path", value);
            }
        }

        public override bool Equals(object obj)
        {
            Meziantou.GitLab.NamespaceBasic a = (obj as Meziantou.GitLab.NamespaceBasic);
            return this.Equals(a);
        }

        public virtual bool Equals(Meziantou.GitLab.NamespaceBasic obj)
        {
            return ((obj != null) && (this.Id == obj.Id));
        }

        public override int GetHashCode()
        {
            int hashCode = 574293967;
            hashCode = ((hashCode * -1521134295) + this.Id.GetHashCode());
            return hashCode;
        }

        public static bool operator !=(Meziantou.GitLab.NamespaceBasic a, Meziantou.GitLab.NamespaceBasic b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.NamespaceBasic a, Meziantou.GitLab.NamespaceBasic b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.NamespaceBasic>.Default.Equals(a, b);
        }
    }

    public partial class Project : BasicProjectDetails
    {
        internal Project(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal Project()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("approvals_before_merge")]
        public System.Nullable<int> ApprovalsBeforeMerge
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<int>>("approvals_before_merge", default(System.Nullable<int>));
            }
            internal set
            {
                this.SetValue("approvals_before_merge", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("archived")]
        public bool Archived
        {
            get
            {
                return this.GetValueOrDefault<bool>("archived", default(bool));
            }
            internal set
            {
                this.SetValue("archived", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("ci_config_path")]
        public string CiConfigPath
        {
            get
            {
                return this.GetValueOrDefault<string>("ci_config_path", default(string));
            }
            internal set
            {
                this.SetValue("ci_config_path", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("container_registry_enabled")]
        public bool ContainerRegistryEnabled
        {
            get
            {
                return this.GetValueOrDefault<bool>("container_registry_enabled", default(bool));
            }
            internal set
            {
                this.SetValue("container_registry_enabled", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("creator_id")]
        public long CreatorId
        {
            get
            {
                return this.GetValueOrDefault<long>("creator_id", default(long));
            }
            internal set
            {
                this.SetValue("creator_id", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("forked_from_project")]
        public BasicProjectDetails ForkedFromProject
        {
            get
            {
                return this.GetValueOrDefault<BasicProjectDetails>("forked_from_project", default(BasicProjectDetails));
            }
            internal set
            {
                this.SetValue("forked_from_project", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("import_status")]
        public ImportStatus ImportStatus
        {
            get
            {
                return this.GetValueOrDefault<ImportStatus>("import_status", default(ImportStatus));
            }
            internal set
            {
                this.SetValue("import_status", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("issues_enabled")]
        public bool IssuesEnabled
        {
            get
            {
                return this.GetValueOrDefault<bool>("issues_enabled", default(bool));
            }
            internal set
            {
                this.SetValue("issues_enabled", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("jobs_enabled")]
        public bool JobsEnabled
        {
            get
            {
                return this.GetValueOrDefault<bool>("jobs_enabled", default(bool));
            }
            internal set
            {
                this.SetValue("jobs_enabled", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("lfs_enabled")]
        public bool LfsEnabled
        {
            get
            {
                return this.GetValueOrDefault<bool>("lfs_enabled", default(bool));
            }
            internal set
            {
                this.SetValue("lfs_enabled", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("_links")]
        public ProjectLink Links
        {
            get
            {
                return this.GetValueOrDefault<ProjectLink>("_links", default(ProjectLink));
            }
            internal set
            {
                this.SetValue("_links", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("merge_method")]
        public MergeMethod MergeMethod
        {
            get
            {
                return this.GetValueOrDefault<MergeMethod>("merge_method", default(MergeMethod));
            }
            internal set
            {
                this.SetValue("merge_method", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("merge_requests_enabled")]
        public bool MergeRequestsEnabled
        {
            get
            {
                return this.GetValueOrDefault<bool>("merge_requests_enabled", default(bool));
            }
            internal set
            {
                this.SetValue("merge_requests_enabled", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("mirror")]
        public bool Mirror
        {
            get
            {
                return this.GetValueOrDefault<bool>("mirror", default(bool));
            }
            internal set
            {
                this.SetValue("mirror", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("mirror_overwrites_diverged_branches")]
        public System.Nullable<bool> MirrorOverwritesDivergedBranches
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<bool>>("mirror_overwrites_diverged_branches", default(System.Nullable<bool>));
            }
            internal set
            {
                this.SetValue("mirror_overwrites_diverged_branches", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("mirror_trigger_builds")]
        public System.Nullable<bool> MirrorTriggerBuilds
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<bool>>("mirror_trigger_builds", default(System.Nullable<bool>));
            }
            internal set
            {
                this.SetValue("mirror_trigger_builds", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("mirror_user_id")]
        public System.Nullable<long> MirrorUserId
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<long>>("mirror_user_id", default(System.Nullable<long>));
            }
            internal set
            {
                this.SetValue("mirror_user_id", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("only_allow_merge_if_all_discussions_are_resolved")]
        public bool OnlyAllowMergeIfAllDiscussionsAreResolved
        {
            get
            {
                return this.GetValueOrDefault<bool>("only_allow_merge_if_all_discussions_are_resolved", default(bool));
            }
            internal set
            {
                this.SetValue("only_allow_merge_if_all_discussions_are_resolved", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("only_allow_merge_if_pipeline_succeeds")]
        public bool OnlyAllowMergeIfPipelineSucceeds
        {
            get
            {
                return this.GetValueOrDefault<bool>("only_allow_merge_if_pipeline_succeeds", default(bool));
            }
            internal set
            {
                this.SetValue("only_allow_merge_if_pipeline_succeeds", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("only_mirror_protected_branches")]
        public System.Nullable<bool> OnlyMirrorProtectedBranches
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<bool>>("only_mirror_protected_branches", default(System.Nullable<bool>));
            }
            internal set
            {
                this.SetValue("only_mirror_protected_branches", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("open_issues_count")]
        public System.Nullable<int> OpenIssuesCount
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<int>>("open_issues_count", default(System.Nullable<int>));
            }
            internal set
            {
                this.SetValue("open_issues_count", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("owner")]
        public UserBasic Owner
        {
            get
            {
                return this.GetValueOrDefault<UserBasic>("owner", default(UserBasic));
            }
            internal set
            {
                this.SetValue("owner", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("permissions")]
        public ProjectPermissions Permissions
        {
            get
            {
                return this.GetValueOrDefault<ProjectPermissions>("permissions", default(ProjectPermissions));
            }
            internal set
            {
                this.SetValue("permissions", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("printing_merge_request_link_enabled")]
        public bool PrintingMergeRequestLinkEnabled
        {
            get
            {
                return this.GetValueOrDefault<bool>("printing_merge_request_link_enabled", default(bool));
            }
            internal set
            {
                this.SetValue("printing_merge_request_link_enabled", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("public_jobs")]
        public bool PublicJobs
        {
            get
            {
                return this.GetValueOrDefault<bool>("public_jobs", default(bool));
            }
            internal set
            {
                this.SetValue("public_jobs", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("request_access_enabled")]
        public bool RequestAccessEnabled
        {
            get
            {
                return this.GetValueOrDefault<bool>("request_access_enabled", default(bool));
            }
            internal set
            {
                this.SetValue("request_access_enabled", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("resolve_outdated_diff_discussions")]
        public System.Nullable<bool> ResolveOutdatedDiffDiscussions
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<bool>>("resolve_outdated_diff_discussions", default(System.Nullable<bool>));
            }
            internal set
            {
                this.SetValue("resolve_outdated_diff_discussions", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("shared_runners_enabled")]
        public bool SharedRunnersEnabled
        {
            get
            {
                return this.GetValueOrDefault<bool>("shared_runners_enabled", default(bool));
            }
            internal set
            {
                this.SetValue("shared_runners_enabled", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("shared_with_groups")]
        public System.Collections.Generic.IReadOnlyList<SharedGroup> SharedWithGroups
        {
            get
            {
                return this.GetValueOrDefault<System.Collections.Generic.IReadOnlyList<SharedGroup>>("shared_with_groups", default(System.Collections.Generic.IReadOnlyList<SharedGroup>));
            }
            internal set
            {
                this.SetValue("shared_with_groups", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("snippets_enabled")]
        public bool SnippetsEnabled
        {
            get
            {
                return this.GetValueOrDefault<bool>("snippets_enabled", default(bool));
            }
            internal set
            {
                this.SetValue("snippets_enabled", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("visibility")]
        public ProjectVisibility Visibility
        {
            get
            {
                return this.GetValueOrDefault<ProjectVisibility>("visibility", default(ProjectVisibility));
            }
            internal set
            {
                this.SetValue("visibility", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("wiki_enabled")]
        public bool WikiEnabled
        {
            get
            {
                return this.GetValueOrDefault<bool>("wiki_enabled", default(bool));
            }
            internal set
            {
                this.SetValue("wiki_enabled", value);
            }
        }
    }

    public partial class ProjectAccess : MemberAccess
    {
        internal ProjectAccess(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal ProjectAccess()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }
    }

    [System.Diagnostics.DebuggerDisplayAttribute("{GetType().Name,nq} PathWithNamespace={PathWithNamespace}, Id={Id}")]
    public partial class ProjectIdentity : GitLab.GitLabObject, System.IEquatable<Meziantou.GitLab.ProjectIdentity>
    {
        internal ProjectIdentity(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal ProjectIdentity()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("created_at")]
        public System.DateTime CreatedAt
        {
            get
            {
                return this.GetValueOrDefault<System.DateTime>("created_at", default(System.DateTime));
            }
            internal set
            {
                this.SetValue("created_at", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("description")]
        public string Description
        {
            get
            {
                return this.GetValueOrDefault<string>("description", default(string));
            }
            internal set
            {
                this.SetValue("description", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("id")]
        public long Id
        {
            get
            {
                return this.GetValueOrDefault<long>("id", default(long));
            }
            internal set
            {
                this.SetValue("id", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("name")]
        public string Name
        {
            get
            {
                return this.GetValueOrDefault<string>("name", default(string));
            }
            internal set
            {
                this.SetValue("name", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("name_with_namespace")]
        public string NameWithNamespace
        {
            get
            {
                return this.GetValueOrDefault<string>("name_with_namespace", default(string));
            }
            internal set
            {
                this.SetValue("name_with_namespace", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("path")]
        public string Path
        {
            get
            {
                return this.GetValueOrDefault<string>("path", default(string));
            }
            internal set
            {
                this.SetValue("path", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("path_with_namespace")]
        public GitLab.PathWithNamespace PathWithNamespace
        {
            get
            {
                return this.GetValueOrDefault<GitLab.PathWithNamespace>("path_with_namespace", default(GitLab.PathWithNamespace));
            }
            internal set
            {
                this.SetValue("path_with_namespace", value);
            }
        }

        public override bool Equals(object obj)
        {
            Meziantou.GitLab.ProjectIdentity a = (obj as Meziantou.GitLab.ProjectIdentity);
            return this.Equals(a);
        }

        public virtual bool Equals(Meziantou.GitLab.ProjectIdentity obj)
        {
            return ((obj != null) && (this.Id == obj.Id));
        }

        public override int GetHashCode()
        {
            int hashCode = 574293967;
            hashCode = ((hashCode * -1521134295) + this.Id.GetHashCode());
            return hashCode;
        }

        public static bool operator !=(Meziantou.GitLab.ProjectIdentity a, Meziantou.GitLab.ProjectIdentity b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.ProjectIdentity a, Meziantou.GitLab.ProjectIdentity b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.ProjectIdentity>.Default.Equals(a, b);
        }
    }

    public partial class ProjectLink : GitLab.GitLabObject
    {
        internal ProjectLink(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal ProjectLink()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("events")]
        public string Events
        {
            get
            {
                return this.GetValueOrDefault<string>("events", default(string));
            }
            internal set
            {
                this.SetValue("events", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("issues")]
        public string Issues
        {
            get
            {
                return this.GetValueOrDefault<string>("issues", default(string));
            }
            internal set
            {
                this.SetValue("issues", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("labels")]
        public string Labels
        {
            get
            {
                return this.GetValueOrDefault<string>("labels", default(string));
            }
            internal set
            {
                this.SetValue("labels", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("members")]
        public string Members
        {
            get
            {
                return this.GetValueOrDefault<string>("members", default(string));
            }
            internal set
            {
                this.SetValue("members", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("merge_requests")]
        public string MergeRequests
        {
            get
            {
                return this.GetValueOrDefault<string>("merge_requests", default(string));
            }
            internal set
            {
                this.SetValue("merge_requests", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("repo_branches")]
        public string RepoBranches
        {
            get
            {
                return this.GetValueOrDefault<string>("repo_branches", default(string));
            }
            internal set
            {
                this.SetValue("repo_branches", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("self")]
        public string Self
        {
            get
            {
                return this.GetValueOrDefault<string>("self", default(string));
            }
            internal set
            {
                this.SetValue("self", value);
            }
        }
    }

    public partial class ProjectPermissions : GitLab.GitLabObject
    {
        internal ProjectPermissions(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal ProjectPermissions()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("group_access")]
        public GroupAccess GroupAccess
        {
            get
            {
                return this.GetValueOrDefault<GroupAccess>("group_access", default(GroupAccess));
            }
            internal set
            {
                this.SetValue("group_access", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("project_access")]
        public ProjectAccess ProjectAccess
        {
            get
            {
                return this.GetValueOrDefault<ProjectAccess>("project_access", default(ProjectAccess));
            }
            internal set
            {
                this.SetValue("project_access", value);
            }
        }
    }

    public partial class RenderedMarkdown : GitLab.GitLabObject, System.IEquatable<Meziantou.GitLab.RenderedMarkdown>
    {
        internal RenderedMarkdown(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal RenderedMarkdown()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("html")]
        public string Html
        {
            get
            {
                return this.GetValueOrDefault<string>("html", default(string));
            }
            internal set
            {
                this.SetValue("html", value);
            }
        }

        public override bool Equals(object obj)
        {
            Meziantou.GitLab.RenderedMarkdown a = (obj as Meziantou.GitLab.RenderedMarkdown);
            return this.Equals(a);
        }

        public virtual bool Equals(Meziantou.GitLab.RenderedMarkdown obj)
        {
            return ((obj != null) && (this.Html == obj.Html));
        }

        public override int GetHashCode()
        {
            int hashCode = 574293967;
            hashCode = ((hashCode * -1521134295) + System.Collections.Generic.EqualityComparer<string>.Default.GetHashCode("Html"));
            return hashCode;
        }

        public static bool operator !=(Meziantou.GitLab.RenderedMarkdown a, Meziantou.GitLab.RenderedMarkdown b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.RenderedMarkdown a, Meziantou.GitLab.RenderedMarkdown b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.RenderedMarkdown>.Default.Equals(a, b);
        }
    }

    public partial class ServerVersion : GitLab.GitLabObject, System.IEquatable<Meziantou.GitLab.ServerVersion>
    {
        internal ServerVersion(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal ServerVersion()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("revision")]
        public string Revision
        {
            get
            {
                return this.GetValueOrDefault<string>("revision", default(string));
            }
            internal set
            {
                this.SetValue("revision", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("version")]
        public string Version
        {
            get
            {
                return this.GetValueOrDefault<string>("version", default(string));
            }
            internal set
            {
                this.SetValue("version", value);
            }
        }

        public override bool Equals(object obj)
        {
            Meziantou.GitLab.ServerVersion a = (obj as Meziantou.GitLab.ServerVersion);
            return this.Equals(a);
        }

        public virtual bool Equals(Meziantou.GitLab.ServerVersion obj)
        {
            return (((obj != null) && (this.Version == obj.Version)) && (this.Revision == obj.Revision));
        }

        public override int GetHashCode()
        {
            int hashCode = 574293967;
            hashCode = ((hashCode * -1521134295) + System.Collections.Generic.EqualityComparer<string>.Default.GetHashCode("Version"));
            hashCode = ((hashCode * -1521134295) + System.Collections.Generic.EqualityComparer<string>.Default.GetHashCode("Revision"));
            return hashCode;
        }

        public static bool operator !=(Meziantou.GitLab.ServerVersion a, Meziantou.GitLab.ServerVersion b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.ServerVersion a, Meziantou.GitLab.ServerVersion b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.ServerVersion>.Default.Equals(a, b);
        }
    }

    public partial class SharedGroup : GitLab.GitLabObject
    {
        internal SharedGroup(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal SharedGroup()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("group_access_level")]
        public Access GroupAccessLevel
        {
            get
            {
                return this.GetValueOrDefault<Access>("group_access_level", default(Access));
            }
            internal set
            {
                this.SetValue("group_access_level", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("group_id")]
        public long GroupId
        {
            get
            {
                return this.GetValueOrDefault<long>("group_id", default(long));
            }
            internal set
            {
                this.SetValue("group_id", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("group_name")]
        public string GroupName
        {
            get
            {
                return this.GetValueOrDefault<string>("group_name", default(string));
            }
            internal set
            {
                this.SetValue("group_name", value);
            }
        }
    }

    [System.Diagnostics.DebuggerDisplayAttribute("{GetType().Name,nq} Title={Title}, Id={Id}")]
    public partial class SshKey : GitLab.GitLabObject, System.IEquatable<Meziantou.GitLab.SshKey>
    {
        internal SshKey(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal SshKey()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("created_at")]
        public System.DateTime CreatedAt
        {
            get
            {
                return this.GetValueOrDefault<System.DateTime>("created_at", default(System.DateTime));
            }
            internal set
            {
                this.SetValue("created_at", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("id")]
        public long Id
        {
            get
            {
                return this.GetValueOrDefault<long>("id", default(long));
            }
            internal set
            {
                this.SetValue("id", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("key")]
        public string Key
        {
            get
            {
                return this.GetValueOrDefault<string>("key", default(string));
            }
            internal set
            {
                this.SetValue("key", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("title")]
        public string Title
        {
            get
            {
                return this.GetValueOrDefault<string>("title", default(string));
            }
            internal set
            {
                this.SetValue("title", value);
            }
        }

        public override bool Equals(object obj)
        {
            Meziantou.GitLab.SshKey a = (obj as Meziantou.GitLab.SshKey);
            return this.Equals(a);
        }

        public virtual bool Equals(Meziantou.GitLab.SshKey obj)
        {
            return ((obj != null) && (this.Id == obj.Id));
        }

        public override int GetHashCode()
        {
            int hashCode = 574293967;
            hashCode = ((hashCode * -1521134295) + this.Id.GetHashCode());
            return hashCode;
        }

        public static bool operator !=(Meziantou.GitLab.SshKey a, Meziantou.GitLab.SshKey b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.SshKey a, Meziantou.GitLab.SshKey b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.SshKey>.Default.Equals(a, b);
        }
    }

    public partial class Todo : GitLab.GitLabObject, System.IEquatable<Meziantou.GitLab.Todo>
    {
        internal Todo(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal Todo()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("action_name")]
        public TodoAction ActionName
        {
            get
            {
                return this.GetValueOrDefault<TodoAction>("action_name", default(TodoAction));
            }
            internal set
            {
                this.SetValue("action_name", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("author")]
        public UserBasic Author
        {
            get
            {
                return this.GetValueOrDefault<UserBasic>("author", default(UserBasic));
            }
            internal set
            {
                this.SetValue("author", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("body")]
        public string Body
        {
            get
            {
                return this.GetValueOrDefault<string>("body", default(string));
            }
            internal set
            {
                this.SetValue("body", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("created_at")]
        public System.DateTime CreatedAt
        {
            get
            {
                return this.GetValueOrDefault<System.DateTime>("created_at", default(System.DateTime));
            }
            internal set
            {
                this.SetValue("created_at", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("id")]
        public long Id
        {
            get
            {
                return this.GetValueOrDefault<long>("id", default(long));
            }
            internal set
            {
                this.SetValue("id", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("project")]
        public BasicProjectDetails Project
        {
            get
            {
                return this.GetValueOrDefault<BasicProjectDetails>("project", default(BasicProjectDetails));
            }
            internal set
            {
                this.SetValue("project", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("state")]
        public TodoState State
        {
            get
            {
                return this.GetValueOrDefault<TodoState>("state", default(TodoState));
            }
            internal set
            {
                this.SetValue("state", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("target_type")]
        public TodoType TargetType
        {
            get
            {
                return this.GetValueOrDefault<TodoType>("target_type", default(TodoType));
            }
            internal set
            {
                this.SetValue("target_type", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("target_url")]
        public string TargetUrl
        {
            get
            {
                return this.GetValueOrDefault<string>("target_url", default(string));
            }
            internal set
            {
                this.SetValue("target_url", value);
            }
        }

        public override bool Equals(object obj)
        {
            Meziantou.GitLab.Todo a = (obj as Meziantou.GitLab.Todo);
            return this.Equals(a);
        }

        public virtual bool Equals(Meziantou.GitLab.Todo obj)
        {
            return ((obj != null) && (this.Id == obj.Id));
        }

        public override int GetHashCode()
        {
            int hashCode = 574293967;
            hashCode = ((hashCode * -1521134295) + this.Id.GetHashCode());
            return hashCode;
        }

        public static bool operator !=(Meziantou.GitLab.Todo a, Meziantou.GitLab.Todo b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.Todo a, Meziantou.GitLab.Todo b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.Todo>.Default.Equals(a, b);
        }
    }

    public partial class User : UserBasic
    {
        internal User(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal User()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("bio")]
        public string Bio
        {
            get
            {
                return this.GetValueOrDefault<string>("bio", default(string));
            }
            internal set
            {
                this.SetValue("bio", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("can_create_group")]
        public System.Nullable<bool> CanCreateGroup
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<bool>>("can_create_group", default(System.Nullable<bool>));
            }
            internal set
            {
                this.SetValue("can_create_group", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("can_create_project")]
        public System.Nullable<bool> CanCreateProject
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<bool>>("can_create_project", default(System.Nullable<bool>));
            }
            internal set
            {
                this.SetValue("can_create_project", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("color_scheme_id")]
        public System.Nullable<long> ColorSchemeId
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<long>>("color_scheme_id", default(System.Nullable<long>));
            }
            internal set
            {
                this.SetValue("color_scheme_id", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("confirmed_at")]
        public System.Nullable<System.DateTime> ConfirmedAt
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<System.DateTime>>("confirmed_at", default(System.Nullable<System.DateTime>));
            }
            internal set
            {
                this.SetValue("confirmed_at", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("created_at")]
        public System.DateTime CreatedAt
        {
            get
            {
                return this.GetValueOrDefault<System.DateTime>("created_at", default(System.DateTime));
            }
            internal set
            {
                this.SetValue("created_at", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("current_sign_in_at")]
        public System.Nullable<System.DateTime> CurrentSignInAt
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<System.DateTime>>("current_sign_in_at", default(System.Nullable<System.DateTime>));
            }
            internal set
            {
                this.SetValue("current_sign_in_at", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("email")]
        public string Email
        {
            get
            {
                return this.GetValueOrDefault<string>("email", default(string));
            }
            internal set
            {
                this.SetValue("email", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("external")]
        public System.Nullable<bool> External
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<bool>>("external", default(System.Nullable<bool>));
            }
            internal set
            {
                this.SetValue("external", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("identities")]
        public System.Collections.Generic.IReadOnlyList<Identity> Identities
        {
            get
            {
                return this.GetValueOrDefault<System.Collections.Generic.IReadOnlyList<Identity>>("identities", default(System.Collections.Generic.IReadOnlyList<Identity>));
            }
            internal set
            {
                this.SetValue("identities", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("is_admin")]
        public System.Nullable<bool> IsAdmin
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<bool>>("is_admin", default(System.Nullable<bool>));
            }
            internal set
            {
                this.SetValue("is_admin", value);
            }
        }

        [Meziantou.GitLab.SkipUtcDateValidationAttribute("Does not contain time nor timezone (e.g. 2018-01-01)")]
        [Meziantou.GitLab.MappedPropertyAttribute("last_activity_on")]
        public System.Nullable<System.DateTime> LastActivityOn
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<System.DateTime>>("last_activity_on", default(System.Nullable<System.DateTime>));
            }
            internal set
            {
                this.SetValue("last_activity_on", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("last_sign_in_at")]
        public System.Nullable<System.DateTime> LastSignInAt
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<System.DateTime>>("last_sign_in_at", default(System.Nullable<System.DateTime>));
            }
            internal set
            {
                this.SetValue("last_sign_in_at", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("linkedin")]
        public string Linkedin
        {
            get
            {
                return this.GetValueOrDefault<string>("linkedin", default(string));
            }
            internal set
            {
                this.SetValue("linkedin", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("location")]
        public string Location
        {
            get
            {
                return this.GetValueOrDefault<string>("location", default(string));
            }
            internal set
            {
                this.SetValue("location", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("organization")]
        public string Organization
        {
            get
            {
                return this.GetValueOrDefault<string>("organization", default(string));
            }
            internal set
            {
                this.SetValue("organization", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("private_profile")]
        public object PrivateProfile
        {
            get
            {
                return this.GetValueOrDefault<object>("private_profile", default(object));
            }
            internal set
            {
                this.SetValue("private_profile", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("projects_limit")]
        public System.Nullable<long> ProjectsLimit
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<long>>("projects_limit", default(System.Nullable<long>));
            }
            internal set
            {
                this.SetValue("projects_limit", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("shared_runners_minutes_limit")]
        public System.Nullable<long> SharedRunnersMinutesLimit
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<long>>("shared_runners_minutes_limit", default(System.Nullable<long>));
            }
            internal set
            {
                this.SetValue("shared_runners_minutes_limit", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("skype")]
        public string Skype
        {
            get
            {
                return this.GetValueOrDefault<string>("skype", default(string));
            }
            internal set
            {
                this.SetValue("skype", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("theme_id")]
        public System.Nullable<long> ThemeId
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<long>>("theme_id", default(System.Nullable<long>));
            }
            internal set
            {
                this.SetValue("theme_id", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("twitter")]
        public string Twitter
        {
            get
            {
                return this.GetValueOrDefault<string>("twitter", default(string));
            }
            internal set
            {
                this.SetValue("twitter", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("two_factor_enabled")]
        public System.Nullable<bool> TwoFactorEnabled
        {
            get
            {
                return this.GetValueOrDefault<System.Nullable<bool>>("two_factor_enabled", default(System.Nullable<bool>));
            }
            internal set
            {
                this.SetValue("two_factor_enabled", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("website_url")]
        public string WebsiteUrl
        {
            get
            {
                return this.GetValueOrDefault<string>("website_url", default(string));
            }
            internal set
            {
                this.SetValue("website_url", value);
            }
        }
    }

    public partial class UserActivity : GitLab.GitLabObject
    {
        internal UserActivity(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal UserActivity()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.SkipUtcDateValidationAttribute("Does not contain time nor timezone (e.g. 2018-01-01)")]
        [Meziantou.GitLab.MappedPropertyAttribute("last_activity_on")]
        public System.DateTime LastActivityOn
        {
            get
            {
                return this.GetValueOrDefault<System.DateTime>("last_activity_on", default(System.DateTime));
            }
            internal set
            {
                this.SetValue("last_activity_on", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("username")]
        public string Username
        {
            get
            {
                return this.GetValueOrDefault<string>("username", default(string));
            }
            internal set
            {
                this.SetValue("username", value);
            }
        }
    }

    public partial class UserBasic : UserSafe
    {
        internal UserBasic(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal UserBasic()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("avatar_path")]
        public string AvatarPath
        {
            get
            {
                return this.GetValueOrDefault<string>("avatar_path", default(string));
            }
            internal set
            {
                this.SetValue("avatar_path", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("avatar_url")]
        public string AvatarUrl
        {
            get
            {
                return this.GetValueOrDefault<string>("avatar_url", default(string));
            }
            internal set
            {
                this.SetValue("avatar_url", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("state")]
        public UserState State
        {
            get
            {
                return this.GetValueOrDefault<UserState>("state", default(UserState));
            }
            internal set
            {
                this.SetValue("state", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("web_url")]
        public string WebUrl
        {
            get
            {
                return this.GetValueOrDefault<string>("web_url", default(string));
            }
            internal set
            {
                this.SetValue("web_url", value);
            }
        }
    }

    [System.Diagnostics.DebuggerDisplayAttribute("{GetType().Name,nq} Username={Username}, Id={Id}")]
    public partial class UserSafe : GitLab.GitLabObject, System.IEquatable<Meziantou.GitLab.UserSafe>
    {
        internal UserSafe(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal UserSafe()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("id")]
        public long Id
        {
            get
            {
                return this.GetValueOrDefault<long>("id", default(long));
            }
            internal set
            {
                this.SetValue("id", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("name")]
        public string Name
        {
            get
            {
                return this.GetValueOrDefault<string>("name", default(string));
            }
            internal set
            {
                this.SetValue("name", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("username")]
        public string Username
        {
            get
            {
                return this.GetValueOrDefault<string>("username", default(string));
            }
            internal set
            {
                this.SetValue("username", value);
            }
        }

        public override bool Equals(object obj)
        {
            Meziantou.GitLab.UserSafe a = (obj as Meziantou.GitLab.UserSafe);
            return this.Equals(a);
        }

        public virtual bool Equals(Meziantou.GitLab.UserSafe obj)
        {
            return ((obj != null) && (this.Id == obj.Id));
        }

        public override int GetHashCode()
        {
            int hashCode = 574293967;
            hashCode = ((hashCode * -1521134295) + this.Id.GetHashCode());
            return hashCode;
        }

        public static bool operator !=(Meziantou.GitLab.UserSafe a, Meziantou.GitLab.UserSafe b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.UserSafe a, Meziantou.GitLab.UserSafe b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.UserSafe>.Default.Equals(a, b);
        }
    }

    public partial class UserStatus : GitLab.GitLabObject
    {
        internal UserStatus(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal UserStatus()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("emoji")]
        public string Emoji
        {
            get
            {
                return this.GetValueOrDefault<string>("emoji", default(string));
            }
            internal set
            {
                this.SetValue("emoji", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("message")]
        public string Message
        {
            get
            {
                return this.GetValueOrDefault<string>("message", default(string));
            }
            internal set
            {
                this.SetValue("message", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("message_html")]
        public string MessageHtml
        {
            get
            {
                return this.GetValueOrDefault<string>("message_html", default(string));
            }
            internal set
            {
                this.SetValue("message_html", value);
            }
        }
    }

    public partial class WikiPage : GitLab.GitLabObject, System.IEquatable<Meziantou.GitLab.WikiPage>
    {
        internal WikiPage(Newtonsoft.Json.Linq.JObject obj)
            : base(obj)
        {
        }

        internal WikiPage()
            : base(new Newtonsoft.Json.Linq.JObject())
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("content")]
        public string Content
        {
            get
            {
                return this.GetValueOrDefault<string>("content", default(string));
            }
            internal set
            {
                this.SetValue("content", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("format")]
        public WikiPageFormat Format
        {
            get
            {
                return this.GetValueOrDefault<WikiPageFormat>("format", default(WikiPageFormat));
            }
            internal set
            {
                this.SetValue("format", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("slug")]
        public string Slug
        {
            get
            {
                return this.GetValueOrDefault<string>("slug", default(string));
            }
            internal set
            {
                this.SetValue("slug", value);
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("title")]
        public string Title
        {
            get
            {
                return this.GetValueOrDefault<string>("title", default(string));
            }
            internal set
            {
                this.SetValue("title", value);
            }
        }

        public override bool Equals(object obj)
        {
            Meziantou.GitLab.WikiPage a = (obj as Meziantou.GitLab.WikiPage);
            return this.Equals(a);
        }

        public virtual bool Equals(Meziantou.GitLab.WikiPage obj)
        {
            return ((obj != null) && (this.Slug == obj.Slug));
        }

        public override int GetHashCode()
        {
            int hashCode = 574293967;
            hashCode = ((hashCode * -1521134295) + System.Collections.Generic.EqualityComparer<string>.Default.GetHashCode("Slug"));
            return hashCode;
        }

        public static bool operator !=(Meziantou.GitLab.WikiPage a, Meziantou.GitLab.WikiPage b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.WikiPage a, Meziantou.GitLab.WikiPage b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.WikiPage>.Default.Equals(a, b);
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

        private ProjectIdOrPathRef(GitLab.PathWithNamespace projectPathWithNamespace)
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

        public static implicit operator Meziantou.GitLab.ProjectIdOrPathRef(GitLab.PathWithNamespace projectPathWithNamespace)
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
    public readonly partial struct TodoRef : Meziantou.GitLab.IReference
    {
        private readonly object _value;

        private TodoRef(long TodoId)
        {
            this._value = TodoId;
        }

        private TodoRef(Todo todo)
        {
            if ((todo == null))
            {
                throw new System.ArgumentNullException(nameof(todo));
            }

            this._value = todo.Id;
        }

        public object Value
        {
            get
            {
                return this._value;
            }
        }

        public static implicit operator Meziantou.GitLab.TodoRef(long TodoId)
        {
            return new Meziantou.GitLab.TodoRef(TodoId);
        }

        public static implicit operator Meziantou.GitLab.TodoRef(Todo todo)
        {
            if ((todo == null))
            {
                throw new System.ArgumentNullException(nameof(todo));
            }

            return new Meziantou.GitLab.TodoRef(todo);
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
    }

    partial interface IGitLabClient
    {
        /// <summary>Creates a new key owned by the currently authenticated user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<SshKey> AddSshKeyAsync(UserRef user, string title, string key, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Creates a new key owned by the currently authenticated user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<SshKey> AddSshKeyAsync(string title, string key, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

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

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<WikiPage> CreateWikiPageAsync(ProjectIdOrPathRef project, string content, string title, System.Nullable<WikiPageFormat> format = default(System.Nullable<WikiPageFormat>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Deletes key owned by currently authenticated user.</summary>
        /// <param name="id">SSH key ID</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task DeleteSshKeyAsync(SshKeyRef id, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task DeleteWikiPageAsync(ProjectIdOrPathRef project, string slug, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Shows information about a single merge request.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<MergeRequest> GetMergeRequestAsync(ProjectIdOrPathRef project, MergeRequestIidRef mergeRequest, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Get all merge requests the authenticated user has access to. By default it returns only merge requests created by the current user. To get all merge requests, use parameter scope=all.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<MergeRequest>> GetMergeRequestsAsync(System.Nullable<MergeRequestState> state = default(System.Nullable<MergeRequestState>), System.Nullable<MergeRequestScopeFilter> scope = default(System.Nullable<MergeRequestScopeFilter>), System.Nullable<UserRef> assigneeId = default(System.Nullable<UserRef>), System.Nullable<UserRef> authorId = default(System.Nullable<UserRef>), string milestone = default(string), System.Nullable<MergeRequestView> view = default(System.Nullable<MergeRequestView>), System.Collections.Generic.IEnumerable<string> labels = default(System.Collections.Generic.IEnumerable<string>), System.Nullable<System.DateTime> createdAfter = default(System.Nullable<System.DateTime>), System.Nullable<System.DateTime> createdBefore = default(System.Nullable<System.DateTime>), System.Nullable<System.DateTime> updatedAfter = default(System.Nullable<System.DateTime>), System.Nullable<System.DateTime> updatedBefore = default(System.Nullable<System.DateTime>), string myReactionEmoji = default(string), string sourceBranch = default(string), string targetBranch = default(string), string search = default(string), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Get all merge requests for this group and its subgroups.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<MergeRequest>> GetMergeRequestsAsync(long group, System.Nullable<MergeRequestState> state = default(System.Nullable<MergeRequestState>), System.Nullable<MergeRequestScopeFilter> scope = default(System.Nullable<MergeRequestScopeFilter>), System.Nullable<UserRef> assigneeId = default(System.Nullable<UserRef>), System.Nullable<UserRef> authorId = default(System.Nullable<UserRef>), string milestone = default(string), System.Nullable<MergeRequestView> view = default(System.Nullable<MergeRequestView>), System.Collections.Generic.IEnumerable<string> labels = default(System.Collections.Generic.IEnumerable<string>), System.Nullable<System.DateTime> createdAfter = default(System.Nullable<System.DateTime>), System.Nullable<System.DateTime> createdBefore = default(System.Nullable<System.DateTime>), System.Nullable<System.DateTime> updatedAfter = default(System.Nullable<System.DateTime>), System.Nullable<System.DateTime> updatedBefore = default(System.Nullable<System.DateTime>), string myReactionEmoji = default(string), string sourceBranch = default(string), string targetBranch = default(string), string search = default(string), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Get all merge requests for this project.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<MergeRequest>> GetMergeRequestsAsync(ProjectIdOrPathRef project, System.Collections.Generic.IEnumerable<GitLab.GitObjectId> iids = default(System.Collections.Generic.IEnumerable<GitLab.GitObjectId>), System.Nullable<MergeRequestState> state = default(System.Nullable<MergeRequestState>), System.Nullable<MergeRequestScopeFilter> scope = default(System.Nullable<MergeRequestScopeFilter>), System.Nullable<UserRef> assigneeId = default(System.Nullable<UserRef>), System.Nullable<UserRef> authorId = default(System.Nullable<UserRef>), string milestone = default(string), System.Nullable<MergeRequestView> view = default(System.Nullable<MergeRequestView>), System.Collections.Generic.IEnumerable<string> labels = default(System.Collections.Generic.IEnumerable<string>), System.Nullable<System.DateTime> createdAfter = default(System.Nullable<System.DateTime>), System.Nullable<System.DateTime> createdBefore = default(System.Nullable<System.DateTime>), System.Nullable<System.DateTime> updatedAfter = default(System.Nullable<System.DateTime>), System.Nullable<System.DateTime> updatedBefore = default(System.Nullable<System.DateTime>), string myReactionEmoji = default(string), string sourceBranch = default(string), string targetBranch = default(string), string search = default(string), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Get a specific project. This endpoint can be accessed without authentication if the project is publicly accessible.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<Project> GetProjectAsync(ProjectIdOrPathRef id, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Get a list of visible projects for the given user. When accessed without authentication, only public projects are returned.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<Project>> GetProjectsAsync(UserRef user, System.Nullable<bool> archived = default(System.Nullable<bool>), System.Nullable<ProjectVisibility> visibility = default(System.Nullable<ProjectVisibility>), string search = default(string), System.Nullable<bool> simple = default(System.Nullable<bool>), System.Nullable<bool> owned = default(System.Nullable<bool>), System.Nullable<bool> membership = default(System.Nullable<bool>), System.Nullable<bool> starred = default(System.Nullable<bool>), System.Nullable<bool> statistics = default(System.Nullable<bool>), System.Nullable<bool> withIssuesEnabled = default(System.Nullable<bool>), System.Nullable<bool> withMergeRequestsEnabled = default(System.Nullable<bool>), System.Nullable<bool> wikiChecksumFailed = default(System.Nullable<bool>), System.Nullable<bool> repositoryChecksumFailed = default(System.Nullable<bool>), System.Nullable<Access> minAccessLevel = default(System.Nullable<Access>), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Get a list of all visible projects across GitLab for the authenticated user. When accessed without authentication, only public projects with "simple" fields are returned.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<Project>> GetProjectsAsync(System.Nullable<bool> archived = default(System.Nullable<bool>), System.Nullable<ProjectVisibility> visibility = default(System.Nullable<ProjectVisibility>), string search = default(string), System.Nullable<bool> simple = default(System.Nullable<bool>), System.Nullable<bool> owned = default(System.Nullable<bool>), System.Nullable<bool> membership = default(System.Nullable<bool>), System.Nullable<bool> starred = default(System.Nullable<bool>), System.Nullable<bool> statistics = default(System.Nullable<bool>), System.Nullable<bool> withIssuesEnabled = default(System.Nullable<bool>), System.Nullable<bool> withMergeRequestsEnabled = default(System.Nullable<bool>), System.Nullable<bool> wikiChecksumFailed = default(System.Nullable<bool>), System.Nullable<bool> repositoryChecksumFailed = default(System.Nullable<bool>), System.Nullable<Access> minAccessLevel = default(System.Nullable<Access>), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

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

        /// <summary>Get the status of the currently signed in user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<UserStatus> GetUserStatusAsync(GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Get the status of a user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<UserStatus> GetUserStatusAsync(UserRef user, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Get a list of users.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<UserBasic>> GetUsersAsync(string username = default(string), bool onlyActiveUsers = default(bool), bool onlyBlockedUsers = default(bool), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<ServerVersion> GetVersionAsync(GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<WikiPage> GetWikiPageAsync(ProjectIdOrPathRef project, string slug, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<WikiPage>> GetWikiPagesAsync(ProjectIdOrPathRef project, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Marks all pending todos for the current user as done.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task MarkAllTodosAsDoneAsync(GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Marks a single pending todo given by its ID for the current user as done.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<Todo> MarkTodoAsDoneAsync(TodoRef todo, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<RenderedMarkdown> RenderMarkdownAsync(string text, System.Nullable<bool> gfm = default(System.Nullable<bool>), string project = default(string), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>Set the status of the current user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<UserStatus> SetUserStatusAsync(string emoji = default(string), string message = default(string), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<FileUpdated> UpdateFileAsync(ProjectIdOrPathRef project, string filePath, string branch, string content, string commitMessage, string startBranch = default(string), string encoding = default(string), string authorEmail = default(string), string authorName = default(string), System.Nullable<GitLab.GitObjectId> lastCommitId = default(System.Nullable<GitLab.GitObjectId>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<WikiPage> UpdateWikiPageAsync(ProjectIdOrPathRef project, string slug, string content = default(string), string title = default(string), System.Nullable<WikiPageFormat> format = default(System.Nullable<WikiPageFormat>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }

    partial class GitLabClient : Meziantou.GitLab.IGitLabClient
    {
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

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<WikiPage> CreateWikiPageAsync(ProjectIdOrPathRef project, string content, string title, System.Nullable<WikiPageFormat> format = default(System.Nullable<WikiPageFormat>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("projects/:project/wikis");
            urlBuilder.WithValue("project", project.Value);
            string url = urlBuilder.Build();
            System.Collections.Generic.Dictionary<string, object> body = new System.Collections.Generic.Dictionary<string, object>();
            body.Add("content", content);
            body.Add("title", title);
            if ((format != null))
            {
                body.Add("format", format);
            }

            return this.PostJsonAsync<WikiPage>(url, body, requestOptions, cancellationToken);
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

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task DeleteWikiPageAsync(ProjectIdOrPathRef project, string slug, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("projects/:project/wikis/:slug");
            urlBuilder.WithValue("project", project.Value);
            urlBuilder.WithValue("slug", slug);
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

        /// <summary>Get all merge requests the authenticated user has access to. By default it returns only merge requests created by the current user. To get all merge requests, use parameter scope=all.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<MergeRequest>> GetMergeRequestsAsync(System.Nullable<MergeRequestState> state = default(System.Nullable<MergeRequestState>), System.Nullable<MergeRequestScopeFilter> scope = default(System.Nullable<MergeRequestScopeFilter>), System.Nullable<UserRef> assigneeId = default(System.Nullable<UserRef>), System.Nullable<UserRef> authorId = default(System.Nullable<UserRef>), string milestone = default(string), System.Nullable<MergeRequestView> view = default(System.Nullable<MergeRequestView>), System.Collections.Generic.IEnumerable<string> labels = default(System.Collections.Generic.IEnumerable<string>), System.Nullable<System.DateTime> createdAfter = default(System.Nullable<System.DateTime>), System.Nullable<System.DateTime> createdBefore = default(System.Nullable<System.DateTime>), System.Nullable<System.DateTime> updatedAfter = default(System.Nullable<System.DateTime>), System.Nullable<System.DateTime> updatedBefore = default(System.Nullable<System.DateTime>), string myReactionEmoji = default(string), string sourceBranch = default(string), string targetBranch = default(string), string search = default(string), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("merge_requests");
            urlBuilder.WithValue("state", state);
            urlBuilder.WithValue("scope", scope);
            if (assigneeId.HasValue)
            {
                urlBuilder.WithValue("assignee_id", assigneeId.Value.Value);
            }

            if (authorId.HasValue)
            {
                urlBuilder.WithValue("author_id", authorId.Value.Value);
            }

            urlBuilder.WithValue("milestone", milestone);
            urlBuilder.WithValue("view", view);
            urlBuilder.WithValue("labels", labels);
            urlBuilder.WithValue("created_after", createdAfter);
            urlBuilder.WithValue("created_before", createdBefore);
            urlBuilder.WithValue("updated_after", updatedAfter);
            urlBuilder.WithValue("updated_before", updatedBefore);
            urlBuilder.WithValue("my_reaction_emoji", myReactionEmoji);
            urlBuilder.WithValue("source_branch", sourceBranch);
            urlBuilder.WithValue("target_branch", targetBranch);
            urlBuilder.WithValue("search", search);
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

        /// <summary>Get all merge requests for this group and its subgroups.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<MergeRequest>> GetMergeRequestsAsync(long group, System.Nullable<MergeRequestState> state = default(System.Nullable<MergeRequestState>), System.Nullable<MergeRequestScopeFilter> scope = default(System.Nullable<MergeRequestScopeFilter>), System.Nullable<UserRef> assigneeId = default(System.Nullable<UserRef>), System.Nullable<UserRef> authorId = default(System.Nullable<UserRef>), string milestone = default(string), System.Nullable<MergeRequestView> view = default(System.Nullable<MergeRequestView>), System.Collections.Generic.IEnumerable<string> labels = default(System.Collections.Generic.IEnumerable<string>), System.Nullable<System.DateTime> createdAfter = default(System.Nullable<System.DateTime>), System.Nullable<System.DateTime> createdBefore = default(System.Nullable<System.DateTime>), System.Nullable<System.DateTime> updatedAfter = default(System.Nullable<System.DateTime>), System.Nullable<System.DateTime> updatedBefore = default(System.Nullable<System.DateTime>), string myReactionEmoji = default(string), string sourceBranch = default(string), string targetBranch = default(string), string search = default(string), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("groups/:group/merge_requests");
            urlBuilder.WithValue("group", group);
            urlBuilder.WithValue("state", state);
            urlBuilder.WithValue("scope", scope);
            if (assigneeId.HasValue)
            {
                urlBuilder.WithValue("assignee_id", assigneeId.Value.Value);
            }

            if (authorId.HasValue)
            {
                urlBuilder.WithValue("author_id", authorId.Value.Value);
            }

            urlBuilder.WithValue("milestone", milestone);
            urlBuilder.WithValue("view", view);
            urlBuilder.WithValue("labels", labels);
            urlBuilder.WithValue("created_after", createdAfter);
            urlBuilder.WithValue("created_before", createdBefore);
            urlBuilder.WithValue("updated_after", updatedAfter);
            urlBuilder.WithValue("updated_before", updatedBefore);
            urlBuilder.WithValue("my_reaction_emoji", myReactionEmoji);
            urlBuilder.WithValue("source_branch", sourceBranch);
            urlBuilder.WithValue("target_branch", targetBranch);
            urlBuilder.WithValue("search", search);
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

        /// <summary>Get all merge requests for this project.</summary>
        /// <param name="pageOptions">The page index and page size</param>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<Meziantou.GitLab.PagedResponse<MergeRequest>> GetMergeRequestsAsync(ProjectIdOrPathRef project, System.Collections.Generic.IEnumerable<GitLab.GitObjectId> iids = default(System.Collections.Generic.IEnumerable<GitLab.GitObjectId>), System.Nullable<MergeRequestState> state = default(System.Nullable<MergeRequestState>), System.Nullable<MergeRequestScopeFilter> scope = default(System.Nullable<MergeRequestScopeFilter>), System.Nullable<UserRef> assigneeId = default(System.Nullable<UserRef>), System.Nullable<UserRef> authorId = default(System.Nullable<UserRef>), string milestone = default(string), System.Nullable<MergeRequestView> view = default(System.Nullable<MergeRequestView>), System.Collections.Generic.IEnumerable<string> labels = default(System.Collections.Generic.IEnumerable<string>), System.Nullable<System.DateTime> createdAfter = default(System.Nullable<System.DateTime>), System.Nullable<System.DateTime> createdBefore = default(System.Nullable<System.DateTime>), System.Nullable<System.DateTime> updatedAfter = default(System.Nullable<System.DateTime>), System.Nullable<System.DateTime> updatedBefore = default(System.Nullable<System.DateTime>), string myReactionEmoji = default(string), string sourceBranch = default(string), string targetBranch = default(string), string search = default(string), Meziantou.GitLab.PageOptions pageOptions = default(Meziantou.GitLab.PageOptions), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("projects/:project/merge_requests");
            urlBuilder.WithValue("project", project.Value);
            urlBuilder.WithValue("iids", iids);
            urlBuilder.WithValue("state", state);
            urlBuilder.WithValue("scope", scope);
            if (assigneeId.HasValue)
            {
                urlBuilder.WithValue("assignee_id", assigneeId.Value.Value);
            }

            if (authorId.HasValue)
            {
                urlBuilder.WithValue("author_id", authorId.Value.Value);
            }

            urlBuilder.WithValue("milestone", milestone);
            urlBuilder.WithValue("view", view);
            urlBuilder.WithValue("labels", labels);
            urlBuilder.WithValue("created_after", createdAfter);
            urlBuilder.WithValue("created_before", createdBefore);
            urlBuilder.WithValue("updated_after", updatedAfter);
            urlBuilder.WithValue("updated_before", updatedBefore);
            urlBuilder.WithValue("my_reaction_emoji", myReactionEmoji);
            urlBuilder.WithValue("source_branch", sourceBranch);
            urlBuilder.WithValue("target_branch", targetBranch);
            urlBuilder.WithValue("search", search);
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

        /// <summary>Get the status of the currently signed in user.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<UserStatus> GetUserStatusAsync(GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("user/status");
            string url = urlBuilder.Build();
            return this.GetAsync<UserStatus>(url, requestOptions, cancellationToken);
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

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<WikiPage> GetWikiPageAsync(ProjectIdOrPathRef project, string slug, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("projects/:project/wikis/:slug");
            urlBuilder.WithValue("project", project.Value);
            urlBuilder.WithValue("slug", slug);
            string url = urlBuilder.Build();
            return this.GetAsync<WikiPage>(url, requestOptions, cancellationToken);
        }

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<WikiPage>> GetWikiPagesAsync(ProjectIdOrPathRef project, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("projects/:project/wikis");
            urlBuilder.WithValue("project", project.Value);
            string url = urlBuilder.Build();
            return this.GetCollectionAsync<WikiPage>(url, requestOptions, cancellationToken);
        }

        /// <summary>Marks all pending todos for the current user as done.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task MarkAllTodosAsDoneAsync(GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("todos/mark_as_done");
            string url = urlBuilder.Build();
            return this.PostJsonAsync(url, null, requestOptions, cancellationToken);
        }

        /// <summary>Marks a single pending todo given by its ID for the current user as done.</summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<Todo> MarkTodoAsDoneAsync(TodoRef todo, GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("todos/:todo/mark_as_done");
            urlBuilder.WithValue("todo", todo.Value);
            string url = urlBuilder.Build();
            return this.PostJsonAsync<Todo>(url, null, requestOptions, cancellationToken);
        }

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<RenderedMarkdown> RenderMarkdownAsync(string text, System.Nullable<bool> gfm = default(System.Nullable<bool>), string project = default(string), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("markdown");
            string url = urlBuilder.Build();
            System.Collections.Generic.Dictionary<string, object> body = new System.Collections.Generic.Dictionary<string, object>();
            body.Add("text", text);
            if ((gfm != null))
            {
                body.Add("gfm", gfm);
            }

            if ((project != null))
            {
                body.Add("project", project);
            }

            return this.PostJsonAsync<RenderedMarkdown>(url, body, requestOptions, cancellationToken);
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
        public System.Threading.Tasks.Task<FileUpdated> UpdateFileAsync(ProjectIdOrPathRef project, string filePath, string branch, string content, string commitMessage, string startBranch = default(string), string encoding = default(string), string authorEmail = default(string), string authorName = default(string), System.Nullable<GitLab.GitObjectId> lastCommitId = default(System.Nullable<GitLab.GitObjectId>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public System.Threading.Tasks.Task<WikiPage> UpdateWikiPageAsync(ProjectIdOrPathRef project, string slug, string content = default(string), string title = default(string), System.Nullable<WikiPageFormat> format = default(System.Nullable<WikiPageFormat>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("projects/:project/wikis/:slug");
            urlBuilder.WithValue("project", project.Value);
            urlBuilder.WithValue("slug", slug);
            string url = urlBuilder.Build();
            System.Collections.Generic.Dictionary<string, object> body = new System.Collections.Generic.Dictionary<string, object>();
            if ((content != null))
            {
                body.Add("content", content);
            }

            if ((title != null))
            {
                body.Add("title", title);
            }

            if ((format != null))
            {
                body.Add("format", format);
            }

            return this.PutJsonAsync<WikiPage>(url, body, requestOptions, cancellationToken);
        }
    }

    public static partial class GitLabClientExtensions
    {
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<FileCreated> CreateFileAsync(this IGitLabClient client, ProjectIdOrPathRef project, string filePath, string branch, System.Byte[] content, string commitMessage, string startBranch = default(string), string authorEmail = default(string), string authorName = default(string), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return client.CreateFileAsync(project, filePath, branch, System.Convert.ToBase64String(content), commitMessage, startBranch, "base64", authorEmail, authorName, requestOptions, cancellationToken);
        }

        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<FileUpdated> UpdateFileAsync(this IGitLabClient client, ProjectIdOrPathRef project, string filePath, string branch, System.Byte[] content, string commitMessage, string startBranch = default(string), string authorEmail = default(string), string authorName = default(string), System.Nullable<GitLab.GitObjectId> lastCommitId = default(System.Nullable<GitLab.GitObjectId>), GitLab.RequestOptions requestOptions = default(GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return client.UpdateFileAsync(project, filePath, branch, System.Convert.ToBase64String(content), commitMessage, startBranch, "base64", authorEmail, authorName, lastCommitId, requestOptions, cancellationToken);
        }
    }
}
