namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder NamespaceBasic { get; } = CreateEntity(entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("name", ModelRef.String)
                .AddProperty("path", ModelRef.String)
                .AddProperty("kind", ModelRef.String)
                .AddProperty("full_path", ModelRef.String, PropertyOptions.IsDisplayName)
                .AddProperty("parent_id", ModelRef.NullableNumberId)
        );
    }
}
