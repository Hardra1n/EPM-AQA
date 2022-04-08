using NUnit.Framework;
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
                 .GoToCarRentals()
                 .ChooseSameLocation()
                 .EnterPickUpLocation(location)
                 .ChooseFirstPickUpSuggestion(location)
                 .ClickSearchButton()
                 .IsNoResultsMessageShown();

            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("ase232")]
        public void InvalidSearchRequest(string location)
        {
            var page = Utilities.RunBrowser(TestsSettings.MainPageUrl)
                .GoToCarRentals()
                .ChooseSameLocation()
                .EnterPickUpLocation(location);

            Assert.Throws<OpenQA.Selenium.NoSuchElementException>(() => page.ClickSearchButton());

            bool vissible = page.IsErrorMessageShown();

            Assert.IsTrue(vissible);
        }

        [Test]
        [TestCase("Pruzhany","Los Angeles")]
        public void SearchWithoutExistingResults(string pickUpLocation,string dropDownLocation) 
        {
            bool result = Utilities.RunBrowser(TestsSettings.MainPageUrl)
                .GoToCarRentals().ChooseDifferentLocation()
                .EnterPickUpLocation(pickUpLocation)
                .ChooseFirstPickUpSuggestion(pickUpLocation)
                .EnterDropOffLocation(dropDownLocation)
                .ChooseFirstDropOffSuggestion(dropDownLocation)
                .ClickSearchButton()
                .IsNoResultsMessageShown();

            Assert.IsTrue(result);
        }
    }
}
