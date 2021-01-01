using System.IO;
using System.Linq;
using System.Text;
using Meziantou.Framework;
using Meziantou.Framework.CodeDom;

namespace Meziantou.GitLabClient.Generator.Internals
{
    internal static class Helpers
    {
        public static void WriteUnit(this CompilationUnit unit, FullPath path)
        {
            using var ms = new MemoryStream();
            using (var writer = new StreamWriter(ms, Encoding.UTF8))
            {
                new CSharpCodeGenerator().Write(writer, unit);
            }

            var bytes = ms.ToArray();
            if (File.Exists(path))
            {
                var existingBytes = File.ReadAllBytes(path);
                if (bytes.SequenceEqual(existingBytes))
                    return;
            }

            File.WriteAllBytes(path, bytes);
        }
    }
}
