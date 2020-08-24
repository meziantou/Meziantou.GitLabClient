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
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Serialization.ProjectLinkJsonConverter))]
    public partial class ProjectLink : Meziantou.GitLab.Core.GitLabObject
    {
        internal ProjectLink(System.Text.Json.JsonElement obj)
            : base(obj)
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("events")]
        public string Events
        {
            get
            {
                return this.GetRequiredNonNullValue<string>("events");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("issues")]
        public string Issues
        {
            get
            {
                return this.GetRequiredNonNullValue<string>("issues");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("labels")]
        public string Labels
        {
            get
            {
                return this.GetRequiredNonNullValue<string>("labels");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("members")]
        public string Members
        {
            get
            {
                return this.GetRequiredNonNullValue<string>("members");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("merge_requests")]
        public string MergeRequests
        {
            get
            {
                return this.GetRequiredNonNullValue<string>("merge_requests");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("repo_branches")]
        public string RepoBranches
        {
            get
            {
                return this.GetRequiredNonNullValue<string>("repo_branches");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("self")]
        public string Self
        {
            get
            {
                return this.GetRequiredNonNullValue<string>("self");
            }
        }
    }
}

namespace Meziantou.GitLab.Serialization
{
    internal sealed partial class ProjectLinkJsonConverter : Meziantou.GitLab.Serialization.GitLabObjectBaseJsonConverter<Meziantou.GitLab.ProjectLink>
    {
        protected override Meziantou.GitLab.ProjectLink CreateInstance(System.Text.Json.JsonElement jsonElement)
        {
            return new Meziantou.GitLab.ProjectLink(jsonElement);
        }
    }
}