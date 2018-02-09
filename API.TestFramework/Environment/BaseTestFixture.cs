using NUnit.Framework;
using System;

namespace API.TestFramework.Environment
{
    [TestFixture]
    public class BaseTestFixture
    {
        public Client Client { get; set; }

        [SetUp]
        public virtual void Setup()
        {
             Client = new Client(new Uri(TestContext.Parameters.Get("apiUrl")));
        }
    }
}
