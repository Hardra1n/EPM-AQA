using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays
{
    public class StaysSearchingPage : BasePage
    {
        private BaseWebElement destinationInput => new(By.XPath("//input[@type='search']"));

        private BaseWebElement searchButton => new(By.XPath("//button[@class='sb-searchbox__button ']"));

        private BaseWebElement calendarDropDownMenu => new(By.XPath("//div[@class='xp__dates-inner']"));

        private BaseWebElement personsDropDownMenu => new(By.XPath("//label[@id='xp__guests__toggle']"));


        public StaysSearchingPage() : base() { }

        public StaysSearchingPage EnterDestination(string destination)
        {
            destinationInput.SendKeys(destination);
            return this;
        }

        public StaysSearchingPage ClickSearchButton()
        {
            searchButton.Click();
            return this;
        }

        public StaysSearchingPage ClickCalendarMenu()
        {
            calendarDropDownMenu.Click();
            return this;
        }

        public StaysSearchingPage ClickPersonsMenu()
        {
            personsDropDownMenu.Click();
            return this;
        }


    }
}
