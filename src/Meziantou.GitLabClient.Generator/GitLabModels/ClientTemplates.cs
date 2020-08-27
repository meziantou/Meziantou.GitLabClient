namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal static partial class Entities
    {
        public static EntityBuilder TemplateBasic { get; private set; }
        public static EntityBuilder Template { get; private set; }

        public static EntityBuilder LicenseTemplate { get; private set; }

        public static void CreateGitIgnore()
        {
            TemplateBasic.Configure(entity => entity
                .AddProperty("key", ModelRef.String, PropertyOptions.IsKey)
                .AddProperty("name", ModelRef.String, PropertyOptions.IsDisplayName)
            );
            Template.Configure(entity => entity
                .AddProperty("name", ModelRef.String, PropertyOptions.IsDisplayName)
                .AddProperty("content", ModelRef.String)
           );

            LicenseTemplate.Configure(entity => entity
                .AddProperty("key", ModelRef.String, PropertyOptions.IsKey)
                .AddProperty("name", ModelRef.String, PropertyOptions.IsDisplayName)
                .AddProperty("nickname", ModelRef.NullableString)
                .AddProperty("featured", ModelRef.Boolean)
                .AddProperty("html_url", ModelRef.Uri)
                .AddProperty("source_url", ModelRef.Uri)
                .AddProperty("description", ModelRef.String)
                .AddProperty("conditions", ModelRef.StringCollection)
                .AddProperty("permissions", ModelRef.StringCollection)
                .AddProperty("limitations", ModelRef.StringCollection)
                .AddProperty("content", ModelRef.String)
            );
        }
    }

    internal sealed class ClientGitIgnore : IGitLabClientDescriptor
    {
        public void Create(Project project)
        {
            var group = project.AddMethodGroup("Templates");

            group.AddMethod("GetGitIgnores", MethodType.GetPaged, "/templates/gitignores", "https://docs.gitlab.com/ee/api/templates/gitignores.html#list-gitignore-templates")
                .WithReturnType(Entities.TemplateBasic)
                ;

            group.AddMethod("GetGitIgnoreByKey", MethodType.Get, "/templates/gitignores/:key", "https://docs.gitlab.com/ee/api/templates/gitignores.html#single-gitignore-template")
                .WithReturnType(Entities.Template)
                .AddRequiredParameter("key", ModelRef.String)
                ;

            group.AddMethod("GetGitLabCiYmls", MethodType.GetPaged, "/templates/gitlab_ci_ymls", "https://docs.gitlab.com/ee/api/templates/gitlab_ci_ymls.html#list-gitlab-ci-yaml-templates")
                .WithReturnType(Entities.TemplateBasic)
                ;

            group.AddMethod("GetGitLabCiYmlByKey", MethodType.Get, "/templates/gitlab_ci_ymls/:key", "https://docs.gitlab.com/ee/api/templates/gitlab_ci_ymls.html#single-gitlab-ci-yaml-template")
                .WithReturnType(Entities.Template)
                .AddRequiredParameter("key", ModelRef.String)
                ;

            group.AddMethod("GetDockerfiles", MethodType.GetPaged, "/templates/dockerfiles", "https://docs.gitlab.com/ee/api/templates/dockerfiles.html#list-dockerfile-templates")
                .WithReturnType(Entities.TemplateBasic)
                ;

            group.AddMethod("GetDockerfileByKey", MethodType.Get, "/templates/dockerfiles/:key", "https://docs.gitlab.com/ee/api/templates/dockerfiles.html#single-dockerfile-template")
                .WithReturnType(Entities.Template)
                .AddRequiredParameter("key", ModelRef.String)
                ;

            group.AddMethod("GetLicenses", MethodType.GetPaged, "/templates/licenses", "https://docs.gitlab.com/ee/api/templates/licenses.html#list-license-templates")
                .WithReturnType(Entities.TemplateBasic)
                .AddOptionalParameter("popular", ModelRef.Boolean)
                ;

            group.AddMethod("GetLicenseByKey", MethodType.Get, "/templates/licenses/:key", "https://docs.gitlab.com/ee/api/templates/licenses.html#single-license-template")
                .WithReturnType(Entities.Template)
                .AddRequiredParameter("key", ModelRef.String)
                .AddOptionalParameter("project", ModelRef.String)
                .AddOptionalParameter("fullname", ModelRef.String)
                ;
        }
    }
}
