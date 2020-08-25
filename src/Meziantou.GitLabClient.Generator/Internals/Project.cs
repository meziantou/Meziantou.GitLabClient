using System.Collections.Generic;
using System.Linq;

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

        public ParameterEntity AddParameterEntity(string name, params ParameterEntityRef[] refs)
        {
            var finalType = ModelRef.Object;
            var types = refs.Select(r => r.FinalPropertyModelRef).Distinct().ToList();
            if (types.Count == 1)
            {
                finalType = types[0];
            }

            var parameterEntity = new ParameterEntity(name, finalType);
            ParameterEntities.Add(parameterEntity);

            foreach (var entityRef in refs)
            {
                parameterEntity.Refs.Add(entityRef);
            }

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

        public Enumeration AddEnumeration(string name) => AddModel(new Enumeration(name));

        public Enumeration AddStringEnumeration(string name) => AddModel(new Enumeration(name) { SerializeAsString = true });
    }
}
