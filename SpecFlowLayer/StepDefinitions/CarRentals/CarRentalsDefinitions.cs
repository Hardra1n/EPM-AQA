using NUnit.Framework;
using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.PageObjects.CarRentals;
using QAAutomationLab.BusinessLayer.PageObjects.MainPageObjects;
using QAAutomationLab.CoreLayer.BasePage;
using TechTalk.SpecFlow;

namespace SpecFlowLayer.StepDefinitions.CarRentals
{
    [Binding]
    public class CarRentalsDefinitions : BaseDefinitions
    {
        public CarRentalsDefinitions(ScenarioContext scenarioContext)
            : base(scenarioContext) { }

        [Given(@"user opened Car Rentals Page")]
        [When(@"user opens Car Rentals Page")]
        public void GoToCarRetnalsPage()
        {
            var page = (MainPage)Page;
            Page = page.MainPageTopBar.GoToCarRentals();
        }

        [Given(@"user chose same location to return car")]
        [When(@"user chooses same location to return car")]
        public void SelectSameLocationToReturnCar()
        {
            var page = (CarRentalsPage)Page;
            page.CarRentalsSearchPanel.ChooseSameLocation();
        }

        [Given(@"user chose different location to return car")]
        [When(@"user chooses different location to return car")]
        public void SelectDifferentLocationToReturnCar()
        {
            var page = (CarRentalsPage)Page;
            page.CarRentalsSearchPanel.ChooseDifferentLocation();
        }

        [Given(@"user entered '(.*)' pick-up location")]
        [When(@"user enters '(.*)' pick-up location")]
        public void EnterPickUpLocation(string location)
        {
            var page = (CarRentalsPage)Page;
            page.CarRentalsSearchPanel.EnterPickUpLocation(location);
        }

        [Given(@"user selected first pick-up suggestion with name '(.*)'")]
        [When(@"user selects first pick-up suggestion with name '(.*)'")]
        public void SelectFirstPickUpSuggestion(string location)
        {
            var page = (CarRentalsPage)Page;
            page.CarRentalsSearchPanel.ChooseFirstPickUpSuggestion(location);
        }

        [Given(@"user entered '(.*)' drop-off location")]
        [When(@"user enters '(.*)' drop-off location")]
        public void EnterDropOffLocation(string location)
        {
            var page = (CarRentalsPage)Page;
            page.CarRentalsSearchPanel.EnterDropOffLocation(location);
        }

        [Given(@"user selected first drop-off suggestion with name '(.*)'")]
        [When(@"user selects first drop-off suggestion with name '(.*)'")]
        public void SelectFirstDropOffSuggestion(string location)
        {
            var page = (CarRentalsPage)Page;
            page.CarRentalsSearchPanel.ChooseFirstDropOffSuggestion(location);
        }

        [Given(@"user selected own driver age '(.*)'")]
        [When(@"user selects own driver age '(.*)'")]
        public void SelectDriverAge(int age)
        {
            var page = (CarRentalsPage)Page;
            page.CarRentalsSearchPanel.ClickAgeCheckBox();
            page.CarRentalsSearchPanel.EnterAge(age.ToString());
        }

        [Given(@"user clicked search button")]
        [When(@"user clicks search button")]
        public void SearchForCar()
        {
            var page = (CarRentalsPage)Page;
            try
            {
                Page = page.CarRentalsSearchPanel.ClickSearchButton();
            }
            catch (WebDriverTimeoutException ex)
            {
                Result = ex;
            }
        }

        [Given("user clicked first location to rent")]
        [When("user clicks first location to rent")]
        public void SelectFirstLocation()
        {
            var page = (SearchResultsPage)Page;
            Page = page.SearchResultsPanel.ChooseFirstSearchResult();
        }

        [Given(@"user clicked first car to book")]
        [When(@"user clicks first car to book")]
        public void SelectFirstCar()
        {
            var page = (CarSelectionPage)Page;
            Page = page.CarSelectionPageRightBar.ChooseFirstCar();
        }

        [Given(@"user chose all car's additional options")]
        [When(@"user choose all car's additional options")]
        public void SelectAllCarsOptions()
        {
            var page = (CarOptionsPage)Page;
            page.CarOptionsMiddleBar.ChooseAllOptions();
        }

        [Given(@"user clicked go to book button")]
        [When(@"user clicks go to book button")]
        public void GoToCarBookingPage()
        {
            var page = (CarOptionsPage)Page;
            Page = page.CarOptionsMiddleBar.GoToBookPage();
        }

        [Then(@"'(.*)' that car rentals results on the page")]
        public void AreResultsShown(bool isOnPage)
        {
            var page = (SearchResultsPage)Page;
            Assert.AreEqual(isOnPage, page.AreResultsShown());
        }

        [Then(@"user can't go to new page")]
        public void GoToNewPageThrowsExpection()
        {
            Assert.IsTrue(Result is WebDriverTimeoutException);
        }

        [Then(@"user can see the error message")]
        public void WrongDestinationMessageIsOnPage()
        {
            var page = (CarRentalsPage)Page;
            Assert.IsTrue(page.CarRentalsSearchPanel.IsErrorMessageShown());
        }

        [Then(@"user on the booking page")]
        public void IsBookingPage()
        {
            Assert.IsTrue(Page is BookPage);
        }

        [Then(@"price should contain '(.*)'")]
        public void PriceShouldContain(string expectedSubstring)
        {
            var page = (SearchResultsPage)Page;
            string resultPrice = page.SearchResultsPanel.GetFirstResultPriceText();
            Assert.That(resultPrice, Does.Contain(expectedSubstring));
        }
    }
}
