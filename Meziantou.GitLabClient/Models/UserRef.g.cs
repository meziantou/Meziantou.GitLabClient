// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated
// </auto-generated>
// ------------------------------------------------------------------------------
#nullable enable
namespace Meziantou.GitLab
{
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Serialization.GitLabObjectObjectReferenceJsonConverter))]
    public readonly partial struct UserRef : Meziantou.GitLab.IGitLabObjectReference<object>, System.IEquatable<Meziantou.GitLab.UserRef>
    {
        private readonly object _value;

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

        private UserRef(long userId)
        {
            this._value = userId;
        }

        public object Value
        {
            get
            {
                return this._value;
            }
        }

        public override bool Equals(object? obj)
        {
            if ((obj is Meziantou.GitLab.UserRef))
            {
                return this.Equals(((Meziantou.GitLab.UserRef)obj));
            }
            else
            {
                return false;
            }
        }

        public bool Equals(Meziantou.GitLab.UserRef obj)
        {
            return object.Equals(this.Value, obj.Value);
        }

        public static Meziantou.GitLab.UserRef FromUser(UserSafe user)
        {
            if ((user == null))
            {
                throw new System.ArgumentNullException(nameof(user));
            }

            return new Meziantou.GitLab.UserRef(user);
        }

        public static Meziantou.GitLab.UserRef FromUserId(long userId)
        {
            return new Meziantou.GitLab.UserRef(userId);
        }

        public static Meziantou.GitLab.UserRef FromUserName(string userName)
        {
            return new Meziantou.GitLab.UserRef(userName);
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(this.Value);
        }

        public override string? ToString()
        {
            return this.Value.ToString();
        }

        public static implicit operator Meziantou.GitLab.UserRef(long userId)
        {
            return Meziantou.GitLab.UserRef.FromUserId(userId);
        }

        public static implicit operator Meziantou.GitLab.UserRef(string userName)
        {
            return Meziantou.GitLab.UserRef.FromUserName(userName);
        }

        public static implicit operator Meziantou.GitLab.UserRef(UserSafe user)
        {
            return Meziantou.GitLab.UserRef.FromUser(user);
        }

        public static bool operator !=(Meziantou.GitLab.UserRef a, Meziantou.GitLab.UserRef b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.UserRef a, Meziantou.GitLab.UserRef b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.UserRef>.Default.Equals(a, b);
        }
    }
}