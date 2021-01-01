namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class ProjectWikisClient : GitLabClientBuilder
    {
        protected override void Create(MethodGroup methodGroup)
        {
            methodGroup.AddMethod("GetWikiPages", MethodType.GetCollection, "/projects/:id/wikis", "https://docs.gitlab.com/ee/api/wikis.html#list-wiki-pages")
                .WithReturnType(Models.WikiPage)
                .AddRequiredParameter("id", Models.ProjectIdOrPathRef)
                ;

            methodGroup.AddMethod("GetWikiPage", MethodType.Get, "/projects/:id/wikis/:slug", "https://docs.gitlab.com/ee/api/wikis.html#get-a-wiki-page")
                .WithReturnType(Models.WikiPage)
                .AddRequiredParameter("id", Models.ProjectIdOrPathRef)
                .AddRequiredParameter("slug", ModelRef.String)
                ;

            methodGroup.AddMethod("CreateWikiPage", MethodType.Post, "/projects/:id/wikis", "https://docs.gitlab.com/ee/api/wikis.html#create-a-new-wiki-page")
                .WithReturnType(Models.WikiPage)
                .AddRequiredParameter("id", Models.ProjectIdOrPathRef)
                .AddRequiredParameter("title", ModelRef.String)
                .AddRequiredParameter("content", ModelRef.String)
                .AddOptionalParameter("format", Models.WikiPageFormat)
                ;

            methodGroup.AddMethod("UpdateWikiPage", MethodType.Put, "/projects/:id/wikis/:slug", "https://docs.gitlab.com/ee/api/wikis.html#edit-an-existing-wiki-page")
                .WithReturnType(Models.WikiPage)
                .AddRequiredParameter("id", Models.ProjectIdOrPathRef)
                .AddRequiredParameter("slug", ModelRef.String)
                .AddOptionalParameter("title", ModelRef.String)
                .AddOptionalParameter("content", ModelRef.String)
                .AddOptionalParameter("format", Models.WikiPageFormat)
                ;

            methodGroup.AddMethod("DeleteWikiPage", MethodType.Delete, "/projects/:id/wikis/:slug", "https://docs.gitlab.com/ee/api/wikis.html#delete-a-wiki-page")
                .AddRequiredParameter("id", Models.ProjectIdOrPathRef)
                .AddRequiredParameter("slug", ModelRef.String)
                ;
        }
    }
}
