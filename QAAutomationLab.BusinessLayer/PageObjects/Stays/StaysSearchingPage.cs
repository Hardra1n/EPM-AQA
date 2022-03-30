using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;
using System;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays
{
    public class StaysSearchingPage : BasePage
    {
        private BaseWebElement destinationInput => new(By.XPath("//input[@type='search']"));

        private BaseWebElement searchButton => new(By.XPath("//button[@class='sb-searchbox__button ']"));

        private CalendarWebElement calendarDropDownMenu => new(By.XPath("//div[@class='xp__dates-inner']"));

        private BaseWebElement personsDropDownMenu => new(By.XPath("//label[@id='xp__guests__toggle']"));

        private AdderWebElement adultsAdderElement
            => new()
            {
                ValueElement = new(By.XPath("//div[contains(@class, 'adult')]//span[@data-bui-ref='input-stepper-value']")),
                RemoveOneFromValueButton = new(By.XPath("//button[@aria-label = 'Decrease number of Adults']")),
                AddOneToValueButton = new(By.XPath("//button[@aria-label = 'Increase number of Adults']"))
            };

        private AdderWebElement childrenAdderElement
            => new()
            {
                ValueElement = new(By.XPath("//div[contains(@class, 'children')]//span[@data-bui-ref='input-stepper-value']")),
                RemoveOneFromValueButton = new(By.XPath("//button[@aria-label = 'Decrease number of Children']")),
                AddOneToValueButton = new(By.XPath("//button[@aria-label = 'Increase number of Children']"))
            };
        private AdderWebElement roomsAdderElement
            => new()
            {
                ValueElement = new(By.XPath("//div[contains(@class, 'rooms')]//span[@data-bui-ref='input-stepper-value']")),
                RemoveOneFromValueButton = new(By.XPath("//button[@aria-label = 'Decrease number of Rooms']")),
                AddOneToValueButton = new(By.XPath("//button[@aria-label = 'Increase number of Rooms']"))
            };


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

        public StaysSearchingPage SelectDatesToStay(DateTime stayFromDate, DateTime stayToDate)
        {
            calendarDropDownMenu.ChooseFromToDates(CreateChoosingDateXPathLocator(stayFromDate),
                                                   CreateChoosingDateXPathLocator(stayToDate));
            return this;
        }

        private By CreateChoosingDateXPathLocator(DateTime date) 
            => By.XPath($"//td[@data-date = '{date.ToString("yyyy-MM-dd")}']");

        public StaysSearchingPage ClickPersonsMenu()
        {
            personsDropDownMenu.Click();
            return this;
        }

        public StaysSearchingPage SelectPersonsValues(int adultsCount, int childrenCount, int roomsCount)
        {
            adultsAdderElement.SetValue(adultsCount);
            childrenAdderElement.SetValue(childrenCount);
            roomsAdderElement.SetValue(roomsCount);
            return this;
        }

    }
}
