using System;

namespace Meziantou.GitLab.Serialization
{
    internal static partial class EnumMember
    {
        private static T FromString<T>(string value, EnumMember<T>[] members)
            where T : struct, Enum
        {
            foreach (var member in members)
            {
                if (value == member.Name)
                    return member.Value;
            }

            throw new ArgumentException($"Value '{value}' is not valid", nameof(value));
        }
    }

    internal readonly struct EnumMember<T>
        where T : struct, Enum
    {
        public EnumMember(T value, string name)
        {
            Value = value;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public T Value { get; }
        public string Name { get; }
    }
}
