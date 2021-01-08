namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ParameterEntityBuilder SshKeyIdRef { get; } = CreateParameterEntity(entity =>
            entity.SetModel(Models.SshKey)
        );
    }
}
