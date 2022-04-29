using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QAAutomationLab.CoreLayer.Driver.DriverCreators
{
    internal class ChromeCreator : DriverCreator
    {
        internal override IWebDriver CreateDriver(string PathToDriver)
            => new ChromeDriver(PathToDriver);
    }
}
