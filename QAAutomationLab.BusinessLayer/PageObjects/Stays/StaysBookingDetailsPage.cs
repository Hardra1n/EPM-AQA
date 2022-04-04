using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays
{
    public class StaysBookingDetailsPage : BasePage
    {
        private BaseWebElement _hotelNameElement = new(By.XPath("//h1[contains(@id, 'title')]"));

        public StaysBookingDetailsPage() : base() { }

        public string GetHotelName() => _hotelNameElement.Text;
    }
}