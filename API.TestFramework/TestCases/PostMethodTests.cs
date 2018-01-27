using API.TestFramework.Environment;
using FluentAssertions;
using NUnit.Framework;

namespace API.TestFramework
{
    [TestFixture]
    public class PostMethodTests : BaseTestFixture
    {
        [Test]
        public void CreateBlogPost()
        {
            var data = new { userId = 1, title = "my awesome post", body = "this is my awesome post!" };
            Client.Content = data.AsJson();
            Client.Method = Method.POST;
            var response = Client.Request($"/posts");
            string blogId = response.id.ToString();
            blogId.Should().NotBeEmpty();
        }
    }
}
