using System.Threading.Tasks;

namespace Meziantou.GitLabClient.Generator
{
    internal static partial class Program
    {
        private static async Task Main()
        {
            await Task.WhenAll(
                Task.Run(() => new GitLabClientGenerator().Generate()),
                Task.Run(() => EmojiGenerator.Generate())
                );
        }
    }
}
