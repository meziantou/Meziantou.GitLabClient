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
    public readonly partial struct UserIdRef : Meziantou.GitLab.Internals.IGitLabObjectReference<long>, System.IEquatable<Meziantou.GitLab.UserIdRef>
    {
        private readonly long _value;

        private UserIdRef(long userId)
        {
            this._value = userId;
        }

        private UserIdRef(UserSafe user)
        {
            if ((user == null))
            {
                throw new System.ArgumentNullException(nameof(user));
            }

            this._value = user.Id;
        }

        public long Value
        {
            get
            {
                return this._value;
            }
        }

        public override bool Equals(object? obj)
        {
            if ((obj is Meziantou.GitLab.UserIdRef))
            {
                return this.Equals(((Meziantou.GitLab.UserIdRef)obj));
            }
            else
            {
                return false;
            }
        }

        public bool Equals(Meziantou.GitLab.UserIdRef other)
        {
            return object.Equals(this.Value, other.Value);
        }

        public static Meziantou.GitLab.UserIdRef FromUser(UserSafe user)
        {
            if ((user == null))
            {
                throw new System.ArgumentNullException(nameof(user));
            }

            return new Meziantou.GitLab.UserIdRef(user);
        }

        public static Meziantou.GitLab.UserIdRef FromUserId(long userId)
        {
            return new Meziantou.GitLab.UserIdRef(userId);
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(this.Value);
        }

        public override string ToString()
        {
            return this.Value.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        public static implicit operator Meziantou.GitLab.UserIdRef(long userId)
        {
            return Meziantou.GitLab.UserIdRef.FromUserId(userId);
        }

        public static implicit operator Meziantou.GitLab.UserIdRef?(long? userId)
        {
            if (userId.HasValue)
            {
                return Meziantou.GitLab.UserIdRef.FromUserId(userId.Value);
            }
            else
            {
                return null;
            }
        }

        public static implicit operator Meziantou.GitLab.UserIdRef(UserSafe user)
        {
            return Meziantou.GitLab.UserIdRef.FromUser(user);
        }

        public static implicit operator Meziantou.GitLab.UserIdRef?(UserSafe? user)
        {
            if (object.ReferenceEquals(user, null))
            {
                return null;
            }
            else
            {
                return Meziantou.GitLab.UserIdRef.FromUser(user);
            }
        }

        public static bool operator !=(Meziantou.GitLab.UserIdRef a, Meziantou.GitLab.UserIdRef b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.UserIdRef a, Meziantou.GitLab.UserIdRef b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.UserIdRef>.Default.Equals(a, b);
        }
    }
}
