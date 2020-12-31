namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder UserSafe { get; } = CreateEntity(entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("name", ModelRef.String)
                .AddProperty("username", ModelRef.String, PropertyOptions.IsDisplayName)
        );
    }
}
