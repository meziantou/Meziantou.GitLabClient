using System;
using System.Collections.Generic;

namespace Meziantou.GitLabClient.Generator
{
    internal sealed class Method
    {
        public Method(string name, string urlTemplate)
        {
            if (!urlTemplate.StartsWith('/'))
                throw new ArgumentException("Template must start with a '/'", nameof(urlTemplate));

            Name = name;
            UrlTemplate = urlTemplate[1..];
        }

        public MethodGroup MethodGroup { get; set; }
        public string Name { get; }
        public string UrlTemplate { get; }
        public string RequestTypeName { get; set; }
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

        public Method WithRequestTypeName(string requestTypeName)
        {
            RequestTypeName = requestTypeName;
            return this;
        }
    }
}
