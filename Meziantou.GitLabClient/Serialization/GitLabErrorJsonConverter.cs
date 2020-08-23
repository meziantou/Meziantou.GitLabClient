using System.Text.Json;

namespace Meziantou.GitLab.Serialization
{
    internal sealed class GitLabErrorJsonConverter : GitLabObjectBaseJsonConverter<GitLabError>
    {
        protected override GitLabError CreateInstance(JsonElement jsonElement)
        {
            return new GitLabError(jsonElement);
        }
    }
}
