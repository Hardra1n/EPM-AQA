using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;

namespace MobileTestsProject.Tests.LocalDevice
{
    public class BaseTest
    {
        private AppiumOptions _options;

        protected AndroidDriver<AndroidElement> Driver { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var dataPath = Directory.GetParent(Directory.
                GetCurrentDirectory()).Parent.Parent.Parent.ToString();
            var fileShortPath = "MobileTestsProject\\Files\\chromedriver.exe";
            dataPath = Path.Combine(dataPath, fileShortPath);

            _options = new AppiumOptions();
            _options.AddAdditionalCapability(MobileCapabilityType.BrowserName, "Chrome");
            _options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            _options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Pixel 5");
            _options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "12.0");
            _options.AddAdditionalCapability("adbExecTimeout", 200000);
            _options.AddAdditionalCapability("chromedriverExecutable", dataPath);
        }

        [SetUp]
        public void SetUp()
        {
            Driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), _options);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
