using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.Waiters;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class SearchResultsLeftBar : BasePage
    {
        private static By containerLocator = By.XPath("//h3[contains(text(),'Filter')]/../..");

        private BaseWebElement _activitiesCheckBox => containerElement.FindElement(By.XPath("//span[text()='Activities']/.."));

        private BaseWebElement _priceCheckBox => containerElement.FindElement(By.XPath("(//div[@class='css-18yal0d'])[10]"));

        private BaseWebElement _freeCancellationCheckBox => containerElement.FindElement(By.XPath("//span[text()='Free cancellation']/.."));

        private BaseWebElement _brooklynCheckBox => containerElement.FindElement(By.XPath("//span[text()='Brooklyn']/.."));

        public SearchResultsLeftBar()
            : base(containerLocator) { }


        public SearchResultsLeftBar FilterResult()
        {
            DriverInstance.WaitForElementToBeClickable(_activitiesCheckBox.Locator);
            _activitiesCheckBox.Click();
            _priceCheckBox.Click();
            _freeCancellationCheckBox.Click();
            _brooklynCheckBox.Click();

            return this;
        }
    }
}
