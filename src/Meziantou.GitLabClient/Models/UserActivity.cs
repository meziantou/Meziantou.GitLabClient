using System.Diagnostics.CodeAnalysis;

namespace Meziantou.GitLab
{
    public partial class UserActivity
    {
        [SuppressMessage("Design", "MA0076:Do not use implicit culture-sensitive ToString in interpolated strings", Justification = "ToString is culture sensitive")]
        public override string ToString()
        {
            return $"{Username} on {LastActivityOn:d}";
        }
    }
}
