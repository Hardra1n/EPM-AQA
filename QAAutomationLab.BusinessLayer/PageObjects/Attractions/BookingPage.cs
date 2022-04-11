using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.Waiters;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class BookingPage : BasePage
    {
        private readonly BaseWebElement _firstNameInput = new(By.Name("firstName"));

        private readonly BaseWebElement _lastNameInput = new(By.Name("lastName"));

        private readonly BaseWebElement _emailInput = new(By.Name("email"));

        private readonly BaseWebElement _phoneInput = new(By.Name("phone"));

        private readonly BaseWebElement _emailConfirmInput = new(By.Name("emailConfirm"));

        private readonly By _submitButtonLocator = By.XPath("//span[@data-testid=\"bpd-cta\"]/button");

        public BookingPage()
            : base() { }

        public string BaseUrl => DriverInstance.Url;

        public BookingPage SubmitData(string urlPartToContain)
        {
            DriverInstance.FindElements(_submitButtonLocator)[0].Click();
            DriverInstance.WaitForUrlToContain(urlPartToContain);

            return this;
        }

        public BookingPage InputFirstName(string value)
        {
            _firstNameInput.SendKeys(value);

            return this;
        }

        public BookingPage InputLastName(string value)
        {
            _lastNameInput.SendKeys(value);

            return this;
        }

        public BookingPage InputEmail(string value)
        {
            _emailInput.SendKeys(value);
            _emailConfirmInput.SendKeys(value);

            return this;
        }

        public BookingPage InputPhone(string value)
        {
            _phoneInput.SendKeys(value);

            return this;
        }
    }
}
