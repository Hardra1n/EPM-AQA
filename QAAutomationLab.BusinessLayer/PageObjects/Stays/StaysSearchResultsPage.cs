using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays
{
    public class StaysSearchResultsPage : BasePage
    {
        private const string _title = "Hotels in";

        public StaysSearchResultsPage() : base()
        {
            DriverInstance.FindElement(By.XPath($"//title[contains(text(),'{_title}')]"));
        }
    }
}
