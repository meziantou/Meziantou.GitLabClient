namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder ServerVersion { get; } = CreateEntity(entity => entity
                .AddProperty("version", ModelRef.String, PropertyOptions.IsKey)
                .AddProperty("revision", ModelRef.String, PropertyOptions.IsKey)
        );
    }
}
