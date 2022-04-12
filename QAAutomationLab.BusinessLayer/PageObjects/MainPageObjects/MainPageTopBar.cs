using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.PageObjects.Attractions;
using QAAutomationLab.BusinessLayer.PageObjects.CarRentals;
using QAAutomationLab.BusinessLayer.PageObjects.Stays;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.MainPageObjects
{
    public class TopBar : BasePage
    {
        private static By containerLocator = By.XPath("//header[contains(@class,'header--logo')]");

        public TopBar()
            : base(containerLocator) { }

        private BaseWebElement _attractionsButton => containerElement.FindElement(By.XPath("//a[@data-decider-header=\"attractions\"]"));

        private BaseWebElement _carRentalsButton => containerElement.FindElement(By.XPath("//span[contains(text(),'Car rentals')]"));

        public AttrationPage GoToAttractions()
        {
            _attractionsButton.Click();
            return new AttrationPage();
        }

        public SearchPanel GoToCarRentals()
        {
            _carRentalsButton.Click();

            return new SearchPanel();
        }

        public StaysSearchingPage GoToStays() => new StaysSearchingPage();
    }
}