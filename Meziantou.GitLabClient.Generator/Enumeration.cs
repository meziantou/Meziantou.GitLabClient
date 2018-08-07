using System.Collections.Generic;

namespace Meziantou.GitLabClient.Generator
{
    internal class Enumeration : Model
    {
        public Enumeration(string name)
            : base(name)
        {
        }

        public IList<EnumerationMember> Members { get; } = new List<EnumerationMember>();
    }
}
