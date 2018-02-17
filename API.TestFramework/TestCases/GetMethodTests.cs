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
            var response = Client.Request($"/posts");
            var userIds = response.JsonBody.SelectToken("$").Select(x => x.SelectToken("userId").ToObject<string>()).ToList();
            userIds.Count.Should().BeGreaterOrEqualTo(1);
            userIds.FirstOrDefault().Should().NotBeEmpty();
        }

        [Test]
        public void GetBlogPostById()
        {
            string expectedId = "1";
            var response = Client.Request($"/posts/{expectedId}");
            response.JsonPath<string>("id").Should().Be(expectedId);
        }
    }
}
