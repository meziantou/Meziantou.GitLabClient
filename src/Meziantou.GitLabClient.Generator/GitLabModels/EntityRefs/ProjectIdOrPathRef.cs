namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ParameterEntityBuilder ProjectIdOrPathRef { get; } = CreateParameterEntity(entity =>
            entity.SetRefs(
                ParameterEntityRef.Create("projectId", ModelRef.NumberId),
                ParameterEntityRef.Create("project", Models.ProjectIdentity),
                ParameterEntityRef.Create("projectPathWithNamespace", ModelRef.PathWithNamespace))
        );
    }
}
