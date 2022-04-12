using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;
using System.Linq;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class AttractionSinglePageRightBar:BasePage
    {
        private static By containerLocator = By.XPath("//form[contains(@class,'css')]");

        private readonly By _lastDateLocator = By.XPath("//td[@role='gridcell']");

        private readonly By _optionLocator = By.TagName("option");

        private readonly By _selectLocator = By.XPath("//button[@data-testid='select-ticket']");

        private BaseWebElement _timePickerSelect => containerElement.FindElement(By.TagName("select"));

        private BaseWebElement _plusElement => containerElement.FindElement(By.XPath("//span[.='+']/.."));

        private BaseWebElement _testDateResultLocator => containerElement.FindElement(By.XPath("//div[@class='css-1tl8iqp']"));

        private BaseWebElement _datePickerSelect => containerElement.FindElement(By.XPath("//div[@data-testid='datepicker']"));

        public AttractionSinglePageRightBar()
            : base(containerLocator) { }

        public AttractionSinglePageRightBar ChooseDateAndTime()
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

        public AttractionSinglePageRightBar ChooseAdultTicket()
        {
            DriverInstance.FindElement(_selectLocator).Click();

            return this;
        }

        public AttractionSinglePageRightBar AddTicket()
        {
            _plusElement.Click();

            return this;
        }

        public AttractionSinglePageRightBar ClickSubmitButton()
        {
            DriverInstance.FindElement(_selectLocator).Click();

            return this;
        }

        public BookingPageMiddleBar GoToBookingPage()
        {
            DriverInstance.FindElement(_selectLocator).Click();
            _plusElement.Click();
            DriverInstance.FindElement(_selectLocator).Click();

            return new BookingPageMiddleBar();
        }
    }
}
