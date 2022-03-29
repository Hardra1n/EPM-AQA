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
            BaseWebElement fromDateElement = new(this.FindElement(dateFromLocator));
            BaseWebElement toDateElement = new(this.FindElement(dateToLocator));
            fromDateElement.Click();
            toDateElement.Click();
        }
    }
}
