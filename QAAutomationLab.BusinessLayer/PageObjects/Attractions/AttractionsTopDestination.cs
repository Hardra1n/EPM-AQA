using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class AttractionsTopDestination : BasePage
    {
        private static readonly By _containerLocator = By.XPath("//div[@class=\"css-1t3v2n3\"]/../../..");

        private static readonly string _linkXPath = "//a[@title=\"{0}\"]";

        public AttractionsTopDestination()
            : base(_containerLocator)
        {
        }

        public SearchResultsPage GoToCity(string cityName)
        {
            GetTopDestination(cityName).Click();

            return new SearchResultsPage();
        }

        private static BaseWebElement GetTopDestination(string cityName)
        {
            return new BaseWebElement(By.XPath(string.Format(_linkXPath, cityName)));
        }
    }
}
