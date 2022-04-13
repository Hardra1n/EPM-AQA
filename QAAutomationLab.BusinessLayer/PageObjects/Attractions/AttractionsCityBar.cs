using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class AttractionsCityBar : BasePage
    {
        private static readonly By _containerLocator = By.ClassName("intersection-visible-wrapper");

        public AttractionsCityBar()
            : base(_containerLocator)
        {
        }

        private BaseWebElement AsiaTab => new(By.XPath("//button[.=\"Asia\"]"));

        private BaseWebElement KyotoLink => new(By.XPath("//a[@title=\"Kyoto\"]"));

        public SearchResultsPage GoToKyoto()
        {
            KyotoLink.Click();

            return new SearchResultsPage();
        }

        public AttractionsCityBar ChooseAsiaTab()
        {
            AsiaTab.Click();

            return this;
        }
    }
}
