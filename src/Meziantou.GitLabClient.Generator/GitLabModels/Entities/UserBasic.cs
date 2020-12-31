namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder UserBasic { get; } = CreateEntity(entity => entity
                .WithBaseType(UserSafe)
                .AddProperty("avatar_url", ModelRef.Uri)
                .AddProperty("avatar_path", ModelRef.NullableString)
                .AddProperty("state", Models.UserState)
                .AddProperty("web_url", ModelRef.Uri)
        );
    }
}
