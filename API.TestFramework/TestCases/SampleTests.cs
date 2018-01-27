using API.TestFramework.Environment;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace API.TestFramework
{
    [TestFixture]
    public class SampleTests
    {
        private Client _client;

        [SetUp]
        public void Setup()
        {
            _client = new Client
            {
                BaseAddress = new Uri(@"https://jsonplaceholder.typicode.com")
            };
        }

        [Test]
        public void GetAllBlogPosts()
        {
            var response = _client.Request($"/posts");
            int blogCount = Enumerable.Count(response);
            blogCount.Should().BeGreaterOrEqualTo(1);
            string userId = response[0].userId.ToString();
            userId.Should().NotBeEmpty();
        }

        [Test]
        public void CreateBlogPost()
        {           
            var data = new { userId = 1, title = "my awesome post", body = "this is my awesome post!" };           
            _client.Content = data.AsJson();
            _client.Method = Method.POST;
            var response = _client.Request($"/posts");
            string blogId = response.id.ToString();
            blogId.Should().NotBeEmpty();
        }

        [Test]
        public void UpdateBlogPost()
        {
            var blogTitle = "my awesome updated post";
            var blogDetails = "this is my awesome updated post!";
            var data = new { userId = 1, title = blogTitle, body = blogDetails };
            _client.Content = data.AsJson();
            _client.Method = Method.PUT;
            var response = _client.Request($"/posts/1");
            string title = response.title.ToString();
            title.Should().Be(blogTitle);
            string details = response.body.ToString();
            details.Should().Be(blogDetails);
        }

        [Test]
        public void GetBlogPostById()
        {
            string expectedId = "1";
            var response = _client.Request($"/posts/{expectedId}");
            string actualId = response.id.ToString();
            actualId.Should().Be(expectedId);
        }

        [Test]
        public void DeleteBlogPost()
        { 
            _client.Method = Method.DELETE;
            var response = _client.Request($"/posts/1");
            string blogPost = response.ToString();
            blogPost.Should().Be("{}");
        }
    }
}
