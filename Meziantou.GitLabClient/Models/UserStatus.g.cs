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
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Serialization.UserStatusJsonConverter))]
    public partial class UserStatus : Meziantou.GitLab.Core.GitLabObject
    {
        internal UserStatus(System.Text.Json.JsonElement obj)
            : base(obj)
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("emoji")]
        public string Emoji
        {
            get
            {
                return this.GetValueOrDefault<string>("emoji", default(string));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("message")]
        public string Message
        {
            get
            {
                return this.GetValueOrDefault<string>("message", default(string));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("message_html")]
        public string MessageHtml
        {
            get
            {
                return this.GetValueOrDefault<string>("message_html", default(string));
            }
        }
    }
}

namespace Meziantou.GitLab.Serialization
{
    internal sealed partial class UserStatusJsonConverter : Meziantou.GitLab.Serialization.GitLabObjectBaseJsonConverter<Meziantou.GitLab.UserStatus>
    {
        protected override Meziantou.GitLab.UserStatus CreateInstance(System.Text.Json.JsonElement jsonElement)
        {
            return new Meziantou.GitLab.UserStatus(jsonElement);
        }
    }
}
#nullable disable
