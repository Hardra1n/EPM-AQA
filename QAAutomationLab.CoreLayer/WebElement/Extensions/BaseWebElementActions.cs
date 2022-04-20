using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using QAAutomationLab.CoreLayer.Logging;
using Serilog;

namespace QAAutomationLab.CoreLayer.WebElement.Extensions
{
    public static class BaseWebElementActions
    {
        private static IWebDriver _driver = Driver.Driver.GetInstance();

        private static ILogger _logger = ReportPortalLogger.GetInstance().Logger;

        public static void ClickAndHold(this BaseWebElement element)
        {
            try
            {
                new Actions(_driver).ClickAndHold(element.Element)
                                    .Build()
                                    .Perform();
                _logger.Information("ClickAndHold:Success");
            }
            catch (Exception)
            {
                _logger.Information("ClickAndHold:Error");
                throw;
            }
        }

        public static void MoveByOffset(this BaseWebElement element, int xOffset, int yOffset)
        {
            try
            {
                new Actions(_driver).MoveByOffset(xOffset, yOffset)
                                    .Build()
                                    .Perform();
                _logger.Information("MoveByOffset:Success");
            }
            catch (Exception)
            {
                _logger.Error("MoveByOffset:Error");
                throw;
            }
        }
    }
}
