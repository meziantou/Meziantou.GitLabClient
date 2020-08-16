using System.Collections.Generic;

namespace Meziantou.GitLabClient.Generator
{
    internal sealed class ParameterEntity
    {
        public ParameterEntity(string name, ModelRef finalType)
        {
            Name = name;
            FinalType = finalType;
        }

        public string Name { get; }
        public ModelRef FinalType { get; }
        public IList<ParameterEntityRef> Refs { get; } = new List<ParameterEntityRef>();
        public Documentation Documentation { get; set; }
    }
}
