# Meziantou.GitLabClient

.NET client for GitLab API

NuGet: `Meziantou.GitLabCLient`

````csharp
using(var client = new GitLabClient("https://gitlab.com", token))
{
    var projects = await client.GetProjectsAsync(); 
}
````
