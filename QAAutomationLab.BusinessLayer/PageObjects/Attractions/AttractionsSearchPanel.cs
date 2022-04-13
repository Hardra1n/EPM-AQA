using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.Waiters;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class AttractionsSearchPanel : BasePage
    {
        private static readonly By _containerLocator = By.ClassName("css-1g9yk3");

        private readonly BaseWebElement _searchFieldElement = new(By.XPath("//input[@type=\"search\"]"));

        private readonly By _cruiseLocator = By.XPath("//a[contains(@href, \"cruise\")]");

        public AttractionsSearchPanel()
            : base(_containerLocator)
        {
        }

        private BaseWebElement SubmitButton => new(By.XPath("//button[.=\"Search\"]"));

        private BaseWebElement CruiseResultLink => new(_cruiseLocator);

        public AttractionsSearchPanel EnterSearchString(string text)
        {
            _searchFieldElement.SendKeys(text);

            return this;
        }

        public SearchResultsPage GoToSearchResult(string text)
        {
            _searchFieldElement.SendKeys(text);
            DriverInstance.WaitForElementToAppear(_cruiseLocator);
            SubmitButton.Click();

            return new SearchResultsPage();
        }

        public AttrationPage SubmitSearchRequest()
        {
            SubmitButton.Click();

            return new AttrationPage();
        }

        public AttractionSinglePage ChooseCruiseResult()
        {
            DriverInstance.WaitForElementToAppear(_cruiseLocator);
            CruiseResultLink.Click();

            return new AttractionSinglePage();
        }
    }
}
