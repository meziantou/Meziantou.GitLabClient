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
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Serialization.LicenseTemplateJsonConverter))]
    public partial class LicenseTemplate : Meziantou.GitLab.Core.GitLabObject, System.IEquatable<Meziantou.GitLab.LicenseTemplate>
    {
        internal LicenseTemplate(System.Text.Json.JsonElement obj)
            : base(obj)
        {
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("conditions")]
        public System.Collections.Generic.IReadOnlyList<string> Conditions
        {
            get
            {
                return this.GetRequiredNonNullValue<System.Collections.Generic.IReadOnlyList<string>>("conditions");
            }
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("content")]
        public string Content
        {
            get
            {
                return this.GetRequiredNonNullValue<string>("content");
            }
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("description")]
        public string Description
        {
            get
            {
                return this.GetRequiredNonNullValue<string>("description");
            }
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("featured")]
        public bool Featured
        {
            get
            {
                return this.GetRequiredNonNullValue<bool>("featured");
            }
        }

        /// <remarks>The value is an absolute URI</remarks>
        [Meziantou.GitLab.Internals.MappedPropertyAttribute("html_url")]
        public System.Uri HtmlUrl
        {
            get
            {
                return this.GetRequiredNonNullValue<System.Uri>("html_url");
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

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("limitations")]
        public System.Collections.Generic.IReadOnlyList<string> Limitations
        {
            get
            {
                return this.GetRequiredNonNullValue<System.Collections.Generic.IReadOnlyList<string>>("limitations");
            }
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("name")]
        public string Name
        {
            get
            {
                return this.GetRequiredNonNullValue<string>("name");
            }
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("nickname")]
        public string? Nickname
        {
            get
            {
                return this.GetValueOrDefault<string?>("nickname", default(string?));
            }
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("permissions")]
        public System.Collections.Generic.IReadOnlyList<string> Permissions
        {
            get
            {
                return this.GetRequiredNonNullValue<System.Collections.Generic.IReadOnlyList<string>>("permissions");
            }
        }

        /// <remarks>The value is an absolute URI</remarks>
        [Meziantou.GitLab.Internals.MappedPropertyAttribute("source_url")]
        public System.Uri SourceUrl
        {
            get
            {
                return this.GetRequiredNonNullValue<System.Uri>("source_url");
            }
        }

        public override bool Equals(object? obj)
        {
            return this.Equals((obj as Meziantou.GitLab.LicenseTemplate));
        }

        public virtual bool Equals(Meziantou.GitLab.LicenseTemplate? other)
        {
            return ((!object.ReferenceEquals(other, null)) && (this.Key == other.Key));
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(this.Key);
        }

        public override string ToString()
        {
            return (((((("LicenseTemplate { " + "Key = ") + this.Key) + ", ") + "Name = ") + this.Name) + " }");
        }

        public static bool operator !=(Meziantou.GitLab.LicenseTemplate? a, Meziantou.GitLab.LicenseTemplate? b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.LicenseTemplate? a, Meziantou.GitLab.LicenseTemplate? b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.LicenseTemplate>.Default.Equals(a, b);
        }
    }
}

namespace Meziantou.GitLab.Serialization
{
    internal sealed partial class LicenseTemplateJsonConverter : Meziantou.GitLab.Serialization.GitLabObjectBaseJsonConverter<Meziantou.GitLab.LicenseTemplate>
    {
        protected override Meziantou.GitLab.LicenseTemplate CreateInstance(System.Text.Json.JsonElement jsonElement)
        {
            return new Meziantou.GitLab.LicenseTemplate(jsonElement);
        }
    }
}
