using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.PageObjects.Account;
using QAAutomationLab.BusinessLayer.PageObjects.Attractions;
using QAAutomationLab.BusinessLayer.PageObjects.CarRentals;
using QAAutomationLab.BusinessLayer.PageObjects.Stays;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;
using System;

namespace QAAutomationLab.BusinessLayer.PageObjects.MainPageObjects
{
    public class MainPageTopBar : BasePage
    {
        private static By containerLocator = By.XPath("//header[contains(@class,'header--logo')]");

        public MainPageTopBar()
            : base(containerLocator) { }

        public bool IsPersonLoggedIn
        {
            get
            {
                try
                {
                    _accountButton.Click();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        private BaseWebElement _attractionsButton => containerElement.FindElement(By.XPath("//a[@data-decider-header=\"attractions\"]"));

        private BaseWebElement _carRentalsButton => containerElement.FindElement(By.XPath("//span[contains(text(),'Car rentals')]"));

        private BaseWebElement _logInButton => containerElement.FindElement(By.XPath("//a[contains(@data-et-click, \":2\") and contains(@href, \"auth\")]"));

        private BaseWebElement _accountButton => containerElement.FindElement(By.XPath("//*[contains(@aria-describedby, \"profile\")]"));

        public AttrationPage GoToAttractions()
        {
            _attractionsButton.Click();
            return new AttrationPage();
        }

        public CarRentalsPage GoToCarRentals()
        {
            _carRentalsButton.Click();

            return new CarRentalsPage();
        }

        public LoginPage GoToLoginPage()
        {
            _logInButton.Click();

            return new LoginPage();
        }

        public AccountMenu ShowAccountMenu()
        {
            _accountButton.Click();

            return new AccountMenu();
        }

        public StaysSearchingPage GoToStays() => new StaysSearchingPage();
    }
}