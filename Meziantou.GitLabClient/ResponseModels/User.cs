using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Meziantou.GitLab
{
    public class PagedResponse<T> : GitLabObject
        where T : GitLabObject
    {
        private static readonly Task<bool> TrueTask = Task.FromResult(true);

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

        public IReadOnlyList<T> Data { get; }

        public Task<PagedResponse<T>> GetFirstPageAsync(CancellationToken cancellationToken = default)
        {
            if (FirstPageUrl == null)
            {
                return Task.FromResult<PagedResponse<T>>(null);
            }

            return GitLabClient.GetPagedAsync<T>(FirstPageUrl, cancellationToken);
        }

        public Task<PagedResponse<T>> GetLastPageAsync(CancellationToken cancellationToken = default)
        {
            if (LastPageUrl == null)
            {
                return Task.FromResult<PagedResponse<T>>(null);
            }

            return GitLabClient.GetPagedAsync<T>(LastPageUrl, cancellationToken);
        }

        public Task<PagedResponse<T>> GetPreviousPageAsync(CancellationToken cancellationToken = default)
        {
            if (PreviousPageUrl == null)
            {
                return Task.FromResult<PagedResponse<T>>(null);
            }

            return GitLabClient.GetPagedAsync<T>(PreviousPageUrl, cancellationToken);
        }

        public Task<PagedResponse<T>> GetNextPageAsync(CancellationToken cancellationToken = default)
        {
            if (NextPageUrl == null)
            {
                return Task.FromResult<PagedResponse<T>>(null);
            }

            return GitLabClient.GetPagedAsync<T>(NextPageUrl, cancellationToken);
        }

        public Task ForEachAsync(Action<T> action, CancellationToken cancellationToken = default)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            Task<bool> Func(T item)
            {
                action(item);
                return TrueTask;
            }

            return ForEachAsync(Func, cancellationToken);
        }

        public Task ForEachAsync(Func<T, bool> action, CancellationToken cancellationToken = default)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            return ForEachAsync(item => Task.FromResult(action(item)), cancellationToken);
        }

        public async Task ForEachAsync(Func<T, Task<bool>> action, CancellationToken cancellationToken = default)
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

                page = await page.GetNextPageAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        public async Task<IReadOnlyList<T>> ToListAsync(CancellationToken cancellationToken = default)
        {
            var items = new List<T>();
            var page = this;
            while (page != null)
            {
                items.AddRange(page.Data);

                page = await page.GetNextPageAsync(cancellationToken).ConfigureAwait(false);
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
                else
                {
                    if (_currentPage.NextPageUrl == null)
                        return false;

                    var nextPage = _currentPage.GetNextPageAsync().Result;
                    if (nextPage == null)
                        return false;

                    _currentPage = nextPage;
                    _currentIndex = -1;
                    return true;
                }
            }

            public void Reset()
            {
                _currentPage = null;
                _currentIndex = -1;
            }
        }
    }

    public class UserSafe : GitLabObject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
    }

    public class UserBasic : UserSafe
    {
        public string AvatarUrl { get; set; }
        public string AvatarPath { get; set; }
        public string WebUrl { get; set; }
    }

    public class User : UserBasic
    {
        public UserState State { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Bio { get; set; }
        public string Location { get; set; }
        public string Skype { get; set; }
        public string Linkedin { get; set; }
        public string Twitter { get; set; }
        public string WebsiteUrl { get; set; }
        public string Organization { get; set; }
        public DateTime? CurrentSignInAt { get; set; }
        public DateTime? LastSignInAt { get; set; }
        public DateTime? ConfirmedAt { get; set; }
        [SkipUtcDateValidation]
        public DateTime? LastActivityOn { get; set; }
        public string Email { get; set; }
        public long ThemeId { get; set; }
        public long ColorSchemeId { get; set; }
        public long ProjectsLimit { get; set; }
        public IReadOnlyList<Identity> Identities { get; set; }
        public bool CanCreateGroup { get; set; }
        public bool CanCreateProject { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool External { get; set; }
        public object PrivateProfile { get; set; }
        public long? SharedRunnersMinutesLimit { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class UserActivity : GitLabObject
    {
        public string Username { get; set; }
        public DateTime LastActivityOn { get; set; }
    }

    public class Identity : GitLabObject
    {
        public string Provider { get; set; }
        public string ExternUid { get; set; }
    }

    public class UserStatus : GitLabObject
    {
        public string Emoji { get; set; }
        public string Message { get; set; }
        public string MessageHtml { get; set; }
    }

    public class Todo : GitLabObject
    {
        public long Id { get; set; }
    }

    public enum TodoState
    {
        Pending,
        Done,
    }
}
