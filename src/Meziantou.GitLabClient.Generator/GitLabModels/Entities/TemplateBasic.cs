namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder TemplateBasic { get; } = CreateEntity(entity => entity
                .AddProperty("key", ModelRef.String, PropertyOptions.IsKey)
                .AddProperty("name", ModelRef.String, PropertyOptions.IsDisplayName)
        );
    }
}
