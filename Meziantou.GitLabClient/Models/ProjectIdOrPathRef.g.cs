// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated
// </auto-generated>
// ------------------------------------------------------------------------------
#nullable enable
namespace Meziantou.GitLab
{
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Serialization.GitLabObjectObjectReferenceJsonConverter))]
    public readonly partial struct ProjectIdOrPathRef : Meziantou.GitLab.IGitLabObjectReference<object>
    {
        private readonly object _value;

        private ProjectIdOrPathRef(long projectId)
        {
            this._value = projectId;
        }

        private ProjectIdOrPathRef(ProjectIdentity project)
        {
            if ((project == null))
            {
                throw new System.ArgumentNullException(nameof(project));
            }

            this._value = project.Id;
        }

        private ProjectIdOrPathRef(Meziantou.GitLab.PathWithNamespace projectPathWithNamespace)
        {
            this._value = projectPathWithNamespace;
        }

        public object Value
        {
            get
            {
                return this._value;
            }
        }

        public static Meziantou.GitLab.ProjectIdOrPathRef FromProject(ProjectIdentity project)
        {
            if ((project == null))
            {
                throw new System.ArgumentNullException(nameof(project));
            }

            return new Meziantou.GitLab.ProjectIdOrPathRef(project);
        }

        public static Meziantou.GitLab.ProjectIdOrPathRef FromProjectId(long projectId)
        {
            return new Meziantou.GitLab.ProjectIdOrPathRef(projectId);
        }

        public static Meziantou.GitLab.ProjectIdOrPathRef FromProjectPathWithNamespace(Meziantou.GitLab.PathWithNamespace projectPathWithNamespace)
        {
            return new Meziantou.GitLab.ProjectIdOrPathRef(projectPathWithNamespace);
        }

        public override string? ToString()
        {
            return this.Value.ToString();
        }

        public static implicit operator Meziantou.GitLab.ProjectIdOrPathRef(long projectId)
        {
            return Meziantou.GitLab.ProjectIdOrPathRef.FromProjectId(projectId);
        }

        public static implicit operator Meziantou.GitLab.ProjectIdOrPathRef(ProjectIdentity project)
        {
            return Meziantou.GitLab.ProjectIdOrPathRef.FromProject(project);
        }

        public static implicit operator Meziantou.GitLab.ProjectIdOrPathRef(Meziantou.GitLab.PathWithNamespace projectPathWithNamespace)
        {
            return Meziantou.GitLab.ProjectIdOrPathRef.FromProjectPathWithNamespace(projectPathWithNamespace);
        }
    }
}
#nullable disable
