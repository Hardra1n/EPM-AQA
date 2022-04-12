using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;
using System.Collections.Generic;

namespace QAAutomationLab.BusinessLayer.PageObjects.CarRentals
{
    public class CarOptionsMiddleBar : BasePage
    {
        private static By containerLocator = By.XPath("//div[@class='tab-wrapper-car-tab']");

        public CarOptionsMiddleBar()
            : base(containerLocator) { }

        private BaseWebElement _goToBookButton => containerElement.FindElement(By.XPath("//span[contains(text(),'book')]"));

        private List<BaseWebElement> _options => (List<BaseWebElement>)containerElement.FindElements(By.XPath("//input[@value='+']"));

        public CarOptionsMiddleBar ChooseAllOptions()
        {
            foreach (BaseWebElement element in _options)
            {
                element.Click();
            }

            return this;
        }

        public BookPage GoToBookPage()
        {
            _goToBookButton.Click();

            return new BookPage();
        }
    }
}
