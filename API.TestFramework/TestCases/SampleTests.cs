using API.TestFramework.Environment;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace API.TestFramework
{
    [TestFixture]
    public class SampleTests : BaseTestFixture
    {
        [Test]
        public void GetAllBlogPosts()
        {
            var response = Client.Request($"/posts");
            int blogCount = Enumerable.Count(response);
            blogCount.Should().BeGreaterOrEqualTo(1);
            string userId = response[0].userId.ToString();
            userId.Should().NotBeEmpty();
        }

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

        [Test]
        public void GetBlogPostById()
        {
            string expectedId = "1";
            var response = Client.Request($"/posts/{expectedId}");
            string actualId = response.id.ToString();
            actualId.Should().Be(expectedId);
        }

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
