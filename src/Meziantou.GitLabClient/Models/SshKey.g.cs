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
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Serialization.SshKeyJsonConverter))]
    public partial class SshKey : Meziantou.GitLab.Core.GitLabObject, System.IEquatable<Meziantou.GitLab.SshKey>
    {
        internal SshKey(System.Text.Json.JsonElement obj)
            : base(obj)
        {
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("created_at")]
        public System.DateTimeOffset CreatedAt
        {
            get
            {
                return this.GetRequiredNonNullValue<System.DateTimeOffset>("created_at");
            }
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("id")]
        public long Id
        {
            get
            {
                return this.GetRequiredNonNullValue<long>("id");
            }
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("key")]
        public string Key
        {
            get
            {
                return this.GetRequiredNonNullValue<string>("key");
            }
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("title")]
        public string Title
        {
            get
            {
                return this.GetRequiredNonNullValue<string>("title");
            }
        }

        public override bool Equals(object? obj)
        {
            return this.Equals((obj as Meziantou.GitLab.SshKey));
        }

        public virtual bool Equals(Meziantou.GitLab.SshKey? other)
        {
            return ((!object.ReferenceEquals(other, null)) && (this.Id == other.Id));
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(this.Id);
        }

        public override string ToString()
        {
            return (((((("SshKey { " + "Id = ") + this.Id) + ", ") + "Title = ") + this.Title) + " }");
        }

        public static bool operator !=(Meziantou.GitLab.SshKey? a, Meziantou.GitLab.SshKey? b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.SshKey? a, Meziantou.GitLab.SshKey? b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.SshKey>.Default.Equals(a, b);
        }
    }
}

namespace Meziantou.GitLab.Serialization
{
    internal sealed partial class SshKeyJsonConverter : Meziantou.GitLab.Serialization.GitLabObjectBaseJsonConverter<Meziantou.GitLab.SshKey>
    {
        protected override Meziantou.GitLab.SshKey CreateInstance(System.Text.Json.JsonElement jsonElement)
        {
            return new Meziantou.GitLab.SshKey(jsonElement);
        }
    }
}
