namespace Meziantou.GitLab.Internals
{
    internal interface IGitLabObjectReference<T>
    {
        T Value { get; }
    }
}
