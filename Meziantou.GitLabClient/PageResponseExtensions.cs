using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meziantou.GitLab
{
    public static class PageResponseExtensions
    {
        public static async Task<IReadOnlyList<T>> ToListAsync<T>(this Task<PagedResponse<T>> pageResponse)
            where T : GitLabObject
        {
            var page = await pageResponse.ConfigureAwait(false);
            return await page.ToListAsync().ConfigureAwait(false);
        }
    }
}
