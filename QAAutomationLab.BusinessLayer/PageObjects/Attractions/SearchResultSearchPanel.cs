using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.Waiters;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class SearchResultSearchPanel : BasePage
    {
        private static readonly By _containerLocator = By.ClassName("css-orcr9a");

        private readonly BaseWebElement _searchField = new(By.XPath("//*[@type=\"search\"]"));

        private readonly By _nightBusLocator = By.XPath("//a[contains(@href, \"night-bus\")]");

        public SearchResultSearchPanel()
            : base(_containerLocator)
        {
        }

        private BaseWebElement SubmitButton => new(By.XPath("//*[@type=\"submit\"]"));

        private BaseWebElement NightBusResult => new(_nightBusLocator);

        public SearchResultsPage SearchForSimilarActivities(string text)
        {
            _searchField.SendKeys(text);
            DriverInstance.WaitForElementToAppear(_nightBusLocator);
            SubmitButton.Click();

            return new SearchResultsPage();
        }

        public AttractionSinglePage ChooseEdgeResult()
        {
            _searchField.SendKeys("Edge");
            DriverInstance.WaitForElementToAppear(_nightBusLocator);
            NightBusResult.Click();

            return new AttractionSinglePage();
        }
    }
}
