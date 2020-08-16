using System.Collections.Generic;
using Meziantou.GitLab.Core;
using Newtonsoft.Json.Linq;

namespace Meziantou.GitLab
{
    public sealed class GitLabError : GitLabObject
    {
        internal GitLabError(JObject obj)
            : base(obj)
        {
        }

        [MappedProperty("error")]
        public string Error => GetValueOrDefault<string>("error");

        [MappedProperty("error_description")]
        public string ErrorDescription => GetValueOrDefault<string>("error_description");

        [MappedProperty("scope")]
        public string Scope => GetValueOrDefault<string>("scope");

        [MappedProperty("message")]
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

        [MappedProperty("message")]
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
