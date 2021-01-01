namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ParameterEntityBuilder UserIdRef { get; } = CreateParameterEntity(entity =>
            entity.SetRefs(
                ParameterEntityRef.Create("userId", ModelRef.NumberId),
                ParameterEntityRef.Create("user", Models.UserSafe))
        );
    }
}
