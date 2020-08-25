using System.Text.Json;
using Meziantou.GitLab.Core;

namespace Meziantou.GitLab.Serialization
{
    internal sealed class GitLabObjectJsonConverter : GitLabObjectBaseJsonConverter<GitLabObject>
    {
        protected override GitLabObject CreateInstance(JsonElement jsonElement)
        {
            return new GitLabObject(jsonElement);
        }
    }
}
