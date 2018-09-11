# Meziantou.GitLabClient

.NET client for GitLab API

NuGet: [Meziantou.GitLabCLient](https://www.nuget.org/packages/Meziantou.GitLabClient/)

````csharp
using(var client = new GitLabClient("https://gitlab.com", token))
{
    var projects = await client.GetProjectsAsync(); 
}
````
