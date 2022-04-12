using System.Linq;
using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays
{
    public class StaysFilterContainer : BasePage
    {
        private static By _containerLocator = By.Id("searchboxInc");

        public StaysFilterContainer()
            : base(_containerLocator) { }

        private BaseWebElement _firstFilteringStarsOption
            => containerElement.FindElements(
                By.XPath("//div[@data-filters-group = 'class']//div[@data-filters-item]")).FirstOrDefault();

        public StaysFilterContainer ClickFirstFilteringStarsOption()
        {
            _firstFilteringStarsOption.Click();
            return this;
        }
    }
}
