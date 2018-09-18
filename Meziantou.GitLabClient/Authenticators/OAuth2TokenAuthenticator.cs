using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Meziantou.GitLab
{
    public class OAuth2TokenAuthenticator : IAuthenticator
    {
        public OAuth2TokenAuthenticator(string token)
        {
            Token = token ?? throw new ArgumentNullException(nameof(token));
        }

        public string Token { get; }

        public Task AuthenticateAsync(HttpRequestMessage message, CancellationToken cancellationToken)
        {
            message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            return Task.CompletedTask;
        }
    }
}
