using System.Collections.Generic;
using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Covid19.Components
{
    public class RestrictionsContainer : BasePage
    {
        private static By _containerLocator
            = By.XPath("//*[contains(@id, 'restrictions')]//ancestor::section");

        public RestrictionsContainer()
            : base(_containerLocator) { }

        private IEnumerable<BaseWebElement> _areaRestrictionsButtons
            => containerElement.FindElements(By.XPath(".//button"));

        private IEnumerable<BaseWebElement> _countryRestrictionsLinks
            => containerElement.FindElements(By.XPath(".//a"));

        public RestrictionsContainer OpenRestrictions()
        {
            foreach (var button in _areaRestrictionsButtons)
            {
                button.Click();
            }

            return this;
        }

        public IEnumerable<BaseWebElement> GetCountryLinks()
        {
            return _countryRestrictionsLinks;
        }
    }
}
