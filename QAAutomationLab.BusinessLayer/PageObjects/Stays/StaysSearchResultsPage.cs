using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays
{
    public class StaysSearchResultsPage : BasePage
    {
        private const string _title = "Hotels in";

        private const string _noAdsExceptionMessage = "There are no ads on the page";

        public StaysSearchResultsPage()
            : base()
        {
            DriverInstance.FindElement(By.XPath($"//title[contains(text(),'{_title}')]"));
        }

        public BaseWebElement _filteringOverlayElement
            => new(By.XPath("//div[@data-testid='overlay-card']"));

        private BaseWebElement _firstAdNavigatingButton
            => new(DriverInstance.FindElements(
                By.XPath("//div[@data-testid='property-card']//a[@role='button']")).FirstOrDefault());

        private BaseWebElement _firstAdTitle
            => new(DriverInstance.FindElements(By.XPath("//div[@data-testid = 'title']")).FirstOrDefault());

        private BaseWebElement _firstFilteringStarsOption
            => new(DriverInstance.FindElements(
                By.XPath("//div[@data-filters-group = 'class']//div[@data-filters-item]")).FirstOrDefault());

        private BaseWebElement _firstShowOnMapButton
            => new(DriverInstance.FindElements(By.XPath("//div[@data-testid = 'location']/a")).FirstOrDefault());

        private BaseWebElement _adsHeadElement => new(By.XPath("//h1"));

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

        public StaysSearchResultsPage ClickFirstFilteringStarsOption()
        {
            _firstFilteringStarsOption.Click();
            var waiter = new WebDriverWait(DriverInstance, TimeSpan.FromSeconds(10));
            waiter.PollingInterval = TimeSpan.FromSeconds(1);
            waiter.Until(x => _filteringOverlayElement.Displayed);
            waiter.Until(x =>
            {
                try
                {
                    return !_filteringOverlayElement.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
            return this;
        }

        public StaysAdPage ClickFirstShowOnMapButton()
        {
            Utilities.Utilities.SwitchToNewHandle(_firstShowOnMapButton.Click);
            return new StaysAdPage();
        }
    }
}
