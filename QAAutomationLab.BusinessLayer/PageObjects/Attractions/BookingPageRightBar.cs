using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.Waiters;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class BookingPageRightBar:BasePage
    {
        private static By containerLocator = By.XPath("//div[@class='css-5dbuoc']");

        private BaseWebElement _confirmButton => containerElement.FindElement(By.XPath("//button[@type='submit']"));

        public BookingPageRightBar()
            : base(containerLocator) { }

        public BookingPageRightBar SubmitData(string urlPartToContain)
        {
            _confirmButton.Click();
            DriverInstance.WaitForUrlToContain(urlPartToContain);

            return this;
        }
    }
}
