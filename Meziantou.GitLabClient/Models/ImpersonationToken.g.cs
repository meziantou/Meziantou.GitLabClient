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
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Serialization.ImpersonationTokenJsonConverter))]
    [System.Diagnostics.DebuggerDisplayAttribute("{GetType().Name,nq} Name={Name}, Id={Id}")]
    public partial class ImpersonationToken : Meziantou.GitLab.Core.GitLabObject, System.IEquatable<Meziantou.GitLab.ImpersonationToken>
    {
        internal ImpersonationToken(System.Text.Json.JsonElement obj)
            : base(obj)
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("active")]
        public bool Active
        {
            get
            {
                return this.GetValueOrDefault<bool>("active", default(bool));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("created_at")]
        public System.DateTimeOffset CreatedAt
        {
            get
            {
                return this.GetValueOrDefault<System.DateTimeOffset>("created_at", default(System.DateTimeOffset));
            }
        }

        [Meziantou.GitLab.SkipUtcDateValidationAttribute("Does not contain time nor timezone (e.g. 2018-01-01)")]
        [Meziantou.GitLab.MappedPropertyAttribute("expires_at")]
        public System.DateTime? ExpiresAt
        {
            get
            {
                return this.GetValueOrDefault<System.DateTime?>("expires_at", default(System.DateTime?));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("id")]
        public long Id
        {
            get
            {
                return this.GetValueOrDefault<long>("id", default(long));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("impersonation")]
        public bool Impersonation
        {
            get
            {
                return this.GetValueOrDefault<bool>("impersonation", default(bool));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("name")]
        public string Name
        {
            get
            {
                return this.GetValueOrDefault<string>("name", default(string));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("revoked")]
        public bool Revoked
        {
            get
            {
                return this.GetValueOrDefault<bool>("revoked", default(bool));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("scopes")]
        public System.Collections.Generic.IReadOnlyList<string> Scopes
        {
            get
            {
                return this.GetValueOrDefault<System.Collections.Generic.IReadOnlyList<string>>("scopes", default(System.Collections.Generic.IReadOnlyList<string>));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("token")]
        public string Token
        {
            get
            {
                return this.GetValueOrDefault<string>("token", default(string));
            }
        }

        public override bool Equals(object? obj)
        {
            return this.Equals((obj as Meziantou.GitLab.ImpersonationToken));
        }

        public virtual bool Equals(Meziantou.GitLab.ImpersonationToken? obj)
        {
            return ((!object.ReferenceEquals(obj, null)) && (this.Id == obj.Id));
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(this.Id);
        }

        public static bool operator !=(Meziantou.GitLab.ImpersonationToken? a, Meziantou.GitLab.ImpersonationToken? b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.ImpersonationToken? a, Meziantou.GitLab.ImpersonationToken? b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.ImpersonationToken>.Default.Equals(a, b);
        }
    }
}

namespace Meziantou.GitLab.Serialization
{
    internal sealed partial class ImpersonationTokenJsonConverter : Meziantou.GitLab.Serialization.GitLabObjectBaseJsonConverter<Meziantou.GitLab.ImpersonationToken>
    {
        protected override Meziantou.GitLab.ImpersonationToken CreateInstance(System.Text.Json.JsonElement jsonElement)
        {
            return new Meziantou.GitLab.ImpersonationToken(jsonElement);
        }
    }
}
#nullable disable
