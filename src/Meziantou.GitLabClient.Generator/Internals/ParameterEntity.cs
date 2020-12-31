using System.Collections.Generic;
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
    }
}
