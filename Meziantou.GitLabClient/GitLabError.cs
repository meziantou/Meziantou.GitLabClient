using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Meziantou.GitLab
{
    // TODO code properies
    public class GitLabError : GitLabObject
    {
        public GitLabError(JObject obj)
            : base(obj)
        {
        }

        public string Error => GetValueOrDefault<string>("error");
        public string ErrorDescription => GetValueOrDefault<string>("error_description");
        public string Scope => GetValueOrDefault<string>("scope");
        public IReadOnlyDictionary<string, IReadOnlyList<string>> Message => GetValueOrDefault<IReadOnlyDictionary<string, IReadOnlyList<string>>>("message");
    }
}
