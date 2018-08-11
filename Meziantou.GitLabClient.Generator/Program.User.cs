namespace Meziantou.GitLabClient.Generator
{
    partial class Program
    {
        private Model _identityModel;
        private Model _sshKey;
        private Model _userActivity;
        private Model _userBasicModel;
        private Model _userModel;
        private Model _userSafeModel;
        private Model _userState;
        private Model _userStatus;
        private ParameterEntity _userRef;
        private ParameterEntity _sshKeyRef;

        private void CreateUserTypes()
        {
            _userState = Project.AddModel(new Enumeration("UserState")
            {
                Members =
                {
                    new EnumerationMember("Active"),
                    new EnumerationMember("Blocked"),
                }
            });

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
                    new EntityProperty("AvatarUrl", ModelRef.String),
                    new EntityProperty("AvatarPath", ModelRef.String),
                    new EntityProperty("WebUrl", ModelRef.String),
                }
            });

            // https://gitlab.com/gitlab-org/gitlab-ce/blob/30c960d4eee9a4814e593abef8e13cd52914bd88/lib/api/entities.rb#L32
            _userModel = Project.AddModel(new Entity("User")
            {
                BaseType = _userBasicModel,
                Properties =
                {
                    new EntityProperty("State", _userState),
                    new EntityProperty("CreatedAt", ModelRef.DateTime),
                    new EntityProperty("Bio", ModelRef.String),
                    new EntityProperty("Location", ModelRef.String),
                    new EntityProperty("Skype", ModelRef.String),
                    new EntityProperty("Linkedin", ModelRef.String),
                    new EntityProperty("Twitter", ModelRef.String),
                    new EntityProperty("WebsiteUrl", ModelRef.String),
                    new EntityProperty("Organization", ModelRef.String),
                    new EntityProperty("CurrentSignInAt", ModelRef.NullableDateTime),
                    new EntityProperty("LastSignInAt", ModelRef.NullableDateTime),
                    new EntityProperty("ConfirmedAt", ModelRef.NullableDateTime),
                    new EntityProperty("LastActivityOn", ModelRef.NullableDate),
                    new EntityProperty("Email", ModelRef.String),
                    new EntityProperty("ThemeId", ModelRef.Id),
                    new EntityProperty("ColorSchemeId", ModelRef.Id),
                    new EntityProperty("ProjectsLimit", ModelRef.Long),
                    new EntityProperty("Identities", new ModelRef(_identityModel) { IsCollection = true }),
                    new EntityProperty("CanCreateGroup", ModelRef.Boolean),
                    new EntityProperty("CanCreateProject", ModelRef.Boolean),
                    new EntityProperty("TwoFactorEnabled", ModelRef.Boolean),
                    new EntityProperty("External", ModelRef.Boolean),
                    new EntityProperty("PrivateProfile", ModelRef.Object),
                    new EntityProperty("SharedRunnersMinutesLimit", ModelRef.NullableLong),
                    new EntityProperty("IsAdmin", ModelRef.NullableBoolean),
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

            // Refs
            _userRef = Project.AddParameterEntity(new ParameterEntity("UserRef", ModelRef.Object)
            {
                Refs =
                {
                    new ParameterEntityRef(ModelRef.Id),
                    new ParameterEntityRef(ModelRef.String),
                    new ParameterEntityRef(_userSafeModel, "Id"),
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
    }
}
