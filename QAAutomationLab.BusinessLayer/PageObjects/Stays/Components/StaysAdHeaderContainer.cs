using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays.Components
{
    public class StaysAdHeaderContainer : BasePage
    {
        private static By _containerLocator = By.XPath("//div[contains(@class, 'gallery-header')]");

        public StaysAdHeaderContainer()
            : base(_containerLocator) { }

        private BaseWebElement _hotelNameElement => new(By.Id("hp_hotel_name"));

        private BaseWebElement _mapContainer => new(By.Id("b_map_container"));

        public string GetHotelName()
        {
            int hotelNameStartIndex = _hotelNameElement.Text.LastIndexOf('\n') + 1;
            return _hotelNameElement.Text.Substring(hotelNameStartIndex);
        }

        public bool IsMapDisplayed() => _mapContainer.Displayed;
    }
}
