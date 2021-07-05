using System;

namespace Meziantou.GitLabClient.Generator
{
    [Flags]
    internal enum MethodParameterOptions
    {
        None = 0x0,
        IsRequired = 0x1,
        DoNotValidate = 0x2,
    }
}
