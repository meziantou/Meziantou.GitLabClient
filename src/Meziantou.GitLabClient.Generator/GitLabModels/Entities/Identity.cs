namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder Identity { get; } = CreateEntity(entity => entity
               .AddProperty("provider", ModelRef.String, PropertyOptions.IsKey)
               .AddProperty("extern_uid", ModelRef.String, PropertyOptions.IsKey)
        );
    }
}
