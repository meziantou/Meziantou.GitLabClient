using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Meziantou.GitLab.Serialization;

namespace Meziantou.GitLab.Core
{
    [JsonConverter(typeof(GitLabObjectJsonConverter))]
    public partial class GitLabObject
    {
        internal readonly JsonElement _jsonObject;

        protected internal GitLabObject(JsonElement jsonObject)
        {
            if (jsonObject.ValueKind != JsonValueKind.Object)
                throw new ArgumentException("The JSON element is not an object", nameof(jsonObject));

            _jsonObject = jsonObject;
        }

        protected JsonElement JsonObject => _jsonObject;

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

        // Internal for testing purpose
        internal protected bool TryGetValue<T>(string name, out T? result)
        {
            if (TryGetValue(name, typeof(T), out var r))
            {
                result = (T?)r;
                return true;
            }

            result = default;
            return false;
        }

        protected T? GetValueOrDefault<T>(string name)
        {
            return GetValueOrDefault(name, default(T));
        }

        protected T? GetValueOrDefault<T>(string name, T? defaultValue)
        {
            if (TryGetValue<T>(name, out var result))
                return result;

            return defaultValue;
        }

        protected T GetRequiredNonNullValue<T>(string name)
            where T : notnull
        {
            if (TryGetValue<T>(name, out var value))
            {
                if (value is null)
                    throw new ArgumentException($"The property '{name}' doesn't exists", nameof(name));

                return value;
            }

            throw new ArgumentException($"The property '{name}' is null", nameof(name));
        }
    }
}
