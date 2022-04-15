using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.CarRentals
{
    public class CarSelectionPageRightBar : BasePage
    {
        private static By containerLocator = By.XPath("//div[contains(@class,'CarCategories')]/..");

        public CarSelectionPageRightBar()
                : base(containerLocator) { }

        private BaseWebElement _firstCarSuggestion => containerElement.FindElement(By.XPath("//span[contains(text(),'Choose')]/.."));

        public CarOptionsPage ChooseFirstCar()
        {
           Utilities.Utilities.SwitchToNewHandle(_firstCarSuggestion.Click);

           return new CarOptionsPage();
        }
    }
}
