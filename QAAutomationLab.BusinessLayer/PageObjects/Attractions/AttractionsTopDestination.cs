using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class AttractionsTopDestination : BasePage
    {
        private static readonly By _containerLocator = By.XPath("//div[@class=\"css-1t3v2n3\"]/../../..");

        private readonly BaseWebElement _topDestinationDubai = new(By.XPath("//a[@title=\"Dubai\"]"));

        public AttractionsTopDestination()
            : base(_containerLocator)
        {
        }

        public SearchResultsPage GoToDubai()
        {
            _topDestinationDubai.Click();

            return new SearchResultsPage();
        }
    }
}
