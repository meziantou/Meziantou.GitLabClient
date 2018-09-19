# Meziantou.GitLabClient

[![NuGet](https://img.shields.io/nuget/v/Meziantou.GitLabClient.svg)](https://www.nuget.org/packages/Meziantou.GitLabClient/)
[![Build Status](https://meziantou.visualstudio.com/GitHub%20projects/_apis/build/status/meziantou.Meziantou.GitLabClient)](https://meziantou.visualstudio.com/GitHub%20projects/_build/latest?definitionId=37)

.NET client for GitLab API. Support .NET Standard 2.0.

# How to install

Install the NuGet package [`Meziantou.GitLabCLient`](https://www.nuget.org/packages/Meziantou.GitLabClient/)

# How to use

Lots of methods are included in the client and accessible through `GitLabClient`:

````csharp
using(var client = new GitLabClient("https://gitlab.com", personalAccessToken))
{
    var projects = await client.GetProjectsAsync();
}
````

Even if the method is not directly exposed, you can use it:

````csharp
using(var client = new GitLabClient("https://gitlab.com", personalAccessToken))
{
    var result = await client.Get<GitLabObject>("repository/new-method");
    var id = result.GetValueOrdefault("id", 0);
}
````
