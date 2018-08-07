using System;

namespace Meziantou.GitLab
{
    /// <summary>
    /// Skip UTC validation. Only used by tests
    /// </summary>
    internal class SkipUtcDateValidationAttribute : Attribute
    {
    }
}
