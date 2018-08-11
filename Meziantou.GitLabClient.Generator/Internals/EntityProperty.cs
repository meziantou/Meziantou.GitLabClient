using System;

namespace Meziantou.GitLabClient.Generator
{
    internal class EntityProperty
    {
        public EntityProperty(string name, ModelRef type)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type;
        }

        public string Name { get; }
        public ModelRef Type { get; }
        public Documentation Documentation { get; set; }
    }
}
