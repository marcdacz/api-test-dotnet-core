using API.TestFramework.Environment;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace API.TestFramework
{
    [TestFixture]
    public class GetMethodTests : BaseTestFixture
    {
        [Test]
        public void GetAllBlogPosts()
        {
            var response = Client.Request($"/posts").GetDynamic();
            int blogCount = Enumerable.Count(response);
            blogCount.Should().BeGreaterOrEqualTo(1);
            string userId = response[0].userId.ToString();
            userId.Should().NotBeEmpty();
        }

        [Test]
        public void GetBlogPostById()
        {
            string expectedId = "1";
            var response = Client.Request($"/posts/{expectedId}").GetDynamic();
            string actualId = response.id.ToString();
            actualId.Should().Be(expectedId);
        }
    }
}
