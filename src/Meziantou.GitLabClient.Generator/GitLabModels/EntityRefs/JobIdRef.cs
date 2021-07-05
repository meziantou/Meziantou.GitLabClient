namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ParameterEntityBuilder JobIdRef { get; } = CreateParameterEntity(entity =>
            entity.SetModel(Models.JobBase)
        );
    }
}
