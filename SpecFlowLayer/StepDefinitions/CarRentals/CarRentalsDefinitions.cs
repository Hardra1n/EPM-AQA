using NUnit.Framework;
using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.PageObjects.CarRentals;
using QAAutomationLab.BusinessLayer.Utilities;
using QAAutomationLab.CoreLayer.BasePage;
using TechTalk.SpecFlow;

namespace SpecFlowLayer.StepDefinitions.CarRentals
{
    [Binding]
    public class CarRentalsDefinitions
    {
        private BasePage _page;

        private object _result;

        [Given(@"user opened Car Rentals Page")]
        public void GoToCarRetnalsPage()
        {
            _page = Utilities.RunBrowser("https://www.booking.com/").MainPageTopBar.GoToCarRentals();
        }

        [Given(@"user chose same location to return car")]
        [When(@"user chooses same location to return car")]
        public void SelectSameLocationToReturnCar()
        {
            CarRentalsPage page = (CarRentalsPage)_page;
            page.CarRentalsSearchPanel.ChooseSameLocation();
        }

        [Given(@"user chose different location to return car")]
        [When(@"user chooses different location to return car")]
        public void SelectDifferentLocationToReturnCar()
        {
            CarRentalsPage page = (CarRentalsPage)_page;
            page.CarRentalsSearchPanel.ChooseDifferentLocation();
        }

        [Given(@"user entered '(.*)' pick-up location")]
        [When(@"user enters '(.*)' pick-up location")]
        public void EnterPickUpLocation(string location)
        {
            CarRentalsPage page = (CarRentalsPage)_page;
            page.CarRentalsSearchPanel.EnterPickUpLocation(location);
        }

        [Given(@"user selected first pick-up suggestion with name '(.*)'")]
        [When(@"user selects first pick-up suggestion with name '(.*)'")]
        public void SelectFirstPickUpSuggestion(string location)
        {
            CarRentalsPage page = (CarRentalsPage)_page;
            page.CarRentalsSearchPanel.ChooseFirstPickUpSuggestion(location);
        }

        [Given(@"user entered '(.*)' drop-off location")]
        [When(@"user enters '(.*)' drop-off location")]
        public void EnterDropOffLocation(string location)
        {
            CarRentalsPage page = (CarRentalsPage)_page;
            page.CarRentalsSearchPanel.EnterDropOffLocation(location);
        }

        [Given(@"user selected first drop-off suggestion with name '(.*)'")]
        [When(@"user selects first drop-off suggestion with name '(.*)'")]
        public void SelectFirstDropOffSuggestion(string location)
        {
            CarRentalsPage page = (CarRentalsPage)_page;
            page.CarRentalsSearchPanel.ChooseFirstDropOffSuggestion(location);
        }

        [Given(@"user selected own driver age '(.*)'")]
        [When(@"user selects own driver age '(.*)'")]
        public void SelectDriverAge(int age)
        {
            CarRentalsPage page = (CarRentalsPage)_page;
            page.CarRentalsSearchPanel.ClickAgeCheckBox();
            page.CarRentalsSearchPanel.EnterAge(age.ToString());
        }

        [Given(@"user clicked search button")]
        [When(@"user clicks search button")]
        public void SearchForCar()
        {
            CarRentalsPage page = (CarRentalsPage)_page;
            try
            {
                _page = page.CarRentalsSearchPanel.ClickSearchButton();
            }
            catch (WebDriverTimeoutException ex)
            {
                _result = ex;
            }
        }

        [Then(@"'(.*)' that car rentals results on the page")]
        public void AreResultsShown(bool isOnPage)
        {
            SearchResultsPage page = (SearchResultsPage)_page;
            Assert.AreEqual(isOnPage, page.AreResultsShown());
        }

        [Then(@"user can't go to new page")]
        public void GoToNewPageThrowsExpection()
        {
            Assert.IsTrue(_result is WebDriverTimeoutException);
        }

        [Then(@"user can see the error message")]
        public void IsWrongDestinationMessageOnPage()
        {
            SearchResultsPage page = (SearchResultsPage)_page;
            Assert.IsTrue(page.SearchResultsPanel.IsNoResultsMessageShown());
        }
    }
}
