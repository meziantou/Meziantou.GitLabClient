using System;
using Newtonsoft.Json;

namespace Meziantou.GitLabClient.Generator
{
    internal sealed class EntityProperty
    {
        public EntityProperty(string name, ModelRef type)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            Name = name.Trim();
            Type = type;
        }

        public string Name { get; }
        public string SerializationName { get; set; }
        public ModelRef Type { get; }
        public Documentation Documentation { get; set; }
        public Required? Required { get; set; }
        public bool IsKey { get; set; }
        public bool IsDisplayName { get; set; }
    }
}
