using OpenQA.Selenium;

namespace QAAutomationLab.CoreLayer.BasePage
{
    public abstract class BasePage
    {
        public IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;           
        }
    }
}
