using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.CarRentals
{
    public class BookPageDetailsBar:BasePage
    {
        private static By containerLocator = By.XPath("//h2[contains(text(),'Details')]/..");

        public BookPageDetailsBar()
            : base(containerLocator) { }
    }
}
