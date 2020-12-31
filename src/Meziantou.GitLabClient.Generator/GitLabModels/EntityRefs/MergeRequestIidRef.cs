namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ParameterEntityBuilder MergeRequestIidRef { get; } = CreateParameterEntity(entity =>
            entity.SetRefs(
                ParameterEntityRef.Create("mergeRequestIid", ModelRef.NumberId),
                ParameterEntityRef.Create("mergeRequest", Models.MergeRequest, "iid"))
        );
    }
}
