using System.Collections.Generic;

namespace Meziantou.GitLabClient.Generator
{
    internal class MethodGroup
    {
        public string Name { get; set; }
        public IList<Method> Methods { get; } = new List<Method>();
    }
}
