namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ParameterEntityBuilder SystemHookIdRef { get; } = CreateParameterEntity(entity =>
            entity.SetModel(Models.SystemHook)
        );
    }
}
