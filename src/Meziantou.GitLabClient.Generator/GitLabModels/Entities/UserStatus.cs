namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder UserStatus { get; } = CreateEntity(entity => entity
                .AddProperty("emoji", ModelRef.NullableString)
                .AddProperty("message", ModelRef.NullableString)
                .AddProperty("message_html", ModelRef.String)
        );
    }
}
