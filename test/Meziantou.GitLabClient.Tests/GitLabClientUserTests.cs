using System;
using System.Linq;
using System.Threading.Tasks;
using Meziantou.Framework;
using Xunit;
using Xunit.Abstractions;

namespace Meziantou.GitLab.Tests
{
    public class GitLabClientUserTests : GitLabTestBase
    {
        public GitLabClientUserTests(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Fact]
        public async Task GetCurrentUser()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();
            // Act
            var user = await client.Users.GetCurrentUserAsync();

            // Assert
            Assert.NotNull(user.Name);
        }

        [Fact]
        public async Task GetUserById()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();
            // Act
            var user = await client.Users.GetByIdAsync(1); // root

            // Assert
            Assert.Equal("root", user.Username);
        }

        [Fact]
        public async Task SetCurrentUserStatus()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();
            // Act
            var emoji = Emoji.EmojiThumbsUpSign;
            var message = context.GetRandomString();
            var status = await client.Users.SetCurrentUserStatusAsync(new SetCurrentUserStatusRequest { Emoji = emoji, Message = message });

            // Assert
            Assert.Equal(emoji, status.Emoji);
            Assert.Equal(message, status.Message);
            Assert.NotNull(status.MessageHtml);

            // Get status
            var currentStatus = await client.Users.GetCurrentUserStatusAsync();

            Assert.Equal(emoji, currentStatus.Emoji);
            Assert.Equal(message, currentStatus.Message);
            Assert.NotNull(currentStatus.MessageHtml);
        }

        [Fact]
        public async Task GetUserStatus_WithUsername()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();
            // Act
            var currentStatus = await client.Users.GetStatusAsync("root");

            // Assert
            Assert.NotNull(currentStatus);
        }

        [Fact]
        public async Task GetUserStatus_WithUserId()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();
            // Act
            var currentStatus = await client.Users.GetStatusAsync(1);

            // Assert
            Assert.NotNull(currentStatus);
        }

        [Fact]
        public async Task AddSshKey()
        {
            var generatedKey = RsaSshKey.GenerateQuickest();

            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();
            long keyId;

            var user = await client.Users.GetCurrentUserAsync();

            // Create Key
            var model = new AddSSHKeyToCurrentUserRequest(title: context.GetRandomString(), key: generatedKey.PublicKey);
            var expectedKey = model.Key;

            {
                var key = await client.Users.AddSSHKeyToCurrentUserAsync(model);

                Assert.True(key.Id > 0);
                Assert.StartsWith(expectedKey, key.Key, StringComparison.Ordinal);
                Assert.Equal(model.Title, key.Title);
                Assert.NotEqual(default, key.CreatedAt);

                keyId = key.Id;
            }

            // Get key
            {
                var key = await client.Users.GetCurrentUserSSHKeyAsync(keyId);
                Assert.Equal(keyId, key.Id);
                Assert.StartsWith(expectedKey, key.Key, StringComparison.Ordinal);
                Assert.NotNull(key.Title);
                Assert.NotEqual(default, key.CreatedAt);
            }

            // List SSH keys
            {
                var keys = await client.Users.GetCurrentUserSSHKeysAsync();
                Assert.Contains(keyId, keys.Select(k => k.Id).ToList());
            }

            // Delete key
            {
                await client.Users.DeleteSSHKeyFromCurrentUserAsync(new DeleteSSHKeyFromCurrentUserRequest(keyId));
            }

            // Get key (new key must not be present)
            {
                var key = await client.Users.GetCurrentUserSSHKeyAsync(keyId);
                Assert.Null(key);
            }
        }

        [Fact]
        public async Task CreateImpersonationToken()
        {
            using var context = await CreateContextAsync();
            using var client = await context.CreateNewUserAsync();
            var user = await client.Users.GetCurrentUserAsync();

            var token = await context.AdminClient.Users.CreateImpersonationTokenAsync(user.Id, "new-token", expiresAt: null, scopes: new[] { ImpersonationTokenScope.ReadUser });
            Assert.NotNull(token.Token);
            Assert.False(token.Revoked);
            Assert.True(token.Active);
            Assert.Null(token.ExpiresAt);
            Assert.Equal(new[] { ImpersonationTokenScope.ReadUser }, token.Scopes.ToList());

            var token2 = await context.AdminClient.Users.CreateImpersonationTokenAsync(user, "new-token", expiresAt: DateTime.Now.AddDays(2), scopes: new[] { ImpersonationTokenScope.ReadUser, ImpersonationTokenScope.Api });
            Assert.NotNull(token2.Token);
            Assert.False(token2.Revoked);
            Assert.True(token2.Active);
            Assert.NotNull(token2.ExpiresAt);
            Assert.Equal(new[] { ImpersonationTokenScope.Api, ImpersonationTokenScope.ReadUser }, token2.Scopes.OrderBy(scope => scope).ToList());
        }
    }
}
