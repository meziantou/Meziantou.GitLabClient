using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Meziantou.GitLabClient.Generator
{
    internal class Method
    {
        public string Name { get; set; }
        public string UrlTemplate { get; set; }
        public ModelRef ReturnType { get; set; }
        public bool IsPaged { get; set; }
        public HttpMethod HttpMethod { get; set; } = HttpMethod.Get;
        public IList<MethodParameter> Parameters { get; } = new List<MethodParameter>();
    }
}
