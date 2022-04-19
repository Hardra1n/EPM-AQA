using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.MainPageObjects
{
    public class LanguageSelectionBar:BasePage
    {
        private static By containerLocator = By.XPath("//div[contains(@class,'bui-group--large')]");

        private List<BaseWebElement> _languagesList => (List<BaseWebElement>)containerElement.FindElements(By.XPath("//div[@class='bui-inline-container__main']"));

        public LanguageSelectionBar()
            : base(containerLocator) { }

        public MainPage ChooseLanguage(string language)
        {
            BaseWebElement selectedLanguage = _languagesList.Where(x => x.Text.Contains(language)).First();

            selectedLanguage.Click();

            return new MainPage();
        }
    }
}
