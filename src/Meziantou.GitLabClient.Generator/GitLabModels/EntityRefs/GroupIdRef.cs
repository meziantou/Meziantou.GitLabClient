namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ParameterEntityBuilder GroupIdRef { get; } = CreateParameterEntity(entity =>
            entity.SetModel(Models.Group)
        );
    }
}
