using System;
using Xunit;

namespace Meziantou.GitLab.Tests
{
    public class Sha1Tests
    {
        [Theory]
        [InlineData("1d5af3e7809623aebc6644160f35accf74166375")]
        [InlineData("8b274174af7deeb18a8242de0eb590dad5345532")]
        [InlineData("8B274174AF7DEEB18A8242DE0EB590DAD5345532")]
        public void TryParse_ValidValue(string value)
        {
            var parsed = new GitObjectId(value);
            Assert.Equal(value, parsed.ToString());
        }

        [Theory]
        [InlineData("1")] // Invalid length
        [InlineData("ZZ274174af7deeb18a8242de0eb590dad5345532")] // Invalid character
        public void TryParse_NotValidValue(string value)
        {
            Assert.Throws<ArgumentException>(() => new GitObjectId(value));
        }
    }
}
