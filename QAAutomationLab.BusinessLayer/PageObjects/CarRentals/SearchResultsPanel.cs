using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.CarRentals
{
    public class SearchResultsPanel : BasePage
    {
        private static By containerLocator = By.XPath("//div[contains(@class,'stage-map')]");

        private readonly By _noResultsMessage = By.XPath("//div[@class='no_results']");

        public SearchResultsPanel()
            : base(containerLocator) { }

        public BaseWebElement _firstSearchResult => containerElement.FindElement(By.XPath("//a[contains(@class,'result__bui-btn')]"));

        public CarSelectionPage ChooseFirstSearchResult()
        {
            _firstSearchResult.Click();

            return new CarSelectionPage();
        }

        public bool IsNoResultsMessageShown()
        {
            try
            {
                DriverInstance.FindElement(_noResultsMessage);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
