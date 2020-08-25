using System.Collections.Generic;

namespace Meziantou.GitLabClient.Generator
{
    internal sealed class MethodGroup
    {
        public string Name { get; set; }
        public IList<Method> Methods { get; } = new List<Method>();

        public Method AddMethod(string name, MethodType methodType, string url, string documentationUrl)
        {
            var method = new Method(name, url)
            {
                MethodType = methodType,
                Documentation = new Documentation
                {
                    HelpLink = documentationUrl,
                },
            };

            method.MethodGroup = this;
            Methods.Add(method);
            return method;
        }
    }
}
