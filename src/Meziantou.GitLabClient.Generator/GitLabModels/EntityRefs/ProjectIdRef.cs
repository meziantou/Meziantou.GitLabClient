namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ParameterEntityBuilder ProjectIdRef { get; } = CreateParameterEntity(entity =>
            entity.SetRefs(
                ParameterEntityRef.Create("projectId", ModelRef.NumberId),
                ParameterEntityRef.Create("project", Models.ProjectIdentity))
        );
    }
}
