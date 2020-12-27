using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Html.Dom;
using AngleSharp.Io;
using Docker.DotNet;
using Docker.DotNet.Models;
using Meziantou.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    public class GitLabDockerContainer
    {
        public const string ContainerName = "MeziantouGitLabClientTests";
        public const string ImageName = "gitlab/gitlab-ee";
        public const string ImageTag = "13.2.4-ee.0"; // Keep in sync with azure-pipelines.yml

        public int HttpPort { get; } = 48624;
        public string AdminUserName { get; } = "root";
        public string AdminPassword { get; } = "Pa$$w0rd";

        public Uri GitLabUrl => new Uri("http://localhost:" + HttpPort.ToStringInvariant());

        public GitLabCredential Credentials { get; set; }

        public async Task SetupAsync()
        {
            await SpawnDockerContainerAsync().ConfigureAwait(false);
            await LoadCredentialsAsync();
            if (Credentials == null)
            {
                await GenerateAdminTokenAsync().ConfigureAwait(false);
                await PersistCredentialsAsync();
            }
        }

        private async Task SpawnDockerContainerAsync()
        {
            // Check if the container is accessible?
            try
            {
                using var httpClient = new HttpClient();
                var result = await httpClient.GetStringAsync(GitLabUrl).ConfigureAwait(false);
                Console.WriteLine(result);
                return;
            }
            catch
            {
                // Not on Azure Pipelines
            }

            // Spawn the container
            // https://docs.gitlab.com/omnibus/settings/configuration.html
            using var conf = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine"));
            using var client = conf.CreateClient();
            var containers = await client.Containers.ListContainersAsync(new ContainersListParameters() { All = true }).ConfigureAwait(false);
            var container = containers.FirstOrDefault(c => c.Names.Contains("/" + ContainerName));
            if (container == null)
            {
                // Download GitLab images
                await client.Images.CreateImageAsync(new ImagesCreateParameters() { FromImage = ImageName, Tag = ImageTag }, new AuthConfig() { }, new Progress<JSONMessage>()).ConfigureAwait(false);

                // Create the container
                var hostConfig = new HostConfig()
                {
                    PortBindings = new Dictionary<string, IList<PortBinding>>(StringComparer.Ordinal)
                    {
                        { "80/tcp", new List<PortBinding> { new PortBinding { HostIP = "127.0.0.1", HostPort = HttpPort.ToString(CultureInfo.InvariantCulture) } } },
                    },
                };

                var response = await client.Containers.CreateContainerAsync(new CreateContainerParameters()
                {
                    Hostname = "localhost",
                    Image = ImageName + ":" + ImageTag,
                    Name = ContainerName,
                    Tty = false,
                    HostConfig = hostConfig,
                }).ConfigureAwait(false);

                containers = await client.Containers.ListContainersAsync(new ContainersListParameters() { All = true }).ConfigureAwait(false);
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

        private async Task WaitForContainerAsync()
        {
            using var httpClient = new HttpClient();
            while (true)
            {
                try
                {
                    using var response = await httpClient.GetAsync(GitLabUrl).ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                        break;
                }
                catch
                {
                }
            }
        }

        private async Task GenerateAdminTokenAsync()
        {
            var credentials = new GitLabCredential();

            var conf = Configuration.Default
              .WithDefaultLoader(new LoaderOptions
              {
                  IsNavigationDisabled = false,
                  IsResourceLoadingEnabled = true,
                  Filter = request => { Console.WriteLine("Requesting " + request.Address); return true; },
              })
              .WithDefaultCookies()
              .WithLocaleBasedEncoding();

            using var context = BrowsingContext.New(conf);

            // Change password
            var result = await context.OpenAsync(GitLabUrl.AbsoluteUri).ConfigureAwait(false);
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
                ((IHtmlInputElement)form["personal_access_token[name]"]).Value = $"GitLabClientTest-" + DateTime.UtcNow.ToString("yyyyMMdd-HHmmss", CultureInfo.InvariantCulture);
                foreach (var element in form.Elements.OfType<IHtmlInputElement>().Where(e => e.Name == "personal_access_token[scopes][]"))
                {
                    element.IsChecked = true;
                }

                result = await form.SubmitAsync();

                credentials.AdminUserToken = result.GetElementById("created-personal-access-token").GetAttribute("value");
            }

            // Get X-Profile-Token
            result = await context.OpenAsync(GitLabUrl + "/admin/requests_profiles");
            var codeElements = result.QuerySelectorAll("code").ToList();
            var tokenElement = codeElements.Single(n => n.TextContent.StartsWith("X-Profile-Token:", StringComparison.Ordinal));
            credentials.ProfileToken = tokenElement.TextContent["X-Profile-Token:".Length..].Trim();

            // Get admin login cookie
            //result.Cookie:  experimentation_subject_id=XXX; _gitlab_session=XXXX; known_sign_in=XXXX
            credentials.Cookies = result.Cookie.Split(';').Select(part => part.Trim()).Single(part => part.StartsWith("_gitlab_session=", StringComparison.Ordinal))["_gitlab_session=".Length..];

            Credentials = credentials;
        }

        private async Task PersistCredentialsAsync()
        {
            var path = GetCredentialsFilePath();
            IOUtilities.PathCreateDirectory(path);
            var json = JsonSerializer.Serialize(Credentials);
            await File.WriteAllTextAsync(path, json);
        }

        private async Task LoadCredentialsAsync()
        {
            var file = GetCredentialsFilePath();
            if (File.Exists(file))
            {
                var json = await File.ReadAllTextAsync(file);
                var credentials = JsonSerializer.Deserialize<GitLabCredential>(json);

                using var client = GitLabClient.Create(GitLabUrl, credentials.AdminUserToken);

                try
                {
                    var user = await client.Users.GetCurrentUserAsync();
                    Credentials = credentials;
                }
                catch (GitLabException ex) when (ex.HttpStatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                }
            }
        }

        private static FullPath GetCredentialsFilePath()
        {
            return FullPath.GetTempPath() / "Meziantou.GitLabClient" / "credentials.json";
        }
    }
}
