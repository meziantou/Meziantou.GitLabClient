namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class SystemHooksClient : GitLabClientBuilder
    {
        protected override void Create(MethodGroup methodGroup)
        {
            methodGroup.AddMethod("AddHook", MethodType.Post, "/hooks", "https://docs.gitlab.com/ee/api/system_hooks.html#add-new-system-hook")
                .WithReturnType(Models.SystemHook)
                .AddRequiredParameter("url", ModelRef.Uri)
                .AddOptionalParameter("token", ModelRef.String)
                .AddOptionalParameter("push_events", ModelRef.Boolean)
                .AddOptionalParameter("tag_push_events", ModelRef.Boolean)
                .AddOptionalParameter("merge_requests_events", ModelRef.Boolean)
                .AddOptionalParameter("repository_update_events", ModelRef.Boolean)
                .AddOptionalParameter("enable_ssl_verification", ModelRef.Boolean)
                ;

            methodGroup.AddMethod("GetSystemHooks", MethodType.GetPaged, "/hooks", "https://docs.gitlab.com/ee/api/system_hooks.html#list-system-hooks")
                .WithReturnType(Models.SystemHook)
                ;

            methodGroup.AddMethod("Delete", MethodType.Delete, "/hooks/:id", "https://docs.gitlab.com/ee/api/system_hooks.html#delete-system-hook")
                .AddRequiredParameter("id", Models.SystemHookIdRef)
                ;
        }
    }
}
