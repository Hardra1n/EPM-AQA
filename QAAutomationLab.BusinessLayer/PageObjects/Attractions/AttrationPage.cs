using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.Waiters;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class AttrationPage : BasePage
    {
        private readonly BaseWebElement _searchFieldElement = new(By.XPath("//input[@type=\"search\"]"));

        private readonly BaseWebElement _topDestinationDubai = new(By.XPath("//a[@title=\"Dubai\"]"));

        private readonly By _cruiseLocator = By.XPath("//a[contains(@href, \"cruise\")]");

        public AttrationPage()
            : base()
        {
        }

        public string BaseUrl => DriverInstance.Url;

        private BaseWebElement _asiaTab => new(By.XPath("//button[.=\"Asia\"]"));

        private BaseWebElement _kyotoLink => new(By.XPath("//a[@title=\"Kyoto\"]"));

        private BaseWebElement _cruiseResultLink => new(_cruiseLocator);

        private BaseWebElement _submitButton => new(By.XPath("//button[.=\"Search\"]"));

        public AttrationPage EnterSearchString(string text)
        {
            _searchFieldElement.SendKeys(text);

            return this;
        }

        public SearchResultsPage GoToDubai()
        {
            _topDestinationDubai.Click();

            return new SearchResultsPage();
        }

        public SearchResultsPage GoToSearchResult(string text)
        {
            _searchFieldElement.SendKeys(text);
            DriverInstance.WaitForElementToAppear(_cruiseLocator);
            _submitButton.Click();

            return new SearchResultsPage();
        }

        public SearchResultsPage GoToKyoto()
        {
            _kyotoLink.Click();

            return new SearchResultsPage();
        }

        public AttrationPage SubmitSearchRequest()
        {
            _submitButton.Click();

            return this;
        }

        public AttrationPage ChooseAsiaTab()
        {
            _asiaTab.Click();

            return this;
        }

        public AttractionSinglePage ChooseCruiseResult()
        {
            DriverInstance.WaitForElementToAppear(_cruiseLocator);
            _cruiseResultLink.Click();

            return new AttractionSinglePage();
        }
    }
}
