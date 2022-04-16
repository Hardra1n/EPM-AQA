using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.Waiters;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class SearchResultCheckBox : BasePage
    {
        private static readonly By _containerLocator = By.ClassName("css-9zgckk");

        public SearchResultCheckBox()
            : base(_containerLocator)
        {
        }

        private BaseWebElement PriceCheckBox => new(By.XPath("(//div[@class=\"css-18yal0d\"])[10]"));

        public SearchResultCheckBox FilterByElementExceptPrice(string innerText)
        {
            var element = GetFilterPoint(innerText);
            DriverInstance.WaitForElementToBeClickable(element.Locator);
            element.Click();

            return this;
        }

        public SearchResultCheckBox FilterByPrice()
        {
            DriverInstance.WaitForElementToBeClickable(PriceCheckBox.Locator);
            PriceCheckBox.Click();

            return this;
        }

        public SearchResultsPage ReturnToSearchResultPage()
        {
            return new SearchResultsPage();
        }

        private static BaseWebElement GetFilterPoint(string innerText)
        {
            return new(By.XPath($"//span[text()=\"{innerText}\"]/.."));
        }
    }
}
