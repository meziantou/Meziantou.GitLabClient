using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Meziantou.GitLab
{
    [JsonConverter(typeof(PathWithNamespaceConverter))]
    public readonly struct PathWithNamespace : IEquatable<PathWithNamespace>
    {
        private readonly string _value;

        public PathWithNamespace(string pathWithNamespace)
        {
            _value = pathWithNamespace;
        }

        public string Path
        {
            get
            {
                if (_value == null)
                    return null;

                var indexOf = _value.LastIndexOf('/');
                if (indexOf < 0)
                    return _value;

                if (_value.Length == indexOf + 1)
                    return null;

                return _value.Substring(indexOf + 1);
            }
        }

        public string Namespace
        {
            get
            {
                if (_value == null)
                    return null;

                var indexOf = _value.LastIndexOf('/');
                if (indexOf < 0)
                    return null;

                return _value.Substring(0, indexOf);
            }
        }

        public override bool Equals(object obj)
        {
            return obj is PathWithNamespace && Equals((PathWithNamespace)obj);
        }

        public bool Equals(PathWithNamespace other)
        {
            return _value == other._value;
        }

        public override int GetHashCode()
        {
            return -1939223833 + EqualityComparer<string>.Default.GetHashCode(_value);
        }

        public override string ToString()
        {
            return _value;
        }

        public static bool operator ==(PathWithNamespace namespace1, PathWithNamespace namespace2)
        {
            return namespace1.Equals(namespace2);
        }

        public static bool operator !=(PathWithNamespace namespace1, PathWithNamespace namespace2)
        {
            return !(namespace1 == namespace2);
        }
    }
}
