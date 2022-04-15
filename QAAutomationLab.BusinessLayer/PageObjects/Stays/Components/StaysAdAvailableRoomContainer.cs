using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays.Components
{
    public class StaysAdAvailableRoomContainer : BasePage
    {
        private static By _containerLocator = By.Id("available_rooms");

        public StaysAdAvailableRoomContainer()
            : base(_containerLocator) { }

        private BaseWebElement _firstRoomSelector
            => new(By.XPath("//select[contains(@data-component, 'select-rooms')]"));

        private BaseWebElement _navigatingToBookingButton
            => new(By.XPath("//div[contains(@data-component, 'reservation-cta')]/button"));

        public StaysAdAvailableRoomContainer AddOneRoomToBooking()
        {
            SelectElement element = new SelectElement(_firstRoomSelector.Element);
            element.SelectByValue("1");
            return this;
        }

        public StaysBookingDetailsPage ClickNavigatingToBookingButton()
        {
            _navigatingToBookingButton.Click();
            return new StaysBookingDetailsPage();
        }
    }
}
