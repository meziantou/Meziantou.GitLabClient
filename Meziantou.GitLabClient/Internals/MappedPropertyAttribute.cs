using System;

namespace Meziantou.GitLab
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class MappedPropertyAttribute : Attribute
    {
        public MappedPropertyAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
