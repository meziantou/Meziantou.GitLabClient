using System;
using System.IO;
using System.Threading.Tasks;
using Meziantou.Framework;
using Meziantou.GitLabClient.Generator.GitLabModels;
using Meziantou.GitLabClient.Generator.Graphql;
using Meziantou.GitLabClient.Generator.Internals;

namespace Meziantou.GitLabClient.Generator
{
    internal static partial class Program
    {
        private static async Task Main(string[] args)
        {
            var noCache = args.ContainsIgnoreCase("/nocache");
            var directory = FullPath.FromPath("../../../../Meziantou.GitLabClient");
            var coverageOutputFile = FullPath.FromPath("../../../../../docs/coverage.md");
            Console.WriteLine("Generating files to " + directory);
            Console.WriteLine("Generating overage file to " + coverageOutputFile);

            var model = GitLabModelBuilder.Create();
            var documentation = await GitLabDocumentationResource.LoadResourcesAsync(noCache);
            model.Merge(documentation);

            await Task.WhenAll(
                Task.Run(() => EmojiGenerator.GenerateAsync(directory)),
                Task.Run(() => new GitLabClientGenerator().Generate(directory, model)),
                Task.Run(() => GenerateApiCoverage()),
                Task.Run(() => GraphqlGenerator.GenerateAsync(directory, noCache))
                );

            async Task GenerateApiCoverage()
            {
                var markdown = ApiCoverage.GetMarkdown(model, documentation);
                IOUtilities.PathCreateDirectory(coverageOutputFile);
                await File.WriteAllTextAsync(coverageOutputFile, markdown);
            }
        }
    }
}
