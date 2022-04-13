using System.Linq;
using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class SinglePageForm : BasePage
    {
        private static readonly By _containerLocator = By.XPath("//form[@class=\"css-1j79jlf\"]");

        private readonly BaseWebElement _datePickerSelect = new(By.XPath("//div[@data-testid=\"datepicker\"]"));

        private readonly By _lastDateLocator = By.XPath("//td[@role=\"gridcell\"]");

        private readonly By _optionLocator = By.TagName("option");

        private readonly By _selectLocator = By.XPath("//button[@data-testid=\"select-ticket\"]");

        public SinglePageForm()
            : base(_containerLocator)
        {
        }

        private BaseWebElement TimePickerSelect => new(By.TagName("select"));

        private BaseWebElement PlusElement => new(By.XPath("//span[.=\"+\"]/.."));

        private BaseWebElement TestDateResultLocator => new(By.XPath("//div[@class=\"css-1tl8iqp\"]"));

        public SinglePageForm ChooseDateAndTime()
        {
            _datePickerSelect.Click();
            DriverInstance.FindElements(_lastDateLocator).Last().Click();

            TimePickerSelect.Click();
            DriverInstance.FindElements(_optionLocator)[1].Click();

            return this;
        }

        public string[] GetDateTimeValues()
        {
            var results = new string[2];
            results[0] = TestDateResultLocator.Text;
            results[1] = TimePickerSelect.GetAttribute("value");

            return results;
        }

        public SinglePageForm ChooseAdultTicket()
        {
            DriverInstance.FindElement(_selectLocator).Click();

            return this;
        }

        public SinglePageForm AddTicket()
        {
            PlusElement.Click();

            return this;
        }

        public AttractionSinglePage ClickSubmitButton()
        {
            DriverInstance.FindElement(_selectLocator).Click();

            return new AttractionSinglePage();
        }

        public BookingPage GoToBookingPage()
        {
            DriverInstance.FindElement(_selectLocator).Click();
            PlusElement.Click();
            DriverInstance.FindElement(_selectLocator).Click();

            return new BookingPage();
        }
    }
}
