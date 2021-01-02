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
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Serialization.IssueJsonConverter))]
    public partial class Issue : Meziantou.GitLab.Core.GitLabObject, System.IEquatable<Meziantou.GitLab.Issue>
    {
        internal Issue(System.Text.Json.JsonElement obj)
            : base(obj)
        {
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("author")]
        public UserBasic Author
        {
            get
            {
                return this.GetRequiredNonNullValue<UserBasic>("author");
            }
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("closed_at")]
        public System.DateTimeOffset? ClosedAt
        {
            get
            {
                return this.GetValueOrDefault<System.DateTimeOffset?>("closed_at", default(System.DateTimeOffset?));
            }
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("closed_by")]
        public UserBasic? ClosedBy
        {
            get
            {
                return this.GetValueOrDefault<UserBasic?>("closed_by", default(UserBasic?));
            }
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

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("iid")]
        public long Iid
        {
            get
            {
                return this.GetRequiredNonNullValue<long>("iid");
            }
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("project_id")]
        public long ProjectId
        {
            get
            {
                return this.GetRequiredNonNullValue<long>("project_id");
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

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("updated_at")]
        public System.DateTimeOffset UpdatedAt
        {
            get
            {
                return this.GetRequiredNonNullValue<System.DateTimeOffset>("updated_at");
            }
        }

        /// <remarks>The value is an absolute URI</remarks>
        [Meziantou.GitLab.Internals.MappedPropertyAttribute("web_url")]
        public System.Uri WebUrl
        {
            get
            {
                return this.GetRequiredNonNullValue<System.Uri>("web_url");
            }
        }

        public override bool Equals(object? obj)
        {
            return this.Equals((obj as Meziantou.GitLab.Issue));
        }

        public virtual bool Equals(Meziantou.GitLab.Issue? other)
        {
            return ((!object.ReferenceEquals(other, null)) && (this.Id == other.Id));
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(this.Id);
        }

        public override string ToString()
        {
            return (((((("Issue { " + "Id = ") + this.Id) + ", ") + "Title = ") + this.Title) + " }");
        }

        public static bool operator !=(Meziantou.GitLab.Issue? a, Meziantou.GitLab.Issue? b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.Issue? a, Meziantou.GitLab.Issue? b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.Issue>.Default.Equals(a, b);
        }
    }
}

namespace Meziantou.GitLab.Serialization
{
    internal sealed partial class IssueJsonConverter : Meziantou.GitLab.Serialization.GitLabObjectBaseJsonConverter<Meziantou.GitLab.Issue>
    {
        protected override Meziantou.GitLab.Issue CreateInstance(System.Text.Json.JsonElement jsonElement)
        {
            return new Meziantou.GitLab.Issue(jsonElement);
        }
    }
}
