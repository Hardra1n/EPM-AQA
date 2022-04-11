using System.Linq;
using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class AttractionSinglePage : BasePage
    {
        private readonly BaseWebElement _datePickerSelect = new(By.XPath("//div[@data-testid=\"datepicker\"]"));

        private readonly By _lastDateLocator = By.XPath("//td[@role=\"gridcell\"]");

        private readonly By _optionLocator = By.TagName("option");

        private readonly By _selectLocator = By.XPath("//button[@data-testid=\"select-ticket\"]");

        public AttractionSinglePage()
            : base()
        {
        }

        public string BaseUrl => DriverInstance.Url;

        private BaseWebElement _timePickerSelect => new(By.TagName("select"));

        private BaseWebElement _plusElement => new(By.XPath("//span[.=\"+\"]/.."));

        private BaseWebElement _testDateResultLocator => new(By.XPath("//div[@class=\"css-1tl8iqp\"]"));

        public AttractionSinglePage ChooseDateAndTime()
        {
            _datePickerSelect.Click();
            DriverInstance.FindElements(_lastDateLocator).Last().Click();

            _timePickerSelect.Click();
            DriverInstance.FindElements(_optionLocator)[1].Click();

            return this;
        }

        public string[] GetDateTimeValues()
        {
            var results = new string[2];
            results[0] = _testDateResultLocator.Text;
            results[1] = _timePickerSelect.GetAttribute("value");

            return results;
        }

        public AttractionSinglePage ChooseAdultTicket()
        {
            DriverInstance.FindElement(_selectLocator).Click();

            return this;
        }

        public AttractionSinglePage AddTicket()
        {
            _plusElement.Click();

            return this;
        }

        public AttractionSinglePage ClickSubmitButton()
        {
            DriverInstance.FindElement(_selectLocator).Click();

            return this;
        }

        public BookingPage GoToBookingPage()
        {
            DriverInstance.FindElement(_selectLocator).Click();
            _plusElement.Click();
            DriverInstance.FindElement(_selectLocator).Click();

            return new BookingPage();
        }
    }
}
