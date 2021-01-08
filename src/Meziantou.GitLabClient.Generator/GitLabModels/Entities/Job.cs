namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder Job { get; } = CreateEntity(entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("name", ModelRef.String, PropertyOptions.IsDisplayName)
                .AddProperty("allow_failure", ModelRef.Boolean)
                .AddProperty("created_at", ModelRef.DateTime)
                .AddProperty("started_at", ModelRef.NullableDateTime)
                .AddProperty("finished_at", ModelRef.NullableDateTime)
                .AddProperty("status", Models.JobStatus)
        );
    }
}
