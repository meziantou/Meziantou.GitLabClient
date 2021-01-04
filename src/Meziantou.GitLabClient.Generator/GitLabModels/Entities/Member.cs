namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder Member { get; } = CreateEntity(entity => entity
                .AddProperty("id", ModelRef.NumberId)
                .AddProperty("username", ModelRef.String, PropertyOptions.IsKey)
                .AddProperty("name", ModelRef.String, PropertyOptions.IsDisplayName)
                .AddProperty("state", ModelRef.String, PropertyOptions.IsDisplayName)
                .AddProperty("avatar_url", ModelRef.Uri)
                .AddProperty("web_url", ModelRef.Uri)
                .AddProperty("expires_at", ModelRef.NullableDateTime)
                .AddProperty("access_level", Models.AccessLevel)
                .AddProperty("email", ModelRef.NullableString)
        );
    }
}
