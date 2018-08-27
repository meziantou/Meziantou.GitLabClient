using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    [TestClass]
    public class GitLabClientTodoTests : GitLabTest
    {
        [TestMethod]
        public async Task GetTodo()
        {
            using (var context = GetContext())
            {
                var todos = await context.Client.GetTodoAsync();
            }
        }
    }
}
