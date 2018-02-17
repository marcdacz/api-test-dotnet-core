using API.TestFramework.Environment;
using FluentAssertions;
using NUnit.Framework;

namespace API.TestFramework
{
    [TestFixture]
    public class SampleTests : BaseTestFixture
    {
        [Test]
        public void UpdateBlogPost()
        {
            var blogTitle = "my awesome updated post";
            var blogDetails = "this is my awesome updated post!";
            var data = new { userId = 1, title = blogTitle, body = blogDetails };
            var response = Client.Request($"/posts/1", ClientMethod.PUT, data.AsJson());
            response.JsonPath<string>("title").Should().Be(blogTitle);
            response.JsonPath<string>("body").Should().Be(blogDetails);
        }
    }
}
