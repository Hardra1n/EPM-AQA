using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace QAAutomationLab.BusinessLayer.Waiters
{
    public static class TestWaiters
    {
        public static IWebElement WaitForElementToAppear(this IWebDriver driver, By locator)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static IWebElement WaitForElementToBeClickable(this IWebDriver driver, By locator)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static bool WaitForUrlToContain(this IWebDriver driver, string urlPart)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.UrlContains(urlPart));
        }
    }
}
