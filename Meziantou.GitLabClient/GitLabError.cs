using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Meziantou.GitLab
{
    public class GitLabError : GitLabObject
    {
        internal GitLabError(JObject obj)
            : base(obj)
        {
        }

        public string Error => GetValueOrDefault<string>("error");
        public string ErrorDescription => GetValueOrDefault<string>("error_description");
        public string Scope => GetValueOrDefault<string>("scope");
        public string Message
        {
            get
            {
                if (TryGetValue<JToken>("message", out var result))
                {
                    if (result.Type == JTokenType.String)
                    {
                        return GetValueOrDefault<string>("message");
                    }
                }

                return null;
            }
        }

        public IReadOnlyDictionary<string, IReadOnlyList<string>> Messages
        {
            get
            {
                if (TryGetValue<JToken>("message", out var result))
                {
                    if (result.Type == JTokenType.Object)
                    {
                        return GetValueOrDefault<IReadOnlyDictionary<string, IReadOnlyList<string>>>("message");
                    }
                }

                return null;
            }
        }
    }
}
