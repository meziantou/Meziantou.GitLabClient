using System;
using System.IO;
using System.Threading.Tasks;
using AngleSharp.Text;
using Meziantou.Framework;

namespace Meziantou.GitLabClient.Generator
{
    internal static partial class Program
    {
        private static async Task Main(string[] args)
        {
            if (args.Contains("documentation"))
            {
                var markdown = await ApiCoverage.GetMarkdownAsync();
                if (args.Length == 2)
                {
                    var outputPath = args[1];
                    IOUtilities.PathCreateDirectory(outputPath);
                    await File.WriteAllTextAsync(outputPath, markdown);
                }
                else
                {
                    Console.WriteLine(markdown);
                }
            }
            else
            {
                var directory = FullPath.FromPath("../../../../Meziantou.GitLabClient");
                if (args.Length > 0)
                {
                    directory = FullPath.FromPath(args[0]);
                }

                await Task.WhenAll(
                    Task.Run(() => new GitLabClientGenerator().Generate(directory)),
                    Task.Run(() => EmojiGenerator.GenerateAsync(directory))
                    );
            }
        }
    }
}
