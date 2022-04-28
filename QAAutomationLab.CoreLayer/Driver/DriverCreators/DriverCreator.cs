using System;
using OpenQA.Selenium;

namespace QAAutomationLab.CoreLayer.Driver.DriverCreators
{
     public abstract class DriverCreator
     {
        protected const int _implicitWaitTime = 15;

        internal virtual void SetupParameters(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_implicitWaitTime);
        }

        internal abstract IWebDriver CreateDriver(string PathToDriver);
    }
}
