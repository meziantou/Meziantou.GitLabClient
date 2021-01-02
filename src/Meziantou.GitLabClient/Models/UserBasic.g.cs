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
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Serialization.UserBasicJsonConverter))]
    public partial class UserBasic : UserSafe
    {
        internal UserBasic(System.Text.Json.JsonElement obj)
            : base(obj)
        {
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("avatar_path")]
        public string? AvatarPath
        {
            get
            {
                return this.GetValueOrDefault<string?>("avatar_path", default(string?));
            }
        }

        /// <remarks>The value is an absolute URI</remarks>
        [Meziantou.GitLab.Internals.MappedPropertyAttribute("avatar_url")]
        public System.Uri AvatarUrl
        {
            get
            {
                return this.GetRequiredNonNullValue<System.Uri>("avatar_url");
            }
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("state")]
        public UserState State
        {
            get
            {
                return this.GetRequiredNonNullValue<UserState>("state");
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

        public override string ToString()
        {
            return (((((("UserBasic { " + "Id = ") + this.Id) + ", ") + "Username = ") + this.Username) + " }");
        }
    }
}

namespace Meziantou.GitLab.Serialization
{
    internal sealed partial class UserBasicJsonConverter : Meziantou.GitLab.Serialization.GitLabObjectBaseJsonConverter<Meziantou.GitLab.UserBasic>
    {
        protected override Meziantou.GitLab.UserBasic CreateInstance(System.Text.Json.JsonElement jsonElement)
        {
            return new Meziantou.GitLab.UserBasic(jsonElement);
        }
    }
}
