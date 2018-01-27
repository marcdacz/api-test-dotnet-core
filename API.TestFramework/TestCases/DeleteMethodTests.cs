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
            Client.Method = Method.DELETE;
            var response = Client.Request($"/posts/1");
            string blogPost = response.ToString();
            blogPost.Should().Be("{}");
        }
    }
}
