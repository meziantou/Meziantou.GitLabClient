// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated
// </auto-generated>
// ------------------------------------------------------------------------------
#nullable enable
namespace Meziantou.GitLab
{
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Serialization.MergeRequestScopeFilterJsonConverter))]
    public enum MergeRequestScopeFilter
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "assigned_to_me")]
        AssignedToMe,
        [System.Runtime.Serialization.EnumMemberAttribute(Value = "all")]
        All
    }
}

namespace Meziantou.GitLab.Serialization
{
    partial class EnumMember
    {
        private static readonly Meziantou.GitLab.Serialization.EnumMember<Meziantou.GitLab.MergeRequestScopeFilter>[] s_MergeRequestScopeFiltermembers = Meziantou.GitLab.Serialization.EnumMember.CreateMergeRequestScopeFilterMembers();

        public static Meziantou.GitLab.MergeRequestScopeFilter MergeRequestScopeFilterFromString(string value)
        {
            return Meziantou.GitLab.Serialization.EnumMember.FromString(value, Meziantou.GitLab.Serialization.EnumMember.s_MergeRequestScopeFiltermembers);
        }

        public static string ToString(Meziantou.GitLab.MergeRequestScopeFilter value)
        {
            if ((value == Meziantou.GitLab.MergeRequestScopeFilter.AssignedToMe))
            {
                return "assigned_to_me";
            }

            if ((value == Meziantou.GitLab.MergeRequestScopeFilter.All))
            {
                return "all";
            }

            throw new System.ArgumentOutOfRangeException(nameof(value));
        }

        private static Meziantou.GitLab.Serialization.EnumMember<Meziantou.GitLab.MergeRequestScopeFilter>[] CreateMergeRequestScopeFilterMembers()
        {
            Meziantou.GitLab.Serialization.EnumMember<Meziantou.GitLab.MergeRequestScopeFilter>[] result = new Meziantou.GitLab.Serialization.EnumMember<Meziantou.GitLab.MergeRequestScopeFilter>[2];
            result[0] = new Meziantou.GitLab.Serialization.EnumMember<Meziantou.GitLab.MergeRequestScopeFilter>(Meziantou.GitLab.MergeRequestScopeFilter.AssignedToMe, "assigned_to_me");
            result[1] = new Meziantou.GitLab.Serialization.EnumMember<Meziantou.GitLab.MergeRequestScopeFilter>(Meziantou.GitLab.MergeRequestScopeFilter.All, "all");
            return result;
        }
    }

    internal sealed partial class MergeRequestScopeFilterJsonConverter : Meziantou.GitLab.Serialization.EnumBaseJsonConverter<Meziantou.GitLab.MergeRequestScopeFilter>
    {
        protected override Meziantou.GitLab.MergeRequestScopeFilter FromString(string value)
        {
            return Meziantou.GitLab.Serialization.EnumMember.MergeRequestScopeFilterFromString(value);
        }

        protected override string ToString(Meziantou.GitLab.MergeRequestScopeFilter value)
        {
            return Meziantou.GitLab.Serialization.EnumMember.ToString(value);
        }
    }
}
#nullable disable
