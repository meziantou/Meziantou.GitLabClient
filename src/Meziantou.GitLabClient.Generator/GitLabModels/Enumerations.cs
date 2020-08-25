namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal static class Enumerations
    {
        public static ModelRef OrderByDirection { get; private set; }
        public static ModelRef AccessLevel { get; private set; }
        public static ModelRef ImportStatus { get; private set; }
        public static ModelRef MergeMethod { get; private set; }
        public static ModelRef MergeRequestScopeFilter { get; private set; }
        public static ModelRef MergeRequestStateFilter { get; private set; }
        public static ModelRef MergeRequestState { get; private set; }
        public static ModelRef MergeRequestStatus { get; private set; }
        public static ModelRef MergeRequestView { get; private set; }
        public static ModelRef ProjectVisibility { get; private set; }
        public static ModelRef UserState { get; private set; }
        public static ModelRef TodoAction { get; private set; }
        public static ModelRef TodoState { get; private set; }
        public static ModelRef TodoType { get; private set; }
        public static ModelRef WikiPageFormat { get; private set; }

        public static void Create(Project project)
        {
            OrderByDirection = project.AddEnumeration("OrderByDirection")
                .AddMember("ascending", serializationName: "asc")
                .AddMember("descending", serializationName: "desc");

            AccessLevel = project.AddEnumeration("AccessLevel")
                .AddMember("guest", 10)
                .AddMember("reporter", 20)
                .AddMember("developer", 30)
                .AddMember("maintainer", 40)
                .AddMember("owner", 50);

            ImportStatus = project.AddStringEnumeration("ImportStatus")
                .AddMembers("none", "scheduled", "failed", "started", "finished");

            MergeMethod = project.AddStringEnumeration("MergeMethod")
                .AddMembers("merge", "rebase_merge")
                .AddMember("fast_forward", serializationName: "ff");

            MergeRequestScopeFilter = project.AddStringEnumeration("MergeRequestScopeFilter")
                .AddMembers("assigned_to_me", "all");

            MergeRequestState = project.AddStringEnumeration("MergeRequestState")
                .AddMembers("opened", "closed", "locked", "merged");

            MergeRequestStatus = project.AddStringEnumeration("MergeRequestStatus")
                .AddMembers("checking", "can_be_merged", "cannot_be_merged");

            ProjectVisibility = project.AddStringEnumeration("ProjectVisibility")
                .AddMembers("private", "internal", "public");

            UserState = project.AddStringEnumeration("UserState")
                .AddMembers("active", "blocked");

            TodoAction = project.AddStringEnumeration("TodoAction")
                .AddMembers("assigned", "mentioned", "build_failed", "marked", "approval_required", "unmergeable", "directly_addressed");

            TodoState = project.AddStringEnumeration("TodoState")
                .AddMembers("pending", "done");

            TodoType = project.AddStringEnumeration("TodoTargetType")
                .AddMembers("Issue", "MergeRequest", "Commit");

            MergeRequestView = project.AddStringEnumeration("MergeRequestView")
                .AddMembers("default", "simple");

            WikiPageFormat = project.AddStringEnumeration("WikiPageFormat")
                .AddMembers("markdown", "rdoc", "asciidoc");
        }
    }
}
