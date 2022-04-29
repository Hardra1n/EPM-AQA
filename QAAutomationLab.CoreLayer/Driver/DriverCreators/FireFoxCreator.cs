using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace QAAutomationLab.CoreLayer.Driver.DriverCreators
{
    internal class FireFoxCreator : DriverCreator
    {
        internal override IWebDriver CreateDriver(string PathToDriver)
        {
            return new FirefoxDriver(PathToDriver);
        }
    }
}
