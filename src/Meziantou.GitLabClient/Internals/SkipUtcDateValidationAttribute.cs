using System;

namespace Meziantou.GitLab.Internals
{
    /// <summary>
    /// Skip UTC validation. Only used by tests
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    internal sealed class SkipUtcDateValidationAttribute : Attribute
    {
    }
}
