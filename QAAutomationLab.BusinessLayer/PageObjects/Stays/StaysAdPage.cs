using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays
{
    public class StaysAdPage : BasePage
    {
        public StaysAdPage()
            : base()
        {
            try
            {
                var str = _hotelNameElement.Text;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\n Driver hasn't navigated to Ad page");
            }
        }

        private BaseWebElement _hotelNameElement => new(By.Id("hp_hotel_name"));

        private BaseWebElement _mapContainer => new(By.Id("b_map_container"));

        private BaseWebElement _firstRoomSelector
            => new(By.XPath("//select[contains(@data-component, 'select-rooms')]"));

        private BaseWebElement _navigatingToBookingButton
            => new(By.XPath("//div[contains(@data-component, 'reservation-cta')]/button"));

        public string GetHotelName()
        {
            int hotelNameStartIndex = _hotelNameElement.Text.LastIndexOf('\n') + 1;
            return _hotelNameElement.Text.Substring(hotelNameStartIndex);
        }

        public bool IsMapDisplayed() => _mapContainer.Displayed;

        public StaysAdPage AddOneRoomToBooking()
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