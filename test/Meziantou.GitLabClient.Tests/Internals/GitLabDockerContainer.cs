using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using AngleSharp.Io;
using Docker.DotNet;
using Docker.DotNet.Models;
using Meziantou.Framework;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    public class GitLabDockerContainer
    {
        private const string LicenseName = "GITLAB_LICENSEFILE";

        public const string ContainerName = "MeziantouGitLabClientTests";
        public const string ImageName = "gitlab/gitlab-ee";
        public const string ImageTag = "13.7.1-ee.0"; // Keep in sync with .github/workflows/ci.yml

        public int HttpPort { get; } = 48624;
        public string AdminUserName { get; } = "root";
        public string AdminPassword { get; } = "Pa$$w0rd";
        public string LicenseFile { get; set; }

        public Uri GitLabUrl => new("http://localhost:" + HttpPort.ToStringInvariant());

        public GitLabCredential Credentials { get; set; }

        public async Task SetupAsync()
        {
            if (string.IsNullOrWhiteSpace(LicenseFile))
            {
                LicenseFile = Environment.GetEnvironmentVariable(LicenseName);
            }

            await SpawnDockerContainerAsync().ConfigureAwait(false);
            await LoadCredentialsAsync();
            if (Credentials == null)
            {
                await GenerateAdminTokenAsync().ConfigureAwait(false);
                await PersistCredentialsAsync();
            }

            // Check license (could we generate a new one automatically?)
            using var client = GitLabClient.Create(GitLabUrl, Credentials.AdminUserToken);
            var currentLicense = await client.License.GetCurrentLicenseAsync();
            if (currentLicense == null)
            {
                if (string.IsNullOrEmpty(LicenseFile))
                {
                    await CreateTrialLicenseAsync();
                }

                if (!string.IsNullOrEmpty(LicenseFile))
                {
                    currentLicense = await client.License.AddLicenseAsync(LicenseFile);
                    if (currentLicense.Expired)
                    {
                        Assert.Fail("The license is invalid");
                    }
                }
            }
        }

        private static bool IsContinuousIntegration()
        {
            return Environment.GetEnvironmentVariable("GITHUB_ACTIONS") == "true";
        }

        private async Task SpawnDockerContainerAsync()
        {
            // Check if the container is accessible?
            var isContinuousIntegration = IsContinuousIntegration();
            try
            {
                using var httpClient = new HttpClient();
                var result = await httpClient.GetStringAsync(GitLabUrl).ConfigureAwait(false);
                if (isContinuousIntegration) // When not on CI, we want to check the container is on the expected version
                    return;
            }
            catch
            {
                if (isContinuousIntegration)
                    throw new InvalidOperationException("The GitLab service is not accessible. Please check the CI configuration.");
            }

            // Spawn the container
            // https://docs.gitlab.com/omnibus/settings/configuration.html
            using var conf = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine"));
            using var client = conf.CreateClient();
            var containers = await client.Containers.ListContainersAsync(new ContainersListParameters() { All = true }).ConfigureAwait(false);
            var container = containers.FirstOrDefault(c => c.Names.Contains("/" + ContainerName));
            if (container != null)
            {
                var inspect = await client.Containers.InspectContainerAsync(container.ID);
                var inspectImage = await client.Images.InspectImageAsync(ImageName + ":" + ImageTag);
                if (inspect.Image != inspectImage.ID)
                {
                    await client.Containers.RemoveContainerAsync(container.ID, new ContainerRemoveParameters() { Force = true });
                    container = null;
                }
            }

            if (container == null)
            {
                // Download GitLab images
                await client.Images.CreateImageAsync(new ImagesCreateParameters() { FromImage = ImageName, Tag = ImageTag }, new AuthConfig() { }, new Progress<JSONMessage>()).ConfigureAwait(false);

                // Create the container
                var hostConfig = new HostConfig()
                {
                    PortBindings = new Dictionary<string, IList<PortBinding>>(StringComparer.Ordinal)
                    {
                        {  HttpPort.ToStringInvariant() + "/tcp", new List<PortBinding> { new PortBinding { HostPort = HttpPort.ToStringInvariant() } } },
                    },
                };

                var response = await client.Containers.CreateContainerAsync(new CreateContainerParameters()
                {
                    Hostname = "localhost",
                    Image = ImageName + ":" + ImageTag,
                    Name = ContainerName,
                    Tty = false,
                    HostConfig = hostConfig,
                    ExposedPorts = new Dictionary<string, EmptyStruct>(StringComparer.Ordinal)
                    {
                        { HttpPort.ToStringInvariant() + "/tcp", new EmptyStruct() },
                    },
                    Env = new List<string>
                    {
                        "GITLAB_OMNIBUS_CONFIG=external_url 'http://localhost:" + HttpPort.ToStringInvariant() + "/'",
                    },
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

            // Wait for the container to be ready.
            while (true)
            {
                var status = await client.Containers.InspectContainerAsync(container.ID);
                if (!status.State.Running)
                    throw new InvalidOperationException($"Container '{status.ID}' is not running");

                var healthState = status.State.Health.Status;
                if (healthState == "starting" || healthState == "unhealthy") // unhealthy is valid as long as the container is running as it may indicate a slow creation
                {
                    await Task.Delay(3000);
                }
                else if (healthState == "healthy")
                {
                    // A healthy container doesn't mean the service is actually running.
                    // GitLab has lots of configuration steps that are still running when the container is healthy.
                    using var httpClient = new HttpClient();
                    try
                    {
                        using var response = await httpClient.GetAsync(GitLabUrl).ConfigureAwait(false);
                        if (response.IsSuccessStatusCode)
                            break;
                    }
                    catch
                    {
                    }

                    await Task.Delay(3000);
                }
                else
                {
                    throw new InvalidOperationException($"Container status '{healthState}' is not supported");
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
                ((IHtmlInputElement)form["user[remember_me]"]).IsChecked = true;
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
                    // Validate token
                    var user = await client.Users.GetCurrentUserAsync();

                    using var httpClient = new HttpClient()
                    {
                        BaseAddress = GitLabUrl,
                        DefaultRequestHeaders =
                        {
                            { "Cookie", "_gitlab_session=" + credentials.Cookies },
                        },
                    };
                    var response = await httpClient.GetAsync("/");
                    if (response.RequestMessage.RequestUri.PathAndQuery == "/users/sign_in")
                        return;

                    // Validate cookie
                    Credentials = credentials;
                }
                catch (GitLabException ex) when (ex.HttpStatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                }
            }
        }

        private async Task CreateTrialLicenseAsync()
        {

            var email = $"test_{Guid.NewGuid():N}@yopmail.com";
            var id = Convert.ToBase64String(Encoding.UTF8.GetBytes(email));

            // Generate key
            using var handler = new HttpClientHandler() { AllowAutoRedirect = false, AutomaticDecompression = System.Net.DecompressionMethods.All, CheckCertificateRevocationList = false };
#pragma warning disable CA5399 // HttpClients should enable certificate revocation list checks
            using var httpClient = new HttpClient(handler);
#pragma warning restore CA5399
            var result = await httpClient.GetStringAsync($"https://customers.gitlab.com/trials/new?return_to={Uri.EscapeDataString(GitLabUrl.ToString())}&id={id}");
            var document = await new HtmlParser().ParseDocumentAsync(result);

            var token = ((IHtmlInputElement)document.Forms["new_trial_user"]["authenticity_token"]).Value;
            using var requestContent = new FormUrlEncodedContent(new[]
            {
                KeyValuePair.Create("utf8", "✓"),
                KeyValuePair.Create("trial_user[authenticity_token]", token),
                KeyValuePair.Create("trial_user[requested_email]", email),
                KeyValuePair.Create("trial_user[first_name]", "a"),
                KeyValuePair.Create("trial_user[last_name]", "a"),
                KeyValuePair.Create("trial_user[work_email]", email),
                KeyValuePair.Create("trial_user[company_name]", "a"),
                KeyValuePair.Create("trial_user[company_size]", "1-99"),
                KeyValuePair.Create("trial_user[phone_number]", "000000000"),
                KeyValuePair.Create("trial_user[number_of_users]", "1"),
                KeyValuePair.Create("trial_user[country]", "AF"),
                KeyValuePair.Create("trial_user[return_to]", GitLabUrl.ToString()),
            });

            using var request = new HttpRequestMessage(System.Net.Http.HttpMethod.Post, "https://customers.gitlab.com/trials")
            {
                Content = requestContent,
            };

            using var response = await httpClient.SendAsync(request);
            var href = QueryHelpers.ParseNullableQuery(response.Headers.Location.Query);
            if (href != null && href.TryGetValue("trial_key", out var value))
            {
                var key = value[0];
                LicenseFile = key;

                if (!IsContinuousIntegration())
                {
                    Environment.SetEnvironmentVariable(LicenseName, LicenseFile, EnvironmentVariableTarget.User);
                }
            }
        }

        private static FullPath GetCredentialsFilePath()
        {
            return FullPath.GetTempPath() / "Meziantou.GitLabClient" / "credentials.json";
        }
    }
}
