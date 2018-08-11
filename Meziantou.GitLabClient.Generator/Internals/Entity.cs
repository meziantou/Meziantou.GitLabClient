using System.Collections.Generic;

namespace Meziantou.GitLabClient.Generator
{
    internal class Entity : Model
    {
        public Entity(string name)
            : base(name)
        {
        }

        public IList<EntityProperty> Properties { get; } = new List<EntityProperty>();
    }
}
