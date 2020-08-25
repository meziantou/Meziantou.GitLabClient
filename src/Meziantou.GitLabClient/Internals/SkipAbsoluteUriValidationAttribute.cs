using System;

namespace Meziantou.GitLab
{
    /// <summary>
    /// Only used by tests
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    internal sealed class SkipAbsoluteUriValidationAttribute : Attribute
    {
    }
}
