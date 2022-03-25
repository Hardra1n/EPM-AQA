using OpenQA.Selenium;

namespace QAAutomationLab.CoreLayer.BasePage
{
    public abstract class BasePage
    {
        public IWebDriver DriverInstance;

        public BasePage()
        {
            this.DriverInstance = Driver.Driver.GetInstance();           
        }
    }
}
