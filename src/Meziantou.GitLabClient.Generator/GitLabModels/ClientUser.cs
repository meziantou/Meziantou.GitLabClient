namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal static partial class Enumerations
    {
        public static ModelRef UserState { get; private set; }

        public static void CreateUser(Project project)
        {
            UserState = project.AddStringEnumeration("UserState")
                .AddMembers("active", "blocked");
        }
    }

    internal static partial class Entities
    {
        public static EntityBuilder UserSafe { get; private set; }
        public static EntityBuilder Identity { get; private set; }
        public static EntityBuilder UserBasic { get; private set; }
        public static EntityBuilder User { get; private set; }
        public static EntityBuilder UserStatus { get; private set; }
        public static EntityBuilder UserActivity { get; private set; }
        public static EntityBuilder SshKey { get; private set; }
        public static EntityBuilder ImpersonationToken { get; private set; }

        public static void CreateUser()
        {
            Identity.Configure(entity => entity
               .AddProperty("provider", ModelRef.String, PropertyOptions.IsKey)
               .AddProperty("extern_uid", ModelRef.String, PropertyOptions.IsKey)
           );

            UserSafe.Configure(entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("name", ModelRef.String)
                .AddProperty("username", ModelRef.String, PropertyOptions.IsDisplayName)
            );

            UserBasic.Configure(entity => entity
                .WithBaseType(UserSafe)
                .AddProperty("avatar_url", ModelRef.Uri)
                .AddProperty("avatar_path", ModelRef.NullableString)
                .AddProperty("state", Enumerations.UserState)
                .AddProperty("web_url", ModelRef.Uri)
            );

            User.Configure(entity => entity
                .WithBaseType(UserBasic)
                .AddProperty("bio", ModelRef.NullableString)
                .AddProperty("can_create_group", ModelRef.NullableBoolean)
                .AddProperty("can_create_project", ModelRef.NullableBoolean)
                .AddProperty("color_scheme_id", ModelRef.NullableNumberId)
                .AddProperty("confirmed_at", ModelRef.NullableDateTime)
                .AddProperty("created_at", ModelRef.DateTime)
                .AddProperty("current_sign_in_at", ModelRef.NullableDateTime)
                .AddProperty("email", ModelRef.NullableString)
                .AddProperty("external", ModelRef.NullableBoolean)
                .AddProperty("identities", Identity.MakeCollectionNullable())
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

            UserStatus.Configure(entity => entity
                .AddProperty("emoji", ModelRef.NullableString)
                .AddProperty("message", ModelRef.NullableString)
                .AddProperty("message_html", ModelRef.String)
            );

            UserActivity.Configure(entity => entity
                .AddProperty("username", ModelRef.String)
                .AddProperty("last_activity_on", ModelRef.Date)
            );

            SshKey.Configure(entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("title", ModelRef.String, PropertyOptions.IsDisplayName)
                .AddProperty("key", ModelRef.String)
                .AddProperty("created_at", ModelRef.DateTime)
            );

            ImpersonationToken.Configure(entity => entity
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
        }
    }

    internal sealed class ClientUser : IGitLabClientDescriptor
    {
        public void Create(Project project)
        {
            var group = project.AddMethodGroup("Users");

            group.AddMethod("GetCurrentUser", MethodType.Get, "/user", "https://docs.gitlab.com/ee/api/users.html#list-current-user-for-normal-users")
                .WithReturnType(Entities.User);

            group.AddMethod("GetById", MethodType.Get, "/users/:user_id", "https://docs.gitlab.com/ee/api/users.html#single-user")
                .WithReturnType(Entities.User)
                .AddRequiredParameter("user_id", ModelRef.NumberId)
                ;

            group.AddMethod("GetAll", MethodType.GetPaged, "/users", "https://docs.gitlab.com/ee/api/users.html#for-normal-users")
                .WithReturnType(Entities.UserBasic)
                .AddOptionalParameter("username", ModelRef.String)
                .AddOptionalParameter("active", ModelRef.Boolean)
                .AddOptionalParameter("blocked", ModelRef.Boolean)
                ;

            group.AddMethod("GetCurrentUserStatus", MethodType.Get, "/user/status", "https://docs.gitlab.com/ee/api/users.html#user-status")
                .WithReturnType(Entities.UserStatus)
                ;

            group.AddMethod("GetStatus", MethodType.Get, "/users/:user_id/status", "https://docs.gitlab.com/ee/api/users.html#get-the-status-of-a-user")
                .WithReturnType(Entities.UserStatus)
                .AddRequiredParameter("user_id", EntityRefs.UserRef)
                ;

            group.AddMethod("SetCurrentUserStatus", MethodType.Put, "/user/status", "https://docs.gitlab.com/ee/api/users.html#set-user-status")
                .WithReturnType(Entities.UserStatus)
                .AddOptionalParameter("emoji", ModelRef.String)
                .AddOptionalParameter("message", ModelRef.String)
                ;

            group.AddMethod("GetCurrentUserSSHKeys", MethodType.GetCollection, "/user/keys", "https://docs.gitlab.com/ee/api/users.html#list-ssh-keys")
                .WithReturnType(Entities.SshKey)
                ;

            group.AddMethod("GetSSHKeys", MethodType.GetCollection, "/users/:user_id/keys", "https://docs.gitlab.com/ee/api/users.html#list-ssh-keys-for-user")
                .WithReturnType(Entities.SshKey)
                .AddRequiredParameter("user_id", EntityRefs.UserRef)
                ;

            group.AddMethod("GetCurrentUserSSHKey", MethodType.Get, "/user/keys/:key_id", "https://docs.gitlab.com/ee/api/users.html#single-ssh-key")
                .WithReturnType(Entities.SshKey)
                .AddRequiredParameter("key_id", EntityRefs.SshKeyRef)
                ;

            group.AddMethod("AddSSHKeyToCurrentUser", MethodType.Post, "/user/keys", "https://docs.gitlab.com/ee/api/users.html#add-ssh-key")
                .WithReturnType(Entities.SshKey)
                .AddRequiredParameter("title", ModelRef.String)
                .AddRequiredParameter("key", ModelRef.String)
                ;

            group.AddMethod("AddSSHKey", MethodType.Post, "/users/:user_id/keys", "https://docs.gitlab.com/ee/api/users.html#add-ssh-key-for-user")
                .WithReturnType(Entities.SshKey)
                .AddRequiredParameter("user_id", EntityRefs.UserRef)
                .AddRequiredParameter("title", ModelRef.String)
                .AddRequiredParameter("key", ModelRef.String)
                ;

            group.AddMethod("DeleteSSHKeyFromCurrentUser", MethodType.Delete, "/user/keys/:key_id", "https://docs.gitlab.com/ee/api/users.html#delete-ssh-key-for-current-user")
                .AddRequiredParameter("key_id", EntityRefs.SshKeyRef)
                ;

            group.AddMethod("DeleteSSHKey", MethodType.Delete, "/users/:user_id/keys/:key_id", "https://docs.gitlab.com/ee/api/users.html#delete-ssh-key-for-given-user")
                .AddRequiredParameter("user_id", EntityRefs.UserRef)
                .AddRequiredParameter("key_id", EntityRefs.SshKeyRef)
                ;

            group.AddMethod("CreateUser", MethodType.Post, "/users", "https://docs.gitlab.com/ee/api/users.html#user-creation")
                .WithReturnType(Entities.User)
                .AddRequiredParameter("email", ModelRef.String)
                .AddRequiredParameter("username", ModelRef.String)
                .AddRequiredParameter("name", ModelRef.String)
                .AddOptionalParameter("password", ModelRef.String)
                .AddOptionalParameter("admin", ModelRef.Boolean)
                .AddOptionalParameter("can_create_group", ModelRef.Boolean)
                .AddOptionalParameter("skip_confirmation", ModelRef.Boolean)
                ;

            group.AddMethod("CreateImpersonationToken", MethodType.Post, "/users/:user_id/impersonation_tokens", "https://docs.gitlab.com/ee/api/users.html#create-an-impersonation-token")
                .WithReturnType(Entities.ImpersonationToken)
                .AddRequiredParameter("user_id", EntityRefs.UserRef)
                .AddRequiredParameter("name", ModelRef.String)
                .AddOptionalParameter("expires_at", ModelRef.Date)
                .AddOptionalParameter("scopes", ModelRef.StringCollection)
                ;
        }
    }
}
