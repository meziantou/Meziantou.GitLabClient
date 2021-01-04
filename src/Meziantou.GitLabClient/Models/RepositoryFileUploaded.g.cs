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
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Serialization.RepositoryFileUploadedJsonConverter))]
    public partial class RepositoryFileUploaded : Meziantou.GitLab.Core.GitLabObject
    {
        internal RepositoryFileUploaded(System.Text.Json.JsonElement obj)
            : base(obj)
        {
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("alt")]
        public string Alt
        {
            get
            {
                return this.GetRequiredNonNullValue<string>("alt");
            }
        }

        /// <remarks>The value may be an absolute or a relative URI</remarks>
        [Meziantou.GitLab.Internals.SkipAbsoluteUriValidationAttribute]
        [Meziantou.GitLab.Internals.MappedPropertyAttribute("full_path")]
        public System.Uri FullPath
        {
            get
            {
                return this.GetRequiredNonNullValue<System.Uri>("full_path");
            }
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("markdown")]
        public string Markdown
        {
            get
            {
                return this.GetRequiredNonNullValue<string>("markdown");
            }
        }

        /// <remarks>The value may be an absolute or a relative URI</remarks>
        [Meziantou.GitLab.Internals.SkipAbsoluteUriValidationAttribute]
        [Meziantou.GitLab.Internals.MappedPropertyAttribute("url")]
        public System.Uri Url
        {
            get
            {
                return this.GetRequiredNonNullValue<System.Uri>("url");
            }
        }
    }
}

namespace Meziantou.GitLab.Serialization
{
    internal sealed partial class RepositoryFileUploadedJsonConverter : Meziantou.GitLab.Serialization.GitLabObjectBaseJsonConverter<Meziantou.GitLab.RepositoryFileUploaded>
    {
        protected override Meziantou.GitLab.RepositoryFileUploaded CreateInstance(System.Text.Json.JsonElement jsonElement)
        {
            return new Meziantou.GitLab.RepositoryFileUploaded(jsonElement);
        }
    }
}