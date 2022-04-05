using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.Logging;
using QAAutomationLab.CoreLayer.WebElement;
using Serilog;

namespace QAAutomationLab.CoreLayer.BasePage
{
    public abstract class BasePage
    {
        protected BaseWebElement ContainerElement;

        public IWebDriver DriverInstance;

        public BasePage()
        {
            this.DriverInstance = Driver.Driver.GetInstance();           
        }

        public BasePage(By containerLocator)
        {
            DriverInstance = Driver.Driver.GetInstance();
            ContainerElement = new(containerLocator);
        }
    }
}
