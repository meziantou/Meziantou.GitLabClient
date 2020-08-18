namespace Meziantou.GitLab
{
    internal interface IGitLabObjectReference<T>
    {
        T Value { get; }
    }
}
