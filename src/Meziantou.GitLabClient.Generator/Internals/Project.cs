using System;
using System.Collections.Generic;
using System.Linq;
using Meziantou.GitLabClient.Generator.Internals;

namespace Meziantou.GitLabClient.Generator
{
    internal sealed class Project
    {
        public IList<Model> Models { get; } = new List<Model>();
        public IList<ParameterEntity> ParameterEntities { get; } = new List<ParameterEntity>();
        public IList<MethodGroup> MethodGroups { get; } = new List<MethodGroup>();

        public T AddModel<T>(T model) where T : Model
        {
            Models.Add(model);
            return model;
        }

        public ParameterEntity AddParameterEntity(ParameterEntity parameterEntity)
        {
            ParameterEntities.Add(parameterEntity);
            return parameterEntity;
        }

        public MethodGroup AddMethodGroup(MethodGroup group)
        {
            MethodGroups.Add(group);
            return group;
        }

        public MethodGroup AddMethodGroup(string name, params Method[] methods)
        {
            var group = new MethodGroup { Name = name };
            foreach (var method in methods)
            {
                group.Methods.Add(method);
            }

            MethodGroups.Add(group);
            return group;
        }

        public void Merge(IReadOnlyCollection<GitLabDocumentationResource> resources)
        {
            foreach (var modelGroup in MethodGroups)
            {
                var documentationGroup = resources.FirstOrDefault(r => r.Name == modelGroup.Name);
                if (documentationGroup == null)
                    throw new InvalidOperationException($"Cannot find resource '{modelGroup.Name}'");

                foreach (var modelMethod in modelGroup.Methods)
                {
                    var documentationMethod = documentationGroup.Methods.FirstOrDefault(m => m.Equals(modelMethod));
                    if (documentationMethod == null)
                        throw new InvalidOperationException($"Cannot find method '{modelMethod.UrlTemplate}'");

                    if (modelMethod.Documentation?.HelpLink != documentationMethod.DocumentationUrl)
                        throw new InvalidOperationException($"Method '{modelMethod.MethodGroup.Name}/{modelMethod.Name}' should have url '{documentationMethod.DocumentationUrl}'");

                    if (modelMethod.Documentation?.Summary == null)
                    {
                        modelMethod.Documentation ??= new Documentation();
                        modelMethod.Documentation.Summary = documentationMethod.Summary;
                    }

                    foreach (var modelParameter in modelMethod.Parameters)
                    {
                        // TODO-GitLab fix GitLab documentation to avoid this case
                        if (documentationMethod.Parameters.Count == 0)
                            continue; // GitLab is so inconsistent in the documentation that sometimes we cannot find the params...

                        var documentationParameter = documentationMethod.Parameters.FirstOrDefault(p => p.Name == modelParameter.Name);
                        if (documentationParameter == null)
                            throw new InvalidOperationException($"Cannot find parameter '{modelParameter.Name}' for the method '{modelMethod.MethodGroup.Name}/{modelMethod.Name}'. Available parameters: {string.Join(", ", documentationMethod.Parameters.Select(p => p.Name))}");

                        if (documentationParameter.Type.Contains('/', StringComparison.Ordinal) && !modelParameter.Type.IsParameterEntity)
                            throw new InvalidOperationException($"Parameter '{modelParameter.Name}' for the method '{modelMethod.MethodGroup.Name}/{modelMethod.Name}' should be a parameter entity because the expected type can be of any of the following data types '{documentationParameter.Type}'");

                        if (modelParameter.Documentation?.Summary == null)
                        {
                            modelParameter.Documentation ??= new Documentation();
                            modelParameter.Documentation.Summary = documentationParameter.Description;
                        }
                    }
                }
            }
        }
    }
}
