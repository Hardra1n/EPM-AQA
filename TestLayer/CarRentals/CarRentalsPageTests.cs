using NUnit.Framework;
using QAAutomationLab.BusinessLayer.PageObjects.CarRentals;
using QAAutomationLab.BusinessLayer.Utilities;

namespace TestLayer.CarRentals
{
    [TestFixture]
    public class CarRentalsPageTests : BaseTest
    {
        [Test]
        [TestCase("Berlin")]
        public void SearchWithExistingResults(string location)
        {
            bool result = Utilities.RunBrowser(TestsSettings.MainPageUrl)
                .MainPageTopBar
                .GoToCarRentals()
                .CarRentalsSearchPanel
                .ChooseSameLocation()
                .EnterPickUpLocation(location)
                .ChooseFirstPickUpSuggestion(location)
                .ClickAgeCheckBox()
                .EnterAge("21")
                .ClickSearchButton()
                .AreResultsShown();

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("Berlin")]
        public void BookCarWithOptions(string location)
        {
            var page = Utilities.RunBrowser(TestsSettings.MainPageUrl)
                .MainPageTopBar
                .GoToCarRentals()
                .CarRentalsSearchPanel
                .ChooseSameLocation()
                .EnterPickUpLocation(location)
                .ChooseFirstPickUpSuggestion(location)
                .ClickAgeCheckBox()
                .EnterAge("21")
                .ClickSearchButton()
                .SearchResultsPanel
                .ChooseFirstSearchResult()
                .CarSelectionPageRightBar
                .ChooseFirstCar()
                .CarOptionsMiddleBar
                .ChooseAllOptions()
                .GoToBookPage();

            Assert.IsTrue(page is BookPage);
        }

        [Test]
        [TestCase("ase232")]
        public void InvalidSearchRequest(string location)
        {
            var page = Utilities.RunBrowser(TestsSettings.MainPageUrl)
                .MainPageTopBar
                .GoToCarRentals()
                .CarRentalsSearchPanel
                .ChooseSameLocation()
                .EnterPickUpLocation(location);

            Assert.Throws<OpenQA.Selenium.WebDriverTimeoutException>(() => page.ClickSearchButton());

            bool vissible = page.IsErrorMessageShown();

            Assert.IsTrue(vissible);
        }

        [Test]
        [TestCase("Pruzhany", "Los Angeles")]
        public void SearchWithoutExistingResults(string pickUpLocation, string dropDownLocation)
        {
            bool result = Utilities.RunBrowser(TestsSettings.MainPageUrl)
                .MainPageTopBar
                .GoToCarRentals()
                .CarRentalsSearchPanel
                .ChooseDifferentLocation()
                .EnterPickUpLocation(pickUpLocation)
                .ChooseFirstPickUpSuggestion(pickUpLocation)
                .EnterDropOffLocation(dropDownLocation)
                .ChooseFirstDropOffSuggestion(dropDownLocation)
                .ClickSearchButton()
                .AreResultsShown();

            Assert.IsFalse(result);
        }
    }
}
