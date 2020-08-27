namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal static partial class Enumerations
    {
        public static ModelRef MergeRequestScopeFilter { get; private set; }
        public static ModelRef MergeRequestState { get; private set; }
        public static ModelRef MergeRequestStatus { get; private set; }
        public static ModelRef MergeRequestView { get; private set; }

        public static void CreateMergeRequest(Project project)
        {

            MergeRequestScopeFilter = project.AddStringEnumeration("MergeRequestScopeFilter")
                .AddMembers("assigned_to_me", "all");

            MergeRequestState = project.AddStringEnumeration("MergeRequestState")
                .AddMembers("opened", "closed", "locked", "merged");

            MergeRequestStatus = project.AddStringEnumeration("MergeRequestStatus")
                .AddMembers("checking", "can_be_merged", "cannot_be_merged");

            MergeRequestView = project.AddStringEnumeration("MergeRequestView")
                .AddMembers("default", "simple");
        }
    }

    internal static partial class Entities
    {
        public static EntityBuilder MergeRequest { get; private set; }

        public static void CreateMergeRequest()
        {
            MergeRequest.Configure(entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("iid", ModelRef.NumberId)
                .AddProperty("author", Entities.UserBasic)
                .AddProperty("assignee", Entities.UserBasic.MakeNullable())
                .AddProperty("title", ModelRef.String, PropertyOptions.IsDisplayName)
                .AddProperty("description", ModelRef.NullableString)
                .AddProperty("state", Enumerations.MergeRequestState)
                .AddProperty("project_id", ModelRef.NumberId)
                .AddProperty("source_project_id", ModelRef.NumberId)
                .AddProperty("target_project_id", ModelRef.NumberId)
                .AddProperty("web_url", ModelRef.Uri)
                .AddProperty("created_at", ModelRef.DateTime)
                .AddProperty("updated_at", ModelRef.DateTime)
                .AddProperty("user_notes_count", ModelRef.Number)
                .AddProperty("target_branch", ModelRef.String)
                .AddProperty("source_branch", ModelRef.String)
                .AddProperty("upvotes", ModelRef.Number)
                .AddProperty("downvotes", ModelRef.Number)
                .AddProperty("labels", ModelRef.StringCollection)
                .AddProperty("work_in_progress", ModelRef.Boolean)
                .AddProperty("merge_when_pipeline_succeeds", ModelRef.Boolean)
                .AddProperty("merge_status", Enumerations.MergeRequestStatus)
                .AddProperty("sha", ModelRef.GitObjectId)
                .AddProperty("merge_commit_sha", ModelRef.NullableGitObjectId)
                .AddProperty("should_remove_source_branch", ModelRef.NullableBoolean)
                .AddProperty("force_remove_source_branch", ModelRef.NullableBoolean)
                .AddProperty("squash", ModelRef.Boolean)
            );
        }
    }

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
