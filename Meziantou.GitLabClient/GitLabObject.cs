using System;
using System.Dynamic;
using System.Linq.Expressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Meziantou.GitLab
{
    [JsonConverter(typeof(GitLabObjectConverter))]
    public class GitLabObject : IGitLabObject, IDynamicMetaObjectProvider
    {
        private static readonly JsonSerializer _jsonSerializer;

        static GitLabObject()
        {
            _jsonSerializer = new JsonSerializer
            {
                Converters =
                {
                    new GitLabObjectConverter(),
                    new GitObjectIdConverter(),
                    new JsonObjectConverter(),
                }
            };
        }

        IGitLabClient IGitLabObject.GitLabClient { get; set; }

        private JObject Object { get; }

        internal GitLabObject(JObject obj)
        {
            Object = obj ?? throw new ArgumentNullException(nameof(obj));
        }

        public virtual bool TryGetValue(string name, Type type, out object result)
        {
            if (Object.TryGetValue(name, out var value))
            {
                result = value.ToObject(type, _jsonSerializer);

                if (result is IGitLabObject g)
                {
                    g.GitLabClient = ((IGitLabObject)this).GitLabClient;
                }

                return true;
            }

            result = default;
            return false;
        }

        public virtual bool TryGetValue<T>(string name, out T result)
        {
            if (TryGetValue(name, typeof(T), out var r))
            {
                result = (T)r;
                return true;
            }

            result = default;
            return false;
        }

        public T GetValueOrDefault<T>(string name)
        {
            return GetValueOrDefault(name, default(T));
        }

        public T GetValueOrDefault<T>(string name, T defaultValue)
        {
            if (TryGetValue<T>(name, out var result))
            {
                return result;
            }

            return defaultValue;
        }

        public object GetValueOrDefault(string name, Type type, object defaultValue)
        {
            if (TryGetValue(name, type, out var result))
            {
                return result;
            }

            return defaultValue;
        }

        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
        {
            return new DelegatingMetaObject(Object, parameter, BindingRestrictions.Empty, Object);
        }
    }
}
