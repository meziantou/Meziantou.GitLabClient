namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class RunnersClient : GitLabClientBuilder
    {
        protected override void Create(MethodGroup methodGroup)
        {
            methodGroup.AddMethod("Register", MethodType.Post, "/runners", "https://docs.gitlab.com/ee/api/runners.html#register-a-new-runner")
                .WithReturnType(Models.RunnerRegistered)
                .AddRequiredParameter("token", ModelRef.String)
                .AddOptionalParameter("description", ModelRef.String)
                .AddOptionalParameter("active", ModelRef.Boolean)
                .AddOptionalParameter("locked", ModelRef.Boolean)
                .AddOptionalParameter("run_untagged", ModelRef.Boolean)
                .AddOptionalParameter("tag_list", ModelRef.StringCollection)
                .AddOptionalParameter("access_level", Choice("RunnerAccessLevel", new[] { "not_protected", "ref_protected" }))
                .AddOptionalParameter("maximum_timeout", ModelRef.Number)
            ;
        }
    }
}
