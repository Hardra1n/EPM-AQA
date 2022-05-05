using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using QAAutomationLab.CoreLayer.Clients;

namespace QAAutomationLab.APITestLayer
{
    public class BaseHttpClientTest
    {
        protected IBaseClient Client { get; private set; }

        protected int UserId { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Client = new BaseHttpClient("https://api.playgroundtech.io/v1/");
        }
    }
}
