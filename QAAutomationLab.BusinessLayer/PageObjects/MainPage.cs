using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.PageObjects.Attractions;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects
{
    public class MainPage:BasePage
    {
        private const string _title = "Booking.com";

        public BaseWebElement CarRentalsButton => new BaseWebElement(By.XPath("//span[contains(text(),'Car rentals')]"));

        private readonly BaseWebElement _attractionsButton = new(By.XPath("//a[@data-decider-header=\"attractions\"]"));

        public MainPage():base() 
        {
            DriverInstance.FindElement(By.XPath($"//title[contains(text(),'{_title})]"));
        }

        public AttrationPage GoToAttractions()
        {
            _attractionsButton.Click();
            return new AttrationPage();
        }
    }
}
