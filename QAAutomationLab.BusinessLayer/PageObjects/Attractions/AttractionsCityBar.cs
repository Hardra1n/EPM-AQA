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

        public SearchResultsPage GoToCity(string cityName)
        {
            GetCityLink(cityName).Click();

            return new SearchResultsPage();
        }

        public AttractionsCityBar ChooseTab(string tabName)
        {
            GetTabElement(tabName).Click();

            return this;
        }

        private static BaseWebElement GetTabElement(string tabName)
        {
            return new BaseWebElement(By.XPath($"//button[.=\"{tabName}\"]"));
        }

        private static BaseWebElement GetCityLink(string cityName)
        {
            return new BaseWebElement(By.XPath($"//a[@title=\"{cityName}\"]"));
        }
    }
}
