using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class SearchResultsList : BasePage
    {
        private static readonly By _containerLocator = By.ClassName("css-wuc7a6");

        private readonly By _firstResultLocator = By.XPath("//a[@class=\"css-xbcz3d\"]");

        public SearchResultsList()
            : base(_containerLocator)
        {
        }

        private BaseWebElement TypeOfSortButton => new(By.XPath("//button[@class=\"_7a08ee31f2 _25a3e33c2a _44a4609e1c _5a7a33cce8 _4671f4fac1\"]"));

        public string ShowFirstResultTitle()
        {
            var firstResultLink = DriverInstance.FindElements(_firstResultLocator)[0];
            return firstResultLink.GetAttribute("title");
        }

        public SearchResultsList ChooseFilterButton(string buttonText)
        {
            TypeOfSortButton.Click();
            GetFilterButton(buttonText).Click();

            return this;
        }

        private static BaseWebElement GetFilterButton(string innerText)
        {
            return new BaseWebElement(By.XPath($"//button[.=\"{innerText}\"]"));
        }
    }
}
