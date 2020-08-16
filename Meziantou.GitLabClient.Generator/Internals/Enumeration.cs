using System.Collections.Generic;

namespace Meziantou.GitLabClient.Generator
{
    internal sealed class Enumeration : Model
    {
        public Enumeration(string name)
            : base(name)
        {
        }

        public bool SerializeAsString { get; set; } = true;
        public IList<EnumerationMember> Members { get; } = new List<EnumerationMember>();
        public bool IsFlags { get; set; }
        public bool GenerateAllMember { get; set; }
    }
}
