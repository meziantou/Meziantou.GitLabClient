﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated
// </auto-generated>
// ------------------------------------------------------------------------------
#nullable enable
namespace Meziantou.GitLab
{
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Serialization.AccessLevelJsonConverter))]
    public enum AccessLevel
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "guest")]
        Guest = 10,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "reporter")]
        Reporter = 20,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "developer")]
        Developer = 30,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "maintainer")]
        Maintainer = 40,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "owner")]
        Owner = 50
    }
}

namespace Meziantou.GitLab.Serialization
{
    internal partial class EnumMember
    {
        private static readonly Meziantou.GitLab.Serialization.EnumMember<Meziantou.GitLab.AccessLevel>[] s_accessLevelMembers = Meziantou.GitLab.Serialization.EnumMember.CreateAccessLevelMembers();

        public static Meziantou.GitLab.AccessLevel AccessLevelFromString(string value)
        {
            return Meziantou.GitLab.Serialization.EnumMember.FromString(value, Meziantou.GitLab.Serialization.EnumMember.s_accessLevelMembers);
        }

        public static string ToString(Meziantou.GitLab.AccessLevel value)
        {
            if ((value == Meziantou.GitLab.AccessLevel.Guest))
            {
                return "guest";
            }

            if ((value == Meziantou.GitLab.AccessLevel.Reporter))
            {
                return "reporter";
            }

            if ((value == Meziantou.GitLab.AccessLevel.Developer))
            {
                return "developer";
            }

            if ((value == Meziantou.GitLab.AccessLevel.Maintainer))
            {
                return "maintainer";
            }

            if ((value == Meziantou.GitLab.AccessLevel.Owner))
            {
                return "owner";
            }

            throw new System.ArgumentOutOfRangeException(nameof(value), string.Concat("Value '", value.ToString(), "' is not valid"));
        }

        private static Meziantou.GitLab.Serialization.EnumMember<Meziantou.GitLab.AccessLevel>[] CreateAccessLevelMembers()
        {
            Meziantou.GitLab.Serialization.EnumMember<Meziantou.GitLab.AccessLevel>[] result = new Meziantou.GitLab.Serialization.EnumMember<Meziantou.GitLab.AccessLevel>[5];
            result[0] = new Meziantou.GitLab.Serialization.EnumMember<Meziantou.GitLab.AccessLevel>(Meziantou.GitLab.AccessLevel.Guest, "guest");
            result[1] = new Meziantou.GitLab.Serialization.EnumMember<Meziantou.GitLab.AccessLevel>(Meziantou.GitLab.AccessLevel.Reporter, "reporter");
            result[2] = new Meziantou.GitLab.Serialization.EnumMember<Meziantou.GitLab.AccessLevel>(Meziantou.GitLab.AccessLevel.Developer, "developer");
            result[3] = new Meziantou.GitLab.Serialization.EnumMember<Meziantou.GitLab.AccessLevel>(Meziantou.GitLab.AccessLevel.Maintainer, "maintainer");
            result[4] = new Meziantou.GitLab.Serialization.EnumMember<Meziantou.GitLab.AccessLevel>(Meziantou.GitLab.AccessLevel.Owner, "owner");
            return result;
        }
    }

    internal sealed partial class AccessLevelJsonConverter : Meziantou.GitLab.Serialization.EnumBaseJsonConverter<Meziantou.GitLab.AccessLevel>
    {
        protected override Meziantou.GitLab.AccessLevel FromString(string value)
        {
            return Meziantou.GitLab.Serialization.EnumMember.AccessLevelFromString(value);
        }

        protected override string ToString(Meziantou.GitLab.AccessLevel value)
        {
            return Meziantou.GitLab.Serialization.EnumMember.ToString(value);
        }
    }
}

namespace Meziantou.GitLab.Internals
{
    internal partial struct UrlBuilder
    {
        public void AppendParameter(Meziantou.GitLab.AccessLevel value)
        {
            this.Append(Meziantou.GitLab.Serialization.EnumMember.ToString(value));
        }
    }
}