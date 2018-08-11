using System.Runtime.Serialization;

namespace Meziantou.GitLab
{
    public enum OrderByDirection
    {
        [EnumMember(Value = "asc")]
        Ascending,
        [EnumMember(Value = "desc")]
        Descending,
    }
}
