namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder WikiPage { get; } = CreateEntity(entity => entity
                .AddProperty("slug", ModelRef.String, PropertyOptions.IsKey)
                .AddProperty("title", ModelRef.String)
                .AddProperty("content", ModelRef.NullableString)
                .AddProperty("format", Models.WikiPageFormat)
        );
    }
}
