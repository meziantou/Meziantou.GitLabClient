namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder BasicProjectDetails { get; } = CreateEntity(entity => entity
                .WithBaseType(ProjectIdentity)
                .AddProperty("avatar_url", ModelRef.NullableUri)
                .AddProperty("default_branch", ModelRef.NullableString)
                .AddProperty("forks_count", ModelRef.Number)
                .AddProperty("http_url_to_repo", ModelRef.Uri)
                .AddProperty("last_activity_at", ModelRef.DateTime)
                .AddProperty("namespace", NamespaceBasic)
                .AddProperty("readme_url", ModelRef.NullableUri)
                .AddProperty("ssh_url_to_repo", ModelRef.NullableUri, PropertyOptions.CanBeAbsoluteOrRelativeUri)
                .AddProperty("star_count", ModelRef.Number)
                .AddProperty("tag_list", ModelRef.StringCollection)
                .AddProperty("web_url", ModelRef.NullableUri)
        );
    }
}
