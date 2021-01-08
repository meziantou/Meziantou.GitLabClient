namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder RunnerRegistered { get; } = CreateEntity(entity => entity
                .AddProperty("id", ModelRef.NumberId)
                .AddProperty("token", ModelRef.String)
        );
    }
}
