namespace Meziantou.GitLab
{
    public partial class ServerVersion
    {
        public override string ToString()
        {
            return $"{Version} rev:{Revision}";
        }
    }
}
