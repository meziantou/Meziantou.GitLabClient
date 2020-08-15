using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Meziantou.GitLab
{
    public class PagedResponse<T>
        where T : GitLabObject
        // TODO IAsyncEnumerable
    {
        private static readonly Task<bool> s_trueTask = Task.FromResult(true);

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

        internal PagedResponse(GitLabClient client, IReadOnlyList<T> data, int pageIndex, int pageSize, int totalItems, int totalPages, string firstUrl, string lastUrl, string previousUrl, string nextUrl)
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

        public Task<PagedResponse<T>> GetFirstPageAsync(CancellationToken cancellationToken = default)
        {
            return GetFirstPageAsync(default, cancellationToken);
        }

        public Task<PagedResponse<T>> GetFirstPageAsync(RequestOptions options, CancellationToken cancellationToken = default)
        {
            if (FirstPageUrl == null)
            {
                return Task.FromResult<PagedResponse<T>>(null);
            }

            return GitLabClient.GetPagedAsync<T>(FirstPageUrl, options, cancellationToken);
        }

        public Task<PagedResponse<T>> GetLastPageAsync(CancellationToken cancellationToken = default)
        {
            return GetLastPageAsync(default, cancellationToken);
        }

        public Task<PagedResponse<T>> GetLastPageAsync(RequestOptions options, CancellationToken cancellationToken = default)
        {
            if (LastPageUrl == null)
            {
                return Task.FromResult<PagedResponse<T>>(null);
            }

            return GitLabClient.GetPagedAsync<T>(LastPageUrl, options, cancellationToken);
        }

        public Task<PagedResponse<T>> GetPreviousPageAsync(CancellationToken cancellationToken = default)
        {
            return GetPreviousPageAsync(default, cancellationToken);
        }

        public Task<PagedResponse<T>> GetPreviousPageAsync(RequestOptions options, CancellationToken cancellationToken = default)
        {
            if (PreviousPageUrl == null)
            {
                return Task.FromResult<PagedResponse<T>>(null);
            }

            return GitLabClient.GetPagedAsync<T>(PreviousPageUrl, options, cancellationToken);
        }

        public Task<PagedResponse<T>> GetNextPageAsync(CancellationToken cancellationToken = default)
        {
            return GetNextPageAsync(default, cancellationToken);
        }

        public Task<PagedResponse<T>> GetNextPageAsync(RequestOptions options, CancellationToken cancellationToken = default)
        {
            if (NextPageUrl == null)
            {
                return Task.FromResult<PagedResponse<T>>(null);
            }

            return GitLabClient.GetPagedAsync<T>(NextPageUrl, options, cancellationToken);
        }

        public Task ForEachAsync(Action<T> action, CancellationToken cancellationToken = default)
        {
            return ForEachAsync(action, default, cancellationToken);
        }

        public Task ForEachAsync(Action<T> action, RequestOptions options, CancellationToken cancellationToken = default)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            Task<bool> Func(T item)
            {
                action(item);
                return s_trueTask;
            }

            return ForEachAsync(Func, options, cancellationToken);
        }

        public Task ForEachAsync(Func<T, bool> action, CancellationToken cancellationToken = default)
        {
            return ForEachAsync(action, cancellationToken);
        }

        public Task ForEachAsync(Func<T, bool> action, RequestOptions options, CancellationToken cancellationToken = default)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            return ForEachAsync(item => Task.FromResult(action(item)), options, cancellationToken);
        }

        public Task ForEachAsync(Func<T, Task<bool>> action, CancellationToken cancellationToken = default)
        {
            return ForEachAsync(action, default, cancellationToken);
        }

        public async Task ForEachAsync(Func<T, Task<bool>> action, RequestOptions options, CancellationToken cancellationToken = default)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var page = this;
            while (page != null)
            {
                foreach (var item in page.Data)
                {
                    var result = await action(item).ConfigureAwait(false);
                    if (!result)
                        return;
                }

                page = await page.GetNextPageAsync(options, cancellationToken).ConfigureAwait(false);
            }
        }

        public Task<IReadOnlyList<T>> ToListAsync(CancellationToken cancellationToken = default)
        {
            return ToListAsync(default, cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ToListAsync(RequestOptions options, CancellationToken cancellationToken = default)
        {
            var items = new List<T>();
            var page = this;
            while (page != null)
            {
                items.AddRange(page.Data);

                page = await page.GetNextPageAsync(options, cancellationToken).ConfigureAwait(false);
            }

            return items;
        }

        public IEnumerable<T> AsEnumerable()
        {
            return new PagedResultEnumerable(this);
        }

        private class PagedResultEnumerable : IEnumerable<T>
        {
            private readonly PagedResponse<T> _pagedResponse;

            public PagedResultEnumerable(PagedResponse<T> pagedResponse)
            {
                _pagedResponse = pagedResponse;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return new PageResultEnumerator(_pagedResponse);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        private class PageResultEnumerator : IEnumerator<T>
        {
            private readonly PagedResponse<T> _initialPage;
            private PagedResponse<T> _currentPage;
            private int _currentIndex;

            public PageResultEnumerator(PagedResponse<T> pagedResponse)
            {
                _initialPage = pagedResponse;
                Reset();
            }

            public T Current => _currentPage?.Data[_currentIndex];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                Reset();
            }

            public bool MoveNext()
            {
                if (_currentPage == null || _currentIndex == _currentPage.Data.Count - 1)
                {
                    if (!MoveNextPage())
                        return false;
                }

                if (_currentPage.Data.Count == 0)
                    return false;

                _currentIndex += 1;
                return true;
            }

            private bool MoveNextPage()
            {
                if (_currentPage == null)
                {
                    _currentPage = _initialPage;
                    _currentIndex = -1;
                    return true;
                }

                if (_currentPage.NextPageUrl == null)
                    return false;

                var nextPage = _currentPage.GetNextPageAsync().Result;
                if (nextPage == null)
                    return false;

                _currentPage = nextPage;
                _currentIndex = -1;
                return true;
            }

            public void Reset()
            {
                _currentPage = null;
                _currentIndex = -1;
            }
        }
    }
}
