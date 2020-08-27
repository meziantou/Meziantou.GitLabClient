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
                var outputFile = FullPath.FromPath("../../../../../docs/coverage.md");
                if (args.Length > 1)
                {
                    outputFile = FullPath.FromPath(args[1]);
                }

                Console.WriteLine("Generating file " + outputFile);
                IOUtilities.PathCreateDirectory(outputFile);
                await File.WriteAllTextAsync(outputFile, markdown);
            }
            else
            {
                var directory = FullPath.FromPath("../../../../Meziantou.GitLabClient");
                if (args.Length > 0)
                {
                    directory = FullPath.FromPath(args[0]);
                }

                Console.WriteLine("Generating files to " + directory);
                await Task.WhenAll(
                    Task.Run(() => new GitLabClientGenerator().Generate(directory)),
                    Task.Run(() => EmojiGenerator.GenerateAsync(directory))
                    );
            }
        }
    }
}
