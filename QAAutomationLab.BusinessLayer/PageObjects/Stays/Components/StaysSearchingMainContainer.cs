using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.PageObjects.Covid19;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays.Components
{
    public class StaysSearchingMainContainer : BasePage
    {
        private static By _containerLocator = By.Id("bodyconstraint");

        public StaysSearchingMainContainer()
            : base(_containerLocator) { }

        private BaseWebElement _covidInfoButton
            => containerElement.FindElement(
                By.XPath("//div[contains(@data-capla-component, 'Covid')]//a"));

        public CovidPage GoToCovidPage()
        {
            _covidInfoButton.Click();
            return new CovidPage();
        }
    }
}
