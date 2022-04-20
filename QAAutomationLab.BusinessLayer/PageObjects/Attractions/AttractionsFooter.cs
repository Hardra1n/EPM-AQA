using System.Collections.Generic;
using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class AttractionsFooter : BasePage
    {
        private static By _containerLocator = By.XPath("//div[@class='css-1020tlj']");

        private IEnumerable<BaseWebElement> _footerLinks 
            => containerElement.FindElements(By.XPath("//a[@target='_blank']"));

        public AttractionsFooter()
            : base(_containerLocator) { }

        public IEnumerable<BaseWebElement> GetFooterLinks()
        {
            return _footerLinks;
        }
    }
}
