using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Meziantou.GitLab
{
    public class CookieAuthenticator : IAuthenticator
    {
        public CookieAuthenticator(string cookie)
        {
            Cookie = cookie ?? throw new ArgumentNullException(nameof(cookie));
        }

        public string Cookie { get; }

        public Task AuthenticateAsync(HttpRequestMessage message, CancellationToken cancellationToken)
        {
            if (message.Headers.TryGetValues("Cookie", out var values))
            {
                var value = values.FirstOrDefault();
                value += ";_gitlab_session=" + Cookie;
                message.Headers.Remove("Cookie");
                message.Headers.Add("Cookie", value);
            }
            else
            {
                message.Headers.Add("Cookie", "_gitlab_session=" + Cookie);
            }

            return Task.CompletedTask;
        }
    }
}
