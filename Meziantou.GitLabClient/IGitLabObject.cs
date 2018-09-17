namespace Meziantou.GitLab
{
    internal interface IGitLabObject
    {
        IGitLabClient GitLabClient { get; set; }
    }
}
