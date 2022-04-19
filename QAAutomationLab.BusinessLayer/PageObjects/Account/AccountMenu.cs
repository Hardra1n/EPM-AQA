using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.PageObjects.MainPageObjects;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Account
{
    public class AccountMenu : BasePage
    {
        private static readonly By _containerLocator = By.ClassName("bui-dropdown-menu__items");

        private readonly BaseWebElement _exitButton = new(By.XPath("//*[@type=\"submit\" and contains(@class, \"dropdown\")]"));

        public AccountMenu()
            : base(_containerLocator) { }

        public MainPage LogOut()
        {
            _exitButton.Click();

            return new MainPage();
        }
    }
}
