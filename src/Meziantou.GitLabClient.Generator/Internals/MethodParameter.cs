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
        public bool IsRequired => Options.HasFlag(MethodParameterOptions.IsRequired);
        public Documentation Documentation { get; set; }
        public MethodParameterOptions Options { get; set; }

        /// <summary>
        /// Used to avoid breaking change when adding new parameters (create overloads instead of changing existing methods)
        /// </summary>
        public int Version { get; set; }
    }
}
