namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder Template { get; } = CreateEntity(entity => entity
                .AddProperty("name", ModelRef.String, PropertyOptions.IsDisplayName)
                .AddProperty("content", ModelRef.String)
        );
    }
}
