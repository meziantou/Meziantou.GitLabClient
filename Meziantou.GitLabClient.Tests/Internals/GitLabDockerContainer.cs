using System;
using System.Collections.Generic;
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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    public class GitLabDockerContainer
    {
        public const string ContainerName = "MeziantouGitLabClientTests";
        public const string ImageName = "gitlab/gitlab-ee";
        public const string ImageTag = "latest";

        public int HttpPort { get; } = 8080;
        public string AdminUserName { get; } = "root";
        public string AdminPassword { get; } = "Pa$$w0rd";

        public string GitLabUrl => "http://localhost:" + HttpPort;

        public string AdminUserToken { get; private set; }
        public string ProfileToken { get; private set; }

        public async Task Setup()
        {
            await SpawnDockerContainer();
            await GenerateAdminTokenAsync();
        }

        private async Task SpawnDockerContainer()
        {
            using (var conf = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine")))
            using (var client = conf.CreateClient())
            {
                var containers = await client.Containers.ListContainersAsync(new ContainersListParameters() { All = true });
                var container = containers.FirstOrDefault(c => c.Names.Contains("/" + ContainerName));
                if (container == null)
                {
                    // Download GitLab images
                    await client.Images.CreateImageAsync(new ImagesCreateParameters() { FromImage = ImageName, Tag = ImageTag }, new AuthConfig() { }, new Progress<JSONMessage>());

                    // Create the container
                    var hostConfig = new HostConfig()
                    {
                        PortBindings = new Dictionary<string, IList<PortBinding>>
                        {
                            { "80/tcp", new List<PortBinding> { new PortBinding { HostIP = "127.0.0.1", HostPort = HttpPort.ToString(CultureInfo.InvariantCulture) } } },
                        }
                    };

                    var response = await client.Containers.CreateContainerAsync(new CreateContainerParameters()
                    {
                        Hostname = "localhost",
                        Image = ImageName + ":" + ImageTag,
                        Name = ContainerName,
                        Tty = false,
                        HostConfig = hostConfig,
                    });

                    containers = await client.Containers.ListContainersAsync(new ContainersListParameters() { All = true });
                    container = containers.First(c => c.ID == response.ID);
                }

                // Start the container
                if (container.State != "running")
                {
                    var started = await client.Containers.StartContainerAsync(container.ID, new ContainerStartParameters());
                    if (!started)
                    {
                        Assert.Fail("Cannot start the docker container");
                    }
                }

                // Wait for the container to be ready
                await WaitForContainerAsync();
            }
        }

        private async Task WaitForContainerAsync()
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

        private async Task GenerateAdminTokenAsync()
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
                result = await form.SubmitAsync();
            }

            // Login
            if (result.Location.PathName == "/users/sign_in")
            {
                var form = result.Forms["new_user"];
                ((IHtmlInputElement)form["user[login]"]).Value = AdminUserName;
                ((IHtmlInputElement)form["user[password]"]).Value = AdminPassword;
                result = await form.SubmitAsync();
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

                result = await form.SubmitAsync();

                AdminUserToken = result.GetElementById("created-personal-access-token").GetAttribute("value");
            }

            // Get X-Profile-Token
            result = await context.OpenAsync(GitLabUrl + "/admin/requests_profiles");
            var codeElements = result.QuerySelectorAll("code").ToList();
            var tokenElement = codeElements.Single(n => n.TextContent.StartsWith("X-Profile-Token:"));
            ProfileToken = tokenElement.TextContent.Substring("X-Profile-Token:".Length).Trim();
        }

        // TODO remove when resolved https://github.com/AngleSharp/AngleSharp/issues/702
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
                const string Expires = "expires=";
                var start = 0;

                while (start < cookie.Length)
                {
                    var index = cookie.IndexOf(Expires, start, StringComparison.OrdinalIgnoreCase);

                    if (index != -1)
                    {
                        var position = index + Expires.Length;
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
