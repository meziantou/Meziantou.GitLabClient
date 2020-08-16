#nullable enable
using System;
#if !REF
using Newtonsoft.Json;
#endif

namespace Meziantou.GitLab
{
#if !REF
    [JsonConverter(typeof(PathWithNamespaceConverter))]
#endif
    public readonly struct PathWithNamespace : IEquatable<PathWithNamespace>
    {
        public PathWithNamespace(string pathWithNamespace)
        {
            FullPath = pathWithNamespace;
        }

        public string FullPath { get; }

        public string Name
        {
            get
            {
                var indexOf = FullPath.LastIndexOf('/');
                if (indexOf < 0)
                    return FullPath;

                if (FullPath.Length == indexOf + 1)
                    return "";

                return FullPath.Substring(indexOf + 1);
            }
        }

        public PathWithNamespace? Namespace
        {
            get
            {
                if (FullPath == null)
                    return null;

                var indexOf = FullPath.LastIndexOf('/');
                if (indexOf < 0)
                    return null;

                return new PathWithNamespace(FullPath.Substring(0, indexOf));
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is PathWithNamespace pathWithNamespace && Equals(pathWithNamespace);
        }

        public bool Equals(PathWithNamespace other)
        {
            return FullPath == other.FullPath;
        }

        public override int GetHashCode()
        {
            return -1939223833 + StringComparer.Ordinal.GetHashCode(FullPath);
        }

        public override string ToString() => FullPath;

        public static bool operator ==(PathWithNamespace namespace1, PathWithNamespace namespace2) => namespace1.Equals(namespace2);

        public static bool operator !=(PathWithNamespace namespace1, PathWithNamespace namespace2) => !(namespace1 == namespace2);

        public static implicit operator string(PathWithNamespace value) => value.FullPath;
    }
}
