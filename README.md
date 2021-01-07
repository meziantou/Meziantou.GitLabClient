# Meziantou.GitLabClient

[![NuGet](https://img.shields.io/nuget/v/Meziantou.GitLabClient.svg)](https://www.nuget.org/packages/Meziantou.GitLabClient/)
[![GitHub license](https://img.shields.io/github/license/meziantou/Meziantou.GitLabClient.svg)](https://github.com/meziantou/Meziantou.GitLabClient/blob/master/LICENSE)

.NET client for GitLab API. Support .NET Standard 2.0.

# How to install

Install the NuGet package [`Meziantou.GitLabCLient`](https://www.nuget.org/packages/Meziantou.GitLabClient/)

# How to use

Lots of methods are included in the client and accessible through `GitLabClient`:

````csharp
using(var client = GitLabClient.Create("https://gitlab.com", personalAccessToken))
{
    var projects = await client.Projects.GetAllAsync().ToListAsync();
}
````

Even if a property is not directly exposed, you can access it using the `dynamic` type:

````csharp
using(var client = GitLabClient.Create("https://gitlab.com", personalAccessToken))
{
    dynamic result = await client.Get<GitLabObject>("repository/new-method");
    string value = result.json_property_name;
}
````
