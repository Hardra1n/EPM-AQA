using System;
using System.Linq;
using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;
using QAAutomationLab.CoreLayer.WebElement.Extensions;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays.Components
{
    public class StaysFilterContainer : BasePage
    {
        private static By _containerLocator = By.Id("searchboxInc");

        public StaysFilterContainer()
            : base(_containerLocator) { }

        private BaseWebElement _firstFilteringStarsOption
            => containerElement.FindElements(
                By.XPath("//div[@data-filters-group = 'class']//div[@data-filters-item]")).FirstOrDefault();

        private BaseWebElement _ownPriceFilteringToggle
            => containerElement.FindElement(
                By.XPath("//div[@data-testid = 'filters-group-toggle-style']"));

        private BaseWebElement _lowerLimitSlider
            => containerElement.FindElements(
                By.XPath(".//div[@role='none']")).FirstOrDefault();

        private BaseWebElement _higerLimitSlider
            => containerElement.FindElements(
                By.XPath(".//div[@role='none']")).LastOrDefault();

        private BaseWebElement _priceLimitInfo
            => containerElement.FindElement(By.XPath(".//input[@type = 'range']"));

        public StaysFilterContainer ClickFirstFilteringStarsOption()
        {
            _firstFilteringStarsOption.Click();
            return this;
        }

        public StaysFilterContainer ClickOwnPriceToggle()
        {
            _ownPriceFilteringToggle.Click();
            return this;
        }

        public StaysFilterContainer SelectOwnPriceLimit(int lowerLimit, int higerLimit)
        {
            ChangeToggleLocation(_lowerLimitSlider, GetLowerLimitPrice, lowerLimit);
            ChangeToggleLocation(_higerLimitSlider, GetHigerLimitPrice, higerLimit);
            return this;
        }

        private void ChangeToggleLocation(BaseWebElement toggle, Func<int> getPriceLimit, int price)
        {
            int currentValue = getPriceLimit.Invoke();
            toggle.ClickAndHold();
            do
            {
                toggle.MoveByOffset(2 * Math.Sign(price - currentValue), 0);
                currentValue = getPriceLimit.Invoke();
            }
            while (currentValue != price);
            toggle.Click();
        }

        private int GetLowerLimitPrice()
        {
            string value = _priceLimitInfo.GetAttribute("aria-valuetext");
            value = value.Substring(0, value.IndexOf(' '));
            return int.Parse(value);
        }

        private int GetHigerLimitPrice()
        {
            string value = _priceLimitInfo.GetAttribute("aria-valuetext");
            int spaceIndex = value.LastIndexOf(' ');
            value = value.Substring(spaceIndex, value.Length - spaceIndex);
            return int.Parse(value);
        }
    }
}
