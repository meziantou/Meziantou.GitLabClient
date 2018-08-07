using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Meziantou.GitLab
{
    public class TokenAuthenticator : IAuthenticator
    {
        public TokenAuthenticator(string token)
        {
            Token = token ?? throw new ArgumentNullException(nameof(token));
        }

        public string Token { get; }

        public Task AuthenticateAsync(HttpRequestMessage message, CancellationToken cancellationToken)
        {
            message.Headers.Add("Private-Token", Token);
            return Task.CompletedTask;
        }
    }
}
