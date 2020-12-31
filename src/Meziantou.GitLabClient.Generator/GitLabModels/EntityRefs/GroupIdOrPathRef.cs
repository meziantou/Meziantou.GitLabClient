namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ParameterEntityBuilder GroupIdOrPathRef { get; } = CreateParameterEntity(entity =>
            entity.SetRefs(
                ParameterEntityRef.Create("groupId", ModelRef.NumberId),
                ParameterEntityRef.Create("projectPathWithNamespace", ModelRef.PathWithNamespace))
        );
    }
}
