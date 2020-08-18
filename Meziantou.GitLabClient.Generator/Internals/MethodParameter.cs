using System;

namespace Meziantou.GitLabClient.Generator
{
    internal sealed class MethodParameter
    {
        public MethodParameter(string name, ModelRef type)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type;
        }

        public string Name { get; }
        public ModelRef Type { get; }
        public string MethodParameterName { get; set; }
        public ParameterLocation Location { get; set; }
        public bool IsRequired { get; set; }
        public Documentation Documentation { get; set; }
    }
}
