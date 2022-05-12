using NUnit.Framework;
using QAAutomationLab.CoreLayer.Clients;

namespace QAAutomationLab.APITestLayer
{
    public class BaseHttpClientTest
    {
        protected IBaseClient Client { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Client = new BaseHttpClient("https://api.playgroundtech.io/v1/");
        }
    }
}
