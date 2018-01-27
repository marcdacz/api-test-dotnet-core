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
            Client.Content = data.AsJson();
            Client.Method = Method.PUT;
            var response = Client.Request($"/posts/1");
            string title = response.title.ToString();
            title.Should().Be(blogTitle);
            string details = response.body.ToString();
            details.Should().Be(blogDetails);
        }
    }
}
