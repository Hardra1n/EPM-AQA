using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace QAAutomationLab.CoreLayer.Waiters
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

        public static bool WaitForElementsCountToBeExpected(this IWebDriver driver, By locator, int count)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(elem => elem.FindElements(locator).Count == count);
        }

        public static bool WaitForElementToBeInvisable(this IWebDriver driver, By locator)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }
    }
}
