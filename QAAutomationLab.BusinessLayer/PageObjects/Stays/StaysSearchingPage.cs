using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QAAutomationLab.BusinessLayer.Models;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;
using System;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays
{
    public class StaysSearchingPage : BasePage
    {
        private BaseWebElement _destinationInput => new(By.XPath("//input[@type='search']"));

        private BaseWebElement _searchButton => new(By.XPath("//button[@class='sb-searchbox__button ']"));

        private CalendarWebElement _calendarDropDownMenu => new(By.XPath("//div[@class='xp__dates-inner']"));

        private BaseWebElement _personsDropDownMenu => new(By.XPath("//label[@id='xp__guests__toggle']"));

        private BaseWebElement _destinationErrorBanner = new(By.XPath("//div[@class='fe_banner__message']"));

        private AdderWebElement _adultsAdderElement
            => new()
            {
                ValueElement = new(By.XPath("//div[contains(@class, 'adult')]//span[@data-bui-ref='input-stepper-value']")),
                RemoveOneFromValueButton = new(By.XPath("//button[@aria-label = 'Decrease number of Adults']")),
                AddOneToValueButton = new(By.XPath("//button[@aria-label = 'Increase number of Adults']")),
            };

        private AdderWebElement _childrenAdderElement
            => new()
            {
                ValueElement = new(By.XPath("//div[contains(@class, 'children')]//span[@data-bui-ref='input-stepper-value']")),
                RemoveOneFromValueButton = new(By.XPath("//button[@aria-label = 'Decrease number of Children']")),
                AddOneToValueButton = new(By.XPath("//button[@aria-label = 'Increase number of Children']")),
            };

        private AdderWebElement _roomsAdderElement
            => new()
            {
                ValueElement = new(By.XPath("//div[contains(@class, 'rooms')]//span[@data-bui-ref='input-stepper-value']")),
                RemoveOneFromValueButton = new(By.XPath("//button[@aria-label = 'Decrease number of Rooms']")),
                AddOneToValueButton = new(By.XPath("//button[@aria-label = 'Increase number of Rooms']")),
            };

        private BaseWebElement _destinationErrorBanner => new(By.XPath("//div[@class='fe_banner__message']"));

        public StaysSearchingPage() : base() { }


        public StaysSearchingPage EnterDestination(string destination)
        {
            _destinationInput.SendKeys(destination);
            return this;
        }

        public StaysSearchResultsPage ClickSearchButton()
        {
            _searchButton.Click();
            return new StaysSearchResultsPage();
        }

        public StaysSearchingPage ClickSearchButtonWithoutNavigating()
        {
            _searchButton.Click();
            return this;
        }

        public StaysSearchingPage ClickCalendarMenu()
        {
            _calendarDropDownMenu.Click();
            return this;
        }

        public StaysSearchingPage SelectDatesToStay(DateTime stayFromDate, DateTime stayToDate)
        {
            _calendarDropDownMenu.ChooseFromToDates(
                CreateChoosingDateXPathLocator(stayFromDate),
                CreateChoosingDateXPathLocator(stayToDate));
            return this;
        }

        public StaysSearchingPage ClickPersonsMenu()
        {
            _personsDropDownMenu.Click();
            return this;
        }

        public StaysSearchingPage SelectPersonsValues(int adultsCount, int childrenCount, int roomsCount, params int[] age)
        {
            _adultsAdderElement.SetValue(adultsCount);
            _childrenAdderElement.SetValue(childrenCount);
            SelectAgeForChildren(age);
            _roomsAdderElement.SetValue(roomsCount);
            return this;
        }

        public StaysSearchingPage SelectAgeForChildren(params int[] age)
        {
            for (int i = 0; i < age.Length; i++)
            {
                var element = new BaseWebElement(CreateChoosingChildAgeLocator(i));
                var selectElement = new SelectElement(element.Element);
                selectElement.SelectByValue(age[i].ToString());
            }

            return this;
        }

        public StaysSearchingPage AddSearchingContext(StaysSearchingContext context)
        {
            EnterDestination(context.Destination);
            ClickCalendarMenu().SelectDatesToStay(
                context.DateFrom,
                context.DateTo);
            ClickPersonsMenu().SelectPersonsValues(
                context.AdultsCount,
                context.ChildrenCount,
                context.RoomsCount,
                context.ChildrenAge);
            return this;
        }

        public string GetDestinationErrorMessage() => _destinationErrorBanner.Text;

        private By CreateChoosingDateXPathLocator(DateTime date)
            => By.XPath($"//td[@data-date = '{date.ToString("yyyy-MM-dd")}']");

        private By CreateChoosingChildAgeLocator(int id)
            => By.XPath($"//select[@data-group-child-age='{id}']");
    }
}
