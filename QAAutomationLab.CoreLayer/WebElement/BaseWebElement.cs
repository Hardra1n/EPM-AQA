using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QAAutomationLab.CoreLayer.Logging;
using Serilog;

namespace QAAutomationLab.CoreLayer.WebElement
{
    public class BaseWebElement
    {
        public BaseWebElement(By locator)
        {
            Logger = ReportPortalLogger.GetInstance().Logger;
            Locator = locator;
            Wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(10));
            Wait.Until(x => x.FindElement(Locator));
            Element = _driver.FindElement(Locator);
        }

        public BaseWebElement(IWebElement element)
        {
            Logger = ReportPortalLogger.GetInstance().Logger;
            Element = element;
            Wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(10));
        }

        public BaseWebElement(IWebElement element, By locator)
        {
            Logger = ReportPortalLogger.GetInstance().Logger;
            Element = element;
            Locator = locator;
            Wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(10));
        }

        public ILogger Logger { get; }

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

        private IWebDriver _driver => Driver.Driver.GetInstance();

        public void SendKeys(string text)
        {
            try
            {
                Wait.Until(x => Element.Displayed && Element.Enabled);
                Element.SendKeys(text);
                Logger.Information("SendKeys:Success");
            }
            catch
            {
                Logger.Error("SendKeys:Error");
            }
        }

        public void Click()
        {
            try
            {
                Wait.Until(x => Element.Displayed && Element.Enabled);
                Element.Click();
                Logger.Information("Click:Success");
            }
            catch
            {
                Logger.Error("Click:Error");
            }
        }

        public string GetAttribute(string attributeName)
        {
            try
            {
                string attribute = Element.GetAttribute(attributeName);
                Logger.Information("GetAttribute:Success");

                return attribute;
            }
            catch
            {
                Logger.Error("GetAttribute:Error");

                throw;
            }
        }

        public string GetProperty(string propertyName)
        {
            try
            {
                string property = Element.GetDomProperty(propertyName);
                Logger.Information("GetProperty:Success");

                return property;
            }
            catch
            {
                Logger.Error("GetProperty:Error");

                throw;
            }
        }

        public void Clear()
        {
            try
            {
                Wait.Until(x => Element.Displayed && Element.Enabled);
                Element.Clear();
                Logger.Information("Clear:Success");
            }
            catch
            {
                Logger.Error("Clear:Error");
            }
        }

        public string GetCssValue(string propertyName)
        {
            try
            {
                string cssValue = Element.GetCssValue(propertyName);
                Logger.Information("GetCssValue:Success");

                return cssValue;
            }
            catch
            {
                Logger.Error("GetCSSValue:Error");

                throw;
            }
        }

        public BaseWebElement FindElement(By by)
        {
            try
            {
                Wait.Until(x => Element.FindElement(by));
                BaseWebElement element = new(Element.FindElement(by));
                Logger.Information("FindElement:Success");

                return element;
            }
            catch
            {
                Logger.Error("FindElement:Error");

                throw;
            }
        }

        public IReadOnlyCollection<BaseWebElement> FindElements(By by)
        {
            try
            {
                IReadOnlyCollection<BaseWebElement> elements
                    = Element.FindElements(by).Select(x => new BaseWebElement(x)).ToList();
                Logger.Information("FindElements:Success");

                return elements;
            }
            catch
            {
                Logger.Error("FindElements:Error");

                throw;
            }
        }
    }
}
