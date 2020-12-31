namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder Issue { get; } = CreateEntity(entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("iid", ModelRef.NumberId)
                .AddProperty("author", Models.UserBasic)
                .AddProperty("title", ModelRef.String, PropertyOptions.IsDisplayName)
                .AddProperty("project_id", ModelRef.NumberId)
                .AddProperty("web_url", ModelRef.Uri)
                .AddProperty("created_at", ModelRef.DateTime)
                .AddProperty("updated_at", ModelRef.DateTime)
                .AddProperty("closed_at", ModelRef.NullableDateTime)
                .AddProperty("closed_by", Models.UserBasic.MakeNullable())
        );
    }
}
