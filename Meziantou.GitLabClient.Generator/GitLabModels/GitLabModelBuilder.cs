using System;
using System.Linq;
using Meziantou.Framework;

namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal static partial class GitLabModelBuilder
    {
        public static Project Create()
        {
            var project = new Project();
            Enumerations.Create(project);
            Entities.Create(project);
            EntityRefs.Create(project);

            typeof(GitLabModelBuilder).Assembly.GetTypes()
                .Where(t => typeof(IGitLabClientDescriptor).IsAssignableFrom(t) && t.IsClass)
                .ForEach(t =>
                {
                    var instance = (IGitLabClientDescriptor)Activator.CreateInstance(t);
                    instance.Create(project);
                });

            return project;
        }

        //Project.AddMethodGroup("MergeRequest",
        //    new[]
        //    {
        //        new Method("GetMergeRequests", "merge_requests")
        //        {
        //            Documentation = new Documentation
        //            {
        //                Summary = "Get all merge requests the authenticated user has access to. By default it returns only merge requests created by the current user. To get all merge requests, use parameter scope=all.",
        //                HelpLink = "https://docs.gitlab.com/ee/api/merge_requests.html#list-merge-requests",
        //            },
        //            ReturnType = Entities.MergeRequest,
        //            MethodType = MethodType.GetPaged,
        //            Parameters =
        //            {
        //                new MethodParameter("state", Enumerations.MergeRequestState.MakeNullable()) { IsOptional = true },
        //                new MethodParameter("scope", Enumerations.MergeRequestScopeFilter.MakeNullable()) { IsOptional = true },
        //                new MethodParameter("assignee_id", EntityRefs.UserRef.MakeNullable()) { IsOptional = true },
        //                new MethodParameter("author_id", EntityRefs.UserRef.MakeNullable()) { IsOptional = true },
        //                new MethodParameter("milestone", ModelRef.String) { IsOptional = true },
        //                new MethodParameter("view", Enumerations.MergeRequestView.MakeNullable()) { IsOptional = true },
        //                new MethodParameter("labels", ModelRef.StringCollection) { IsOptional = true },
        //                new MethodParameter("created_after", ModelRef.NullableDateTime) { IsOptional = true },
        //                new MethodParameter("created_before", ModelRef.NullableDateTime) { IsOptional = true },
        //                new MethodParameter("updated_after", ModelRef.NullableDateTime) { IsOptional = true },
        //                new MethodParameter("updated_before", ModelRef.NullableDateTime) { IsOptional = true },
        //                new MethodParameter("my_reaction_emoji", ModelRef.String) { IsOptional = true },
        //                new MethodParameter("source_branch", ModelRef.String) { IsOptional = true },
        //                new MethodParameter("target_branch", ModelRef.String) { IsOptional = true },
        //                new MethodParameter("search", ModelRef.String) { IsOptional = true },
        //            },
        //        },
        //        new Method("GetMergeRequests", "groups/:group/merge_requests")
        //        {
        //            Documentation = new Documentation
        //            {
        //                Summary = "Get all merge requests for this group and its subgroups.",
        //                HelpLink = "https://docs.gitlab.com/ee/api/merge_requests.html#list-group-merge-requests",
        //            },
        //            ReturnType = Entities.MergeRequest,
        //            MethodType = MethodType.GetPaged,
        //            Parameters =
        //            {
        //                new MethodParameter("group", ModelRef.NumberId),
        //                new MethodParameter("state", Enumerations.MergeRequestState.MakeNullable()) { IsOptional = true },
        //                new MethodParameter("scope", Enumerations.MergeRequestScopeFilter.MakeNullable()) { IsOptional = true },
        //                new MethodParameter("assignee_id", EntityRefs.UserRef.MakeNullable()) { IsOptional = true },
        //                new MethodParameter("author_id", EntityRefs.UserRef.MakeNullable()) { IsOptional = true },
        //                new MethodParameter("milestone", ModelRef.String) { IsOptional = true },
        //                new MethodParameter("view", Enumerations.MergeRequestView.MakeNullable()) { IsOptional = true },
        //                new MethodParameter("labels", ModelRef.StringCollection) { IsOptional = true },
        //                new MethodParameter("created_after", ModelRef.NullableDateTime) { IsOptional = true },
        //                new MethodParameter("created_before", ModelRef.NullableDateTime) { IsOptional = true },
        //                new MethodParameter("updated_after", ModelRef.NullableDateTime) { IsOptional = true },
        //                new MethodParameter("updated_before", ModelRef.NullableDateTime) { IsOptional = true },
        //                new MethodParameter("my_reaction_emoji", ModelRef.String) { IsOptional = true },
        //                new MethodParameter("source_branch", ModelRef.String) { IsOptional = true },
        //                new MethodParameter("target_branch", ModelRef.String) { IsOptional = true },
        //                new MethodParameter("search", ModelRef.String) { IsOptional = true },
        //            },
        //        },
        //        new Method("GetMergeRequests", "projects/:project/merge_requests")
        //        {
        //            Documentation = new Documentation
        //            {
        //                Summary = "Get all merge requests for this project.",
        //                HelpLink = "https://docs.gitlab.com/ee/api/merge_requests.html#list-project-merge-requests",
        //            },
        //            ReturnType = Entities.MergeRequest,
        //            MethodType = MethodType.GetPaged,
        //            Parameters =
        //            {
        //                new MethodParameter("project", EntityRefs.ProjectIdOrPathRef),
        //                new MethodParameter("iids", ModelRef.GitObjectId.MakeCollection()) { IsOptional = true },
        //                new MethodParameter("state", Enumerations.MergeRequestState.MakeNullable()) { IsOptional = true },
        //                new MethodParameter("scope", Enumerations.MergeRequestScopeFilter.MakeNullable()) { IsOptional = true },
        //                new MethodParameter("assignee_id", EntityRefs.UserRef.MakeNullable()) { IsOptional = true },
        //                new MethodParameter("author_id", EntityRefs.UserRef.MakeNullable()) { IsOptional = true },
        //                new MethodParameter("milestone", ModelRef.String) { IsOptional = true },
        //                new MethodParameter("view", Enumerations.MergeRequestView.MakeNullable()) { IsOptional = true },
        //                new MethodParameter("labels", ModelRef.StringCollection) { IsOptional = true },
        //                new MethodParameter("created_after", ModelRef.NullableDateTime) { IsOptional = true },
        //                new MethodParameter("created_before", ModelRef.NullableDateTime) { IsOptional = true },
        //                new MethodParameter("updated_after", ModelRef.NullableDateTime) { IsOptional = true },
        //                new MethodParameter("updated_before", ModelRef.NullableDateTime) { IsOptional = true },
        //                new MethodParameter("my_reaction_emoji", ModelRef.String) { IsOptional = true },
        //                new MethodParameter("source_branch", ModelRef.String) { IsOptional = true },
        //                new MethodParameter("target_branch", ModelRef.String) { IsOptional = true },
        //                new MethodParameter("search", ModelRef.String) { IsOptional = true },
        //            },
        //        },
        //        new Method("GetMergeRequest", "projects/:project/merge_requests/:merge_request")
        //        {
        //            Documentation = new Documentation
        //            {
        //                Summary = "Shows information about a single merge request.",
        //                HelpLink = "https://docs.gitlab.com/ee/api/merge_requests.html#get-single-mr",
        //            },
        //            ReturnType = Entities.MergeRequest,
        //            MethodType = MethodType.Get,
        //            Parameters =
        //            {
        //                new MethodParameter("project", EntityRefs.ProjectIdOrPathRef),
        //                new MethodParameter("merge_request", EntityRefs.MergeRequestIdRef),
        //            },
        //        },
        //        new Method("CreateMergeRequest", "projects/:project/merge_requests")
        //        {
        //            Documentation = new Documentation
        //            {
        //                Summary = "Creates a new merge request.",
        //                HelpLink = "https://docs.gitlab.com/ee/api/merge_requests.html#create-mr",
        //            },
        //            ReturnType = Entities.MergeRequest,
        //            MethodType = MethodType.Post,
        //            Parameters =
        //            {
        //                new MethodParameter("project", EntityRefs.ProjectIdOrPathRef),
        //                new MethodParameter("source_branch", ModelRef.String),
        //                new MethodParameter("target_branch", ModelRef.String),
        //                new MethodParameter("title", ModelRef.String),
        //                new MethodParameter("description", ModelRef.String) { IsOptional = true },
        //                new MethodParameter("assignee_id", EntityRefs.UserRef.MakeNullable()) { IsOptional = true },
        //                new MethodParameter("target_project_id", EntityRefs.ProjectIdRef.MakeNullable()) { IsOptional = true },
        //                new MethodParameter("remove_source_branch", ModelRef.NullableBoolean) { IsOptional = true },
        //                new MethodParameter("allow_collaboration", ModelRef.NullableBoolean) { IsOptional = true },
        //                new MethodParameter("allow_maintainer_to_push", ModelRef.NullableBoolean) { IsOptional = true },
        //                new MethodParameter("squash", ModelRef.NullableBoolean) { IsOptional = true },
        //            },
        //        },
        //    });

        //Project.AddMethodGroup("Repository",
        //    new[]
        //    {
        //        new Method("CreateFile", "projects/:project/repository/files/:file_path")
        //        {
        //            Documentation = new Documentation
        //            {
        //                HelpLink = "https://docs.gitlab.com/ee/api/repository_files.html#create-new-file-in-repository",
        //            },
        //            ReturnType = Entities.FileCreated,
        //            MethodType = MethodType.Post,
        //            Parameters =
        //            {
        //                new MethodParameter("project", EntityRefs.ProjectIdOrPathRef),
        //                new MethodParameter("file_path", ModelRef.String),
        //                new MethodParameter("branch", ModelRef.String),
        //                new MethodParameter("start_branch", ModelRef.String) { IsOptional = true },
        //                new MethodParameter("encoding", ModelRef.String) { IsOptional = true },
        //                new MethodParameter("author_email", ModelRef.String) { IsOptional = true },
        //                new MethodParameter("author_name", ModelRef.String) { IsOptional = true },
        //                new MethodParameter("content", ModelRef.String),
        //                new MethodParameter("commit_message", ModelRef.String),
        //            },
        //        },
        //        new Method("UpdateFile", "projects/:project/repository/files/:file_path")
        //        {
        //            Documentation = new Documentation
        //            {
        //                HelpLink = "https://docs.gitlab.com/ee/api/repository_files.html#update-existing-file-in-repository",
        //            },
        //            ReturnType = Entities.FileUpdated,
        //            MethodType = MethodType.Put,
        //            Parameters =
        //            {
        //                new MethodParameter("project", EntityRefs.ProjectIdOrPathRef),
        //                new MethodParameter("file_path", ModelRef.String),
        //                new MethodParameter("branch", ModelRef.String),
        //                new MethodParameter("start_branch", ModelRef.String) { IsOptional = true },
        //                new MethodParameter("encoding", ModelRef.String) { IsOptional = true },
        //                new MethodParameter("author_email", ModelRef.String) { IsOptional = true },
        //                new MethodParameter("author_name", ModelRef.String) { IsOptional = true },
        //                new MethodParameter("last_commit_id", ModelRef.NullableGitObjectId) { IsOptional = true },
        //                new MethodParameter("content", ModelRef.String),
        //                new MethodParameter("commit_message", ModelRef.String),
        //            },
        //        },
        //    });

        //Project.AddMethodGroup("Todo",
        //    new[]
        //    {
        //        new Method("GetTodos", "todos")
        //        {
        //            Documentation = new Documentation
        //            {
        //                Summary = "Returns a list of todos. When no filter is applied, it returns all pending todos for the current user. Different filters allow the user to precise the request.",
        //                HelpLink = "https://docs.gitlab.com/ee/api/todos.html#get-a-list-of-todos",
        //            },
        //            ReturnType = Entities.Todo,
        //            MethodType = MethodType.GetPaged,
        //            Parameters =
        //            {
        //                new MethodParameter("action", Enumerations.TodoAction.MakeNullable()) { IsOptional = true },
        //            },
        //        },
        //        new Method("MarkTodoAsDone", "todos/:todo/mark_as_done")
        //        {
        //            Documentation = new Documentation
        //            {
        //                Summary = "Marks a single pending todo given by its ID for the current user as done.",
        //                HelpLink = "https://docs.gitlab.com/ee/api/todos.html#mark-a-todo-as-done",
        //            },
        //            ReturnType = Entities.Todo,
        //            MethodType = MethodType.Post,
        //            Parameters =
        //            {
        //                new MethodParameter("todo", EntityRefs.TodoIdRef),
        //            },
        //        },
        //        new Method("MarkAllTodosAsDone", "todos/mark_as_done")
        //        {
        //            Documentation = new Documentation
        //            {
        //                Summary = "Marks all pending todos for the current user as done.",
        //                HelpLink = "https://docs.gitlab.com/ee/api/todos.html#mark-a-todo-as-done",
        //            },
        //            MethodType = MethodType.Post,
        //        },
        //    });


        //Project.AddMethodGroup("Wiki",
        //    new[]
        //    {
        //        new Method("GetWikiPages", "projects/:project/wikis")
        //        {
        //            Documentation = new Documentation
        //            {
        //                HelpLink = "https://docs.gitlab.com/ee/api/wikis.html#list-wiki-pages",
        //            },
        //            ReturnType = Entities.WikiPage.MakeCollection(),
        //            MethodType = MethodType.Get,
        //            Parameters =
        //            {
        //                new MethodParameter("project", EntityRefs.ProjectIdOrPathRef),
        //            },
        //        },
        //        new Method("GetWikiPage", "projects/:project/wikis/:slug")
        //        {
        //            Documentation = new Documentation
        //            {
        //                HelpLink = "https://docs.gitlab.com/ee/api/wikis.html#list-wiki-pages",
        //            },
        //            ReturnType = Entities.WikiPage,
        //            MethodType = MethodType.Get,
        //            Parameters =
        //            {
        //                new MethodParameter("project", EntityRefs.ProjectIdOrPathRef),
        //                new MethodParameter("slug", ModelRef.String),
        //            },
        //        },
        //        new Method("CreateWikiPage", "projects/:project/wikis")
        //        {
        //            Documentation = new Documentation
        //            {
        //                HelpLink = "https://docs.gitlab.com/ee/api/wikis.html#list-wiki-pages",
        //            },
        //            ReturnType = Entities.WikiPage,
        //            MethodType = MethodType.Post,
        //            Parameters =
        //            {
        //                new MethodParameter("project", EntityRefs.ProjectIdOrPathRef),
        //                new MethodParameter("content", ModelRef.String),
        //                new MethodParameter("title", ModelRef.String),
        //                new MethodParameter("format", Enumerations.WikiPageFormat.MakeNullable()) { IsOptional = true },
        //            },
        //        },
        //        new Method("UpdateWikiPage", "projects/:project/wikis/:slug")
        //        {
        //            Documentation = new Documentation
        //            {
        //                HelpLink = "https://docs.gitlab.com/ee/api/wikis.html#list-wiki-pages",
        //            },
        //            ReturnType = Entities.WikiPage,
        //            MethodType = MethodType.Put,
        //            Parameters =
        //            {
        //                new MethodParameter("project", EntityRefs.ProjectIdOrPathRef),
        //                new MethodParameter("slug", ModelRef.String),
        //                new MethodParameter("content", ModelRef.String) { IsOptional = true },
        //                new MethodParameter("title", ModelRef.String) { IsOptional = true },
        //                new MethodParameter("format", Enumerations.WikiPageFormat.MakeNullable()) { IsOptional = true },
        //            },
        //        },
        //        new Method("DeleteWikiPage", "projects/:project/wikis/:slug")
        //        {
        //            Documentation = new Documentation
        //            {
        //                HelpLink = "https://docs.gitlab.com/ee/api/wikis.html#list-wiki-pages",
        //            },
        //            ReturnType = null,
        //            MethodType = MethodType.Delete,
        //            Parameters =
        //            {
        //                new MethodParameter("project", EntityRefs.ProjectIdOrPathRef),
        //                new MethodParameter("slug", ModelRef.String),
        //            },
        //        },
        //    });
    }
}
