namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder Group { get; } = CreateEntity(entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("name", ModelRef.String)
                .AddProperty("path", ModelRef.String)
                .AddProperty("name_with_namespace", ModelRef.String)
                .AddProperty("path_with_namespace", ModelRef.PathWithNamespace, PropertyOptions.IsDisplayName)
                .AddProperty("description", ModelRef.NullableString)
                .AddProperty("created_at", ModelRef.DateTime)
                .AddProperty("visibility", Visibility)
                .AddProperty("project_creation_level", ProjectCreationLevel)
                .AddProperty("auto_devops_enabled", ModelRef.Boolean)
        );
    }
}
