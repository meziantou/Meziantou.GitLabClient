﻿using System;

namespace Meziantou.GitLab
{
    /// <summary>
    /// Skip UTC validation. Only used by tests
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    internal sealed class SkipUtcDateValidationAttribute : Attribute
    {
        public SkipUtcDateValidationAttribute(string reason)
        {
            Reason = reason ?? throw new ArgumentNullException(nameof(reason));
        }

        public string Reason { get; }
    }
}
