using System.Collections.Generic;

namespace Meziantou.GitLab
{
    public class GitLabError : GitLabObject
    {
        public string Error { get; set; }
        public string ErrorDescription { get; set; }
        public string Scope { get; set; }
        public IReadOnlyDictionary<string, IReadOnlyList<string>> Message { get; set; }
    }
}
