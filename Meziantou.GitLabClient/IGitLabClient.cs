using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Meziantou.GitLab
{
    public partial interface IGitLabClient : IDisposable
    {
        Task<T> GetAsync<T>(string url, RequestOptions options, CancellationToken cancellationToken) where T : GitLabObject;
        Task<IReadOnlyList<T>> GetCollectionAsync<T>(string url, RequestOptions options, CancellationToken cancellationToken) where T : GitLabObject;
        Task<T> PostJsonAsync<T>(string url, object data, RequestOptions options, CancellationToken cancellationToken) where T : GitLabObject;
        Task<T> PutJsonAsync<T>(string url, object data, RequestOptions options, CancellationToken cancellationToken) where T : GitLabObject;
        Task DeleteAsync(string url, RequestOptions options, CancellationToken cancellationToken);
        Task<GitLabPageResponse<T>> GetPagedAsync<T>(string url, RequestOptions options, CancellationToken cancellationToken) where T : GitLabObject;
    }
}
