using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class AttractionPageSearchPanel : BasePage
    {
        private static By containerLocator = By.XPath("//div[contains(text(),'Find and book')]/..");

        private BaseWebElement _submitButton => containerElement.FindElement(By.XPath("//button[.=\"Search\"]"));

        private BaseWebElement _searchFieldElement => containerElement.FindElement(By.XPath("//input[@type='search']"));

        public AttractionPageSearchPanel()
            : base(containerLocator) { }

        public AttractionPageSearchPanel EnterSearchString(string text)
        {
            _searchFieldElement.SendKeys(text);

            return this;
        }

        public AttractionPageSearchPanel SubmitSearchRequest()
        {
            _submitButton.Click();

            return this;
        }

        /*
         public SearchResultsPage GoToSearchResult(string text)
        {
            _searchFieldElement.SendKeys(text);
            DriverInstance.WaitForElementToAppear(_cruiseLocator);
            _submitButton.Click();

            return new SearchResultsPage();
        }
        */
    }
}
