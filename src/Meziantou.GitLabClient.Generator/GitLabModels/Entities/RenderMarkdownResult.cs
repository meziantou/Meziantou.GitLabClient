namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder RenderMarkdownResult { get; } = CreateEntity(entity => entity
                 .AddProperty("html", ModelRef.String, PropertyOptions.IsKey)
        );
    }
}
