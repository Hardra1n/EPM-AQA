using OpenQA.Selenium;
using System;

namespace QAAutomationLab.CoreLayer.WebElement
{
    public class CalendarWebElement : BaseWebElement
    {
        public CalendarWebElement(By openCalendarLocator) : base(openCalendarLocator) {}

        public void ChooseFromToDates(By dateFromLocator, By dateToLocator)
        {
            try
            {
                BaseWebElement fromDateElement = this.FindElement(dateFromLocator);
                BaseWebElement toDateElement = this.FindElement(dateToLocator);
                fromDateElement.Click();
                toDateElement.Click();
                _logger.Information("Calendar.ChooseFromToDates:Success");
            }
            catch (Exception)
            {
                _logger.Error("Calendar.ChooseFromToDates:Error");
                throw;
            }
        }
    }
}
