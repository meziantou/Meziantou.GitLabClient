namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder MemberAccess { get; } = CreateEntity(entity => entity
                .AddProperty("access_level", Models.AccessLevel)
                .AddProperty("notification_level", ModelRef.String)
        );
    }
}
