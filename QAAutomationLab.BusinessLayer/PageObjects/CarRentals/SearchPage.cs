using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.CarRentals
{
    public class SearchPage:BasePage
    {
        private const string _title = "car hire";

        public BaseWebElement SameLocationSelector = new BaseWebElement(By.XPath("//label[contains(text(),'same location')]"));

        public BaseWebElement DifferentLocationSelector = new BaseWebElement(By.XPath("//label[contains(text(),'different location')]"));

        public BaseWebElement SearchField = new BaseWebElement(By.XPath("//input[contains(@placeholder,'Pick-up location')]"));

        public BaseWebElement SearchButton = new BaseWebElement(By.XPath("//span[contains(text(),'Search')]/.."));

        public SearchPage( ):base()
        {
            DriverInstance.FindElement(By.XPath($"//title[contains(text(),'{_title}')]"));
        }
    }
}
