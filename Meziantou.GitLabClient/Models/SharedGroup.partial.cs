namespace Meziantou.GitLab
{
    public partial class SharedGroup
    {
        public override string ToString()
        {
            return $"{GroupName} - {GroupAccessLevel}";
        }
    }
}
