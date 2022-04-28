using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace QAAutomationLab.CoreLayer.Driver.DriverCreators
{
    internal class IECreator : DriverCreator
    {
        internal override IWebDriver CreateDriver(string PathToDriver)
            => new InternetExplorerDriver(PathToDriver);
    }
}
