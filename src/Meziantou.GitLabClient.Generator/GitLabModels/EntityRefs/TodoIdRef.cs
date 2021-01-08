namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ParameterEntityBuilder TodoIdRef { get; } = CreateParameterEntity(entity =>
            entity.SetModel(Models.Todo)
        );
    }
}
