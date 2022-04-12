using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.CarRentals
{
    public class NoSearchResultsPageMiddleBar:BasePage
    {
        private static By containerLocator = By.XPath("//div[@class='no_results']/../../..");

        public NoSearchResultsPageMiddleBar()
            : base(containerLocator) { }
    }
}
