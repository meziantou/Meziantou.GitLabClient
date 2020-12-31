using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal static partial class Models
    {
        private static Enumeration CreateStringEnumeration([CallerFilePath] string filePath = null)
        {
            var name = Path.GetFileNameWithoutExtension(filePath);
            var enumeration = new Enumeration(name) { SerializeAsString = true };
            return enumeration;
        }

        private static Enumeration CreateEnumeration([CallerFilePath] string filePath = null)
        {
            var name = Path.GetFileNameWithoutExtension(filePath);
            var enumeration = new Enumeration(name) { SerializeAsString = false };
            return enumeration;
        }

        private static EntityBuilder CreateEntity(Action<Entity> configure, [CallerFilePath] string filePath = null)
        {
            var name = Path.GetFileNameWithoutExtension(filePath);
            var enumeration = new EntityBuilder(name, configure);
            return enumeration;
        }
    }
}
