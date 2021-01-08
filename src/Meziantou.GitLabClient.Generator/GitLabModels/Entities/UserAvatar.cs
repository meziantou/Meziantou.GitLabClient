namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder UserAvatar { get; } = CreateEntity(entity => entity
                .AddProperty("avatar_url", ModelRef.Uri)
        );
    }
}
