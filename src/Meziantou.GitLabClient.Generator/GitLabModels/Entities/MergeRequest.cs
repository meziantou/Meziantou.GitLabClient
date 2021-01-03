namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder MergeRequest { get; } = CreateEntity(entity => entity
                .AddProperty("id", ModelRef.NumberId)
                .AddProperty("iid", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("project_id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("author", Models.UserBasic)
                .AddProperty("assignee", Models.UserBasic.MakeNullable())
                .AddProperty("title", ModelRef.String, PropertyOptions.IsDisplayName)
                .AddProperty("description", ModelRef.NullableString)
                .AddProperty("state", Models.MergeRequestState)
                .AddProperty("source_project_id", ModelRef.NumberId)
                .AddProperty("target_project_id", ModelRef.NumberId)
                .AddProperty("web_url", ModelRef.Uri)
                .AddProperty("created_at", ModelRef.DateTime)
                .AddProperty("updated_at", ModelRef.DateTime)
                .AddProperty("user_notes_count", ModelRef.Number)
                .AddProperty("target_branch", ModelRef.String)
                .AddProperty("source_branch", ModelRef.String)
                .AddProperty("upvotes", ModelRef.Number)
                .AddProperty("downvotes", ModelRef.Number)
                .AddProperty("labels", ModelRef.StringCollection)
                .AddProperty("work_in_progress", ModelRef.Boolean)
                .AddProperty("merge_when_pipeline_succeeds", ModelRef.Boolean)
                .AddProperty("merge_status", Models.MergeRequestStatus)
                .AddProperty("sha", ModelRef.GitObjectId)
                .AddProperty("merge_commit_sha", ModelRef.NullableGitObjectId)
                .AddProperty("should_remove_source_branch", ModelRef.NullableBoolean)
                .AddProperty("force_remove_source_branch", ModelRef.NullableBoolean)
                .AddProperty("squash", ModelRef.Boolean)
        );
    }
}
