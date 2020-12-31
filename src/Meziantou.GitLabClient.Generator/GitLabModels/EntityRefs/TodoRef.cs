namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static ParameterEntityBuilder TodoRef { get; } = CreateParameterEntity(entity =>
            entity.SetRefs(
                ParameterEntityRef.Create("todoId", ModelRef.NumberId),
                ParameterEntityRef.Create("todo", Models.Todo))
        );
    }
}
