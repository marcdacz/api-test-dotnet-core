using API.TestFramework.Environment;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace API.TestFramework
{
    [TestFixture]
    public class PostMethodTests : BaseTestFixture
    {
        [Test]
        public void CreateBlogPost()
        {
            var data = new { userId = 1, title = "my awesome post", body = "this is my awesome post!" };
            var response = Client.Request($"/posts", ClientMethod.POST, data.AsJson()).GetDynamic();
            string blogIdStr = response.id.ToString();
            int blogId = Convert.ToInt32(blogIdStr);
            blogId.Should().BeGreaterThan(0);
        }
    }
}
