namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder ImpersonationToken { get; } = CreateEntity(entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("revoked", ModelRef.Boolean)
                .AddProperty("scopes", Models.ImpersonationTokenScope.MakeCollection())
                .AddProperty("token", ModelRef.String)
                .AddProperty("active", ModelRef.Boolean)
                .AddProperty("impersonation", ModelRef.Boolean)
                .AddProperty("name", ModelRef.String, PropertyOptions.IsDisplayName)
                .AddProperty("created_at", ModelRef.DateTime)
                .AddProperty("expires_at", ModelRef.NullableDate, PropertyOptions.IsNotUTCDate)
        );
    }
}
