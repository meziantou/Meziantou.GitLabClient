using System;

namespace Meziantou.GitLabClient.Generator
{
    internal abstract class Model
    {
        public Model(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; }
        public ModelRef BaseType { get; set; }
        public Documentation Documentation { get; set; }
    }
}
