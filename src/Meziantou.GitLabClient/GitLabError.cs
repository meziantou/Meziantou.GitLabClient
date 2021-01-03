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
                try
                {
                    if (TryGetValue<string>("message", out var result))
                        return result;
                }
                catch (JsonException)
                {
                    // The 'message' properties could be a single string value or a dictionary...
                }

                return null;
            }
        }

        [MappedProperty("message")]
        public IReadOnlyDictionary<string, IReadOnlyList<string>>? Messages
        {
            get
            {
                try
                {
                    if (TryGetValue<IReadOnlyDictionary<string, IReadOnlyList<string>>>("message", out var result))
                        return result;
                }
                catch (JsonException)
                {
                    // The 'message' properties could be a single string value or a dictionary...
                }

                return null;
            }
        }

        public override string ToString()
        {
            var result = "";
            if (!string.IsNullOrEmpty(Error))
            {
                result = AppendError(result, Error);
            }

            if (!string.IsNullOrEmpty(Message))
            {
                result = AppendError(result, Message);
            }

            if (Messages != null)
            {
                foreach (var item in Messages)
                {
                    foreach (var entry in item.Value)
                    {
                        result = AppendError(result, item.Key + ": " + Message);
                    }
                }
            }

            return result;

            static string AppendError(string currentError, string error)
            {
                if (string.IsNullOrEmpty(currentError))
                    return error;

                return currentError + '\n' + error;
            }
        }
    }
}
