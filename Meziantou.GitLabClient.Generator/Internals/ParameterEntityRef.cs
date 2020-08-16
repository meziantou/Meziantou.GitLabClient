using System.Collections.Generic;

namespace Meziantou.GitLabClient.Generator
{
    internal sealed class ParameterEntityRef
    {
        public ParameterEntityRef(string name, ModelRef modelRef, params string[] properties)
        {
            Name = name;
            ModelRef = modelRef;
            Properties = properties;
        }

        public string Name { get; }
        public ModelRef ModelRef { get; }
        public IReadOnlyList<string> Properties { get; }
    }
}
