namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder LicenseTemplate { get; } = CreateEntity(entity => entity
                .AddProperty("key", ModelRef.String, PropertyOptions.IsKey)
                .AddProperty("name", ModelRef.String, PropertyOptions.IsDisplayName)
                .AddProperty("nickname", ModelRef.NullableString)
                .AddProperty("featured", ModelRef.Boolean)
                .AddProperty("html_url", ModelRef.Uri)
                .AddProperty("source_url", ModelRef.Uri)
                .AddProperty("description", ModelRef.String)
                .AddProperty("conditions", ModelRef.StringCollection)
                .AddProperty("permissions", ModelRef.StringCollection)
                .AddProperty("limitations", ModelRef.StringCollection)
                .AddProperty("content", ModelRef.String)
        );
    }
}
