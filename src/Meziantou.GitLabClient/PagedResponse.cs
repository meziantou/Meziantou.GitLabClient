using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Meziantou.GitLab.Core;

namespace Meziantou.GitLab
{
    // TODO add page size / page index / keyset
    public sealed class PagedResponse<T> : IAsyncEnumerable<T>
        where T : GitLabObject
    {
        private const int FirstPageIndex = 1;

        private readonly string _initialUrl;
        private readonly RequestOptions? _options;
        private bool? _keyset;
        private int? _pageSize;
        private int _pageIndex;

        public GitLabClient Client { get; }

        internal PagedResponse(GitLabClient client, string initialUrl, RequestOptions? options)
        {
            Client = client;
            _initialUrl = initialUrl;
            _options = options;
        }

        public PagedResponse<T> ConfigurePageOptions(int? pageSize = null, int startPageIndex = FirstPageIndex)
        {
            if (startPageIndex > FirstPageIndex && _keyset == true)
                throw new ArgumentException("Start page index cannot be set when keyset pagination is enabled", nameof(startPageIndex));

            _pageSize = pageSize;
            _pageIndex = startPageIndex;
            return this;
        }

        public PagedResponse<T> EnableKeysetPagination(bool enabled = true)
        {
            if (_pageIndex > FirstPageIndex && enabled)
                throw new ArgumentException("keyset pagination cannot be enabled when start page index is set", nameof(enabled));

            _keyset = true;
            return this;
        }

        private string BuildUrl()
        {
            string parameters;
            if (_initialUrl.Contains('?', StringComparison.Ordinal))
            {
                parameters = "&";
            }
            else
            {
                parameters = "?";
            }

            if (_keyset != false && _pageIndex <= FirstPageIndex)
            {
                parameters += "keyset=true&";
            }

            if (_pageIndex > FirstPageIndex)
            {
                parameters += "page=" + _pageIndex.ToString(CultureInfo.InvariantCulture) + "&";
            }

            if (_pageSize.HasValue)
            {
                parameters += "per_page=" + _pageSize.GetValueOrDefault().ToString(CultureInfo.InvariantCulture) + "&";
            }

            return _initialUrl + parameters[..^1];
        }

        public async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            var page = await Client.GetPagedCollectionAsync<T>(BuildUrl(), _options, cancellationToken).ConfigureAwait(false);
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
