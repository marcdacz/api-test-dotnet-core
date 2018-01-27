using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.IO;

namespace API.TestFramework.Environment
{
    public class BaseTestFixture
    {
        public IConfigurationRoot Configuration { get; set; }
        public Uri BaseAddress { get; set; }
        public Client Client { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("testsettings.json");

            Configuration = builder.Build();
            BaseAddress = new Uri (Configuration.GetSection("TestAPIUrl").Value);
        }

        [SetUp]
        public void Setup()
        {
            Client = new Client
            {
                BaseAddress = BaseAddress
            };
        }
    }
}
