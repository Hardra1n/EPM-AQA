using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QAAutomationLab.BusinessLayer.Models;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays
{
    public class StaysBookingDetailsPage : BasePage
    {
        public StaysBookingDetailsPage()
            : base() { }

        private BaseWebElement _unfinishedNotification => new(By.Id("growl_squash"));

        private BaseWebElement _hotelNameElement => new(By.XPath("//h1[contains(@id, 'title')]"));

        private BaseWebElement _firstNameInput => new(By.Name("firstname"));

        private BaseWebElement _lastNameInput => new(By.Name("lastname"));

        private BaseWebElement _emailInput => new(By.Name("email"));

        private BaseWebElement _confirmEmailInput => new(By.Name("email_confirm"));

        private BaseWebElement _confirmDetailsButton => new(By.Name("book"));

        private BaseWebElement _checkInArrivalTimeSelect => new(By.Name("checkin_eta_hour"));

        public string GetHotelName() => _hotelNameElement.Text;

        public StaysBookingDetailsPage EnterFirstName(string firstname)
        {
            _firstNameInput.SendKeys(firstname);
            return this;
        }

        public StaysBookingDetailsPage EnterLastName(string lastname)
        {
            _lastNameInput.SendKeys(lastname);
            return this;
        }

        public StaysBookingDetailsPage EnterEmail(string email)
        {
            _emailInput.SendKeys(email);
            return this;
        }

        public StaysBookingDetailsPage EnterEmailConfirm(string email)
        {
            _confirmEmailInput.SendKeys(email);
            return this;
        }

        public StaysBookingFinalStepPage ClickConfirmButton()
        {
            _confirmDetailsButton.Click();
            return new StaysBookingFinalStepPage();
        }

        public StaysBookingDetailsPage SelectDefaultArriavalTime()
        {
            SelectElement element = new SelectElement(_checkInArrivalTimeSelect.Element);
            element.SelectByValue("-1");
            return this;
        }

        public StaysBookingDetailsPage AddBookingDetailsContext(StaysBookingDetailsContext context)
        {
            EnterFirstName(context.FirstName);
            EnterLastName(context.LastName);
            EnterEmail(context.Email);
            EnterEmailConfirm(context.ConfirmEmail);
            SelectDefaultArriavalTime();
            return this;
        }

        public bool IsThereUnfinishedBookingNotification() => _unfinishedNotification.Displayed;
    }
}