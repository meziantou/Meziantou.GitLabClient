namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder ProjectLinks { get; } = CreateEntity(entity => entity
                .AddProperty("events", ModelRef.String)
                .AddProperty("issues", ModelRef.String)
                .AddProperty("labels", ModelRef.String)
                .AddProperty("members", ModelRef.String)
                .AddProperty("merge_requests", ModelRef.String)
                .AddProperty("repo_branches", ModelRef.String)
                .AddProperty("self", ModelRef.String)
        );
    }
}
