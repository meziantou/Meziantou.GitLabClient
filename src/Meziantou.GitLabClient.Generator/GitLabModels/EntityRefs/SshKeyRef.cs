namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ParameterEntityBuilder SshKeyRef { get; } = CreateParameterEntity(entity =>
            entity.SetRefs(
                ParameterEntityRef.Create("sshKeyId", ModelRef.NumberId),
                ParameterEntityRef.Create("sskKey", Models.SshKey))
        );
    }
}
