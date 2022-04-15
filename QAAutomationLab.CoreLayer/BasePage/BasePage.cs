using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.CoreLayer.BasePage
{
    public abstract class BasePage
    {
        protected BaseWebElement containerElement;

        public BasePage()
        {
            DriverInstance = Driver.Driver.GetInstance();
        }

        public BasePage(By containerLocator)
        {
            DriverInstance = Driver.Driver.GetInstance();
            containerElement = new(containerLocator);
        }

        public IWebDriver DriverInstance { get; }
    }
}
