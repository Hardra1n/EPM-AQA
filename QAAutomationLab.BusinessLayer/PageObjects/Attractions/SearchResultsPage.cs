using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.Waiters;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;
using System.Collections.Generic;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class SearchResultsPage : BasePage
    {
        private BaseWebElement _activitiesCheckBox => new(By.XPath("//span[text()=\"Activities\"]/.."));
        
        private BaseWebElement _priceCheckBox => new(By.XPath("(//div[@class=\"css-18yal0d\"])[10]"));

        private BaseWebElement _freeCancellationCheckBox => new(By.XPath("//span[text()=\"Free cancellation\"]/.."));

        private BaseWebElement _brooklynCheckBox => new(By.XPath("//span[text()=\"Brooklyn\"]/.."));

        private readonly BaseWebElement _searchField = new(By.XPath("//*[@type=\"search\"]"));

        private BaseWebElement _submitButton => new(By.XPath("//*[@type=\"submit\"]"));

        private readonly By _firstResultLocator = By.XPath("//a[@class=\"css-xbcz3d\"]");

        private readonly By _nightBusLocator = By.XPath("//a[contains(@href, \"night-bus\")]");

        private BaseWebElement _nightBusResult => new(_nightBusLocator);

        public string BaseUrl => DriverInstance.Url;

        public SearchResultsPage() : base()
        {
        }

        public string ShowFirstResultTitle()
        {
            var firstResultLink = DriverInstance.FindElements(_firstResultLocator)[0];
            return firstResultLink.GetAttribute("title");
        }

        public SearchResultsPage FilterResult()
        {
            DriverInstance.WaitForElementToBeClickable(_activitiesCheckBox.Locator);
            _activitiesCheckBox.Click();
            _priceCheckBox.Click();
            _freeCancellationCheckBox.Click();
            _brooklynCheckBox.Click();

            return this;
        }

        public SearchResultsPage SearchForSimilarActivities(string text)
        {
            _searchField.SendKeys(text);
            DriverInstance.WaitForElementToAppear(_nightBusLocator);
            _submitButton.Click();

            return this;
        }

        public AttractionSinglePage ChooseEdgeResult()
        {
            _searchField.SendKeys("Edge");
            DriverInstance.WaitForElementToAppear(_nightBusLocator);
            _nightBusResult.Click();

            return new AttractionSinglePage();
        }

        public IReadOnlyCollection<IWebElement> FindAllResults()
        {
            DriverInstance.WaitForElementsCountToBeExpected(_firstResultLocator, 4);
            return DriverInstance.FindElements(_firstResultLocator);
        }
    }
}
