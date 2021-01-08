using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Meziantou.GitLabClient.Generator
{
    internal sealed class ParameterEntity
    {
        public ParameterEntity(string name)
            : this(name, ModelRef.Object)
        {
        }

        public ParameterEntity(string name, ModelRef finalType)
        {
            Name = name;
            FinalType = finalType;
        }

        public string Name { get; }
        public ModelRef FinalType { get; private set; }
        public IList<ParameterEntityRef> Refs { get; } = new List<ParameterEntityRef>();
        public Documentation Documentation { get; set; }

        public ModelRef MakeNullable()
        {
            ModelRef result = this;
            return result.MakeNullable();
        }

        public void SetRefs(params ParameterEntityRef[] refs)
        {
            var finalType = ModelRef.Object;
            var types = refs.Select(r => r.FinalPropertyModelRef).Distinct().ToList();
            if (types.Count == 1)
            {
                finalType = types[0];
            }

            FinalType = finalType;
            foreach (var entityRef in refs)
            {
                Refs.Add(entityRef);
            }
        }

        public void SetModel(ModelRef modelRef)
        {
            if (modelRef.Model is not Entity entity)
                throw new InvalidOperationException("ModelRef must be an entity");

            var keyProperty = entity.AllProperties.Single(p => p.IsKey);

            FinalType = keyProperty.Type;
            Refs.Add(ParameterEntityRef.Create(entity.Name + GitLabClientGenerator.ToPropertyName(keyProperty.Name), keyProperty.Type));
            Refs.Add(ParameterEntityRef.Create(entity.Name, modelRef, keyProperty.Name));
        }

        public static ParameterEntity CreateFromModel(ModelRef modelRef)
        {
            if (modelRef.Model is not Entity entity)
                throw new InvalidOperationException("ModelRef must be an entity");

            var keyProperty = entity.AllProperties.Single(p => p.IsKey);

            var result = new ParameterEntity(entity.Name + keyProperty.Name + "Ref");
            result.SetModel(modelRef);
            return result;
        }
    }
}
