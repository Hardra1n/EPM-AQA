using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.CarRentals
{
    public class SearchResultsPage : BasePage
    {
        private const string _title = "at discounted rates";

        private readonly By _noResultsMessage = By.XPath("//div[@class='no_results']");

        public SearchResultsPage()
            : base()
        {
            WebDriverWait wait = new WebDriverWait(DriverInstance, System.TimeSpan.FromSeconds(25));

            wait.Until(x => x.FindElement(By.XPath($"//title[contains(text(),'{_title}')]")));
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
