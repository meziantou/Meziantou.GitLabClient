using System;

namespace Meziantou.GitLab
{
    public readonly struct UserRef
    {
        public long? Id { get; }
        public string Username { get; }

        public object Value => Id.HasValue ? (object)Id.Value : Username;

        public UserRef(long id)
        {
            Id = id;
            Username = null;
        }

        public UserRef(string username)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Id = null;
        }

        public UserRef(UserSafe user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            Id = user.Id;
            Username = user.Username;
        }

        public static implicit operator UserRef(long id) => new UserRef(id);

        public static implicit operator UserRef(string username) => new UserRef(username);

        public static implicit operator UserRef(UserSafe user) => new UserRef(user);
    }
}
