namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder Project { get; } = CreateEntity(entity => entity
                .WithBaseType(BasicProjectDetails)
                .AddProperty("approvals_before_merge", ModelRef.NullableNumber)
                .AddProperty("archived", ModelRef.Boolean)
                .AddProperty("ci_config_path", ModelRef.NullableString)
                .AddProperty("container_registry_enabled", ModelRef.Boolean)
                .AddProperty("creator_id", ModelRef.NumberId)
                .AddProperty("forked_from_project", BasicProjectDetails.MakeNullable())
                .AddProperty("import_status", Models.ProjectImportStatus)
                .AddProperty("issues_enabled", ModelRef.Boolean)
                .AddProperty("jobs_enabled", ModelRef.Boolean)
                .AddProperty("lfs_enabled", ModelRef.Boolean)
                .AddProperty("_links", ProjectLinks)
                .AddProperty("merge_method", Models.MergeMethod)
                .AddProperty("merge_requests_enabled", ModelRef.Boolean)
                .AddProperty("mirror", ModelRef.NullableBoolean)
                .AddProperty("mirror_user_id", ModelRef.NullableNumberId)
                .AddProperty("mirror_trigger_builds", ModelRef.NullableBoolean)
                .AddProperty("mirror_overwrites_diverged_branches", ModelRef.NullableBoolean)
                .AddProperty("only_allow_merge_if_all_discussions_are_resolved", ModelRef.Boolean)
                .AddProperty("only_allow_merge_if_pipeline_succeeds", ModelRef.Boolean)
                .AddProperty("only_mirror_protected_branches", ModelRef.NullableBoolean)
                .AddProperty("open_issues_count", ModelRef.NullableNumber)
                .AddProperty("owner", Models.UserBasic.MakeNullable()) // The self monitoring project has no owner (https://docs.gitlab.com/ee/administration/monitoring/gitlab_self_monitoring_project/)
                .AddProperty("permissions", ProjectPermissions.MakeNullable())
                .AddProperty("printing_merge_request_link_enabled", ModelRef.Boolean)
                .AddProperty("public_jobs", ModelRef.Boolean)
                .AddProperty("request_access_enabled", ModelRef.Boolean)
                .AddProperty("resolve_outdated_diff_discussions", ModelRef.NullableBoolean)
                .AddProperty("shared_runners_enabled", ModelRef.Boolean)
                .AddProperty("shared_with_groups", SharedGroup.MakeCollection())
                .AddProperty("snippets_enabled", ModelRef.Boolean)
                .AddProperty("visibility", Models.Visibility)
                .AddProperty("wiki_enabled", ModelRef.Boolean)
        );
    }
}
