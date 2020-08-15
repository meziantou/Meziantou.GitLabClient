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
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            // Act
            var user = await client.GetUserAsync();

            // Assert
            Assert.IsNotNull(user.Name);
        }

        [TestMethod]
        public async Task GetUserById()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            // Act
            var user = await client.GetUserAsync(1); // root

            // Assert
            Assert.AreEqual("root", user.Username);
        }

        [TestMethod]
        [DoNotParallelize] // Getting a collection on GitLab is not thread safe... AllItemsAreUnique may be false because another test may add a new user
        public async Task GetAllUsers()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            var currentUser = await client.GetUserAsync();

            // Act
            var users = await client.GetUsersAsync().ToListAsync();

            // Assert
            Assert.IsNotNull(users);

            // There should be at least 2 users in GitLab (root and current user)
            Assert.IsTrue(users.Count >= 2);
            CollectionAssert.AllItemsAreNotNull(users.ToArray());
            CollectionAssert.AllItemsAreUnique(users.ToArray());
            CollectionAssert.Contains(users.Select(u => u.Username).ToList(), "root");
            CollectionAssert.Contains(users.Select(u => u.Username).ToList(), currentUser.Username);
        }

        [TestMethod]
        public async Task SetCurrentUserStatus()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            // Act
            var emoji = context.GetRandomEmojiName();
            var message = context.GetRandomString();
            var status = await client.SetUserStatusAsync(emoji, message);

            // Assert
            Assert.AreEqual(emoji, status.Emoji);
            Assert.AreEqual(message, status.Message);
            Assert.IsNotNull(status.MessageHtml);

            // Get status
            var currentStatus = await client.GetUserStatusAsync();

            Assert.AreEqual(emoji, currentStatus.Emoji);
            Assert.AreEqual(message, currentStatus.Message);
            Assert.IsNotNull(currentStatus.MessageHtml);
        }

        [TestMethod]
        public async Task GetUserStatus_WithUsername()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            // Act
            var currentStatus = await client.GetUserStatusAsync("root");

            // Assert
            Assert.IsNotNull(currentStatus);
        }

        [TestMethod]
        public async Task GetUserStatus_WithUserId()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            // Act
            var currentStatus = await client.GetUserStatusAsync(1);

            // Assert
            Assert.IsNotNull(currentStatus);
        }

        //[TestMethod]
        //public async Task AddSshKey_WhenKeyIsInvalid()
        //{
        //    using (var context = GetContext())
        //    {
        //        // Act
        //        var exception = await Assert.ThrowsExceptionAsync<GitLabException>(() => context.Client.AddSshKeyAsync(
        //            title: context.GetRandomString(),
        //            key: "ssh-dss AAAAB3NzaC1kc3MAAACBAMLrhYgI3atfrSD6KDas1b/3n6R/HP+bLaHHX6oh+L1vg31mdUqK0Ac/NjZoQunavoyzqdPYhFz9zzOezCrZKjuJDS3NRK9rspvjgM0xYR4d47oNZbdZbwkI4cTv/gcMlquRy0OvpfIvJtjtaJWMwTLtM5VhRusRuUlpH99UUVeXAAAAFQCVyX+92hBEjInEKL0v13c/egDCTQAAAIEAvFdWGq0ccOPbw4f/F8LpZqvWDydAcpXHV3thwb7WkFfppvm4SZte0zds1FJ+Hr8Xzzc5zMHe6J4Nlay/rP4ewmIW7iFKNBEYb/yWa+ceLrs+TfR672TaAgO6o7iSRofEq5YLdwgrwkMmIawa21FrZ2D9SPao/IwvENzk/xcHu7YAAACAQFXQH6HQnxOrw4dqf0NqeKy1tfIPxYYUZhPJfo9O0AmBW2S36pD2l14kS89fvz6Y1g8gN/FwFnRncMzlLY/hX70FSc/3hKBSbH6C6j8hwlgFKfizav21eS358JJz93leOakJZnGb8XlWvz1UJbwCsnR2VEY8Dz90uIk1l/UqHkA= loic@call"));
        //        Assert.AreEqual("type is forbidden. Must be RSA, ECDSA, or ED25519", exception.ErrorObject.Message["key"].Single());
        //    }
        //}

        [TestMethod]
        public async Task AddSshKey()
        {
            var generatedKey = RsaSshKey.GenerateQuickest();

            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            long keyId;

            // Create Key
            {
                var model = new
                {
                    Title = context.GetRandomString(),
                    Key = generatedKey.PublicKey,
                };

                var key = await client.AddSshKeyAsync(
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
                var key = await client.GetSshKeyAsync(keyId);
                Assert.AreEqual(keyId, key.Id);
                Assert.IsNotNull(key.Key);
                Assert.IsNotNull(key.Title);
                Assert.AreNotEqual(default, key.CreatedAt);
            }

            // List SSH keys
            {
                var keys = await client.GetSshKeysAsync();
                CollectionAssert.Contains(keys.Select(k => k.Id).ToList(), keyId);
            }

            // Delete key
            {
                await client.DeleteSshKeyAsync(keyId);
            }

            // Get key (new key must not be present)
            {
                var key = await client.GetSshKeyAsync(keyId);
                Assert.IsNull(key);
            }
        }
    }
}
