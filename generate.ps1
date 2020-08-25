$GeneratorPath = Join-Path  $PSScriptRoot src Meziantou.GitLabClient.Generator
$OutputPath = Join-Path  $PSScriptRoot src Meziantou.GitLabClient
$DocumentationPath = Join-Path  $PSScriptRoot docs coverage.md
Write-Output $GeneratorPath $OutputPath
dotnet run --project $GeneratorPath -- $OutputPath
dotnet run --project $GeneratorPath -- documentation $DocumentationPath
