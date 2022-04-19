using System.Linq;
using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.Waiters;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays.Components
{
    public class StaysSearchResultsContainer : BasePage
    {
        private static By _containerLocator = By.Id("right");

        public StaysSearchResultsContainer()
            : base(_containerLocator) { }

        public By FilteringOverlayLocator => By.XPath("//div[@data-testid='overlay-card']");

        private By _propertyCardLocator => By.XPath("//div[@data-testid='property-card']");

        private BaseWebElement _adsHeadElement
            => containerElement.FindElement(By.XPath("//h1"));

        public int? GetAdsCount()
        {
            string digits = new string(_adsHeadElement.Text.Where(c => char.IsDigit(c)).ToArray());
            if (int.TryParse(digits, out int number))
            {
                return number;
            }
            else
            {
                return null;
            }
        }

        public int GetAdsCountOnPage()
            => containerElement.FindElements(_propertyCardLocator).Count();

        public StaysSearchAdCard GetAdCard(int cardIndex = 1)
        {
            return new StaysSearchAdCard(cardIndex);
        }

        public StaysSearchResultsContainer WaitForUpdateResults()
        {
            DriverInstance.WaitForElementToAppear(FilteringOverlayLocator);
            DriverInstance.WaitForElementToBeInvisable(FilteringOverlayLocator);
            return this;
        }
    }
}
