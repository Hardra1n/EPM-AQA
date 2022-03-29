using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace QAAutomationLab.CoreLayer.Driver
{
    public class Driver
    {
        private static IWebDriver _driver;

        public const int _implicitWaitTime = 15;

        public static string PathToDriver;

        private static object _locker = new object();

        private Driver() { }

        public static IWebDriver GetInstance()
        {
            if (_driver is null)
            {
                lock (_locker)
                {
                    _driver = new ChromeDriver(@"D:\qa-automation-lab\QAAutomationLab.CoreLayer\Files\");
                }

                SetUpParameters();
            }

            return _driver;
        }

        private static void SetUpParameters()
        {
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_implicitWaitTime);
        }

        public static void Quit()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
