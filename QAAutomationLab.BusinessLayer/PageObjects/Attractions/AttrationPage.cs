using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class AttrationPage : BasePage
    {
        private readonly BaseWebElement _searchFieldElement = new(By.XPath("//input[@type=\"search\"]"));

        private readonly BaseWebElement _submitButton = new(By.XPath("//input[@type=\"search\"]"));

        private readonly BaseWebElement _topDestinationDubai = new(By.XPath("//a[@title=\"Dubai\"]"));

        private readonly BaseWebElement _asiaTab = new(By.XPath("//button[.=\"Asia\"]"));

        private readonly BaseWebElement _kyotoLink = new(By.XPath("//a[@title=\"Kyoto\"]"));

        public string BaseUrl;

        public AttrationPage() : base()
        {
            BaseUrl = DriverInstance.Url;
        }

        public AttrationPage EnterSearchString(string text)
        {
            _searchFieldElement.SendKeys(text);

            return this;
        }

        public SearchResultsPage GoToDubai()
        {
            _topDestinationDubai.Click();

            return new SearchResultsPage(Driver);
        }

        public SearchResultsPage GoToSearchResult(string text)
        {
            _searchFieldElement.SendKeys(text);
            _submitButton.Click();

            return new SearchResultsPage(Driver);
        }

        public SearchResultsPage GoToKyoto()
        {
            _kyotoLink.Click();

            return new SearchResultsPage(Driver);
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
    }
}
