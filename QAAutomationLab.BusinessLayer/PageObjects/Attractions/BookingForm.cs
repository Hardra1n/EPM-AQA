using System.Linq;
using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.Waiters;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class BookingForm : BasePage
    {
        private static readonly By _containerLocator = By.ClassName("css-12ew8ia");

        private readonly By _submitButtonLocator = By.XPath("//*[@class=\"_7a08ee31f2 _25a3e33c2a f273203173 d4d2a5e0a2 _595367e7bb c1e37769f7\"]");

        public BookingForm()
            : base(_containerLocator)
        {
        }

        public BookingForm InputFirstName(string value)
        {
            GetInput("firstName").SendKeys(value);

            return this;
        }

        public BookingForm InputLastName(string value)
        {
            GetInput("lastName").SendKeys(value);

            return this;
        }

        public BookingForm InputEmail(string value)
        {
            GetInput("email").SendKeys(value);
            GetInput("emailConfirm").SendKeys(value);

            return this;
        }

        public BookingForm InputPhone(string value)
        {
            GetInput("phone").SendKeys(value);

            return this;
        }

        public BookingPage SubmitData(string urlPartToContain)
        {
            DriverInstance.WaitForElementToBeClickable(_submitButtonLocator);
            DriverInstance.FindElements(_submitButtonLocator).Last().Click();
            DriverInstance.WaitForUrlToContain(urlPartToContain);

            return new BookingPage();
        }

        private static BaseWebElement GetInput(string name)
        {
            return new BaseWebElement(By.Name(name));
        }
    }
}
