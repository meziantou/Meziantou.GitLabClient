using Meziantou.GitLab.Internals;
using Xunit;

namespace Meziantou.GitLab.Tests
{
    public class LinkHeaderValueTests
    {
        [Theory]
        [InlineData("<http://localhost:7965/api/customers/pagelinks?pageNo=1&pageSize=50>; rel=\"first\"", "http://localhost:7965/api/customers/pagelinks?pageNo=1&pageSize=50", "first")]
        public void Test(string headerValue, string expectedUrl, string expectedRel)
        {
            var parsed = LinkHeaderValue.TryParse(headerValue, out var value);

            Assert.True(parsed);
            Assert.Equal(expectedUrl, value.Url);
            Assert.Equal(expectedRel, value.Rel);
        }
    }
}
