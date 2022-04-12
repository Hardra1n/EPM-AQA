using System.Collections.Generic;
using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.Waiters;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class SearchResultsMiddleBar:BasePage
    {
        private static By containerLocator = By.XPath("//button[@type='submit']/../../../../../..");

        private readonly By _cruiseLocator = By.XPath("//a[contains(@href, 'cruise')]");

        private readonly By _firstResultLocator = By.XPath("//a[@class='css-xbcz3d']");

        private readonly By _nightBusLocator = By.XPath("//a[contains(@href, 'night-bus')]");

        private BaseWebElement _searchField => containerElement.FindElement(By.XPath("//*[@type='search']"));

        private BaseWebElement _submitButton => containerElement.FindElement(By.XPath("//*[@type='submit']"));

        private BaseWebElement _nightBusResult => containerElement.FindElement(_nightBusLocator);

        private BaseWebElement _cruiseResultLink => containerElement.FindElement(_cruiseLocator);

        public SearchResultsMiddleBar()
            : base(containerLocator) { }

        public AttractionsSinglePageRightBar ChooseCruiseResult()
        {
            DriverInstance.WaitForElementToAppear(_cruiseLocator);
            _cruiseResultLink.Click();

            return new AttractionsSinglePageRightBar();
        }

        public string ShowFirstResultTitle()
        {
            var firstResultLink = DriverInstance.FindElements(_firstResultLocator)[0];
            return firstResultLink.GetAttribute("title");
        }

        public AttractionsSinglePageRightBar ChooseEdgeResult()
        {
            _searchField.SendKeys("Edge");
            DriverInstance.WaitForElementToAppear(_nightBusLocator);
            _nightBusResult.Click();

            return new AttractionsSinglePageRightBar();
        }

        public SearchResultsMiddleBar SearchForSimilarActivities(string text)
        {
            _searchField.SendKeys(text);
            DriverInstance.WaitForElementToAppear(_nightBusLocator);
            _submitButton.Click();

            return this;
        }

        public IReadOnlyCollection<IWebElement> FindAllResults()
        {
            DriverInstance.WaitForElementsCountToBeExpected(_firstResultLocator, 4);
            return DriverInstance.FindElements(_firstResultLocator);
        }
    }
}
