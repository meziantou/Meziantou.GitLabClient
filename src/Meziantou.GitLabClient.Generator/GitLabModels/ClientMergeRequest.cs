namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class ClientMergeRequest : IGitLabClientDescriptor
    {
        public void Create(Project project)
        {
            var group = project.AddMethodGroup("MergeRequests");

            group.AddMethod("GetMergeRequests", MethodType.GetPaged, "/merge_requests", "https://docs.gitlab.com/ee/api/merge_requests.html#list-merge-requests")
                .WithReturnType(Entities.MergeRequest)
                .AddOptionalParameter("state", Enumerations.MergeRequestState)
                .AddOptionalParameter("scope", Enumerations.MergeRequestScopeFilter)
                .AddOptionalParameter("assignee_id", EntityRefs.UserRef)
                .AddOptionalParameter("author_id", EntityRefs.UserRef)
                .AddOptionalParameter("milestone", ModelRef.String)
                .AddOptionalParameter("view", Enumerations.MergeRequestView)
                .AddOptionalParameter("labels", ModelRef.StringCollection)
                .AddOptionalParameter("created_after", ModelRef.DateTime)
                .AddOptionalParameter("created_before", ModelRef.DateTime)
                .AddOptionalParameter("updated_after", ModelRef.DateTime)
                .AddOptionalParameter("updated_before", ModelRef.DateTime)
                .AddOptionalParameter("my_reaction_emoji", ModelRef.String)
                .AddOptionalParameter("source_branch", ModelRef.String)
                .AddOptionalParameter("target_branch", ModelRef.String)
                .AddOptionalParameter("search", ModelRef.String)
                ;

            group.AddMethod("GetGroupMergeRequests", MethodType.GetPaged, "/groups/:group_id/merge_requests", "https://docs.gitlab.com/ee/api/merge_requests.html#list-group-merge-requests")
                .WithReturnType(Entities.MergeRequest)
                .AddRequiredParameter("group_id", EntityRefs.GroupIdOrPathRef)
                .AddOptionalParameter("state", Enumerations.MergeRequestState)
                .AddOptionalParameter("scope", Enumerations.MergeRequestScopeFilter)
                .AddOptionalParameter("assignee_id", EntityRefs.UserRef)
                .AddOptionalParameter("author_id", EntityRefs.UserRef)
                .AddOptionalParameter("milestone", ModelRef.String)
                .AddOptionalParameter("view", Enumerations.MergeRequestView)
                .AddOptionalParameter("labels", ModelRef.StringCollection)
                .AddOptionalParameter("created_after", ModelRef.DateTime)
                .AddOptionalParameter("created_before", ModelRef.DateTime)
                .AddOptionalParameter("updated_after", ModelRef.DateTime)
                .AddOptionalParameter("updated_before", ModelRef.DateTime)
                .AddOptionalParameter("my_reaction_emoji", ModelRef.String)
                .AddOptionalParameter("source_branch", ModelRef.String)
                .AddOptionalParameter("target_branch", ModelRef.String)
                .AddOptionalParameter("search", ModelRef.String)
                ;

            group.AddMethod("GetProjectMergeRequests", MethodType.GetPaged, "/projects/:project_id/merge_requests", "https://docs.gitlab.com/ee/api/merge_requests.html#list-project-merge-requests")
                .WithReturnType(Entities.MergeRequest)
                .AddRequiredParameter("project_id", EntityRefs.ProjectIdOrPathRef)
                .AddOptionalParameter("iids", ModelRef.NumberId.MakeCollection())
                .AddOptionalParameter("state", Enumerations.MergeRequestState)
                .AddOptionalParameter("scope", Enumerations.MergeRequestScopeFilter)
                .AddOptionalParameter("assignee_id", EntityRefs.UserRef)
                .AddOptionalParameter("author_id", EntityRefs.UserRef)
                .AddOptionalParameter("milestone", ModelRef.String)
                .AddOptionalParameter("view", Enumerations.MergeRequestView)
                .AddOptionalParameter("labels", ModelRef.StringCollection)
                .AddOptionalParameter("created_after", ModelRef.DateTime)
                .AddOptionalParameter("created_before", ModelRef.DateTime)
                .AddOptionalParameter("updated_after", ModelRef.DateTime)
                .AddOptionalParameter("updated_before", ModelRef.DateTime)
                .AddOptionalParameter("my_reaction_emoji", ModelRef.String)
                .AddOptionalParameter("source_branch", ModelRef.String)
                .AddOptionalParameter("target_branch", ModelRef.String)
                .AddOptionalParameter("search", ModelRef.String)
                ;

            group.AddMethod("GetMergeRequest", MethodType.Get, "/projects/:project_id/merge_requests/:merge_request_iid", "https://docs.gitlab.com/ee/api/merge_requests.html#get-single-mr")
                .WithReturnType(Entities.MergeRequest)
                .AddRequiredParameter("project_id", EntityRefs.ProjectIdOrPathRef)
                .AddRequiredParameter("merge_request_iid", EntityRefs.MergeRequestIdRef)
                ;

            group.AddMethod("CreateMergeRequest", MethodType.Post, "/projects/:project_id/merge_requests", "https://docs.gitlab.com/ee/api/merge_requests.html#create-mr")
                .WithReturnType(Entities.MergeRequest)
                .AddRequiredParameter("project_id", EntityRefs.ProjectIdOrPathRef)
                .AddRequiredParameter("source_branch", ModelRef.String)
                .AddRequiredParameter("target_branch", ModelRef.String)
                .AddRequiredParameter("title", ModelRef.String)
                .AddOptionalParameter("description", ModelRef.String)
                .AddOptionalParameter("assignee_id", EntityRefs.UserRef)
                .AddOptionalParameter("target_project_id", EntityRefs.ProjectIdRef)
                .AddOptionalParameter("remove_source_branch", ModelRef.Boolean)
                .AddOptionalParameter("allow_collaboration", ModelRef.Boolean)
                .AddOptionalParameter("allow_maintainer_to_push", ModelRef.Boolean)
                .AddOptionalParameter("squash", ModelRef.Boolean)
                ;
        }
    }
}
