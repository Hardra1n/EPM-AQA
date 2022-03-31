using OpenQA.Selenium;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;
using System;
using System.Linq;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays
{
    public class StaysSearchResultsPage : BasePage
    {
        private const string _title = "Hotels in";

        private const string _noAdsExceptionMessage = "There are no ads on the page";

        private BaseWebElement AdsHeadElement => new(By.XPath("//h1"));

        private BaseWebElement FirstAdNavigatingButton
            => new(DriverInstance.FindElements(By.XPath("//div[@data-testid='property-card']//a[@role='button']")).FirstOrDefault());

        private BaseWebElement FirstAdTitle
            => new(DriverInstance.FindElements(By.XPath("//div[@data-testid = 'title']")).FirstOrDefault());

        public StaysSearchResultsPage() : base()
        {
            DriverInstance.FindElement(By.XPath($"//title[contains(text(),'{_title}')]"));
        }

        public int? GetAdsCount()
        {
            string digits = new String(AdsHeadElement.Text.Where(c => Char.IsDigit(c)).ToArray());
            if (Int32.TryParse(digits, out int number))
                return number;
            else
                return null;
        }

        public string GetFirstAddTitle()
            => FirstAdTitle.Text;

        public StaysAdPage ClickFirstAdNavigatingButton()
        {
            if (GetAdsCount() > 0)
            { 
                Utilities.Utilities.SwitchToNewHandle(FirstAdNavigatingButton.Click);
                return new StaysAdPage();
            }
            throw new ArgumentException(_noAdsExceptionMessage);
        }
    }
}
