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
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Serialization.UserSafeJsonConverter))]
    [System.Diagnostics.DebuggerDisplayAttribute("{GetType().Name,nq} Username={Username}, Id={Id}")]
    public partial class UserSafe : Meziantou.GitLab.Core.GitLabObject, System.IEquatable<Meziantou.GitLab.UserSafe>
    {
        internal UserSafe(System.Text.Json.JsonElement obj)
            : base(obj)
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("id")]
        public long Id
        {
            get
            {
                return this.GetRequiredNonNullValue<long>("id");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("name")]
        public string Name
        {
            get
            {
                return this.GetRequiredNonNullValue<string>("name");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("username")]
        public string Username
        {
            get
            {
                return this.GetRequiredNonNullValue<string>("username");
            }
        }

        public User AsUser()
        {
            return new User(this.JsonObject);
        }

        public UserBasic AsUserBasic()
        {
            return new UserBasic(this.JsonObject);
        }

        public override bool Equals(object? obj)
        {
            return this.Equals((obj as Meziantou.GitLab.UserSafe));
        }

        public virtual bool Equals(Meziantou.GitLab.UserSafe? obj)
        {
            return ((!object.ReferenceEquals(obj, null)) && (this.Id == obj.Id));
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(this.Id);
        }

        public static bool operator !=(Meziantou.GitLab.UserSafe? a, Meziantou.GitLab.UserSafe? b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.UserSafe? a, Meziantou.GitLab.UserSafe? b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.UserSafe>.Default.Equals(a, b);
        }
    }
}

namespace Meziantou.GitLab.Serialization
{
    internal sealed partial class UserSafeJsonConverter : Meziantou.GitLab.Serialization.GitLabObjectBaseJsonConverter<Meziantou.GitLab.UserSafe>
    {
        protected override Meziantou.GitLab.UserSafe CreateInstance(System.Text.Json.JsonElement jsonElement)
        {
            return new Meziantou.GitLab.UserSafe(jsonElement);
        }
    }
}
