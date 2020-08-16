﻿using System;

namespace Meziantou.GitLabClient.Generator
{
    internal sealed class EnumerationMember
    {
        public EnumerationMember(string name)
            : this(name, value: null)
        {
        }

        public EnumerationMember(string name, object value)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Value = value;
        }

        public string Name { get; set; }
        public string SerializationName { get; set; }
        public object Value { get; set; }
        public Documentation Documentation { get; set; }
    }
}
