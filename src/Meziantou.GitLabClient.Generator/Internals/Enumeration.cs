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

        public Enumeration AddMembers(params string[] names)
        {
            foreach (var name in names)
            {
                AddMember(name);
            }

            return this;
        }

        public Enumeration AddMember(string name, object value = null, string serializationName = null)
        {
            var member = new EnumerationMember(name, value)
            {
                SerializationName = serializationName,
            };
            Members.Add(member);
            return this;
        }
    }
}
