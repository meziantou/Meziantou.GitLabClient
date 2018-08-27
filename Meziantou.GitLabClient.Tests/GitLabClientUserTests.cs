using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class GitLabClientUserTests : GitLabTest
    {
        [TestMethod]
        public async Task GetCurrentUser()
        {
            using (var context = GetContext())
            {
                // Act
                var user = await context.Client.GetUserAsync();

                // Assert
                Assert.IsNotNull(user.Name);
            }
        }

        [TestMethod]
        public async Task GetUserById()
        {
            using (var context = GetContext())
            {
                // Act
                var user = await context.Client.GetUserAsync(1); // root

                // Assert
                Assert.AreEqual("root", user.Username);
            }
        }

        [TestMethod]
        public async Task GetAllUsers()
        {
            using (var context = GetContext())
            {
                // Act
                // There should be only 2 users in GitLab, so get page of 1
                var users = await context.Client.GetUsersAsync();

                // Assert
                Assert.IsNotNull(users);

                var allUsers = users.AsEnumerable().ToList();
                Assert.IsTrue(allUsers.Count >= 2);
                CollectionAssert.AllItemsAreNotNull(allUsers);
                CollectionAssert.AllItemsAreUnique(allUsers);
                CollectionAssert.Contains(allUsers.Select(u => u.Username).ToList(), "root");
                CollectionAssert.Contains(allUsers.Select(u => u.Username).ToList(), "user");
            }
        }

        [TestMethod]
        public async Task SetCurrentUserStatus()
        {
            using (var context = GetContext())
            {
                // Act
                var emoji = context.GetRandomEmojiName();
                var message = context.GetRandomString();
                var status = await context.Client.SetUserStatusAsync(emoji, message);

                // Assert
                Assert.AreEqual(emoji, status.Emoji);
                Assert.AreEqual(message, status.Message);
                Assert.IsNotNull(status.MessageHtml);

                // Get status
                var currentStatus = await context.Client.GetUserStatusAsync();

                Assert.AreEqual(emoji, currentStatus.Emoji);
                Assert.AreEqual(message, currentStatus.Message);
                Assert.IsNotNull(currentStatus.MessageHtml);
            }
        }

        [TestMethod]
        public async Task GetUserStatus_WithUsername()
        {
            using (var context = GetContext())
            {
                // Act
                var currentStatus = await context.Client.GetUserStatusAsync("root");

                // Assert
                Assert.IsNotNull(currentStatus);
            }
        }

        [TestMethod]
        public async Task GetUserStatus_WithUserId()
        {
            using (var context = GetContext())
            {
                // Act
                var currentStatus = await context.Client.GetUserStatusAsync(1);

                // Assert
                Assert.IsNotNull(currentStatus);
            }
        }

        [TestMethod]
        public async Task AddSshKey_WhenKeyIsInvalid()
        {
            using (var context = GetContext())
            {
                // Act
                var exception = await Assert.ThrowsExceptionAsync<GitLabException>(() => context.Client.AddSshKeyAsync(
                    title: context.GetRandomString(),
                    key: "ssh-dss AAAAB3NzaC1kc3MAAACBAMLrhYgI3atfrSD6KDas1b/3n6R/HP+bLaHHX6oh+L1vg31mdUqK0Ac/NjZoQunavoyzqdPYhFz9zzOezCrZKjuJDS3NRK9rspvjgM0xYR4d47oNZbdZbwkI4cTv/gcMlquRy0OvpfIvJtjtaJWMwTLtM5VhRusRuUlpH99UUVeXAAAAFQCVyX+92hBEjInEKL0v13c/egDCTQAAAIEAvFdWGq0ccOPbw4f/F8LpZqvWDydAcpXHV3thwb7WkFfppvm4SZte0zds1FJ+Hr8Xzzc5zMHe6J4Nlay/rP4ewmIW7iFKNBEYb/yWa+ceLrs+TfR672TaAgO6o7iSRofEq5YLdwgrwkMmIawa21FrZ2D9SPao/IwvENzk/xcHu7YAAACAQFXQH6HQnxOrw4dqf0NqeKy1tfIPxYYUZhPJfo9O0AmBW2S36pD2l14kS89fvz6Y1g8gN/FwFnRncMzlLY/hX70FSc/3hKBSbH6C6j8hwlgFKfizav21eS358JJz93leOakJZnGb8XlWvz1UJbwCsnR2VEY8Dz90uIk1l/UqHkA= loic@call"));
                Assert.AreEqual("type is forbidden. Must be RSA, ECDSA, or ED25519", exception.ErrorObject.Message["key"].Single());
            }
        }

        [TestMethod]
        public async Task AddSshKey()
        {
            var generatedKey = RsaSshKey.GenerateQuickest();

            using (var context = GetContext())
            {
                long keyId;

                // Create Key
                {
                    var model = new
                    {
                        Title = context.GetRandomString(),
                        Key = generatedKey.PublicKey,
                    };

                    var key = await context.Client.AddSshKeyAsync(
                        title: model.Title,
                        key: model.Key);

                    Assert.IsTrue(key.Id > 0);
                    Assert.AreEqual(model.Key, key.Key);
                    Assert.AreEqual(model.Title, key.Title);
                    Assert.AreNotEqual(default, key.CreatedAt);

                    keyId = key.Id;
                }

                // Get key
                {
                    var key = await context.Client.GetSshKeyAsync(keyId);
                    Assert.AreEqual(keyId, key.Id);
                    Assert.IsNotNull(key.Key);
                    Assert.IsNotNull(key.Title);
                    Assert.AreNotEqual(default, key.CreatedAt);
                }

                // List SSH keys
                {
                    var keys = await context.Client.GetSshKeysAsync();
                    CollectionAssert.Contains(keys.Select(k => k.Id).ToList(), keyId);
                }

                // Delete key
                {
                    await context.Client.DeleteSshKeyAsync(keyId);
                }

                // Get key (new key must not be present)
                {
                    var key = await context.Client.GetSshKeyAsync(keyId);
                    Assert.IsNull(key);
                }
            }
        }
    }
}
