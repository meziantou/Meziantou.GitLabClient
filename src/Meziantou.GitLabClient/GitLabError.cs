using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Meziantou.GitLab.Core;
using Meziantou.GitLab.Internals;
using Meziantou.GitLab.Serialization;

namespace Meziantou.GitLab
{
    [JsonConverter(typeof(GitLabErrorJsonConverter))]
    public sealed class GitLabError : GitLabObject
    {
        internal GitLabError(JsonElement obj)
            : base(obj)
        {
        }

        [MappedProperty("error")]
        public string? Error => GetValueOrDefault<string>("error");

        [MappedProperty("error_description")]
        public string? ErrorDescription => GetValueOrDefault<string>("error_description");

        [MappedProperty("scope")]
        public string? Scope => GetValueOrDefault<string>("scope");

        [MappedProperty("message")]
        public string? Message
        {
            get
            {
                if (TryGetValue<string>("message", out var result))
                    return result;

                return null;
            }
        }

        [MappedProperty("message")]
        public IReadOnlyDictionary<string, IReadOnlyList<string>>? Messages
        {
            get
            {
                if (TryGetValue<IReadOnlyDictionary<string, IReadOnlyList<string>>>("message", out var result))
                    return result;

                return null;
            }
        }
    }
}
