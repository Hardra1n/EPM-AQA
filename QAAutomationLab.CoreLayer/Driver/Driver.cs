using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QAAutomationLab.CoreLayer.Driver
{
    public class Driver
    {
        public const int _implicitWaitTime = 15;

        private static IWebDriver _driver;

        private static object _locker = new object();

        private Driver() { }

        public static string PathToDriver { get; set; }

        public static IWebDriver GetInstance()
        {
            if (_driver is null)
            {
                lock (_locker)
                {
                    _driver = new ChromeDriver(PathToDriver);
                }

                SetUpParameters();
            }

            return _driver;
        }

        public static void Quit()
        {
            _driver.Quit();
            _driver = null;
        }

        private static void SetUpParameters()
        {
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_implicitWaitTime);
        }
    }
}
