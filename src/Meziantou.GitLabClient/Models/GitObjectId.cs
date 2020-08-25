using System;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using Meziantou.GitLab.Serialization;

namespace Meziantou.GitLab
{
    [JsonConverter(typeof(GitObjectIdJsonConverter))]
    [StructLayout(LayoutKind.Auto)]
    public readonly struct GitObjectId : IEquatable<GitObjectId>
    {
        private readonly string _id;

        public GitObjectId(string id)
        {
            // Sha1 or Sha256
            if (id.Length != 40 && id.Length != 64)
                throw new ArgumentException($"The provided value '{id}' is not a valid SHA1 or SHA256", nameof(id));

            foreach (var c in id)
            {
                if (!IsValid(c))
                    throw new ArgumentException($"The provided value '{id}' is not a valid SHA1 or SHA256: '{c}' is not valid", nameof(id));
            }

            _id = id;
        }

        private static bool IsValid(char c)
        {
            return (c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F');
        }

        public static GitObjectId Empty { get; }

        public override string ToString() => _id;

        public override bool Equals(object? obj)
        {
            return obj is GitObjectId gitObjectId && Equals(gitObjectId);
        }

        public bool Equals(GitObjectId other)
        {
            return _id == other._id;
        }

        public override int GetHashCode() => HashCode.Combine(_id);

        public static bool operator ==(GitObjectId sha1, GitObjectId sha2) => sha1.Equals(sha2);

        public static bool operator !=(GitObjectId sha1, GitObjectId sha2) => !(sha1 == sha2);
    }
}
