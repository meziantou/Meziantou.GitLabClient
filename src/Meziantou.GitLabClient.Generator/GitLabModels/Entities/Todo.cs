namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder Todo { get; } = CreateEntity(entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("action_name", Models.TodoAction)
                .AddProperty("author", Models.UserBasic)
                .AddProperty("project", BasicProjectDetails)
                .AddProperty("target_type", Models.TodoTargetType)
                .AddProperty("target_url", ModelRef.Uri)
                .AddProperty("body", ModelRef.String)
                .AddProperty("state", Models.TodoState)
                .AddProperty("created_at", ModelRef.DateTime)
        );
    }
}
