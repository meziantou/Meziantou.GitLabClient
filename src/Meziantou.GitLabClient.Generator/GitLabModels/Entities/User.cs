namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder User { get; } = CreateEntity(entity => entity
                .WithBaseType(UserBasic)
                .AddProperty("bio", ModelRef.NullableString)
                .AddProperty("can_create_group", ModelRef.NullableBoolean)
                .AddProperty("can_create_project", ModelRef.NullableBoolean)
                .AddProperty("color_scheme_id", ModelRef.NullableNumberId)
                .AddProperty("confirmed_at", ModelRef.NullableDateTime)
                .AddProperty("created_at", ModelRef.DateTime)
                .AddProperty("current_sign_in_at", ModelRef.NullableDateTime)
                .AddProperty("email", ModelRef.NullableString)
                .AddProperty("external", ModelRef.NullableBoolean)
                .AddProperty("identities", Identity.MakeCollectionNullable())
                .AddProperty("is_admin", ModelRef.NullableBoolean)
                .AddProperty("last_activity_on", ModelRef.NullableDate, PropertyOptions.IsNotUTCDate)
                .AddProperty("last_sign_in_at", ModelRef.NullableDateTime)
                .AddProperty("linkedin", ModelRef.NullableString)
                .AddProperty("location", ModelRef.NullableString)
                .AddProperty("organization", ModelRef.NullableString)
                .AddProperty("private_profile", ModelRef.NullableBoolean)
                .AddProperty("projects_limit", ModelRef.NullableNumber)
                .AddProperty("shared_runners_minutes_limit", ModelRef.NullableNumber)
                .AddProperty("skype", ModelRef.NullableString)
                .AddProperty("theme_id", ModelRef.NullableNumberId)
                .AddProperty("twitter", ModelRef.NullableString)
                .AddProperty("two_factor_enabled", ModelRef.NullableBoolean)
                .AddProperty("website_url", ModelRef.NullableUri, PropertyOptions.CanBeAbsoluteOrRelativeUri)
        );
    }
}
