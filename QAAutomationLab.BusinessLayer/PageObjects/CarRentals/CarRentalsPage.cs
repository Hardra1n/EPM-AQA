using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.CarRentals
{
    public class CarRentalsPage:BasePage
    {
        private const string _title = "car hire";

        private BaseWebElement _sameLocationSelector = new BaseWebElement(By.XPath("//label[@for='return-location-same']"));

        private BaseWebElement _differentLocationSelector = new BaseWebElement(By.XPath("//label[@for='return-location-different']"));

        private BaseWebElement _pickUpLocationField = new BaseWebElement(By.XPath("//input[@id='ss_origin']"));

        private BaseWebElement _dropOffLocationField = new BaseWebElement(By.XPath("//input[@id='ss']"));

        private BaseWebElement _searchButton = new BaseWebElement(By.XPath("//button[@type='submit']"));

        private BaseWebElement _invalidSearchRequrstMessage = new BaseWebElement(By.XPath("//div[@id='destination__error']"));

        private readonly By _pickUpFirstSearchSuggestion =By.XPath("//div[@data-visible='rentalcars']//ul//li");

        private readonly By _dropOffFirstSearchSuggestion =By.XPath("//input[@id='ss']/../..//li");

        public CarRentalsPage():base()
        {
            WebDriverWait Wait = new WebDriverWait(DriverInstance, System.TimeSpan.FromSeconds(10));

            Wait.Until(x => x.FindElement(By.XPath($"//title[contains(text(),'{_title}')]")));
        }

        public CarRentalsPage ChooseSameLocation() 
        {
            _sameLocationSelector.Click();

            return this;
        }

        public CarRentalsPage ChooseDifferentLocation() 
        {
            _differentLocationSelector.Click();

            return this;
        }

        public CarRentalsPage EnterPickUpLocation(string location) 
        {
            _pickUpLocationField.SendKeys(location);

            return this;
        }

        public CarRentalsPage EnterDropOffLocation(string location)
        {
            _dropOffLocationField.SendKeys(location);

            return this;
        }

        public CarRentalsPage ChooseFirstDropOffSuggestion(string location) 
        {
            _dropOffLocationField.Wait.Until(x => x.FindElement(_dropOffFirstSearchSuggestion).Text.Contains(location));

            DriverInstance.FindElement(_dropOffFirstSearchSuggestion).Click();

            return this;
        }

        public CarRentalsPage ChooseFirstPickUpSuggestion(string location)
        {
            _pickUpLocationField.Wait.Until(x => x.FindElement(_pickUpFirstSearchSuggestion).Text.Contains(location));

            DriverInstance.FindElement(_pickUpFirstSearchSuggestion).Click();

            return this;
        }

        public SearchResultsPage ClickSearchButton()
        {
            _searchButton.Click();

            return new SearchResultsPage();
        }

        public bool IsErrorMessageShown() 
        {
            return _invalidSearchRequrstMessage.Displayed && _invalidSearchRequrstMessage.Enabled;
        }
    }
}
