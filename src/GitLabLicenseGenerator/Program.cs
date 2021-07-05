using System;
using System.Threading.Tasks;
using Meziantou.GitLab.Tests;

namespace GitLabLicenseGenerator
{
    internal static class Program
    {
        private static async Task Main()
        {
            Console.WriteLine(await GitLabDockerContainer.CreateTrialLicenseAsync("http://localhost:48624").ConfigureAwait(false));
        }
    }
}
