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
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Serialization.ProjectJsonConverter))]
    public partial class Project : BasicProjectDetails
    {
        internal Project(System.Text.Json.JsonElement obj)
            : base(obj)
        {
        }

        [Meziantou.GitLab.MappedPropertyAttribute("approvals_before_merge")]
        public int? ApprovalsBeforeMerge
        {
            get
            {
                return this.GetValueOrDefault<int?>("approvals_before_merge", default(int?));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("archived")]
        public bool Archived
        {
            get
            {
                return this.GetValueOrDefault<bool>("archived", default(bool));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("ci_config_path")]
        public string CiConfigPath
        {
            get
            {
                return this.GetValueOrDefault<string>("ci_config_path", default(string));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("container_registry_enabled")]
        public bool ContainerRegistryEnabled
        {
            get
            {
                return this.GetValueOrDefault<bool>("container_registry_enabled", default(bool));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("creator_id")]
        public long CreatorId
        {
            get
            {
                return this.GetValueOrDefault<long>("creator_id", default(long));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("forked_from_project")]
        public BasicProjectDetails ForkedFromProject
        {
            get
            {
                return this.GetValueOrDefault<BasicProjectDetails>("forked_from_project", default(BasicProjectDetails));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("import_status")]
        public ImportStatus ImportStatus
        {
            get
            {
                return this.GetValueOrDefault<ImportStatus>("import_status", default(ImportStatus));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("issues_enabled")]
        public bool IssuesEnabled
        {
            get
            {
                return this.GetValueOrDefault<bool>("issues_enabled", default(bool));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("jobs_enabled")]
        public bool JobsEnabled
        {
            get
            {
                return this.GetValueOrDefault<bool>("jobs_enabled", default(bool));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("lfs_enabled")]
        public bool LfsEnabled
        {
            get
            {
                return this.GetValueOrDefault<bool>("lfs_enabled", default(bool));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("_links")]
        public ProjectLink Links
        {
            get
            {
                return this.GetValueOrDefault<ProjectLink>("_links", default(ProjectLink));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("merge_method")]
        public MergeMethod MergeMethod
        {
            get
            {
                return this.GetValueOrDefault<MergeMethod>("merge_method", default(MergeMethod));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("merge_requests_enabled")]
        public bool MergeRequestsEnabled
        {
            get
            {
                return this.GetValueOrDefault<bool>("merge_requests_enabled", default(bool));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("mirror")]
        public bool Mirror
        {
            get
            {
                return this.GetValueOrDefault<bool>("mirror", default(bool));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("mirror_overwrites_diverged_branches")]
        public bool? MirrorOverwritesDivergedBranches
        {
            get
            {
                return this.GetValueOrDefault<bool?>("mirror_overwrites_diverged_branches", default(bool?));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("mirror_trigger_builds")]
        public bool? MirrorTriggerBuilds
        {
            get
            {
                return this.GetValueOrDefault<bool?>("mirror_trigger_builds", default(bool?));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("mirror_user_id")]
        public long? MirrorUserId
        {
            get
            {
                return this.GetValueOrDefault<long?>("mirror_user_id", default(long?));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("only_allow_merge_if_all_discussions_are_resolved")]
        public bool OnlyAllowMergeIfAllDiscussionsAreResolved
        {
            get
            {
                return this.GetValueOrDefault<bool>("only_allow_merge_if_all_discussions_are_resolved", default(bool));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("only_allow_merge_if_pipeline_succeeds")]
        public bool OnlyAllowMergeIfPipelineSucceeds
        {
            get
            {
                return this.GetValueOrDefault<bool>("only_allow_merge_if_pipeline_succeeds", default(bool));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("only_mirror_protected_branches")]
        public bool? OnlyMirrorProtectedBranches
        {
            get
            {
                return this.GetValueOrDefault<bool?>("only_mirror_protected_branches", default(bool?));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("open_issues_count")]
        public int? OpenIssuesCount
        {
            get
            {
                return this.GetValueOrDefault<int?>("open_issues_count", default(int?));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("owner")]
        public UserBasic Owner
        {
            get
            {
                return this.GetValueOrDefault<UserBasic>("owner", default(UserBasic));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("permissions")]
        public ProjectPermissions Permissions
        {
            get
            {
                return this.GetValueOrDefault<ProjectPermissions>("permissions", default(ProjectPermissions));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("printing_merge_request_link_enabled")]
        public bool PrintingMergeRequestLinkEnabled
        {
            get
            {
                return this.GetValueOrDefault<bool>("printing_merge_request_link_enabled", default(bool));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("public_jobs")]
        public bool PublicJobs
        {
            get
            {
                return this.GetValueOrDefault<bool>("public_jobs", default(bool));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("request_access_enabled")]
        public bool RequestAccessEnabled
        {
            get
            {
                return this.GetValueOrDefault<bool>("request_access_enabled", default(bool));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("resolve_outdated_diff_discussions")]
        public bool? ResolveOutdatedDiffDiscussions
        {
            get
            {
                return this.GetValueOrDefault<bool?>("resolve_outdated_diff_discussions", default(bool?));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("shared_runners_enabled")]
        public bool SharedRunnersEnabled
        {
            get
            {
                return this.GetValueOrDefault<bool>("shared_runners_enabled", default(bool));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("shared_with_groups")]
        public System.Collections.Generic.IReadOnlyList<SharedGroup> SharedWithGroups
        {
            get
            {
                return this.GetValueOrDefault<System.Collections.Generic.IReadOnlyList<SharedGroup>>("shared_with_groups", default(System.Collections.Generic.IReadOnlyList<SharedGroup>));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("snippets_enabled")]
        public bool SnippetsEnabled
        {
            get
            {
                return this.GetValueOrDefault<bool>("snippets_enabled", default(bool));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("visibility")]
        public ProjectVisibility Visibility
        {
            get
            {
                return this.GetValueOrDefault<ProjectVisibility>("visibility", default(ProjectVisibility));
            }
        }

        [Meziantou.GitLab.MappedPropertyAttribute("wiki_enabled")]
        public bool WikiEnabled
        {
            get
            {
                return this.GetValueOrDefault<bool>("wiki_enabled", default(bool));
            }
        }
    }
}

namespace Meziantou.GitLab.Serialization
{
    internal sealed partial class ProjectJsonConverter : Meziantou.GitLab.Serialization.GitLabObjectBaseJsonConverter<Meziantou.GitLab.Project>
    {
        protected override Meziantou.GitLab.Project CreateInstance(System.Text.Json.JsonElement jsonElement)
        {
            return new Meziantou.GitLab.Project(jsonElement);
        }
    }
}
#nullable disable
