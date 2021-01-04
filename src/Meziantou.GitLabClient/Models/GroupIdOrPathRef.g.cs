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
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Serialization.GitLabObjectObjectReferenceJsonConverterFactory))]
    public readonly partial struct GroupIdOrPathRef : Meziantou.GitLab.Internals.IGitLabObjectReference<object>, System.IEquatable<Meziantou.GitLab.GroupIdOrPathRef>
    {
        private readonly object _value;

        private GroupIdOrPathRef(long groupId)
        {
            this._value = groupId;
        }

        private GroupIdOrPathRef(Meziantou.GitLab.PathWithNamespace projectPathWithNamespace)
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

        public override bool Equals(object? obj)
        {
            if ((obj is Meziantou.GitLab.GroupIdOrPathRef))
            {
                return this.Equals(((Meziantou.GitLab.GroupIdOrPathRef)obj));
            }
            else
            {
                return false;
            }
        }

        public bool Equals(Meziantou.GitLab.GroupIdOrPathRef other)
        {
            return object.Equals(this.Value, other.Value);
        }

        public static Meziantou.GitLab.GroupIdOrPathRef FromGroupId(long groupId)
        {
            return new Meziantou.GitLab.GroupIdOrPathRef(groupId);
        }

        public static Meziantou.GitLab.GroupIdOrPathRef FromProjectPathWithNamespace(Meziantou.GitLab.PathWithNamespace projectPathWithNamespace)
        {
            return new Meziantou.GitLab.GroupIdOrPathRef(projectPathWithNamespace);
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(this.Value);
        }

        public override string? ToString()
        {
            return this.Value.ToString();
        }

        public static implicit operator Meziantou.GitLab.GroupIdOrPathRef(long groupId)
        {
            return Meziantou.GitLab.GroupIdOrPathRef.FromGroupId(groupId);
        }

        public static implicit operator Meziantou.GitLab.GroupIdOrPathRef?(long? groupId)
        {
            if (groupId.HasValue)
            {
                return Meziantou.GitLab.GroupIdOrPathRef.FromGroupId(groupId.Value);
            }
            else
            {
                return null;
            }
        }

        public static implicit operator Meziantou.GitLab.GroupIdOrPathRef(Meziantou.GitLab.PathWithNamespace projectPathWithNamespace)
        {
            return Meziantou.GitLab.GroupIdOrPathRef.FromProjectPathWithNamespace(projectPathWithNamespace);
        }

        public static implicit operator Meziantou.GitLab.GroupIdOrPathRef?(Meziantou.GitLab.PathWithNamespace? projectPathWithNamespace)
        {
            if (projectPathWithNamespace.HasValue)
            {
                return Meziantou.GitLab.GroupIdOrPathRef.FromProjectPathWithNamespace(projectPathWithNamespace.Value);
            }
            else
            {
                return null;
            }
        }

        public static bool operator !=(Meziantou.GitLab.GroupIdOrPathRef a, Meziantou.GitLab.GroupIdOrPathRef b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.GroupIdOrPathRef a, Meziantou.GitLab.GroupIdOrPathRef b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.GroupIdOrPathRef>.Default.Equals(a, b);
        }
    }
}
