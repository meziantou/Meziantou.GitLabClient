using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Meziantou.GitLab
{
    public class PagedResponse<T> : IAsyncEnumerable<T>
        where T : GitLabObject
    {
        private readonly string _initialUrl;
        private readonly RequestOptions _options;

        internal GitLabClient GitLabClient { get; }
        public GitLabClient Client { get; }

        internal PagedResponse(GitLabClient client, string initialUrl, RequestOptions options)
        {
            Client = client;
            _initialUrl = initialUrl;
            _options = options;
        }

        public async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            var url = _initialUrl;
            var page = await Client.GetPagedAsync<T>(url, _options, cancellationToken).ConfigureAwait(false);
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

    // TODO move to an subnamespace (Core) as it is not something a end-user should use directly
    public sealed class GitLabPageResponse<T>
        where T : GitLabObject
    {
        public int PageIndex { get; }
        public int PageSize { get; }
        public int TotalItems { get; }
        public int TotalPages { get; }
        private string PreviousPageUrl { get; }
        private string NextPageUrl { get; }
        private string FirstPageUrl { get; }
        private string LastPageUrl { get; }

        public bool IsLastPage => NextPageUrl == null;
        public bool IsFirstPage => PreviousPageUrl == null;

        internal GitLabClient GitLabClient { get; }
        public IReadOnlyList<T> Data { get; }

        internal GitLabPageResponse(GitLabClient client, IReadOnlyList<T> data, int pageIndex, int pageSize, int totalItems, int totalPages, string firstUrl, string lastUrl, string previousUrl, string nextUrl)
        {
            GitLabClient = client ?? throw new ArgumentNullException(nameof(client));
            Data = data ?? throw new ArgumentNullException(nameof(data));
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalItems = totalItems;
            TotalPages = totalPages;
            FirstPageUrl = firstUrl;
            LastPageUrl = lastUrl;
            PreviousPageUrl = previousUrl;
            NextPageUrl = nextUrl;
        }

        public ValueTask<GitLabPageResponse<T>> GetFirstPageAsync(RequestOptions options, CancellationToken cancellationToken = default)
        {
            if (FirstPageUrl == null)
            {
                return new ValueTask<GitLabPageResponse<T>>();
            }

            return new ValueTask<GitLabPageResponse<T>>(GitLabClient.GetPagedAsync<T>(FirstPageUrl, options, cancellationToken));
        }

        public ValueTask<GitLabPageResponse<T>> GetLastPageAsync(RequestOptions options, CancellationToken cancellationToken = default)
        {
            if (LastPageUrl == null)
            {
                return new ValueTask<GitLabPageResponse<T>>();
            }

            return new ValueTask<GitLabPageResponse<T>>(GitLabClient.GetPagedAsync<T>(LastPageUrl, options, cancellationToken));
        }

        public ValueTask<GitLabPageResponse<T>> GetPreviousPageAsync(RequestOptions options, CancellationToken cancellationToken = default)
        {
            if (PreviousPageUrl == null)
            {
                return new ValueTask<GitLabPageResponse<T>>();
            }

            return new ValueTask<GitLabPageResponse<T>>(GitLabClient.GetPagedAsync<T>(PreviousPageUrl, options, cancellationToken));
        }

        public ValueTask<GitLabPageResponse<T>> GetNextPageAsync(RequestOptions options, CancellationToken cancellationToken = default)
        {
            if (NextPageUrl == null)
            {
                return new ValueTask<GitLabPageResponse<T>>();
            }

            return new ValueTask<GitLabPageResponse<T>>(GitLabClient.GetPagedAsync<T>(NextPageUrl, options, cancellationToken));
        }
    }
}
