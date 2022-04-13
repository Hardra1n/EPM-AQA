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

        private BaseWebElement ActivitiesCheckBox => new(By.XPath("//span[text()=\"Activities\"]/.."));

        private BaseWebElement PriceCheckBox => new(By.XPath("(//div[@class=\"css-18yal0d\"])[10]"));

        private BaseWebElement FreeCancellationCheckBox => new(By.XPath("//span[text()=\"Free cancellation\"]/.."));

        private BaseWebElement BrooklynCheckBox => new(By.XPath("//span[text()=\"Brooklyn\"]/.."));

        public SearchResultsPage FilterResult()
        {
            DriverInstance.WaitForElementToBeClickable(ActivitiesCheckBox.Locator);
            ActivitiesCheckBox.Click();
            PriceCheckBox.Click();
            FreeCancellationCheckBox.Click();
            BrooklynCheckBox.Click();

            return new SearchResultsPage();
        }
    }
}
