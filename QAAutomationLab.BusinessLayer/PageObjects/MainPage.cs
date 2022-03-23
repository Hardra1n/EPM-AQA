using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects
{
    public class MainPage:BasePage
    {
        private const string _title = "Booking.com";

        public MainPage(IWebDriver driver):base(driver) 
        {
            Driver.FindElement(By.XPath($"//title[contains(text(),'{_title})]"));
        }
    }
}
