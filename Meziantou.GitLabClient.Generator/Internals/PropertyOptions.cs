﻿using System;

namespace Meziantou.GitLabClient.Generator
{
    [Flags]
    internal enum PropertyOptions
    {
        None = 0x0,
        IsKey = 0x1,
        IsDisplayName = 0x2,
        CanBeAbsoluteOrRelativeUri = 0x4,
        IsNotUTCDate = 0x8,
    }
}