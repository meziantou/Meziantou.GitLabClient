﻿using System;

namespace Meziantou.GitLab
{
    [AttributeUsage(AttributeTargets.Property)]
    internal sealed class MappedPropertyAttribute : Attribute
    {
        public MappedPropertyAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
