namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder ProjectAccess { get; } = CreateEntity(entity => entity
                .WithBaseType(MemberAccess)
        );
    }
}
