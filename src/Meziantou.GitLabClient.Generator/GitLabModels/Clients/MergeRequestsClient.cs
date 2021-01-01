namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class MergeRequestsClient : GitLabClientBuilder
    {
        protected override void Create(MethodGroup methodGroup)
        {
            methodGroup.AddMethod("GetMergeRequests", MethodType.GetPaged, "/merge_requests", "https://docs.gitlab.com/ee/api/merge_requests.html#list-merge-requests")
                .WithReturnType(Models.MergeRequest)
                .AddOptionalParameter("state", Models.MergeRequestState)
                .AddOptionalParameter("scope", Models.MergeRequestScopeFilter)
                .AddOptionalParameter("assignee_id", Models.UserIdOrUserNameRef)
                .AddOptionalParameter("author_id", Models.UserIdOrUserNameRef)
                .AddOptionalParameter("milestone", ModelRef.String)
                .AddOptionalParameter("view", Models.MergeRequestView)
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

            methodGroup.AddMethod("GetGroupMergeRequests", MethodType.GetPaged, "/groups/:id/merge_requests", "https://docs.gitlab.com/ee/api/merge_requests.html#list-group-merge-requests")
                .WithReturnType(Models.MergeRequest)
                .AddRequiredParameter("id", Models.GroupIdOrPathRef)
                .AddOptionalParameter("state", Models.MergeRequestState)
                .AddOptionalParameter("scope", Models.MergeRequestScopeFilter)
                .AddOptionalParameter("assignee_id", Models.UserIdOrUserNameRef)
                .AddOptionalParameter("author_id", Models.UserIdOrUserNameRef)
                .AddOptionalParameter("milestone", ModelRef.String)
                .AddOptionalParameter("view", Models.MergeRequestView)
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

            methodGroup.AddMethod("GetProjectMergeRequests", MethodType.GetPaged, "/projects/:id/merge_requests", "https://docs.gitlab.com/ee/api/merge_requests.html#list-project-merge-requests")
                .WithReturnType(Models.MergeRequest)
                .AddRequiredParameter("id", Models.ProjectIdOrPathRef)
                .AddOptionalParameter("iids", ModelRef.NumberId.MakeCollection())
                .AddOptionalParameter("state", Models.MergeRequestState)
                .AddOptionalParameter("scope", Models.MergeRequestScopeFilter)
                .AddOptionalParameter("assignee_id", Models.UserIdOrUserNameRef)
                .AddOptionalParameter("author_id", Models.UserIdOrUserNameRef)
                .AddOptionalParameter("milestone", ModelRef.String)
                .AddOptionalParameter("view", Models.MergeRequestView)
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

            methodGroup.AddMethod("GetMergeRequest", MethodType.Get, "/projects/:id/merge_requests/:merge_request_iid", "https://docs.gitlab.com/ee/api/merge_requests.html#get-single-mr")
                .WithReturnType(Models.MergeRequest)
                .AddRequiredParameter("id", Models.ProjectIdOrPathRef)
                .AddRequiredParameter("merge_request_iid", Models.MergeRequestIidRef)
                ;

            methodGroup.AddMethod("CreateMergeRequest", MethodType.Post, "/projects/:id/merge_requests", "https://docs.gitlab.com/ee/api/merge_requests.html#create-mr")
                .WithReturnType(Models.MergeRequest)
                .AddRequiredParameter("id", Models.ProjectIdOrPathRef)
                .AddRequiredParameter("source_branch", ModelRef.String)
                .AddRequiredParameter("target_branch", ModelRef.String)
                .AddRequiredParameter("title", ModelRef.String)
                .AddOptionalParameter("description", ModelRef.String)
                .AddOptionalParameter("assignee_id", Models.UserIdOrUserNameRef)
                .AddOptionalParameter("target_project_id", Models.ProjectIdRef)
                .AddOptionalParameter("remove_source_branch", ModelRef.Boolean)
                .AddOptionalParameter("allow_collaboration", ModelRef.Boolean)
                .AddOptionalParameter("allow_maintainer_to_push", ModelRef.Boolean)
                .AddOptionalParameter("squash", ModelRef.Boolean)
                ;
        }
    }
}
