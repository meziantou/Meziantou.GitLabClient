namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal static class EntityRefs
    {
        public static ParameterEntity GroupIdOrPathRef { get; private set; }
        public static ParameterEntity MergeRequestIdRef { get; private set; }
        public static ParameterEntity ProjectIdRef { get; private set; }
        public static ParameterEntity ProjectIdOrPathRef { get; private set; }
        public static ParameterEntity SshKeyRef { get; private set; }
        public static ParameterEntity TodoIdRef { get; private set; }
        public static ParameterEntity UserRef { get; private set; }

        public static void Create(Project project)
        {
            ProjectIdRef = project.AddParameterEntity("ProjectIdRef",
                ParameterEntityRef.Create("projectId", ModelRef.NumberId),
                ParameterEntityRef.Create("project", Models.ProjectIdentity)
            );

            ProjectIdOrPathRef = project.AddParameterEntity("ProjectIdOrPathRef",
                ParameterEntityRef.Create("projectId", ModelRef.NumberId),
                ParameterEntityRef.Create("project", Models.ProjectIdentity),
                ParameterEntityRef.Create("projectPathWithNamespace", ModelRef.PathWithNamespace)
            );

            GroupIdOrPathRef = project.AddParameterEntity("GroupIdOrPathRef",
                ParameterEntityRef.Create("groupId", ModelRef.NumberId),
                ParameterEntityRef.Create("projectPathWithNamespace", ModelRef.PathWithNamespace)
            );

            SshKeyRef = project.AddParameterEntity("SshKeyRef",
                ParameterEntityRef.Create("sshKeyId", ModelRef.NumberId),
                ParameterEntityRef.Create("sskKey", Models.SshKey)
            );

            UserRef = project.AddParameterEntity("UserRef",
                ParameterEntityRef.Create("userId", ModelRef.NumberId),
                ParameterEntityRef.Create("userName", ModelRef.String),
                ParameterEntityRef.Create("user", Models.UserSafe)
            );

            MergeRequestIdRef = project.AddParameterEntity("MergeRequestIidRef",
                ParameterEntityRef.Create("mergeRequestIid", ModelRef.NumberId),
                ParameterEntityRef.Create("mergeRequest", Models.MergeRequest, "iid")
            );

            TodoIdRef = project.AddParameterEntity("TodoRef",
                ParameterEntityRef.Create("todoId", ModelRef.NumberId),
                ParameterEntityRef.Create("todo", Models.Todo)
            );
        }
    }
}
