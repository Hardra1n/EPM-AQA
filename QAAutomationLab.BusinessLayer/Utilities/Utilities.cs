using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.PageObjects;
using QAAutomationLab.CoreLayer.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QAAutomationLab.BusinessLayer.Utilities
{
    public class Utilities
    {
        public static MainPage RunBrowser(string url) 
        {
            IWebDriver driver = Driver.GetInstance();

            driver.Navigate().GoToUrl(url);

            return new MainPage();
        }

        public static void SwitchToNewHandle(Action op)
        {
            IWebDriver driver = Driver.GetInstance();
            List<string> handlesList = driver.WindowHandles.ToList();
            op.Invoke();
            string newHandle = driver.WindowHandles.Where(str => !handlesList.Contains(str))
                                                   .FirstOrDefault();
            if (newHandle != null)
            {
                driver.SwitchTo().Window(newHandle);
            }
        }
    }
}
