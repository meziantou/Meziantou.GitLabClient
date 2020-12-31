namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder GroupAccess { get; } = CreateEntity(entity => entity
                .WithBaseType(MemberAccess)
        );
    }
}
