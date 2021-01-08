namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ParameterEntityBuilder GroupIdRef { get; } = CreateParameterEntity(entity =>
            entity.SetRefs(
                ParameterEntityRef.Create("groupId", ModelRef.NumberId),
                ParameterEntityRef.Create("group", Models.Group))
        );
    }
}
