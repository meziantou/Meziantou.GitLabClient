using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Dom.Events;
using AngleSharp.Dom.Html;
using Docker.DotNet;
using Docker.DotNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class Initialize
    {
        public static string GitLabServer { get; set; }
        public static string GitLabAdminUserName { get; set; }
        public static string GitLabAdminPassword { get; set; }
        
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            InitializeDocker().Wait();
        }

        private static async Task InitializeDocker()
        {
            await SpawnDockerContainer();
            await GenerateToken();
        }

        private static async Task SpawnDockerContainer()
        {
            const string DockerName = "MeziantouGitLabClientTests";

            var client = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine")).CreateClient();

            var containers = await client.Containers.ListContainersAsync(new ContainersListParameters() { All = true });
            var gitLabContainer = containers.FirstOrDefault(c => c.Names.Contains("/" + DockerName));
            if (gitLabContainer == null)
            {
                var arguments = Meziantou.Framework.CommandLineBuilder.WindowsQuotedArguments(
                    "run",
                    "--hostname", "localhost",
                    "--publish", "4433:443", "--publish", "8080:80", "--publish", "2222:22",
                    "--name", DockerName,
                    "--restart", "always",
                    "--volume", "/data/gitlab/config:/etc/gitlab",
                    "--volume", "/data/gitlab/logs:/var/log/gitlab",
                    "--volume", "/data/gitlab/data:/var/opt/gitlab",
                    "-e", "POSTGRES_ENV_POSTGRES_USER=user_postgres",
                    "-d",
                    "gitlab/gitlab-ce:latest");

                var result = await Meziantou.Framework.Utilities.ProcessExtensions.RunAsTask("docker", arguments);
                Assert.AreEqual(0, result.ExitCode);
            }

            // Wait for the container to be ready
            using (var httpClient = new HttpClient())
            {
                while (true)
                {
                    try
                    {
                        using (var response = await httpClient.GetAsync("http://localhost:8080"))
                        {
                            if (response.IsSuccessStatusCode)
                                break;
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        private static async Task GenerateToken()
        {
            var conf = Configuration.Default
              .WithDefaultLoader(setup =>
              {
                  setup.IsNavigationEnabled = true;
                  setup.IsResourceLoadingEnabled = true;
              })
              .WithCookies()
              .WithLocaleBasedEncoding();

            var context = BrowsingContext.New(conf);
            context.Requesting += (sender, e) => Console.WriteLine("Requesting " + ((RequestEvent)e).Request.Address);

            // Change password
            var result = await context.OpenAsync("http://localhost:8080");
            AssertPath(result, "/users/password/edit");
            var form = result.Forms["new_user"];
            ((IHtmlInputElement)form["user[password]"]).Value = "dLpwdrZ9";
            ((IHtmlInputElement)form["user[password_confirmation]"]).Value = "dLpwdrZ9";
            result = await form.SubmitAsync();

            // Login
            AssertPath(result, "/users/sign_in");
            form = result.Forms["new_user"];
            ((IHtmlInputElement)form["user[login]"]).Value = "root";
            ((IHtmlInputElement)form["user[password]"]).Value = "dLpwdrZ9";
            result = await form.SubmitAsync();

            // Create a token
            AssertPath(result, "/");
            result = await context.OpenAsync("http://localhost:8080/profile/personal_access_tokens");
            form = result.Forms["new_personal_access_token"];
            ((IHtmlInputElement)form["personal_access_token[name]"]).Value = $"GitLabClientTest-{DateTime.Now:yyyyMMdd-HHmmss}";
            foreach (var element in form.Elements.OfType<IHtmlInputElement>().Where(e => e.Name == "personal_access_token[scopes][]"))
            {
                element.IsChecked = true;
            }

            result = await form.SubmitAsync();
            Console.WriteLine(result.GetElementById("created-personal-access-token").GetAttribute("value"));
        }

        private static void AssertPath(IDocument document, string path)
        {
            if (document.Location.PathName == path)
                return;

            throw new Exception($"Expected url: {path}. Actual {document.Location.Href}");
        }
    }
}
