namespace Meziantou.GitLab
{
    public partial class Identity : GitLab.GitLabObject
    {
        private string _provider;

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

        private string _externUid;

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
    }

    public partial class SshKey : GitLab.GitLabObject
    {
        private long _id;

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

        private string _title;

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

        private string _key;

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

        private System.DateTime _createdAt;

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
    }

    public partial class User : UserBasic
    {
        private UserState _state;

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

        private System.DateTime _createdAt;

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

        private string _bio;

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

        private string _location;

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

        private string _skype;

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

        private string _linkedin;

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

        private string _twitter;

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

        private string _websiteUrl;

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

        private string _organization;

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

        private System.Nullable<System.DateTime> _currentSignInAt;

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

        private System.Nullable<System.DateTime> _lastSignInAt;

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

        private System.Nullable<System.DateTime> _confirmedAt;

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

        private System.Nullable<System.DateTime> _lastActivityOn;

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

        private string _email;

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

        private long _themeId;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "theme_id")]
        public long ThemeId
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

        private long _colorSchemeId;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "color_scheme_id")]
        public long ColorSchemeId
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

        private long _projectsLimit;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "projects_limit")]
        public long ProjectsLimit
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

        private System.Collections.Generic.IReadOnlyList<Identity> _identities;

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

        private bool _canCreateGroup;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "can_create_group")]
        public bool CanCreateGroup
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

        private bool _canCreateProject;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "can_create_project")]
        public bool CanCreateProject
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

        private bool _twoFactorEnabled;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "two_factor_enabled")]
        public bool TwoFactorEnabled
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

        private bool _external;

        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "external")]
        public bool External
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

        private object _privateProfile;

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

        private System.Nullable<long> _sharedRunnersMinutesLimit;

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

        private System.Nullable<bool> _isAdmin;

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
    }

    public partial class UserActivity : GitLab.GitLabObject
    {
        private string _username;

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

        private System.DateTime _lastActivityOn;

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
    }

    public partial class UserBasic : UserSafe
    {
        private string _avatarUrl;

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

        private string _avatarPath;

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

        private string _webUrl;

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

        private string _name;

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

        private string _username;

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

        private string _message;

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

        private string _messageHtml;

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

    public partial class AddSshKey
    {
        private string _title;

        /// <summary>new SSH Key's title</summary>
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "title")]
        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
            }
        }

        private string _key;

        /// <summary>new SSH key</summary>
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "key")]
        public string Key
        {
            get
            {
                return this._key;
            }
            set
            {
                this._key = value;
            }
        }
    }

    public partial class SetUserStatus
    {
        private string _emoji;

        /// <summary>The name of the emoji to use as status, if omitted speech_balloon is used. Emoji name can be one of the specified names in the Gemojione index.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "emoji")]
        public string Emoji
        {
            get
            {
                return this._emoji;
            }
            set
            {
                this._emoji = value;
            }
        }

        private string _message;

        /// <summary>The message to set as a status. It can also contain emoji codes.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute(PropertyName = "message")]
        public string Message
        {
            get
            {
                return this._message;
            }
            set
            {
                this._message = value;
            }
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
        public System.Threading.Tasks.Task<UserStatus> SetUserStatusAsync(SetUserStatus status, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("user/status");

            string url = urlBuilder.Build();

            return this.PutJsonAsync<UserStatus>(url, status, cancellationToken);
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
        public System.Threading.Tasks.Task<SshKey> AddSshKeyAsync(AddSshKey sshKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("user/keys");

            string url = urlBuilder.Build();

            return this.PostJsonAsync<SshKey>(url, sshKey, cancellationToken);
        }

        /// <summary>Creates a new key owned by the currently authenticated user.</summary>
        /// <param name="user">new SSH Key's title</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public System.Threading.Tasks.Task<SshKey> AddSshKeyAsync(string user, AddSshKey sshKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UrlBuilder urlBuilder = Meziantou.GitLab.UrlBuilder.Get("users/:user/keys");

            urlBuilder.WithValue("user", user);

            string url = urlBuilder.Build();

            return this.PostJsonAsync<SshKey>(url, sshKey, cancellationToken);
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
    }
}
