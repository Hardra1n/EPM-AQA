using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace QAAutomationLab.CoreLayer.Driver.DriverCreators
{
    internal class EdgeCreator : DriverCreator
    {
        internal override IWebDriver CreateDriver(string PathToDriver) 
            => new EdgeDriver(PathToDriver);
    }
}
