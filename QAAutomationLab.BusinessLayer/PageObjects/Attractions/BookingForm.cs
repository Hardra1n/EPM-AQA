using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.Waiters;
using QAAutomationLab.CoreLayer.WebElement;
using System.Linq;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class BookingForm : BasePage
    {
        private static readonly By _containerLocator = By.ClassName("css-12ew8ia");

        private readonly BaseWebElement _firstNameInput = new(By.Name("firstName"));

        private readonly BaseWebElement _lastNameInput = new(By.Name("lastName"));

        private readonly BaseWebElement _emailInput = new(By.Name("email"));

        private readonly BaseWebElement _phoneInput = new(By.Name("phone"));

        private readonly BaseWebElement _emailConfirmInput = new(By.Name("emailConfirm"));

        private readonly By _submitButtonLocator = By.XPath("//*[@class=\"_7a08ee31f2 _25a3e33c2a f273203173 d4d2a5e0a2 _595367e7bb c1e37769f7\"]");

        public BookingForm()
            : base(_containerLocator)
        {
        }

        public BookingForm InputFirstName(string value)
        {
            _firstNameInput.SendKeys(value);

            return this;
        }

        public BookingForm InputLastName(string value)
        {
            _lastNameInput.SendKeys(value);

            return this;
        }

        public BookingForm InputEmail(string value)
        {
            _emailInput.SendKeys(value);
            _emailConfirmInput.SendKeys(value);

            return this;
        }

        public BookingForm InputPhone(string value)
        {
            _phoneInput.SendKeys(value);

            return this;
        }

        public BookingPage SubmitData(string urlPartToContain)
        {
            DriverInstance.FindElements(_submitButtonLocator).Last().Click();
            DriverInstance.WaitForUrlToContain(urlPartToContain);

            return new BookingPage();
        }
    }
}
