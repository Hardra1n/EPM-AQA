using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.PageObjects.MainPageObjects;
using QAAutomationLab.CoreLayer.Driver;

namespace QAAutomationLab.BusinessLayer.Utilities
{
    public class Utilities
    {
        public static MainPageTopBar RunBrowser(string url)
        {
            IWebDriver driver = Driver.GetInstance();

            driver.Navigate().GoToUrl(url);

            return new MainPageTopBar();
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
