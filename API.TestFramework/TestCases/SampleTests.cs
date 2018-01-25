using API.TestFramework.Environment;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Text;

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
        public void SubmitBlogPost()
        {
            _client.Method = Method.POST;
            _client.Content = new StringContent("{\"userId\": 1, \"title\": \"my awesome post\", \"body\": \"this is my awesome post!\"}", Encoding.UTF8, "application/json");
            var response = _client.Request($"/posts");
        }

        [Test]
        public void GetBlogPosts()
        {
            var response = _client.Request($"/posts");
            string userId = response[0].userId.ToString();
            userId.Should().NotBeEmpty();
        }

        [Test]
        public void GetBlogPostById()
        {
            string expectedId = "1";
            var response = _client.Request($"/posts/{expectedId}");
            string actualId = response.id.ToString();
            actualId.Should().Be(expectedId);
        }
    }
}
