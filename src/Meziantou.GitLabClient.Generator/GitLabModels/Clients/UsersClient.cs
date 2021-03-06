﻿namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class UsersClient : GitLabClientBuilder
    {
        protected override void Create(MethodGroup methodGroup)
        {
            var usersOrderBy = Choice("UsersOrderBy", new[] { "id", "name", "username", "created_at", "updated_at" });

            methodGroup.AddMethod("GetCurrentUser", MethodType.Get, "/user", "https://docs.gitlab.com/ee/api/users.html#list-current-user-for-normal-users")
                .WithReturnType(Models.User);

            methodGroup.AddMethod("GetById", MethodType.Get, "/users/:user_id", "https://docs.gitlab.com/ee/api/users.html#for-user")
                .WithReturnType(Models.User)
                .AddRequiredParameter("user_id", Models.UserIdRef)
                ;

            methodGroup.AddMethod("GetAll", MethodType.GetPaged, "/users", "https://docs.gitlab.com/ee/api/users.html#for-normal-users")
                .WithReturnType(Models.UserBasic)
                .AddOptionalParameter("username", ModelRef.String)
                .AddOptionalParameter("active", ModelRef.Boolean)
                .AddOptionalParameter("blocked", ModelRef.Boolean)
                .AddOptionalParameter("order_by", usersOrderBy)
                .AddOptionalParameter("sort", Models.OrderByDirection)
                ;

            methodGroup.AddMethod("GetCurrentUserStatus", MethodType.Get, "/user/status", "https://docs.gitlab.com/ee/api/users.html#user-status")
                .WithReturnType(Models.UserStatus)
                ;

            methodGroup.AddMethod("GetStatus", MethodType.Get, "/users/:id_or_username/status", "https://docs.gitlab.com/ee/api/users.html#get-the-status-of-a-user")
                .WithReturnType(Models.UserStatus)
                .AddRequiredParameter("id_or_username", Models.UserIdOrUserNameRef)
                ;

            methodGroup.AddMethod("SetCurrentUserStatus", MethodType.Put, "/user/status", "https://docs.gitlab.com/ee/api/users.html#set-user-status")
                .WithReturnType(Models.UserStatus)
                .AddOptionalParameter("emoji", ModelRef.String)
                .AddOptionalParameter("message", ModelRef.String)
                ;

            methodGroup.AddMethod("GetCurrentUserSSHKeys", MethodType.GetCollection, "/user/keys", "https://docs.gitlab.com/ee/api/users.html#list-ssh-keys")
                .WithReturnType(Models.SshKey)
                ;

            methodGroup.AddMethod("GetSSHKeys", MethodType.GetCollection, "/users/:id_or_username/keys", "https://docs.gitlab.com/ee/api/users.html#list-ssh-keys-for-user")
                .WithReturnType(Models.SshKey)
                .AddRequiredParameter("id_or_username", Models.UserIdOrUserNameRef)
                ;

            methodGroup.AddMethod("GetCurrentUserSSHKey", MethodType.Get, "/user/keys/:key_id", "https://docs.gitlab.com/ee/api/users.html#single-ssh-key")
                .WithReturnType(Models.SshKey)
                .AddRequiredParameter("key_id", Models.SshKeyIdRef)
                ;

            methodGroup.AddMethod("AddSSHKeyToCurrentUser", MethodType.Post, "/user/keys", "https://docs.gitlab.com/ee/api/users.html#add-ssh-key")
                .WithReturnType(Models.SshKey)
                .AddRequiredParameter("title", ModelRef.String)
                .AddRequiredParameter("key", ModelRef.String)
                ;

            methodGroup.AddMethod("AddSSHKey", MethodType.Post, "/users/:id_or_username/keys", "https://docs.gitlab.com/ee/api/users.html#add-ssh-key-for-user")
                .WithReturnType(Models.SshKey)
                .AddRequiredParameter("id_or_username", Models.UserIdOrUserNameRef)
                .AddRequiredParameter("title", ModelRef.String)
                .AddRequiredParameter("key", ModelRef.String)
                ;

            methodGroup.AddMethod("DeleteSSHKeyFromCurrentUser", MethodType.Delete, "/user/keys/:key_id", "https://docs.gitlab.com/ee/api/users.html#delete-ssh-key-for-current-user")
                .AddRequiredParameter("key_id", Models.SshKeyIdRef)
                ;

            methodGroup.AddMethod("DeleteSSHKey", MethodType.Delete, "/users/:id_or_username/keys/:key_id", "https://docs.gitlab.com/ee/api/users.html#delete-ssh-key-for-given-user")
                .AddRequiredParameter("id_or_username", Models.UserIdOrUserNameRef)
                .AddRequiredParameter("key_id", Models.SshKeyIdRef)
                ;

            methodGroup.AddMethod("CreateUser", MethodType.Post, "/users", "https://docs.gitlab.com/ee/api/users.html#user-creation")
                .WithReturnType(Models.User)
                .AddRequiredParameter("email", ModelRef.String)
                .AddRequiredParameter("username", ModelRef.String)
                .AddRequiredParameter("name", ModelRef.String)
                .AddOptionalParameter("password", ModelRef.String)
                .AddOptionalParameter("admin", ModelRef.Boolean)
                .AddOptionalParameter("can_create_group", ModelRef.Boolean)
                .AddOptionalParameter("skip_confirmation", ModelRef.Boolean)
                ;

            methodGroup.AddMethod("CreateImpersonationToken", MethodType.Post, "/users/:user_id/impersonation_tokens", "https://docs.gitlab.com/ee/api/users.html#create-an-impersonation-token")
                .WithReturnType(Models.ImpersonationToken)
                .AddRequiredParameter("user_id", Models.UserIdRef)
                .AddRequiredParameter("name", ModelRef.String)
                .AddOptionalParameter("expires_at", ModelRef.Date)
                .AddOptionalParameter("scopes", Choice("ImpersonationTokenScope", new[] { "api", "read_user" }).MakeCollection())
                ;
        }
    }
}
