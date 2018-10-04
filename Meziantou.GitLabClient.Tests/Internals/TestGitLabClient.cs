using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Meziantou.Framework.Threading;

namespace Meziantou.GitLab.Tests
{
    public class TestGitLabClient : GitLabClient
    {
        private static readonly AsyncReaderWriterLock _readerWriterLockSlim = new AsyncReaderWriterLock();

        public List<object> Objects { get; } = new List<object>();

        public GitLabTestContext Context { get; set; }

        public TestGitLabClient(GitLabTestContext context, HttpClient client, string serverUri, string token)
            : base(client, serverUri, token)
        {
            Context = context;
        }

        public override async Task<T> GetAsync<T>(string url, RequestOptions options, CancellationToken cancellationToken)
        {
            using (await ReaderLockAsync())
            {
                var result = await base.GetAsync<T>(url, options, cancellationToken);
                Objects.Add(result);
                return result;
            }
        }

        public override async Task<IReadOnlyList<T>> GetCollectionAsync<T>(string url, RequestOptions options, CancellationToken cancellationToken)
        {
            using (await ReaderLockAsync())
            {
                var readOnlyList = await base.GetCollectionAsync<T>(url, options, cancellationToken).ConfigureAwait(false);
                Objects.AddRange(readOnlyList);
                return readOnlyList;
            }
        }

        public override async Task<PagedResponse<T>> GetPagedAsync<T>(string url, RequestOptions options, CancellationToken cancellationToken)
        {
            using (await ReaderLockAsync())
            {
                var pagedResponse = await base.GetPagedAsync<T>(url, options, cancellationToken).ConfigureAwait(false);
                Objects.AddRange(pagedResponse.Data);
                return pagedResponse;
            }
        }

        public override async Task<T> PostJsonAsync<T>(string url, object data, RequestOptions options, CancellationToken cancellationToken)
        {
            using (await WriterLockAsync())
            {
                var result = await base.PostJsonAsync<T>(url, data, options, cancellationToken).ConfigureAwait(false);
                Objects.Add(result);
                return result;
            }
        }

        public override async Task PostJsonAsync(string url, object data, RequestOptions options, CancellationToken cancellationToken)
        {
            using (await WriterLockAsync())
            {
                await base.PostJsonAsync(url, data, options, cancellationToken).ConfigureAwait(false);
            }
        }

        public override async Task<T> PutJsonAsync<T>(string url, object data, RequestOptions options, CancellationToken cancellationToken)
        {
            using (await WriterLockAsync())
            {
                var result = await base.PutJsonAsync<T>(url, data, options, cancellationToken).ConfigureAwait(false);
                Objects.Add(result);
                return result;
            }
        }

        public override async Task DeleteAsync(string url, RequestOptions options, CancellationToken cancellationToken)
        {
            using (await WriterLockAsync())
            {
                await base.DeleteAsync(url, options, cancellationToken);
            }
        }

        private Task<AsyncReaderWriterLock.Releaser> ReaderLockAsync()
        {
            return _readerWriterLockSlim.ReaderLockAsync();
        }

        private Task<AsyncReaderWriterLock.Releaser> WriterLockAsync()
        {
            return _readerWriterLockSlim.WriterLockAsync();
        }
    }
}
