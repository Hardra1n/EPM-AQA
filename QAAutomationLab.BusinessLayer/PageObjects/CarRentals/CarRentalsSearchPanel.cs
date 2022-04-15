using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.CarRentals
{
    public class CarRentalsSearchPanel : BasePage
    {
        private static By containerLocator = By.XPath("//div[contains(@class,'car-index')]");

        private readonly By _pickUpFirstSearchSuggestion = By.XPath("//div[@data-visible='rentalcars']//ul//li");

        private readonly By _dropOffFirstSearchSuggestion = By.XPath("//input[@id='ss']/../..//li");

        public CarRentalsSearchPanel()
            : base(containerLocator) { }

        public BaseWebElement _sameLocationSelector => containerElement.FindElement(By.XPath("//label[@for='return-location-same']"));

        private BaseWebElement _differentLocationSelector => containerElement.FindElement(By.XPath("//label[@for='return-location-different']"));

        private BaseWebElement _pickUpLocationField => containerElement.FindElement(By.XPath("//input[@id='ss_origin']"));

        private BaseWebElement _dropOffLocationField => containerElement.FindElement(By.XPath("//input[@id='ss']"));

        private BaseWebElement _searchButton => containerElement.FindElement(By.XPath("//button[@type='submit']"));

        private BaseWebElement _invalidSearchRequrstMessage => containerElement.FindElement(By.XPath("//div[@id='destination__error']"));

        private BaseWebElement _ageCheckBox => containerElement.FindElement(By.XPath("//span[contains(@class,'bui-checkbox')]"));

        private BaseWebElement _ageField => containerElement.FindElement(By.XPath("//input[@id='driverAgeInput']"));

        private BaseWebElement _invalidAgeMessage => containerElement.FindElement(By.XPath("//div[contains(@class,'searchbox__error sb-searchbox__driver-age')]"));

        public CarRentalsSearchPanel ChooseSameLocation()
        {
            _sameLocationSelector.Click();

            return this;
        }

        public CarRentalsSearchPanel ChooseDifferentLocation()
        {
            _differentLocationSelector.Click();

            return this;
        }

        public CarRentalsSearchPanel EnterPickUpLocation(string location)
        {
            _pickUpLocationField.SendKeys(location);

            return this;
        }

        public CarRentalsSearchPanel EnterDropOffLocation(string location)
        {
            _dropOffLocationField.SendKeys(location);

            return this;
        }

        public CarRentalsSearchPanel ChooseFirstDropOffSuggestion(string location)
        {
            _dropOffLocationField.Wait.Until(x => x.FindElement(_dropOffFirstSearchSuggestion).Text.Contains(location));

            DriverInstance.FindElement(_dropOffFirstSearchSuggestion).Click();

            return this;
        }

        public CarRentalsSearchPanel ChooseFirstPickUpSuggestion(string location)
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

        public CarRentalsSearchPanel ClickAgeCheckBox()
        {
            _ageCheckBox.Click();

            return this;
        }

        public CarRentalsSearchPanel EnterAge(string age)
        {
            _ageField.SendKeys(age);

            return this;
        }

        public bool IsErrorMessageShown()
        {
            return _invalidSearchRequrstMessage.Displayed && _invalidSearchRequrstMessage.Enabled;
        }

        public bool IsIncorrectAgeMessageShown()
        {
            return _invalidAgeMessage.Displayed && _invalidAgeMessage.Enabled;
        }
    }
}
