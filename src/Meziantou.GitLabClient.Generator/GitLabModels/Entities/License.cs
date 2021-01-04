namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder License { get; } = CreateEntity(entity => entity
            .AddProperty("id", ModelRef.NumberId)
            .AddProperty("plan", ModelRef.String)
            .AddProperty("created_at", ModelRef.DateTime)
            .AddProperty("starts_at", ModelRef.Date)
            .AddProperty("expires_at", ModelRef.Date)
            .AddProperty("historical_max", ModelRef.Number)
            .AddProperty("maximum_user_count", ModelRef.Number)
            .AddProperty("expired", ModelRef.Boolean)
            .AddProperty("overage", ModelRef.Number)
            .AddProperty("user_limit", ModelRef.Number)
            .AddProperty("active_users", ModelRef.Number)
        );
    }
}
