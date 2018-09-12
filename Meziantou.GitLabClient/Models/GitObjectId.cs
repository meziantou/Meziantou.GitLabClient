using System;
using Newtonsoft.Json;

namespace Meziantou.GitLab
{
    [JsonConverter(typeof(GitObjectIdConverter))]
    public readonly struct GitObjectId : IEquatable<GitObjectId>
    {
        // a sha1 is 20 bytes long
        // 20 bytes to hexa => 40 characters
        private readonly uint _p1;
        private readonly uint _p2;
        private readonly uint _p3;
        private readonly uint _p4;
        private readonly uint _p5;

        private GitObjectId(uint p1, uint p2, uint p3, uint p4, uint p5)
        {
            _p1 = p1;
            _p2 = p2;
            _p3 = p3;
            _p4 = p4;
            _p5 = p5;
        }

        public static GitObjectId Empty { get; } = default;

        public static bool TryParse(string value, out GitObjectId result)
        {
            if (value == null || value.Length != 40)
            {
                result = default;
                return false;
            }

            //TODO when supported: Span<byte> b = stackalloc byte[20];
            var index = 0;

            var p1 = GetUInt32(ref index);
            var p2 = GetUInt32(ref index);
            var p3 = GetUInt32(ref index);
            var p4 = GetUInt32(ref index);
            var p5 = GetUInt32(ref index);
            var isValid = true;
            if (isValid)
            {
                result = new GitObjectId(p1, p2, p3, p4, p5);
                return true;
            }

            result = default;
            return false;

            uint GetUInt32(ref int i)
            {
                unchecked
                {
                    return (GetByte(value[i++], value[i++]) << 24) |
                           (GetByte(value[i++], value[i++]) << 16) |
                           (GetByte(value[i++], value[i++]) << 8) |
                           GetByte(value[i++], value[i++]);
                }
            }

            uint GetByte(char c1, char c2)
            {
                unchecked
                {
                    return (GetHexVal(c1) << 4) | GetHexVal(c2);
                }
            }

            uint GetHexVal(char c)
            {
                const uint Digit = '0';
                const uint LowerCase = 'a' - 10;
                const uint UpperCase = 'A' - 10;

                if (c >= '0' && c <= '9')
                    return c - Digit;

                if (c >= 'A' && c <= 'F') // Upper case
                    return c - UpperCase;

                if (c >= 'a' && c <= 'f') // Upper case
                    return c - LowerCase;

                isValid = false;
                return 0;
            }
        }

        public override string ToString()
        {
            return _p1.ToString("x8") +
                   _p2.ToString("x8") +
                   _p3.ToString("x8") +
                   _p4.ToString("x8") +
                   _p5.ToString("x8");
        }

        public override bool Equals(object obj)
        {
            return obj is GitObjectId sha1 && Equals(sha1);
        }

        public bool Equals(GitObjectId other)
        {
            return _p1 == other._p1 &&
                   _p2 == other._p2 &&
                   _p3 == other._p3 &&
                   _p4 == other._p4 &&
                   _p5 == other._p5;
        }

        public override int GetHashCode()
        {
            var hashCode = 1974593755;
            hashCode = hashCode * -1521134295 + _p1.GetHashCode();
            hashCode = hashCode * -1521134295 + _p2.GetHashCode();
            hashCode = hashCode * -1521134295 + _p3.GetHashCode();
            hashCode = hashCode * -1521134295 + _p4.GetHashCode();
            hashCode = hashCode * -1521134295 + _p5.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(GitObjectId sha1, GitObjectId sha2) => sha1.Equals(sha2);

        public static bool operator !=(GitObjectId sha1, GitObjectId sha2) => !(sha1 == sha2);
    }
}
