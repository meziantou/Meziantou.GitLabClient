using System;

namespace Meziantou.GitLabClient.Generator
{
    internal sealed class EntityProperty
    {
        public EntityProperty(string name, ModelRef type)
            : this(name, type, PropertyOptions.None)
        {
        }

        public EntityProperty(string name, ModelRef type, PropertyOptions options)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            Name = name.Trim();
            Type = type;
            Options = options;
        }

        public string Name { get; }
        public ModelRef Type { get; }
        public Documentation Documentation { get; set; }
        public PropertyOptions Options { get; set; }
        public bool IsKey => Options.HasFlag(PropertyOptions.IsKey);
        public bool IsDisplayName => Options.HasFlag(PropertyOptions.IsDisplayName);
    }
}
