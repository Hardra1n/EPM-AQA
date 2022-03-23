using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects
{
    public class MainPage:BasePage
    {
        private const string _title = "Booking.com";

        public BaseWebElement CarRentalsButton => new BaseWebElement(By.XPath("//span[contains(text(),'Car rentals')]"));

        public MainPage(IWebDriver driver):base(driver) 
        {
            Driver.FindElement(By.XPath($"//title[contains(text(),'{_title})]"));
        }
    }
}
