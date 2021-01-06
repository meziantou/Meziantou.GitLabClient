using Xunit;

namespace Meziantou.GitLab.Tests
{
    [CollectionDefinition(nameof(NotThreadSafeResourceCollection), DisableParallelization = true)]
    public class NotThreadSafeResourceCollection
    {
    }
}
