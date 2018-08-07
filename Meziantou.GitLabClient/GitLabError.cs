namespace Meziantou.GitLab
{
    public class GitLabError : GitLabObject
    {
        public ErrorCode Error { get; set; }
        public string ErrorDescription { get; set; }
        public string Scope { get; set; }
    }
}
