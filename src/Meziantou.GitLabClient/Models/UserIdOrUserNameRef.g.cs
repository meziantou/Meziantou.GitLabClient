﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated
// </auto-generated>
// ------------------------------------------------------------------------------
#nullable enable
namespace Meziantou.GitLab
{
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Serialization.GitLabObjectReferenceJsonConverterFactory))]
    public readonly partial struct UserIdOrUserNameRef : Meziantou.GitLab.Internals.IGitLabObjectReference<object>, System.IEquatable<Meziantou.GitLab.UserIdOrUserNameRef>
    {
        private readonly object _value;

        private UserIdOrUserNameRef(long userId)
        {
            this._value = userId;
        }

        private UserIdOrUserNameRef(string userName)
        {
            this._value = userName;
        }

        private UserIdOrUserNameRef(UserSafe user)
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

        public bool Equals(Meziantou.GitLab.UserIdOrUserNameRef other)
        {
            return object.Equals(this.Value, other.Value);
        }

        public override bool Equals(object? obj)
        {
            if ((obj is Meziantou.GitLab.UserIdOrUserNameRef))
            {
                return this.Equals(((Meziantou.GitLab.UserIdOrUserNameRef)obj));
            }
            else
            {
                return false;
            }
        }

        public static Meziantou.GitLab.UserIdOrUserNameRef FromUser(UserSafe user)
        {
            if ((user == null))
            {
                throw new System.ArgumentNullException(nameof(user));
            }

            return new Meziantou.GitLab.UserIdOrUserNameRef(user);
        }

        public static Meziantou.GitLab.UserIdOrUserNameRef FromUserId(long userId)
        {
            return new Meziantou.GitLab.UserIdOrUserNameRef(userId);
        }

        public static Meziantou.GitLab.UserIdOrUserNameRef FromUserName(string userName)
        {
            return new Meziantou.GitLab.UserIdOrUserNameRef(userName);
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(this.Value);
        }

        public override string? ToString()
        {
            return this.Value.ToString();
        }

        public static implicit operator Meziantou.GitLab.UserIdOrUserNameRef(string userName)
        {
            return Meziantou.GitLab.UserIdOrUserNameRef.FromUserName(userName);
        }

        public static implicit operator Meziantou.GitLab.UserIdOrUserNameRef(UserSafe user)
        {
            return Meziantou.GitLab.UserIdOrUserNameRef.FromUser(user);
        }

        public static implicit operator Meziantou.GitLab.UserIdOrUserNameRef?(UserSafe? user)
        {
            if (object.ReferenceEquals(user, null))
            {
                return null;
            }
            else
            {
                return Meziantou.GitLab.UserIdOrUserNameRef.FromUser(user);
            }
        }

        public static implicit operator Meziantou.GitLab.UserIdOrUserNameRef?(long? userId)
        {
            if (userId.HasValue)
            {
                return Meziantou.GitLab.UserIdOrUserNameRef.FromUserId(userId.Value);
            }
            else
            {
                return null;
            }
        }

        public static implicit operator Meziantou.GitLab.UserIdOrUserNameRef(long userId)
        {
            return Meziantou.GitLab.UserIdOrUserNameRef.FromUserId(userId);
        }

        public static implicit operator Meziantou.GitLab.UserIdOrUserNameRef?(string? userName)
        {
            if (object.ReferenceEquals(userName, null))
            {
                return null;
            }
            else
            {
                return Meziantou.GitLab.UserIdOrUserNameRef.FromUserName(userName);
            }
        }

        public static bool operator !=(Meziantou.GitLab.UserIdOrUserNameRef a, Meziantou.GitLab.UserIdOrUserNameRef b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.UserIdOrUserNameRef a, Meziantou.GitLab.UserIdOrUserNameRef b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.UserIdOrUserNameRef>.Default.Equals(a, b);
        }
    }
}
