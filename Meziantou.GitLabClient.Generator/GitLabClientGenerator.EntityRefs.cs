namespace Meziantou.GitLabClient.Generator
{
    internal sealed partial class GitLabClientGenerator
    {
        private static class EntityRefs
        {
            public static ParameterEntity ProjectIdRef { get; private set; }
            public static ParameterEntity ProjectIdOrPathRef { get; private set; }
            public static ParameterEntity SshKeyRef { get; private set; }
            public static ParameterEntity UserRef { get; private set; }
            public static ParameterEntity MergeRequestIdRef { get; private set; }
            public static ParameterEntity TodoIdRef { get; private set; }

            public static void Create(Project project)
            {
                ProjectIdRef = project.AddParameterEntity("ProjectIdRef",
                    ParameterEntityRef.Create("projectId", ModelRef.NumberId),
                    ParameterEntityRef.Create("project", Entities.ProjectIdentity)
                );

                ProjectIdOrPathRef = project.AddParameterEntity("ProjectIdOrPathRef",
                    ParameterEntityRef.Create("projectId", ModelRef.NumberId),
                    ParameterEntityRef.Create("project", Entities.ProjectIdentity),
                    ParameterEntityRef.Create("projectPathWithNamespace", ModelRef.PathWithNamespace)
                );

                SshKeyRef = project.AddParameterEntity("SshKeyRef",
                    ParameterEntityRef.Create("sshKeyId", ModelRef.NumberId),
                    ParameterEntityRef.Create("sskKey", Entities.SshKey)
                );

                UserRef = project.AddParameterEntity("UserRef",
                    ParameterEntityRef.Create("userId", ModelRef.NumberId),
                    ParameterEntityRef.Create("userName", ModelRef.String),
                    ParameterEntityRef.Create("user", Entities.UserSafe)
                );

                MergeRequestIdRef = project.AddParameterEntity("MergeRequestIidRef",
                    ParameterEntityRef.Create("mergeRequestIid", ModelRef.NumberId),
                    ParameterEntityRef.Create("mergeRequest", Entities.MergeRequest, "iid")
                );

                TodoIdRef = project.AddParameterEntity("TodoRef",
                    ParameterEntityRef.Create("TodoId", ModelRef.NumberId),
                    ParameterEntityRef.Create("todo", Entities.Todo)
                );
            }
        }
    }
}
