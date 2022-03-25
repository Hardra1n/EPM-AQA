using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.PageObjects;
using QAAutomationLab.CoreLayer.Driver;

namespace QAAutomationLab.BusinessLayer.Utilities
{
    public class Utilities
    {
        public static MainPage RunBrowser(string url) 
        {
            IWebDriver driver = Driver.GetInstance();

            driver.Navigate().GoToUrl(url);

            return new MainPage(driver);
        }
    }
}
