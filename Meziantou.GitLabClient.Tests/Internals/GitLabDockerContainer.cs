using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom.Events;
using AngleSharp.Dom.Html;
using AngleSharp.Services;
using Docker.DotNet;
using Docker.DotNet.Models;
using Meziantou.Framework;
using Meziantou.Framework.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    public class GitLabDockerContainer
    {
        public string ContainerName { get; set; } = "MeziantouGitLabClientTests";
        public int HttpPort { get; set; } = 8080;
        public int HttpsPort { get; set; } = 4433;
        public string AdminUserName { get; set; } = "root";
        public string AdminPassword { get; set; } = "dLpwdrZ9";

        public string GitLabUrl => "http://localhost:" + HttpPort;

        public string AdminToken { get; set; }

        public async Task Setup()
        {
            await SpawnDockerContainer();
            await GenerateToken();
        }

        private async Task SpawnDockerContainer()
        {
            using (var conf = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine")))
            using (var client = conf.CreateClient())
            {
                var containers = await client.Containers.ListContainersAsync(new ContainersListParameters() { All = true }).ConfigureAwait(false);
                var gitLabContainer = containers.FirstOrDefault(c => c.Names.Contains("/" + ContainerName));
                if (gitLabContainer == null)
                {
                    var arguments = CommandLineBuilder.WindowsQuotedArguments(
                        "run",
                        "--hostname", "localhost",
                        "--publish", HttpsPort + ":443", "--publish", HttpPort + ":80", "--publish", "2222:22",
                        "--name", ContainerName,
                        "--restart", "always",
                        "--volume", "/data/gitlab/config:/etc/gitlab",
                        "--volume", "/data/gitlab/logs:/var/log/gitlab",
                        "--volume", "/data/gitlab/data:/var/opt/gitlab",
                        "-e", "POSTGRES_ENV_POSTGRES_USER=user_postgres",
                        "-d",
                        "gitlab/gitlab-ce:latest");

                    var result = await ProcessExtensions.RunAsTask("docker", arguments).ConfigureAwait(false);
                    Assert.AreEqual(0, result.ExitCode);
                }

                // Wait for the container to be ready
                await WaitForGitLabServer().ConfigureAwait(false);
            }
        }

        private async Task WaitForGitLabServer()
        {
            using (var httpClient = new HttpClient())
            {
                while (true)
                {
                    try
                    {
                        using (var response = await httpClient.GetAsync(GitLabUrl))
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

        private async Task GenerateToken()
        {
            var conf = Configuration.Default
              .WithDefaultLoader(setup =>
              {
                  setup.IsNavigationEnabled = true;
                  setup.IsResourceLoadingEnabled = true;
              })
              .With(new MemoryCookieProvider())
              .WithLocaleBasedEncoding();

            var context = BrowsingContext.New(conf);
            context.Requesting += (sender, e) => Console.WriteLine("Requesting " + ((RequestEvent)e).Request.Address);

            // Change password
            var result = await context.OpenAsync(GitLabUrl);
            if (result.Location.PathName == "/users/password/edit")
            {
                var form = result.Forms["new_user"];
                ((IHtmlInputElement)form["user[password]"]).Value = AdminPassword;
                ((IHtmlInputElement)form["user[password_confirmation]"]).Value = AdminPassword;
                result = await form.SubmitAsync().ConfigureAwait(false);
            }

            // Login
            if (result.Location.PathName == "/users/sign_in")
            {
                var form = result.Forms["new_user"];
                ((IHtmlInputElement)form["user[login]"]).Value = AdminUserName;
                ((IHtmlInputElement)form["user[password]"]).Value = AdminPassword;
                result = await form.SubmitAsync().ConfigureAwait(false);
            }

            // Create a token
            if (result.Location.PathName == "/")
            {
                result = await context.OpenAsync(GitLabUrl + "/profile/personal_access_tokens");
                var form = result.Forms["new_personal_access_token"];
                ((IHtmlInputElement)form["personal_access_token[name]"]).Value = $"GitLabClientTest-{DateTime.Now:yyyyMMdd-HHmmss}";
                foreach (var element in form.Elements.OfType<IHtmlInputElement>().Where(e => e.Name == "personal_access_token[scopes][]"))
                {
                    element.IsChecked = true;
                }

                result = await form.SubmitAsync().ConfigureAwait(false);

                AdminToken = result.GetElementById("created-personal-access-token").GetAttribute("value");
            }
        }

        private class MemoryCookieProvider : ICookieProvider
        {
            public CookieContainer Container { get; } = new CookieContainer();

            public string GetCookie(string origin)
            {
                if (origin == null)
                    return null;

                return Container.GetCookieHeader(new Uri(origin));
            }

            public void SetCookie(string origin, string value)
            {
                var cookies = Sanatize(value);
                Container.SetCookies(new Uri(origin), cookies);
            }

            private static string Sanatize(string cookie)
            {
                var expires = "expires=";
                var start = 0;

                while (start < cookie.Length)
                {
                    var index = cookie.IndexOf(expires, start, StringComparison.OrdinalIgnoreCase);

                    if (index != -1)
                    {
                        var position = index + expires.Length;
                        var end = cookie.IndexOfAny(new[] { ';', ',' }, position + 4);

                        if (end == -1)
                        {
                            end = cookie.Length;
                        }

                        var front = cookie.Substring(0, position);
                        var middle = cookie.Substring(position, end - position);
                        var back = cookie.Substring(end);
                        var utc = DateTime.Now;

                        if (DateTime.TryParse(middle.Replace("UTC", "GMT"), out utc))
                        {
                            var time = utc.ToString("ddd, dd MMM yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            cookie = front + time + back;
                        }

                        start = end;
                    }
                    else
                    {
                        break;
                    }
                }

                return cookie;
            }
        }
    }
}
