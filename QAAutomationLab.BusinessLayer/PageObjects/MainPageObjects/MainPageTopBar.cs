using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.PageObjects.Attractions;
using QAAutomationLab.BusinessLayer.PageObjects.CarRentals;
using QAAutomationLab.BusinessLayer.PageObjects.HelpCenter;
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

        private BaseWebElement _attractionsButton => containerElement.FindElement(By.XPath("//a[contains(@href,'/attractions')]//span[@class='bui-tab__text']"));

        private BaseWebElement _carRentalsButton => containerElement.FindElement(By.XPath("//a[contains(@href,'/cars')]//span[@class='bui-tab__text']"));

        private BaseWebElement _languageSelectionButton => containerElement.FindElement(By.XPath("//button[@data-modal-id='language-selection']"));

        private BaseWebElement _helpCenterButton
            => containerElement.FindElement(By.XPath("//a[@data-bui-component='Tooltip']"));

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

        public LanguageSelectionBar ClickLanguageSelectionButton() 
        {
            _languageSelectionButton.Click();

            return new LanguageSelectionBar();
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