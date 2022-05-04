using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.Configuration;
using QAAutomationLab.CoreLayer.Driver.DriverCreators;

namespace QAAutomationLab.CoreLayer.Driver
{
    public class Driver
    {
        private static IWebDriver _driver;

        private static object _locker = new object();

        private Driver()
        {
            var creator = SelectDriverCreator();
            _driver = creator.CreateDriver(PathToDriver);
            creator.SetupParameters(_driver);
        }

        public static string PathToDriver { get; set; }

        public static IWebDriver GetInstance()
        {
            if (_driver is null)
            {
                lock (_locker)
                {
                    new Driver();
                }
            }

            return _driver;
        }

        public static void Quit()
        {
            _driver.Quit();
            _driver = null;
        }

        private static DriverCreator SelectDriverCreator()
        {
            var root = ConfigProvider.GetConfigRoot();
            string browser = root["browser"];
            //string browser = ConfigProvider.GetConfigRoot()["browser"];
            switch (browser.ToLower())
            {
                case "firefox":
                    return new FireFoxCreator();

                case "edge":
                    return new EdgeCreator();

                case "chrome":
                default:
                    return new ChromeCreator();
            }
        }
    }
}
