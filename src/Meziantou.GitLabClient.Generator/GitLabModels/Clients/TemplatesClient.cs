namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class TemplatesClient : GitLabClientBuilder
    {
        protected override void Create(MethodGroup methodGroup)
        {
            methodGroup.AddMethod("GetGitIgnores", MethodType.GetPaged, "/templates/gitignores", "https://docs.gitlab.com/ee/api/templates/gitignores.html#list-gitignore-templates")
                .WithReturnType(Models.TemplateBasic)
                ;

            methodGroup.AddMethod("GetGitIgnoreByKey", MethodType.Get, "/templates/gitignores/:key", "https://docs.gitlab.com/ee/api/templates/gitignores.html#single-gitignore-template")
                .WithReturnType(Models.Template)
                .AddRequiredParameter("key", ModelRef.String)
                ;

            methodGroup.AddMethod("GetGitLabCiYmls", MethodType.GetPaged, "/templates/gitlab_ci_ymls", "https://docs.gitlab.com/ee/api/templates/gitlab_ci_ymls.html#list-gitlab-ci-yaml-templates")
                .WithReturnType(Models.TemplateBasic)
                ;

            methodGroup.AddMethod("GetGitLabCiYmlByKey", MethodType.Get, "/templates/gitlab_ci_ymls/:key", "https://docs.gitlab.com/ee/api/templates/gitlab_ci_ymls.html#single-gitlab-ci-yaml-template")
                .WithReturnType(Models.Template)
                .AddRequiredParameter("key", ModelRef.String)
                ;

            methodGroup.AddMethod("GetDockerfiles", MethodType.GetPaged, "/templates/dockerfiles", "https://docs.gitlab.com/ee/api/templates/dockerfiles.html#list-dockerfile-templates")
                .WithReturnType(Models.TemplateBasic)
                ;

            methodGroup.AddMethod("GetDockerfileByKey", MethodType.Get, "/templates/dockerfiles/:key", "https://docs.gitlab.com/ee/api/templates/dockerfiles.html#single-dockerfile-template")
                .WithReturnType(Models.Template)
                .AddRequiredParameter("key", ModelRef.String)
                ;

            methodGroup.AddMethod("GetLicenses", MethodType.GetPaged, "/templates/licenses", "https://docs.gitlab.com/ee/api/templates/licenses.html#list-license-templates")
                .WithReturnType(Models.TemplateBasic)
                .AddOptionalParameter("popular", ModelRef.Boolean)
                ;

            methodGroup.AddMethod("GetLicenseByKey", MethodType.Get, "/templates/licenses/:key", "https://docs.gitlab.com/ee/api/templates/licenses.html#single-license-template")
                .WithReturnType(Models.Template)
                .AddRequiredParameter("key", ModelRef.String)
                .AddOptionalParameter("project", ModelRef.String)
                .AddOptionalParameter("fullname", ModelRef.String)
                ;
        }
    }
}
