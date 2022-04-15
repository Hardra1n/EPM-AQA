using System.Linq;
using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays.Components
{
    public class StaysSearchAdCard : BasePage
    {
        private static string _containerSelector = ".//div[@data-testid = 'property-card']";

        public StaysSearchAdCard(int cardIndex)
            : base(By.XPath(_containerSelector + $"[{cardIndex}]")) { }

        private BaseWebElement _adNavigatingButton
            => containerElement.FindElement(By.XPath(".//a[@role='button']"));

        private BaseWebElement _adTitleElement
            => containerElement.FindElement(By.XPath(".//div[@data-testid = 'title']"));

        private BaseWebElement _showOnMapButton
            => containerElement.FindElement(By.XPath("//div[@data-testid = 'location']/a"));

        private BaseWebElement _priceElement
            => containerElement.FindElement(
                By.XPath("//div[contains(@data-testid, 'discounted-price')]"));

        public string GetAdTitle() => _adTitleElement.Text;

        public StaysAdPage ClickNavigatingButton()
        {
            Utilities.Utilities.SwitchToNewHandle(_adNavigatingButton.Click);
            return new StaysAdPage();
        }

        public StaysAdPage ClickShowOnMapButton()
        {
            Utilities.Utilities.SwitchToNewHandle(_showOnMapButton.Click);
            return new StaysAdPage();
        }

        public int GetPrice()
        {
            string price = new string(_priceElement.Text.Where(x => char.IsDigit(x)).ToArray());
            return int.Parse(price);
        }
    }
}
