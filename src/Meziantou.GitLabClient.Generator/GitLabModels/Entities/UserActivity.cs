namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder UserActivity { get; } = CreateEntity(entity => entity
                .AddProperty("username", ModelRef.String)
                .AddProperty("last_activity_on", ModelRef.Date)
        );
    }
}
