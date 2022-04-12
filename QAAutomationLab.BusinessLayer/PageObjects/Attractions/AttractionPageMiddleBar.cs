using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class AttractionPageMiddleBar : BasePage
    {
        private static By containerLocator = By.XPath("//section/..");

        private BaseWebElement _topDestinationDubai => containerElement.FindElement(By.XPath("//a[@title='Dubai']"));

        private BaseWebElement _asiaTab => containerElement.FindElement(By.XPath("//button[.='Asia']"));

        private BaseWebElement _kyotoLink => containerElement.FindElement(By.XPath("//a[@title='Kyoto']"));

        public AttractionPageMiddleBar()
            : base(containerLocator) { }

        public SearchResultsMiddleBar GoToDubai()
        {
            _topDestinationDubai.Click();

            return new SearchResultsMiddleBar();
        }

        public SearchResultsMiddleBar GoToKyoto()
        {
            _kyotoLink.Click();

            return new SearchResultsMiddleBar();
        }

        public AttractionPageMiddleBar ChooseAsiaTab()
        {
            _asiaTab.Click();

            return this;
        }


    }
}
