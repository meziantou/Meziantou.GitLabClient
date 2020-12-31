namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder SshKey { get; } = CreateEntity(entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("title", ModelRef.String, PropertyOptions.IsDisplayName)
                .AddProperty("key", ModelRef.String)
                .AddProperty("created_at", ModelRef.DateTime)
        );
    }
}
