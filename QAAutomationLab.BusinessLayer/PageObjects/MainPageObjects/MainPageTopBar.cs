using System;
using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.PageObjects.Account;
using QAAutomationLab.BusinessLayer.PageObjects.Attractions;
using QAAutomationLab.BusinessLayer.PageObjects.CarRentals;
using QAAutomationLab.BusinessLayer.PageObjects.HelpCenter;
using QAAutomationLab.BusinessLayer.PageObjects.Stays;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

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

        private BaseWebElement _attractionsButton => containerElement.FindElement(By.XPath("//a[contains(@href,'/attractions')]//span[@class='bui-tab__text']"));

        private BaseWebElement _carRentalsButton => containerElement.FindElement(By.XPath("//a[contains(@href,'/cars')]//span[@class='bui-tab__text']"));

        private BaseWebElement _languageSelectionButton => containerElement.FindElement(By.XPath("//button[@data-modal-id='language-selection']"));

        private BaseWebElement _helpCenterButton
            => containerElement.FindElement(By.XPath("//a[@data-bui-component='Tooltip']"));

        private BaseWebElement _logInButton => containerElement.FindElement(By.XPath("//a[contains(@data-et-click, \":2\") and contains(@href, \"auth\")]"));

        private BaseWebElement _accountButton => containerElement.FindElement(By.XPath("//*[contains(@aria-describedby, \"profile\")]"));

        private BaseWebElement _currencySelectionButton => containerElement.FindElement(By.XPath("//button[@data-modal-header-async-type='currencyDesktop']"));

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

        public LanguageSelectionBar ClickLanguageSelectionButton()
        {
            _languageSelectionButton.Click();

            return new LanguageSelectionBar();
        }

        public CurrencyVariationBar ClickCurrencyVariationButton()
        {
            _currencySelectionButton.Click();

            return new CurrencyVariationBar();
        }

        public StaysSearchingPage GoToStays() => new StaysSearchingPage();

        public HelpCenterPage GoToHelpCenter()
        {
            _helpCenterButton.Click();
            return new HelpCenterPage();
        }

        public string GetCarRentalsButtonsText()
        {
            return _carRentalsButton.Text;
        }
    }
}