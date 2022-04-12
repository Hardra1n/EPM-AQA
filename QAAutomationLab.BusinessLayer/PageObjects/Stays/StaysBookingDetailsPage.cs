using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.PageObjects.Stays.Components;
using QAAutomationLab.CoreLayer.BasePage;
using QAAutomationLab.CoreLayer.WebElement;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays
{
    public class StaysBookingDetailsPage : BasePage
    {
        public StaysBookingDetailsMainContainer MainContainer => new();

        private BaseWebElement _unfinishedNotification => new(By.Id("growl_squash"));

        public bool IsThereUnfinishedBookingNotification() => _unfinishedNotification.Displayed;
    }
}