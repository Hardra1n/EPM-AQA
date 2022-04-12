using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class BookingPageMiddleBar : BasePage
    {
        private static By containerLocator = By.XPath("//form/../..");

        private BaseWebElement _firstNameInput => containerElement.FindElement(By.Name("firstName"));

        private BaseWebElement _lastNameInput => containerElement.FindElement(By.Name("lastName"));

        private BaseWebElement _emailInput => containerElement.FindElement(By.Name("email"));

        private BaseWebElement _phoneInput => containerElement.FindElement(By.Name("phone"));

        private BaseWebElement _emailConfirmInput => containerElement.FindElement(By.Name("emailConfirm"));

        public BookingPageMiddleBar()
            : base(containerLocator) { }

        public BookingPageMiddleBar InputFirstName(string value)
        {
            _firstNameInput.SendKeys(value);

            return this;
        }

        public BookingPageMiddleBar InputLastName(string value)
        {
            _lastNameInput.SendKeys(value);

            return this;
        }

        public BookingPageMiddleBar InputEmail(string value)
        {
            _emailInput.SendKeys(value);
            _emailConfirmInput.SendKeys(value);

            return this;
        }

        public BookingPageMiddleBar InputPhone(string value)
        {
            _phoneInput.SendKeys(value);

            return this;
        }
    }
}
