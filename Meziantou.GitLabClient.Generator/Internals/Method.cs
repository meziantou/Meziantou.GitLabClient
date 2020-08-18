using System.Collections.Generic;

namespace Meziantou.GitLabClient.Generator
{
    internal sealed class Method
    {
        public Method(string name, string urlTemplate)
        {
            Name = name;
            UrlTemplate = urlTemplate;
        }

        public MethodGroup MethodGroup { get; set; }
        public string Name { get; }
        public string UrlTemplate { get; }
        public ModelRef ReturnType { get; set; }
        public MethodType MethodType { get; set; }
        public IList<MethodParameter> Parameters { get; set; } = new List<MethodParameter>();
        public Documentation Documentation { get; set; }

        public Method AddRequiredParameter(string name, ModelRef type)
        {
            var parameter = new MethodParameter(name, type)
            {
                IsRequired = true,
            };

            Parameters.Add(parameter);
            return this;
        }

        public Method AddOptionalParameter(string name, ModelRef type)
        {
            var parameter = new MethodParameter(name, type);
            Parameters.Add(parameter);
            return this;
        }

        public Method WithReturnType(ModelRef returnType)
        {
            ReturnType = returnType;
            return this;
        }
    }
}
