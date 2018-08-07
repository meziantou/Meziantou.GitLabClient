using System.Collections.Generic;

namespace Meziantou.GitLabClient.Generator
{
    internal class Project
    {
        public IList<Model> Models { get; } = new List<Model>();
        public IList<Method> Methods { get; } = new List<Method>();

        public Model AddModel(Model model)
        {
            Models.Add(model);
            return model;
        }

        public Method AddMethod(Method method)
        {
            Methods.Add(method);
            return method;
        }
    }
}
