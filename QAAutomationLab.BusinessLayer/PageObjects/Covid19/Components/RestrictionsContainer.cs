using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.Covid19.Components
{
    public class RestrictionsContainer : BasePage
    {
        private static By _containerLocator
            = By.XPath("//*[contains(@id, 'restrictions')]//ancestor::section");

        public RestrictionsContainer()
            : base(_containerLocator) { }
    }
}
