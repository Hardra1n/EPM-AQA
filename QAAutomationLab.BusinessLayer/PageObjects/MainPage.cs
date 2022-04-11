using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.PageObjects.Attractions;
using QAAutomationLab.BusinessLayer.PageObjects.CarRentals;
using QAAutomationLab.BusinessLayer.PageObjects.Stays;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects
{
    public class MainPage : BasePage
    {
        private const string _title = "Booking.com";

        private readonly BaseWebElement _attractionsButton = new(By.XPath("//a[@data-decider-header=\"attractions\"]"));

        public MainPage()
            : base()
        {
            DriverInstance.FindElement(By.XPath($"//title[contains(text(),'{_title}')]"));
        }

        private BaseWebElement _carRentalsButton => new BaseWebElement(By.XPath("//span[contains(text(),'Car rentals')]"));

        public AttrationPage GoToAttractions()
        {
            _attractionsButton.Click();
            return new AttrationPage();
        }

        public CarRentalsPage GoToCarRentals()
        {
            _carRentalsButton.Click();

            return new CarRentalsPage();
        }

        public StaysSearchingPage GoToStays() => new StaysSearchingPage();
    }
}
