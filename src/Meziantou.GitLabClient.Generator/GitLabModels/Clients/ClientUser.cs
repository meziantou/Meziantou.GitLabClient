namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class ClientUser : IGitLabClientDescriptor
    {
        public void Create(Project project)
        {
            var group = project.AddMethodGroup("Users");

            group.AddMethod("GetCurrentUser", MethodType.Get, "/user", "https://docs.gitlab.com/ee/api/users.html#list-current-user-for-normal-users")
                .WithReturnType(Models.User);

            group.AddMethod("GetById", MethodType.Get, "/users/:user_id", "https://docs.gitlab.com/ee/api/users.html#single-user")
                .WithReturnType(Models.User)
                .AddRequiredParameter("user_id", ModelRef.NumberId)
                ;

            group.AddMethod("GetAll", MethodType.GetPaged, "/users", "https://docs.gitlab.com/ee/api/users.html#for-normal-users")
                .WithReturnType(Models.UserBasic)
                .AddOptionalParameter("username", ModelRef.String)
                .AddOptionalParameter("active", ModelRef.Boolean)
                .AddOptionalParameter("blocked", ModelRef.Boolean)
                ;

            group.AddMethod("GetCurrentUserStatus", MethodType.Get, "/user/status", "https://docs.gitlab.com/ee/api/users.html#user-status")
                .WithReturnType(Models.UserStatus)
                ;

            group.AddMethod("GetStatus", MethodType.Get, "/users/:user_id/status", "https://docs.gitlab.com/ee/api/users.html#get-the-status-of-a-user")
                .WithReturnType(Models.UserStatus)
                .AddRequiredParameter("user_id", EntityRefs.UserRef)
                ;

            group.AddMethod("SetCurrentUserStatus", MethodType.Put, "/user/status", "https://docs.gitlab.com/ee/api/users.html#set-user-status")
                .WithReturnType(Models.UserStatus)
                .AddOptionalParameter("emoji", ModelRef.String)
                .AddOptionalParameter("message", ModelRef.String)
                ;

            group.AddMethod("GetCurrentUserSSHKeys", MethodType.GetCollection, "/user/keys", "https://docs.gitlab.com/ee/api/users.html#list-ssh-keys")
                .WithReturnType(Models.SshKey)
                ;

            group.AddMethod("GetSSHKeys", MethodType.GetCollection, "/users/:user_id/keys", "https://docs.gitlab.com/ee/api/users.html#list-ssh-keys-for-user")
                .WithReturnType(Models.SshKey)
                .AddRequiredParameter("user_id", EntityRefs.UserRef)
                ;

            group.AddMethod("GetCurrentUserSSHKey", MethodType.Get, "/user/keys/:key_id", "https://docs.gitlab.com/ee/api/users.html#single-ssh-key")
                .WithReturnType(Models.SshKey)
                .AddRequiredParameter("key_id", EntityRefs.SshKeyRef)
                ;

            group.AddMethod("AddSSHKeyToCurrentUser", MethodType.Post, "/user/keys", "https://docs.gitlab.com/ee/api/users.html#add-ssh-key")
                .WithReturnType(Models.SshKey)
                .AddRequiredParameter("title", ModelRef.String)
                .AddRequiredParameter("key", ModelRef.String)
                ;

            group.AddMethod("AddSSHKey", MethodType.Post, "/users/:user_id/keys", "https://docs.gitlab.com/ee/api/users.html#add-ssh-key-for-user")
                .WithReturnType(Models.SshKey)
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
                .WithReturnType(Models.User)
                .AddRequiredParameter("email", ModelRef.String)
                .AddRequiredParameter("username", ModelRef.String)
                .AddRequiredParameter("name", ModelRef.String)
                .AddOptionalParameter("password", ModelRef.String)
                .AddOptionalParameter("admin", ModelRef.Boolean)
                .AddOptionalParameter("can_create_group", ModelRef.Boolean)
                .AddOptionalParameter("skip_confirmation", ModelRef.Boolean)
                ;

            group.AddMethod("CreateImpersonationToken", MethodType.Post, "/users/:user_id/impersonation_tokens", "https://docs.gitlab.com/ee/api/users.html#create-an-impersonation-token")
                .WithReturnType(Models.ImpersonationToken)
                .AddRequiredParameter("user_id", EntityRefs.UserRef)
                .AddRequiredParameter("name", ModelRef.String)
                .AddOptionalParameter("expires_at", ModelRef.Date)
                .AddOptionalParameter("scopes", ModelRef.StringCollection)
                ;
        }
    }
}
