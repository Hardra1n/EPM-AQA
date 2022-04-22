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
                By.XPath("//a[contains(@aria-label, 'COVID')]"));

        public CovidPage GoToCovidPage()
        {
            Utilities.Utilities.SwitchToNewHandle(_covidInfoButton.Click);
            return new CovidPage();
        }
    }
}
