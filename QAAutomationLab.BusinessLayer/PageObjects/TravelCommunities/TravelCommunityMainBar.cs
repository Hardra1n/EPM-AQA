using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.Waiters;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.TravelCommunities
{
    public class TravelCommunityMainBar : BasePage
    {
        private static readonly By _containerLocator = By.TagName("main");

        private readonly By _resultsLocator = By.XPath("//*[@data-post-full-url]");

        private List<SearchResultElement> _searchResultElements;

        public TravelCommunityMainBar()
            : base(_containerLocator)
        {
            GetResultList();
        }

        private BaseWebElement SearchInput => new(By.XPath("//input[contains(@class, \"c-input\")]"));

        private BaseWebElement SearchButton => new(By.XPath("//*[@type=\"submit\"]"));

        public bool CheckIfResultExists(string resultTitle)
        {
            return _searchResultElements.Any(elem => elem.GetTitle().Contains(resultTitle));
        }

        public TravelCommunityMainBar FilterResults(string filterInput)
        {
            SearchInput.SendKeys(filterInput);
            SearchButton.Click();

            DriverInstance.WaitForElementToBeClickable(_resultsLocator);

            GetResultList();

            return new TravelCommunityMainBar();
        }

        private void GetResultList()
        {
            _searchResultElements = new List<SearchResultElement>();
            var results = DriverInstance.FindElements(_resultsLocator);
            foreach (var result in results)
            {
                _searchResultElements.Add(new(new BaseWebElement(result)));
            }
        }
    }
}
