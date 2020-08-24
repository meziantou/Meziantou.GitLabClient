using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Meziantou.Framework;
using Meziantou.Framework.Threading;
using Meziantou.GitLab.Core;

namespace Meziantou.GitLab.Tests
{
    public class TestGitLabClient : GitLabClient
    {
        private static readonly AsyncReaderWriterLock s_readerWriterLockSlim = new AsyncReaderWriterLock();

        public IList<object> Objects { get; } = new List<object>();

        public GitLabTestContext Context { get; set; }

        public string ProfileToken { get; set; }

        public TestGitLabClient(GitLabTestContext context, HttpClient client, Uri serverUri, string token)
            : base(client, httpClientOwned: false, serverUri, new PersonalAccessTokenAuthenticator(token))
        {
            Context = context;
        }

        public override async Task<T> GetAsync<T>(string url, RequestOptions options, CancellationToken cancellationToken = default)
        {
            using (await ReaderLockAsync())
            {
                var result = await base.GetAsync<T>(url, options, cancellationToken);
                Objects.Add(result);
                return result;
            }
        }

        public override async Task<IReadOnlyList<T>> GetCollectionAsync<T>(string url, RequestOptions options, CancellationToken cancellationToken = default)
        {
            using (await ReaderLockAsync())
            {
                var readOnlyList = await base.GetCollectionAsync<T>(url, options, cancellationToken).ConfigureAwait(false);
                Objects.AddRange(readOnlyList);
                return readOnlyList;
            }
        }

        public override async Task<GitLabPageResponse<T>> GetPagedCollectionAsync<T>(string url, RequestOptions options, CancellationToken cancellationToken = default)
        {
            using (await ReaderLockAsync())
            {
                var pagedResponse = await base.GetPagedCollectionAsync<T>(url, options, cancellationToken).ConfigureAwait(false);
                Objects.AddRange(pagedResponse.Data);
                return pagedResponse;
            }
        }

        public override async Task<T> PostJsonAsync<T>(string url, object data, RequestOptions options, CancellationToken cancellationToken = default)
        {
            using (await WriterLockAsync())
            {
                var result = await base.PostJsonAsync<T>(url, data, options, cancellationToken).ConfigureAwait(false);
                Objects.Add(result);
                return result;
            }
        }

        public override async Task PostJsonAsync(string url, object data, RequestOptions options, CancellationToken cancellationToken = default)
        {
            using (await WriterLockAsync())
            {
                await base.PostJsonAsync(url, data, options, cancellationToken).ConfigureAwait(false);
            }
        }

        public override async Task<T> PutJsonAsync<T>(string url, object data, RequestOptions options, CancellationToken cancellationToken = default)
        {
            using (await WriterLockAsync())
            {
                var result = await base.PutJsonAsync<T>(url, data, options, cancellationToken).ConfigureAwait(false);
                Objects.Add(result);
                return result;
            }
        }

        public override async Task DeleteAsync(string url, RequestOptions options, CancellationToken cancellationToken = default)
        {
            using (await WriterLockAsync())
            {
                await base.DeleteAsync(url, options, cancellationToken);
            }
        }

        private static Task<AsyncReaderWriterLock.Releaser> ReaderLockAsync()
        {
            return s_readerWriterLockSlim.ReaderLockAsync();
        }

        private static Task<AsyncReaderWriterLock.Releaser> WriterLockAsync()
        {
            return s_readerWriterLockSlim.WriterLockAsync();
        }
    }
}
