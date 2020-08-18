using System.Collections.Generic;

namespace Meziantou.GitLabClient.Generator
{
    internal sealed class Entity : Model
    {
        public Entity(string name)
            : base(name)
        {
        }

        public IList<EntityProperty> Properties { get; } = new List<EntityProperty>();

        public Entity AddProperty(string name, ModelRef type, PropertyOptions options)
        {
            Properties.Add(new EntityProperty(name, type, options));
            return this;
        }

        public Entity AddProperty(string name, ModelRef type)
        {
            Properties.Add(new EntityProperty(name, type));
            return this;
        }

        public Entity WithBaseType(ModelRef baseType)
        {
            BaseType = baseType;
            return this;
        }
    }
}
