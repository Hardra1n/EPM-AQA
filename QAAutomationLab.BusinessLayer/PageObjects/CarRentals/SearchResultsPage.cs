using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.CarRentals
{
    public class SearchResultsPage:BasePage
    {
        private const string _title = "at discounted rates";

        public SearchResultsPage() : base() 
        {
            DriverInstance.FindElement(By.XPath($"//title[contains(text(),'{_title}')]"));
        }
    }
}
