using System;
using System.Dynamic;
using System.Linq.Expressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Meziantou.GitLab.Core
{
    [JsonConverter(typeof(GitLabObjectConverter))]
    public class GitLabObject : IDynamicMetaObjectProvider
    {
        private static readonly JsonSerializer s_jsonSerializer = GetJsonSerializer();

        private readonly JObject _jsonObject;

        internal IGitLabClient GitLabClient { get; set; }

        protected internal GitLabObject(JObject obj)
        {
            _jsonObject = obj ?? throw new ArgumentNullException(nameof(obj));
        }

        protected virtual bool TryGetValue(string name, Type type, out object result)
        {
            if (_jsonObject.TryGetValue(name, StringComparison.Ordinal, out var value))
            {
                result = value.ToObject(type, s_jsonSerializer);
                if (result is GitLabObject g)
                {
                    g.GitLabClient = GitLabClient;
                }

                return true;
            }

            result = default;
            return false;
        }

        internal protected bool TryGetValue<T>(string name, out T result)
        {
            if (TryGetValue(name, typeof(T), out var r))
            {
                result = (T)r;
                return true;
            }

            result = default;
            return false;
        }

        protected T GetValueOrDefault<T>(string name)
        {
            return GetValueOrDefault(name, default(T));
        }

        protected T GetValueOrDefault<T>(string name, T defaultValue)
        {
            if (TryGetValue<T>(name, out var result))
            {
                return result;
            }

            return defaultValue;
        }

        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
        {
            return GetMetaObject(parameter);
        }

        protected virtual DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new DelegatingMetaObject(_jsonObject, parameter, BindingRestrictions.Empty, _jsonObject);
        }

        private static JsonSerializer GetJsonSerializer()
        {
            return new JsonSerializer
            {
                Converters =
                {
                    new GitLabObjectConverter(),
                    new JsonObjectConverter(),
                },
            };
        }
    }
}
