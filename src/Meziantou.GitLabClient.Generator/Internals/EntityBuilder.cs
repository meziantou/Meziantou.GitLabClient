using System;

namespace Meziantou.GitLabClient.Generator
{
    internal sealed class EntityBuilder
    {
        private readonly Action<Entity> _configure;

        public EntityBuilder(string name)
        {
            Value = new Entity(name);
        }

        public EntityBuilder(string name, Action<Entity> configure)
        {
            Value = new Entity(name);
            _configure = configure;
        }

        public Entity Value { get; }

        public void Build()
        {
            _configure(Value);
        }

        public ModelRef MakeCollection()
        {
            ModelRef result = Value;
            return result.MakeCollection();
        }

        public ModelRef MakeCollectionNullable()
        {
            ModelRef result = Value;
            return result.MakeCollectionNullable();
        }

        public ModelRef MakeNullable()
        {
            ModelRef result = Value;
            return result.MakeNullable();
        }
    }
}
