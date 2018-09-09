using System.Threading.Tasks;

namespace Meziantou.GitLabClient.Generator
{
    internal partial class Program
    {
        public static bool MustGenerateEmoji => false;

        private static async Task Main()
        {
            if (MustGenerateEmoji)
            {
                await new EmojiGenerator().Generate();
            }

            new GitLabClientGenerator().Generate();
        }
    }
}
