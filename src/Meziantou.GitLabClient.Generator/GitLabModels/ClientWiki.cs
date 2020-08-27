namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal static partial class Enumerations
    {
        public static ModelRef WikiPageFormat { get; private set; }

        public static void CreateWiki(Project project)
        {

            WikiPageFormat = project.AddStringEnumeration("WikiPageFormat")
                .AddMembers("markdown", "rdoc", "asciidoc");
        }
    }

    internal static partial class Entities
    {
        public static EntityBuilder WikiPage { get; private set; }

        public static void CreateWiki()
        {
            WikiPage.Configure(entity => entity
                .AddProperty("slug", ModelRef.String, PropertyOptions.IsKey)
                .AddProperty("title", ModelRef.String)
                .AddProperty("content", ModelRef.NullableString)
                .AddProperty("format", Enumerations.WikiPageFormat)
            );
        }
    }

    internal sealed class ClientWiki : IGitLabClientDescriptor
    {
        public void Create(Project project)
        {
            var group = project.AddMethodGroup("Wikis");

            group.AddMethod("GetWikiPages", MethodType.GetCollection, "/projects/:project_id/wikis", "https://docs.gitlab.com/ee/api/wikis.html#list-wiki-pages")
                .WithReturnType(Entities.WikiPage)
                .AddRequiredParameter("project_id", EntityRefs.ProjectIdOrPathRef)
                ;

            group.AddMethod("GetWikiPage", MethodType.Get, "/projects/:project_id/wikis/:slug", "https://docs.gitlab.com/ee/api/wikis.html#get-a-wiki-page")
                .WithReturnType(Entities.WikiPage)
                .AddRequiredParameter("project_id", EntityRefs.ProjectIdOrPathRef)
                .AddRequiredParameter("slug", ModelRef.String)
                ;

            group.AddMethod("CreateWikiPage", MethodType.Post, "/projects/:project_id/wikis", "https://docs.gitlab.com/ee/api/wikis.html#create-a-new-wiki-page")
                .WithReturnType(Entities.WikiPage)
                .AddRequiredParameter("project_id", EntityRefs.ProjectIdOrPathRef)
                .AddRequiredParameter("title", ModelRef.String)
                .AddRequiredParameter("content", ModelRef.String)
                .AddOptionalParameter("format", Enumerations.WikiPageFormat)
                ;

            group.AddMethod("UpdateWikiPage", MethodType.Put, "/projects/:project_id/wikis/:slug", "https://docs.gitlab.com/ee/api/wikis.html#edit-an-existing-wiki-page")
                .WithReturnType(Entities.WikiPage)
                .AddRequiredParameter("project_id", EntityRefs.ProjectIdOrPathRef)
                .AddRequiredParameter("slug", ModelRef.String)
                .AddOptionalParameter("title", ModelRef.String)
                .AddOptionalParameter("content", ModelRef.String)
                .AddOptionalParameter("format", Enumerations.WikiPageFormat)
                ;

            group.AddMethod("DeleteWikiPage", MethodType.Delete, "/projects/:project_id/wikis/:slug", "https://docs.gitlab.com/ee/api/wikis.html#delete-a-wiki-page")
                .AddRequiredParameter("project_id", EntityRefs.ProjectIdOrPathRef)
                .AddRequiredParameter("slug", ModelRef.String)
                ;
        }
    }
}
