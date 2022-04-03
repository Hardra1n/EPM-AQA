using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;
using System;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays
{
    public class StaysAdPage : BasePage
    {
        private BaseWebElement _hotelNameElement = new(By.Id("hp_hotel_name"));

        private BaseWebElement _mapContainer = new(By.Id("b_map_container"));

        public StaysAdPage() : base()
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

        public string GetHotelName() => _hotelNameElement.Text;

        public bool IsMapDisplayed() => _mapContainer.Displayed;
    }
}