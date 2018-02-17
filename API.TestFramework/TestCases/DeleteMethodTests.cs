using API.TestFramework.Environment;
using FluentAssertions;
using NUnit.Framework;

namespace API.TestFramework
{
    [TestFixture]
    public class DeleteMethodTests : BaseTestFixture
    {
        [Test]
        public void DeleteBlogPost()
        {
            var response = Client.Request($"/posts/1", ClientMethod.DELETE);
            string blogPost = response.StringBody;
            blogPost.Should().Be("{}");
        }
    }
}
