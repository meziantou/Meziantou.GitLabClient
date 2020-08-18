using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Meziantou.GitLab.Core;

namespace Meziantou.GitLab
{
    public partial interface IRawGitLabClient
    {
        Task<T?> GetAsync<T>(string url, RequestOptions? options, CancellationToken cancellationToken = default)
    where T : GitLabObject;

        Task<IReadOnlyList<T>> GetCollectionAsync<T>(string url, RequestOptions? options, CancellationToken cancellationToken = default)
            where T : GitLabObject;

        Task<T?> PostJsonAsync<T>(string url, object data, RequestOptions? options, CancellationToken cancellationToken = default)
            where T : GitLabObject;

        Task<T?> PutJsonAsync<T>(string url, object data, RequestOptions? options, CancellationToken cancellationToken = default)
            where T : GitLabObject;

        Task DeleteAsync(string url, RequestOptions? options, CancellationToken cancellationToken = default);

        Task<GitLabPageResponse<T>> GetPagedCollectionAsync<T>(string url, RequestOptions? options, CancellationToken cancellationToken = default)
            where T : GitLabObject;
    }
}
