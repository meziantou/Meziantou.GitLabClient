namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder Job { get; } = CreateEntity(entity => entity
                .WithBaseType(JobBase)
                .AddProperty("web_url", ModelRef.Uri)
        );
    }
}
