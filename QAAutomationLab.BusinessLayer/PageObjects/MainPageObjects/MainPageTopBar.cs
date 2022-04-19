using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.PageObjects.Attractions;
using QAAutomationLab.BusinessLayer.PageObjects.CarRentals;
using QAAutomationLab.BusinessLayer.PageObjects.HelpCenter;
using QAAutomationLab.BusinessLayer.PageObjects.Stays;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.MainPageObjects
{
    public class MainPageTopBar : BasePage
    {
        private static By containerLocator = By.XPath("//header[contains(@class,'header--logo')]");

        public MainPageTopBar()
            : base(containerLocator) { }

        private BaseWebElement _attractionsButton => containerElement.FindElement(By.XPath("//a[@data-decider-header=\"attractions\"]"));

        private BaseWebElement _carRentalsButton => containerElement.FindElement(By.XPath("//span[contains(text(),'Car rentals')]"));

        private BaseWebElement _helpCenterButton
            => containerElement.FindElement(By.XPath("//a[@data-bui-component='Tooltip']"));

        public AttrationPage GoToAttractions()
        {
            _attractionsButton.Click();
            return new AttrationPage();
        }

        public CarRentalsPage GoToCarRentals()
        {
            _carRentalsButton.Click();

            return new CarRentalsPage();
        }

        public StaysSearchingPage GoToStays() => new StaysSearchingPage();

        public HelpCenterPage GoToHelpCenter()
        {
            _helpCenterButton.Click();
            return new HelpCenterPage();
        }
    }
}