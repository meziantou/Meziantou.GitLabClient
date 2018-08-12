using System.Collections.Generic;

namespace Meziantou.GitLabClient.Generator
{
    internal class Enumeration : Model
    {
        public Enumeration(string name)
            : base(name)
        {
        }

        public bool SerializeAsString { get; set; } = true;
        public IList<EnumerationMember> Members { get; } = new List<EnumerationMember>();
    }
}
