namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder SharedGroup { get; } = CreateEntity(entity => entity
                .AddProperty("group_id", ModelRef.NumberId)
                .AddProperty("group_name", ModelRef.String)
                .AddProperty("group_access_level", Models.AccessLevel)
        );
    }
}
