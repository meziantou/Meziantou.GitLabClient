using System.Threading;
using System.Threading.Tasks;

namespace Meziantou.GitLab
{
    partial class GitLabClient
    {
        public Task<User> GetUserAsync(CancellationToken cancellationToken = default)
        {
            return GetAsync<User>("user", cancellationToken);
        }

        // TODO add pagination parameters
        // TODO add filter parameters
        public Task<PagedResponse<UserBasic>> GetUsersAsync(CancellationToken cancellationToken = default)
        {
            return GetPagedAsync<UserBasic>("users", cancellationToken);
        }

        public Task<UserStatus> GetUserStatusAsync(CancellationToken cancellationToken = default)
        {
            return GetAsync<UserStatus>("user/status", cancellationToken);
        }

        public Task<UserStatus> GetUserStatusAsync(UserRef user, CancellationToken cancellationToken = default)
        {
            var url = UrlBuilder.Get("users/:user/status")
                .WithValue("user", user.Value)
                .Build();

            return GetAsync<UserStatus>(url, cancellationToken);
        }

        // https://docs.gitlab.com/ee/api/users.html#set-user-status
        public Task<UserStatus> SetUserStatusAsync(SetUserStatusRequest data, CancellationToken cancellationToken = default)
        {
            if (data == null)
            {
                throw new System.ArgumentNullException(nameof(data));
            }

            return PutJsonAsync<UserStatus>("user/status", data, cancellationToken);
        }
    }

    public class SetUserStatusRequest
    {
        public string Emoji { get; set; }
        public string Message { get; set; }
    }
}
