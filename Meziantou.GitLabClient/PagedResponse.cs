using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Meziantou.GitLab.Core;

namespace Meziantou.GitLab
{
    // TODO Add options
    public sealed class PagedResponse<T> : IAsyncEnumerable<T>
        where T : GitLabObject
    {
        private readonly string _initialUrl;
        private readonly RequestOptions? _options;

        public GitLabClient Client { get; }

        internal PagedResponse(GitLabClient client, string initialUrl, RequestOptions? options)
        {
            Client = client;
            _initialUrl = initialUrl;
            _options = options;
        }

        public async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            var url = _initialUrl;
            var page = await Client.GetPagedCollectionAsync<T>(url, _options, cancellationToken).ConfigureAwait(false);
            do
            {
                foreach (var item in page.Data)
                {
                    yield return item;
                }
            } while ((page = await page.GetNextPageAsync(_options, cancellationToken).ConfigureAwait(false)) != null);
        }

        public async Task<IReadOnlyList<T>> ToListAsync(CancellationToken cancellationToken = default)
        {
            // TODO optimize with TotalItems header if possible
            var list = new List<T>();
            await foreach (var item in this.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                list.Add(item);
            }

            return list;
        }
    }
}
