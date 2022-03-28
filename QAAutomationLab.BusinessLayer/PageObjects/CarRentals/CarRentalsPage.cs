using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.CarRentals
{
    public class CarRentalsPage:BasePage
    {
        private const string _title = "car hire";

        private BaseWebElement _sameLocationSelector = new BaseWebElement(By.XPath("//label[contains(text(),'same location')]"));

        private BaseWebElement _differentLocationSelector = new BaseWebElement(By.XPath("//label[contains(text(),'different location')]"));

        private BaseWebElement _pickUpLocationField = new BaseWebElement(By.XPath("//input[contains(@placeholder,'Pick-up location')]"));

        private BaseWebElement _dropOffLocationField = new BaseWebElement(By.XPath("//input[contains(@placeholder,'Drop-off location')]"));

        private BaseWebElement _searchButton = new BaseWebElement(By.XPath("//span[contains(text(),'Search')]/.."));

        private BaseWebElement _firstSearchSuggestion = new BaseWebElement(By.XPath("//ul[contains(@aria-label,'suggested destinations')]//li"));



        public CarRentalsPage():base()
        {
            DriverInstance.FindElement(By.XPath($"//title[contains(text(),'{_title}')]"));
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

        public CarRentalsPage ChooseFirstSearchSuggestion()
        {
            _firstSearchSuggestion.Click();

            return this;
        }

        public SearchResultsPage ClickSearchButton()
        {
            _searchButton.Click();

            return new SearchResultsPage();
        }
    }
}
