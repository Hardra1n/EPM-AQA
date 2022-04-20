using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays.Components
{
    public class StaysFooterContainer : BasePage
    {
        private static By _containerLocator = By.Id("booking-footer");

        public StaysFooterContainer()
            : base(_containerLocator) { }

        private IEnumerable<BaseWebElement> _footerLinks
            => containerElement.FindElements(
                By.XPath("//li[@class = 'footer-navigation-link']/a"));

        public IEnumerable<BaseWebElement> GetFooterLinks()
        {
            return _footerLinks;
        }
    }
}
