using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.CarRentals
{
    public class SearchResultsPanel : BasePage
    {
        private static By containerLocator = By.XPath("//div[contains(@class,'stage-map')]");

        private readonly By _noResultsMessage = By.XPath("//div[@class='no_results']");

        public SearchResultsPanel()
            : base(containerLocator) { }

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
