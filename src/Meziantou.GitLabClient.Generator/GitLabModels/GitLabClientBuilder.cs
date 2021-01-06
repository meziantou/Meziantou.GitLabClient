using System;

namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal abstract class GitLabClientBuilder
    {
        public void Create(Project project)
        {
            var typeName = GetType().Name;
            if (!typeName.EndsWith("Client", StringComparison.Ordinal))
                throw new InvalidOperationException($"Client class '{typeName}' must end with 'Client'");

            var group = project.AddMethodGroup(typeName.Substring(0, typeName.Length - "Client".Length));
            Create(group);
        }

        protected abstract void Create(MethodGroup methodGroup);

        protected static ModelRef Choice(string name, string[] values)
        {
            return new Enumeration(name).AddMembers(values);
        }
    }
}
