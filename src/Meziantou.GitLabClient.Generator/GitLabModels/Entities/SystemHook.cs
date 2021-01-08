namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder SystemHook { get; } = CreateEntity(entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("url", ModelRef.Uri, PropertyOptions.IsDisplayName)
                .AddProperty("created_at", ModelRef.DateTime)
                .AddProperty("push_events", ModelRef.Boolean)
                .AddProperty("tag_push_events", ModelRef.Boolean)
                .AddProperty("merge_requests_events", ModelRef.Boolean)
                .AddProperty("repository_update_events", ModelRef.Boolean)
                .AddProperty("enable_ssl_verification", ModelRef.Boolean)
        );
    }
}
