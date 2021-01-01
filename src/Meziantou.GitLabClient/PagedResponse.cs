using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Meziantou.GitLab.Core;

namespace Meziantou.GitLab
{
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

        [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "Rule doesn't understand disposable ref struct")]
        private string BuildUrl()
        {
            using var sb = new Internals.UrlBuilder();
            sb.Append(_initialUrl);

            char separator;
            if (_initialUrl.Contains('?', StringComparison.Ordinal))
            {
                separator = '&';
            }
            else
            {
                separator = '?';
            }

            if (_keyset != false && _pageIndex <= FirstPageIndex)
            {
                sb.Append(separator);
                separator = '&';

                sb.Append("keyset=true");
            }

            if (_pageIndex > FirstPageIndex)
            {
                sb.Append(separator);
                separator = '&';

                sb.Append("page=");
                sb.AppendParameter(_pageIndex);
            }

            if (_pageSize.HasValue)
            {
                sb.Append(separator);
                separator = '&';

                sb.Append("per_page=");
                sb.AppendParameter(_pageSize.GetValueOrDefault());
            }

            return sb.ToString();
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
            var page = await Client.GetPagedCollectionAsync<T>(BuildUrl(), _options, cancellationToken).ConfigureAwait(false);

            var list = new List<T>(page.TotalItems);
            do
            {
                foreach (var item in page.Data)
                {
                    list.Add(item);
                }
            } while ((page = await page.GetNextPageAsync(_options, cancellationToken).ConfigureAwait(false)) != null);

            return list;
        }
    }
}
