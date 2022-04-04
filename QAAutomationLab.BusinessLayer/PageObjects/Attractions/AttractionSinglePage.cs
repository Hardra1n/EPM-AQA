using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;
using System.Linq;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class AttractionSinglePage : BasePage
    {
        private readonly BaseWebElement _datePickerSelect = new(By.XPath("//div[@data-testid=\"datepicker\"]"));

        private readonly By _lastDateLocator = By.XPath("//td[@role=\"gridcell\"]");

        private BaseWebElement _timePickerSelect => new(By.TagName("select"));

        private BaseWebElement _secondTimeOption => new(By.XPath("//option[@value=\"TSchR5i9micp\"]"));

        private readonly By _selectLocator = By.XPath("//button[@data-testid=\"select-ticket\"]");

        private BaseWebElement _plusElement => new(By.XPath("//span[.=\"+\"]/.."));

        private BaseWebElement _testDateResultLocator => new(By.XPath("//div[@class=\"css-1tl8iqp\"]"));

        public string BaseUrl => DriverInstance.Url;

        public AttractionSinglePage() : base()
        {
        }

        public AttractionSinglePage ChooseDateAndTime()
        {
            _datePickerSelect.Click();
            DriverInstance.FindElements(_lastDateLocator).Last().Click();

            _timePickerSelect.Click();
            _secondTimeOption.Click();

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
            DriverInstance.FindElements(_selectLocator)[1].Click();

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
            DriverInstance.FindElements(_selectLocator)[1].Click();
            _plusElement.Click();
            DriverInstance.FindElement(_selectLocator).Click();

            return new BookingPage();
        }
    }
}
