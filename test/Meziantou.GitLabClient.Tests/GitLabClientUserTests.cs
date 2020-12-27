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
            var user = await client.Users.GetCurrentUserAsync();

            // Assert
            Assert.IsNotNull(user.Name);
        }

        [TestMethod]
        public async Task GetUserById()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            // Act
            var user = await client.Users.GetByIdAsync(1); // root

            // Assert
            Assert.AreEqual("root", user.Username);
        }

        [TestMethod]
        [DoNotParallelize] // Getting a collection on GitLab is not thread safe... AllItemsAreUnique may be false because another test may add a new user
        public async Task GetAllUsers()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            var currentUser = await client.Users.GetCurrentUserAsync();

            // Act
            var users = await client.Users.GetAll().ToListAsync();

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
            var emoji = Emoji.EmojiThumbsUpSign;
            var message = context.GetRandomString();
            var status = await client.Users.SetCurrentUserStatusAsync(new SetCurrentUserStatusRequest { Emoji = emoji, Message = message });

            // Assert
            Assert.AreEqual(emoji, status.Emoji);
            Assert.AreEqual(message, status.Message);
            Assert.IsNotNull(status.MessageHtml);

            // Get status
            var currentStatus = await client.Users.GetCurrentUserStatusAsync();

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
            var currentStatus = await client.Users.GetStatusAsync("root");

            // Assert
            Assert.IsNotNull(currentStatus);
        }

        [TestMethod]
        public async Task GetUserStatus_WithUserId()
        {
            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            // Act
            var currentStatus = await client.Users.GetStatusAsync(1);

            // Assert
            Assert.IsNotNull(currentStatus);
        }

        [TestMethod]
        public async Task AddSshKey()
        {
            var generatedKey = RsaSshKey.GenerateQuickest();

            using var context = GetContext();
            using var client = await context.CreateNewUserAsync();
            long keyId;

            var user = await client.Users.GetCurrentUserAsync();

            // Create Key
            var model = new AddSSHKeyToCurrentUserRequest(title: context.GetRandomString(), key: generatedKey.PublicKey);
            var expectedKey = model.Key;

            {
                var key = await client.Users.AddSSHKeyToCurrentUserAsync(model);

                Assert.IsTrue(key.Id > 0);
                StringAssert.StartsWith(key.Key, expectedKey);
                Assert.AreEqual(model.Title, key.Title);
                Assert.AreNotEqual(default, key.CreatedAt);

                keyId = key.Id;
            }

            // Get key
            {
                var key = await client.Users.GetCurrentUserSSHKeyAsync(keyId);
                Assert.AreEqual(keyId, key.Id);
                StringAssert.StartsWith(key.Key, expectedKey);
                Assert.IsNotNull(key.Title);
                Assert.AreNotEqual(default, key.CreatedAt);
            }

            // List SSH keys
            {
                var keys = await client.Users.GetCurrentUserSSHKeysAsync();
                CollectionAssert.Contains(keys.Select(k => k.Id).ToList(), keyId);
            }

            // Delete key
            {
                await client.Users.DeleteSSHKeyFromCurrentUserAsync(new DeleteSSHKeyFromCurrentUserRequest(keyId));
            }

            // Get key (new key must not be present)
            {
                var key = await client.Users.GetCurrentUserSSHKeyAsync(keyId);
                Assert.IsNull(key);
            }
        }
    }
}
