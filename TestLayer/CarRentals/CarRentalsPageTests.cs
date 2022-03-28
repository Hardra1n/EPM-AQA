using NUnit.Framework;
using QAAutomationLab.BusinessLayer.PageObjects.CarRentals;
using QAAutomationLab.BusinessLayer.Utilities;

namespace TestLayer.CarRentals
{
    [TestFixture]
    public class CarRentalsPageTests:BaseTest
    {
        [Test]
        public void SearchWithExistingResults() 
        {
            var page = Utilities.RunBrowser("www.booking.com")
                 .GoToCarRentals()
                 .ChooseSameLocation()
                 .EnterPickUpLocation("Berlin")
                 .ChooseFirstSearchSuggestion().ClickSearchButton();

            Assert.IsTrue(page is SearchResultsPage);
        }
    }
}
