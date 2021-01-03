namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder RepositoryFileUploaded { get; } = CreateEntity(entity => entity
                .AddProperty("alt", ModelRef.String)
                .AddProperty("url", ModelRef.Uri, PropertyOptions.CanBeAbsoluteOrRelativeUri)
                .AddProperty("full_path", ModelRef.Uri, PropertyOptions.CanBeAbsoluteOrRelativeUri)
                .AddProperty("markdown", ModelRef.String)
        );
    }
}
