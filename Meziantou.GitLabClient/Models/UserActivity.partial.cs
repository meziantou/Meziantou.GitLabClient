namespace Meziantou.GitLab
{
    public partial class UserActivity
    {
        public override string ToString()
        {
            return $"{Username} on {LastActivityOn:d}";
        }
    }
}
