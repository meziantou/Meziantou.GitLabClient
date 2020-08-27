using System;

namespace Meziantou.GitLabClient.Generator
{
    internal sealed class EntityBuilder
    {
        private Action<Entity> _configure;

        public EntityBuilder(string name)
        {
            Value = new Entity(name);
        }

        public Entity Value { get; }

        public void Configure(Action<Entity> configure)
        {
            _configure = configure;
        }

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
