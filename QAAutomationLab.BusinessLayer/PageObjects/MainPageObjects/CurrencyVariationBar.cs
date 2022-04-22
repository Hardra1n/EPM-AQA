using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.MainPageObjects
{
    public class CurrencyVariationBar : BasePage
    {
        private static By containerLocator = By.XPath("//div[@class='bui-group bui-group--large']");

        private List<BaseWebElement> _currencyContainerList => (List<BaseWebElement>)containerElement.FindElements(By.XPath("//div[@class='bui-traveller-header__currency']/.."));

        public CurrencyVariationBar()
            : base(containerLocator) { }

        public MainPage ChooseCurrency(string currency)
        {
            BaseWebElement selectedLanguage = _currencyContainerList.Where(x => x.Text.Contains(currency)).First();

            selectedLanguage.Click();

            return new MainPage();
        }
    }
}
