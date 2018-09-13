using System.Collections.Generic;

namespace Meziantou.GitLabClient.Generator
{
    internal class Method
    {
        public Method(string name, string urlTemplate)
        {
            Name = name;
            UrlTemplate = urlTemplate;
        }

        public string Name { get; }
        public string UrlTemplate { get; }
        public ModelRef ReturnType { get; set; }
        public MethodType MethodType { get; set; }
        public IList<MethodParameter> Parameters { get; set; } = new List<MethodParameter>();
        public Documentation Documentation { get; set; }
    }
}
