using System;
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
        public async Task GetAllUsers()
        {
            using (var context = GetContext())
            {
                // Act
                var users = await context.Client.GetUsersAsync();

                // Assert
                Assert.IsNotNull(users);

                var firstUsers = users.AsEnumerable().Take(users.PageSize + 1).ToList(); // Get the second page
                Assert.AreEqual(21, firstUsers.Count); // Default page size is 20
                CollectionAssert.AllItemsAreNotNull(firstUsers);
                CollectionAssert.AllItemsAreUnique(firstUsers);
            }
        }

        [TestMethod]
        public async Task SetCurrentUserStatus()
        {
            using (var context = GetContext())
            {
                // Act
                var data = new SetUserStatusRequest
                {
                    Emoji = "guardsman_tone5",
                    Message = Guid.NewGuid().ToString()
                };

                var status = await context.Client.SetUserStatusAsync(data);

                // Assert
                Assert.AreEqual(data.Emoji, status.Emoji);
                Assert.AreEqual(data.Message, status.Message);
                Assert.IsNotNull(status.MessageHtml);

                // Get status
                var currentStatus = await context.Client.GetUserStatusAsync();

                Assert.AreEqual(data.Emoji, currentStatus.Emoji);
                Assert.AreEqual(data.Message, currentStatus.Message);
                Assert.IsNotNull(currentStatus.MessageHtml);
            }
        }

        [TestMethod]
        public async Task GetUserStatus()
        {
            using (var context = GetContext())
            {
                // Act
                var currentStatus = await context.Client.GetUserStatusAsync("meziantou");

                Assert.IsNotNull(currentStatus.Emoji);
                Assert.IsNotNull(currentStatus.Message);
                Assert.IsNotNull(currentStatus.MessageHtml);
            }
        }
    }
}
