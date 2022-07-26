﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QAAutomationLab.BusinessLayer.Models;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays.Components
{
    public class StaysBookingDetailsMainContainer : BasePage
    {
        private static By _containerLocator = By.Id("content");

        public StaysBookingDetailsMainContainer()
            : base(_containerLocator) { }

        private BaseWebElement _hotelNameElement => new(By.XPath("//h1[contains(@id, 'title')]"));

        private BaseWebElement _firstNameInput => new(By.Name("firstname"));

        private BaseWebElement _lastNameInput => new(By.Name("lastname"));

        private BaseWebElement _emailInput => new(By.Name("email"));

        private BaseWebElement _confirmEmailInput => new(By.Name("email_confirm"));

        private BaseWebElement _confirmDetailsButton => new(By.Name("book"));

        private BaseWebElement _checkInArrivalTimeSelect => new(By.Name("checkin_eta_hour"));

        public string GetHotelName() => _hotelNameElement.Text;

        public StaysBookingDetailsMainContainer EnterFirstName(string firstname)
        {
            _firstNameInput.SendKeys(firstname);
            return this;
        }

        public StaysBookingDetailsMainContainer EnterLastName(string lastname)
        {
            _lastNameInput.SendKeys(lastname);
            return this;
        }

        public StaysBookingDetailsMainContainer EnterEmail(string email)
        {
            _emailInput.SendKeys(email);
            return this;
        }

        public StaysBookingDetailsMainContainer EnterEmailConfirm(string email)
        {
            _confirmEmailInput.SendKeys(email);
            return this;
        }

        public StaysBookingFinalStepPage ClickConfirmButton()
        {
            _confirmDetailsButton.Click();
            return new StaysBookingFinalStepPage();
        }

        public StaysBookingDetailsMainContainer SelectDefaultArriavalTime()
        {
            SelectElement element = new SelectElement(_checkInArrivalTimeSelect.Element);
            element.SelectByValue("-1");
            return this;
        }

        public StaysBookingDetailsMainContainer AddBookingDetailsContext(StaysBookingDetailsContext context)
        {
            EnterFirstName(context.FirstName);
            EnterLastName(context.LastName);
            EnterEmail(context.Email);
            EnterEmailConfirm(context.ConfirmEmail);
            SelectDefaultArriavalTime();
            return this;
        }
    }
}
