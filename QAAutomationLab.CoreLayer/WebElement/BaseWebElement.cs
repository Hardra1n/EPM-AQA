using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QAAutomationLab.CoreLayer.Logging;
using Serilog;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace QAAutomationLab.CoreLayer.WebElement
{
    public class BaseWebElement
    {
        private IWebDriver _driver => Driver.Driver.GetInstance();

        public ILogger _logger;

        public IWebElement Element { get; private set; }

        public WebDriverWait Wait { get; private set; }

        public By Locator { get; private set; }

        public string Text => Element.Text;

        public string TagName => Element.TagName;

        public bool Selected => Element.Selected;

        public bool Enabled => Element.Enabled;

        public bool Displayed => Element.Displayed;

        public Size Size => Element.Size;

        public Point Location => Element.Location;

        public BaseWebElement(By locator)
        {
            _logger = ReportPortalLogger.GetInstance().Logger;
            Locator = locator;
            Element = _driver.FindElement(Locator);
            Wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(10));
        }

        public BaseWebElement(IWebElement element)
        {
            _logger = ReportPortalLogger.GetInstance().Logger;
            Element = element;
            Wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(10));
        }

        public BaseWebElement(IWebElement element, By locator)
        {
            _logger = ReportPortalLogger.GetInstance().Logger;
            Element = element;
            Locator = locator;
            Wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(10));
        }

        public void SendKeys(string text)
        {
            try
            {
                Element.SendKeys(text);
                _logger.Information("SendKeys:Success");
            }
            catch
            {
                _logger.Error("SendKeys:Error");
            }
        }

        public void Click()
        {
            try
            {
                Element.Click();
                _logger.Information("Click:Success");
            }
            catch
            {
                _logger.Error("Click:Error");
            }
        }

        public string GetAttribute(string attributeName)
        {
            try
            {
                string attribute = Element.GetAttribute(attributeName);
                _logger.Information("GetAttribute:Success");

                return attribute;
            }
            catch
            {
                _logger.Error("GetAttribute:Error");

                throw;
            }
        }

        public string GetProperty(string propertyName)
        {
            try
            {
                string property = Element.GetProperty(propertyName);
                _logger.Information("GetProperty:Success");

                return property;
            }
            catch
            {
                _logger.Error("GetProperty:Error");

                throw;
            }
        }

        public void Clear()
        {
            try
            {
                Element.Clear();
                _logger.Information("Clear:Success");
            }
            catch
            {
                _logger.Error("Clear:Error");
            }
        }

        public string GetCssValue(string propertyName)
        {
            try
            {
                string cssValue = Element.GetCssValue(propertyName);
                _logger.Information("GetCssValue:Success");

                return cssValue;
            }
            catch
            {
                _logger.Error("GetCSSValue:Error");

                throw;
            }
        }

        public BaseWebElement FindElement(By by)
        {
            try
            {
                BaseWebElement element = new(Element.FindElement(by));
                _logger.Information("FindElement:Success");

                return element;
            }
            catch
            {
                _logger.Error("FindElement:Error");

                throw;
            }
        }

        public IReadOnlyCollection<BaseWebElement> FindElements(By by)
        {
            try
            {
                IReadOnlyCollection<BaseWebElement> elements 
                    = Element.FindElements(by).Select(x => new BaseWebElement(x)).ToList();
                _logger.Information("FindElements:Success");

                return elements;
            }
            catch
            {
                _logger.Error("FindElements:Error");

                throw;
            }
        }
    }
}
