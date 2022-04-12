using System;
using System.Linq;
using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays
{
    public class StaysSearchResultsContainer : BasePage
    {
        private static By _containerLocator = By.Id("right");

        private readonly string _noAdsExceptionMessage = "There are no ads on the page";

        public StaysSearchResultsContainer()
            : base(_containerLocator) { }

        public By FilteringOverlayLocator => By.XPath("//div[@data-testid='overlay-card']");

        private BaseWebElement _adsHeadElement
            => containerElement.FindElement(By.XPath("//h1"));

        private BaseWebElement _firstAdNavigatingButton
            => containerElement.FindElements(
                By.XPath("//div[@data-testid='property-card']//a[@role='button']")).FirstOrDefault();

        private BaseWebElement _firstAdTitle
            => containerElement.FindElements(By.XPath("//div[@data-testid = 'title']")).FirstOrDefault();

        private BaseWebElement _firstShowOnMapButton
            => containerElement.FindElements(By.XPath("//div[@data-testid = 'location']/a")).FirstOrDefault();

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

        public string GetFirstAddTitle()
            => _firstAdTitle.Text;

        public StaysAdPage ClickFirstAdNavigatingButton()
        {
            if (GetAdsCount() > 0)
            {
                Utilities.Utilities.SwitchToNewHandle(_firstAdNavigatingButton.Click);
                return new StaysAdPage();
            }

            throw new ArgumentException(_noAdsExceptionMessage);
        }

        public StaysAdPage ClickFirstShowOnMapButton()
        {
            Utilities.Utilities.SwitchToNewHandle(_firstShowOnMapButton.Click);
            return new StaysAdPage();
        }
    }
}
