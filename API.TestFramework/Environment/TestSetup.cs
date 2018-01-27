using NUnit.Framework;

namespace API.TestFramework
{
    [SetUpFixture]
    public class TestSetup
    {     
        [OneTimeSetUp]
        public void Setup()
        {
            /*
             One Time Setup Code Here
             */
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            /*
             One Time Cleanup Code Here
             */
        }
    }
}
