using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Meziantou.GitLab
{
    public static class PagedResponseExtensions
    {
        public static async Task<IReadOnlyList<T>> ToListAsync<T>(this Task<PagedResponse<T>> pageResponse, CancellationToken cancellationToken = default)
            where T : GitLabObject
        {
            var page = await pageResponse.ConfigureAwait(false);
            return await page.ToListAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
