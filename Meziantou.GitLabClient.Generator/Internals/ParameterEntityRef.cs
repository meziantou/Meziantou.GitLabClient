using System.Collections.Generic;

namespace Meziantou.GitLabClient.Generator
{
    internal class ParameterEntityRef
    {
        public ParameterEntityRef(ModelRef modelRef, params string[] properties)
        {
            ModelRef = modelRef;
            Properties = properties;
        }

        public ModelRef ModelRef { get; }
        public IReadOnlyList<string> Properties { get; }
    }
}
