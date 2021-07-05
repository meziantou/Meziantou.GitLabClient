namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ParameterEntityBuilder PipelineIdRef { get; } = CreateParameterEntity(entity =>
            entity.SetModel(Models.PipelineBasic)
        );
    }
}
