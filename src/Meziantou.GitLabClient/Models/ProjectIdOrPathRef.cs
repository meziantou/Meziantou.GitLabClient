using System;
using System.Globalization;

namespace Meziantou.GitLab
{
    public readonly partial struct ProjectIdOrPathRef
    {
        public string ValueAsString => _value switch
        {
            long l => l.ToString(CultureInfo.InvariantCulture),
            PathWithNamespace pathWithNamespace => pathWithNamespace.FullPath,
            _ => throw new InvalidOperationException("Value is not supported"),
        };
    }
}
