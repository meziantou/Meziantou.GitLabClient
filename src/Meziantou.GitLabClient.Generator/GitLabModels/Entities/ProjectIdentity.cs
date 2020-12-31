namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder ProjectIdentity { get; } = CreateEntity(entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("created_at", ModelRef.DateTime)
                .AddProperty("description", ModelRef.NullableString)
                .AddProperty("name", ModelRef.String)
                .AddProperty("name_with_namespace", ModelRef.String)
                .AddProperty("path", ModelRef.String)
                .AddProperty("path_with_namespace", ModelRef.PathWithNamespace, PropertyOptions.IsDisplayName)
        );
    }
}
