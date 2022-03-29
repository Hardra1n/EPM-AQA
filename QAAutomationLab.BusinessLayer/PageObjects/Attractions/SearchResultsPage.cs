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
    public class SearchResultsPage : BasePage
    {
        private BaseWebElement _activitiesCheckBox => new(By.XPath("//*[@value=\"activities\"]"));

        private BaseWebElement _priceCheckBox => new(By.XPath("//*[@value=\"b1\"]"));

        private BaseWebElement _freeCancellationCheckBox => new(By.XPath("//*[@value=\"free_cancellation\"]"));

        private BaseWebElement _brooklynCheckBox => new(By.XPath("//*[@value=\"20085207\"]"));

        private readonly BaseWebElement _searchField = new(By.XPath("//*[@type=\"search\"]"));

        private readonly BaseWebElement _submitButton = new(By.XPath("//*[@type=\"submit\"]"));

        public string BaseUrl;

        public SearchResultsPage() : base()
        {
            BaseUrl = DriverInstance.Url;
        }

        public string ShowFirstResultTitle()
        {
            var firstResultLink = DriverInstance.FindElements(By.XPath("//a[@class=\"css-xbcz3d\"]"))[0];
            return firstResultLink.GetAttribute("title");
        }

        public SearchResultsPage FilterResult()
        {
            _activitiesCheckBox.Click();
            _priceCheckBox.Click();
            _freeCancellationCheckBox.Click();
            _brooklynCheckBox.Click();

            return this;
        }

        public SearchResultsPage SearchForSimilarActivities(string text)
        {
            _searchField.SendKeys(text);
            _submitButton.Click();

            return this;
        }
    }
}
