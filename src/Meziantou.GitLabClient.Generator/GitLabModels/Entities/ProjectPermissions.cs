namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder ProjectPermissions { get; } = CreateEntity(entity => entity
                .AddProperty("group_access", GroupAccess)
                .AddProperty("project_access", ProjectAccess)
        );
    }
}
