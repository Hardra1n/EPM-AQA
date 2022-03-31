using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;
using System;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays
{
    public class StaysAdPage : BasePage
    {
        private BaseWebElement _titleElement = new(By.XPath("//title"));

        private BaseWebElement _hotelNameElement = new(By.Id("hp_hotel_name"));

        private BaseWebElement _reserveButton = new(By.Id("hp_book_now_button"));

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
    }
}