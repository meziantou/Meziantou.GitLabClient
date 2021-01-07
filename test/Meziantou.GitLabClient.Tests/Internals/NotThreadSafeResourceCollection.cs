using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Meziantou.GitLab.Tests
{
    [CollectionDefinition(nameof(NotThreadSafeResourceCollection), DisableParallelization = true)]
    [SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix", Justification = "xUnit test collection")]
    public class NotThreadSafeResourceCollection
    {
    }
}
