using System.Collections.Generic;

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

        public MethodGroup AddMethodGroup(string name, Method[] methods)
        {
            var group = new MethodGroup { Name = name };
            foreach (var method in methods)
            {
                group.Methods.Add(method);
            }

            MethodGroups.Add(group);
            return group;
        }
    }
}
