using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class SearchResultsList : BasePage
    {
        private static readonly By _containerLocator = By.ClassName("css-wuc7a6");

        private readonly By _resultLocator = By.XPath("//a[@class=\"css-xbcz3d\"]");

        private List<SearchResultElement> _searchResults = new();

        public SearchResultsList()
            : base(_containerLocator)
        {
            GetResultList();
        }

        private BaseWebElement TypeOfSortButton => new(By.XPath("//button[@class=\"_7a08ee31f2 _25a3e33c2a _44a4609e1c _5a7a33cce8 _4671f4fac1\"]"));

        public string ShowFirstResultTitle()
        {
            return _searchResults.First().GetTitle();
        }

        public SearchResultsList ChooseFilterButton(string buttonText)
        {
            TypeOfSortButton.Click();
            GetFilterButton(buttonText).Click();
            GetResultList();

            return this;
        }

        private static BaseWebElement GetFilterButton(string innerText)
        {
            return new BaseWebElement(By.XPath($"//button[.=\"{innerText}\"]"));
        }

        private void GetResultList()
        {
            _searchResults = new List<SearchResultElement>();
            var results = containerElement.FindElements(_resultLocator);
            foreach (var result in results)
            {
                _searchResults.Add(new(result));
            }
        }
    }
}
