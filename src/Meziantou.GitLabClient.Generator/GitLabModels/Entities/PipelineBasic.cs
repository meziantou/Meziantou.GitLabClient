namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder PipelineBasic { get; } = CreateEntity(entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("created_at", ModelRef.DateTime)
                .AddProperty("updated_at", ModelRef.NullableDateTime)
                .AddProperty("status", Models.PipelineStatus)
                .AddProperty("web_url", ModelRef.Uri)
        );
    }
}
