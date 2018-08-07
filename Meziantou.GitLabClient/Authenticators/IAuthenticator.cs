using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Meziantou.GitLab
{
    public interface IAuthenticator
    {
        Task AuthenticateAsync(HttpRequestMessage message, CancellationToken cancellationToken);
    }
}
