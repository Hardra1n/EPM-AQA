using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAAutomationLab.CoreLayer.WebElement
{
    public class CalendarWebElement : BaseWebElement
    {
        public CalendarWebElement(By openCalendarLocator) : base(openCalendarLocator) {}

        public void ChooseFromToDates(By dateFromLocator, By dateToLocator)
        {
            try
            {
                BaseWebElement fromDateElement = new(this.FindElement(dateFromLocator));
                BaseWebElement toDateElement = new(this.FindElement(dateToLocator));
                fromDateElement.Click();
                toDateElement.Click();
                _logger.Information("Calendar.ChooseFromToDates:Success");
            }
            catch (Exception ex)
            {
                _logger.Error("Calendar.ChooseFromToDates:Error");
                throw;
            }
        }
    }
}
