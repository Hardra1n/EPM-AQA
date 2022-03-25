using OpenQA.Selenium;

namespace QAAutomationLab.CoreLayer.BasePage
{
    public abstract class BasePage
    {
        public IWebDriver Driver;

        public BasePage()
        {
            this.Driver = CoreLayer.Driver.Driver.GetInstance();           
        }
    }
}
