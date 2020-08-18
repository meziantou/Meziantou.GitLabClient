using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Meziantou.GitLab.Serialization;

namespace Meziantou.GitLab.Core
{
    [JsonConverter(typeof(GitLabObjectJsonConverter))]
    public class GitLabObject
    {
        internal readonly JsonElement _jsonObject;

        protected internal GitLabObject(JsonElement jsonObject)
        {
            if (jsonObject.ValueKind != JsonValueKind.Object)
                throw new ArgumentException("The JSON element is not an object", nameof(jsonObject));

            _jsonObject = jsonObject;
        }

        protected virtual bool TryGetValue(string name, Type type, out object? result)
        {
            if (_jsonObject.TryGetProperty(name, out var value))
            {
                result = JsonSerialization.ToObject(value, type);
                return true;
            }

            result = default;
            return false;
        }

        internal protected bool TryGetValue<T>(string name, [MaybeNull] out T result)
        {
            if (TryGetValue(name, typeof(T), out var r))
            {
                result = (T)r;
                return true;
            }

            result = default;
            return false;
        }

        [return: MaybeNull]
        protected T GetValueOrDefault<T>(string name)
        {
            return GetValueOrDefault(name, default(T));
        }

        [return: MaybeNull]
        protected T GetValueOrDefault<T>(string name, [AllowNull] T defaultValue)
        {
            if (TryGetValue<T>(name, out var result))
                return result;

            return defaultValue;
        }
    }
}
