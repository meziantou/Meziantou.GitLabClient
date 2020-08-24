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
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Serialization.MergeRequestJsonConverter))]
    [System.Diagnostics.DebuggerDisplayAttribute("{GetType().Name,nq} Title={Title}, Id={Id}")]
    public partial class MergeRequest : Meziantou.GitLab.Core.GitLabObject, System.IEquatable<Meziantou.GitLab.MergeRequest>
    {
        internal MergeRequest(System.Text.Json.JsonElement obj)
            : base(obj)
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("assignee")]
        public UserBasic Assignee
        {
            get
            {
                return this.GetRequiredNonNullValue<UserBasic>("assignee");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("author")]
        public UserBasic Author
        {
            get
            {
                return this.GetRequiredNonNullValue<UserBasic>("author");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("created_at")]
        public System.DateTimeOffset CreatedAt
        {
            get
            {
                return this.GetRequiredNonNullValue<System.DateTimeOffset>("created_at");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("description")]
        public string Description
        {
            get
            {
                return this.GetRequiredNonNullValue<string>("description");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("downvotes")]
        public int Downvotes
        {
            get
            {
                return this.GetRequiredNonNullValue<int>("downvotes");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("force_remove_source_branch")]
        public bool? ForceRemoveSourceBranch
        {
            get
            {
                return this.GetValueOrDefault<bool?>("force_remove_source_branch", default(bool?));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("id")]
        public long Id
        {
            get
            {
                return this.GetRequiredNonNullValue<long>("id");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("iid")]
        public long Iid
        {
            get
            {
                return this.GetRequiredNonNullValue<long>("iid");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("labels")]
        public System.Collections.Generic.IReadOnlyList<string> Labels
        {
            get
            {
                return this.GetRequiredNonNullValue<System.Collections.Generic.IReadOnlyList<string>>("labels");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("merge_commit_sha")]
        public Meziantou.GitLab.GitObjectId? MergeCommitSha
        {
            get
            {
                return this.GetValueOrDefault<Meziantou.GitLab.GitObjectId?>("merge_commit_sha", default(Meziantou.GitLab.GitObjectId?));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("merge_status")]
        public MergeRequestStatus MergeStatus
        {
            get
            {
                return this.GetRequiredNonNullValue<MergeRequestStatus>("merge_status");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("merge_when_pipeline_succeeds")]
        public bool MergeWhenPipelineSucceeds
        {
            get
            {
                return this.GetRequiredNonNullValue<bool>("merge_when_pipeline_succeeds");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("project_id")]
        public long ProjectId
        {
            get
            {
                return this.GetRequiredNonNullValue<long>("project_id");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("sha")]
        public Meziantou.GitLab.GitObjectId Sha
        {
            get
            {
                return this.GetRequiredNonNullValue<Meziantou.GitLab.GitObjectId>("sha");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("should_remove_source_branch")]
        public bool? ShouldRemoveSourceBranch
        {
            get
            {
                return this.GetValueOrDefault<bool?>("should_remove_source_branch", default(bool?));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("source_branch")]
        public string SourceBranch
        {
            get
            {
                return this.GetRequiredNonNullValue<string>("source_branch");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("source_project_id")]
        public long SourceProjectId
        {
            get
            {
                return this.GetRequiredNonNullValue<long>("source_project_id");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("squash")]
        public bool Squash
        {
            get
            {
                return this.GetRequiredNonNullValue<bool>("squash");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("state")]
        public MergeRequestState State
        {
            get
            {
                return this.GetRequiredNonNullValue<MergeRequestState>("state");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("target_branch")]
        public string TargetBranch
        {
            get
            {
                return this.GetRequiredNonNullValue<string>("target_branch");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("target_project_id")]
        public long TargetProjectId
        {
            get
            {
                return this.GetRequiredNonNullValue<long>("target_project_id");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("title")]
        public string Title
        {
            get
            {
                return this.GetRequiredNonNullValue<string>("title");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("updated_at")]
        public System.DateTimeOffset UpdatedAt
        {
            get
            {
                return this.GetRequiredNonNullValue<System.DateTimeOffset>("updated_at");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("upvotes")]
        public int Upvotes
        {
            get
            {
                return this.GetRequiredNonNullValue<int>("upvotes");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("user_notes_count")]
        public int UserNotesCount
        {
            get
            {
                return this.GetRequiredNonNullValue<int>("user_notes_count");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("web_url")]
        public System.Uri WebUrl
        {
            get
            {
                return this.GetRequiredNonNullValue<System.Uri>("web_url");
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("work_in_progress")]
        public bool WorkInProgress
        {
            get
            {
                return this.GetRequiredNonNullValue<bool>("work_in_progress");
            }
        }

        public override bool Equals(object? obj)
        {
            return this.Equals((obj as Meziantou.GitLab.MergeRequest));
        }

        public virtual bool Equals(Meziantou.GitLab.MergeRequest? obj)
        {
            return ((!object.ReferenceEquals(obj, null)) && (this.Id == obj.Id));
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(this.Id);
        }

        public static bool operator !=(Meziantou.GitLab.MergeRequest? a, Meziantou.GitLab.MergeRequest? b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.MergeRequest? a, Meziantou.GitLab.MergeRequest? b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.MergeRequest>.Default.Equals(a, b);
        }
    }
}

namespace Meziantou.GitLab.Serialization
{
    internal sealed partial class MergeRequestJsonConverter : Meziantou.GitLab.Serialization.GitLabObjectBaseJsonConverter<Meziantou.GitLab.MergeRequest>
    {
        protected override Meziantou.GitLab.MergeRequest CreateInstance(System.Text.Json.JsonElement jsonElement)
        {
            return new Meziantou.GitLab.MergeRequest(jsonElement);
        }
    }
}