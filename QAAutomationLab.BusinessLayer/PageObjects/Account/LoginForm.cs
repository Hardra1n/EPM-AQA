using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.PageObjects.MainPageObjects;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.Waiters;
using QAAutomationLab.CoreLayer.WebElement;
using System;

namespace QAAutomationLab.BusinessLayer.PageObjects.Account
{
    public class LoginForm : BasePage
    {
        private static readonly By _containerLocator = By.ClassName("transition-container");

        public LoginForm()
            : base(_containerLocator)
        {
        }

        private BaseWebElement EmailInput => new(By.XPath("//*[@type=\"email\"]"));

        private BaseWebElement SubmitButton => new(By.XPath("//*[@type=\"submit\"]"));

        private BaseWebElement PasswordInput => new(By.XPath("//*[@type=\"password\"]"));

        private BaseWebElement GetLinkButton => new(By.XPath("//*[contains(@class, \"without\")]"));

        private BaseWebElement ReturnToLoginButton => new(By.ClassName("nw-link-signin"));

        private BaseWebElement AlertMessage => new(By.XPath("//*[@role=\"alert\"]"));

        private BaseWebElement HeaderText => new(By.TagName("h1"));

        public LoginForm InputEmail(string email)
        {
            EmailInput.SendKeys(email);

            return this;
        }

        public LoginForm InputPassword(string password)
        {
            DriverInstance.WaitForElementToAppear(PasswordInput.Locator);
            PasswordInput.SendKeys(password);

            return this;
        }

        public LoginForm GoToGetLinkForm()
        {
            DriverInstance.WaitForElementToBeClickable(GetLinkButton.Locator);
            GetLinkButton.Click();
            DriverInstance.WaitForElementToBeClickable(ReturnToLoginButton.Locator);

            return this;
        }

        public LoginForm ReturnToLogin()
        {
            ReturnToLoginButton.Click();

            return this;
        }

        public LoginForm SubmitData()
        {
            SubmitButton.Click();

            return this;
        }

        public bool CheckIfReturnButtonExist()
        {
            try
            {
                return ReturnToLoginButton.Enabled;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CheckIfGetLinkExist()
        {
            try
            {
                return GetLinkButton.Enabled;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CheckIfAlertExist()
        {
            try
            {
                return AlertMessage.Enabled;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetAlertMessage()
        {
            return AlertMessage.Text;
        }

        public string GetHeadText()
        {
            return HeaderText.Text;
        }

        public MainPage LogIn(string email, string password)
        {
            EmailInput.SendKeys(email);
            SubmitButton.Click();
            DriverInstance.WaitForElementToAppear(PasswordInput.Locator);
            PasswordInput.SendKeys(password);
            SubmitButton.Click();

            return new MainPage();
        }
    }
}
