using NUnit.Framework;
using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.PageObjects.Stays;
using QAAutomationLab.BusinessLayer.Utilities;
using System;
using System.Threading;

namespace TestLayer.Stays
{
    [TestFixture]
    public class SearchingPageTests : BaseTest
    {
        private StaysSearchingPage _page;

        [SetUp]
        public void SetUp()
        {
            _page = Utilities.RunBrowser(TestsSettings.MainPageUrl).GoToStays();
        }

        [TestCase("Warsaw")]
        public void CorrectStaysSearchingTest(string destination)
        {
            DateTime stayFromDate = DateTime.Now;
            DateTime stayToDate = DateTime.Now.AddDays(1);
            int adultsCount = 5;
            int childrenCount = 2;
            int roomsCount = 3;
            int[] childrenAge = new int[] {15, 16};

            var resultpage = _page.EnterDestination(destination)
                                  .ClickCalendarMenu()
                                  .SelectDatesToStay(stayFromDate, stayToDate)
                                  .ClickPersonsMenu()
                                  .SelectPersonsValues(adultsCount, childrenCount, roomsCount, childrenAge)
                                  .ClickSearchButton();

            Assert.That(resultpage is StaysSearchResultsPage, Is.True);
        }

        [Test]
        public void UnableToSearchWithoutSelectedDestiantion()
        {
            string expectedErrorMessage = "enter a destination to start searching.";
            DateTime stayFromDate = DateTime.Now;
            DateTime stayToDate = DateTime.Now.AddDays(1);
            int adultsCount = 5;
            int childrenCount = 2;
            int roomsCount = 3;
            int[] childrenAge = new int[] { 15, 16 };

            _page.ClickCalendarMenu()
                 .SelectDatesToStay(stayFromDate, stayToDate)
                 .ClickPersonsMenu()
                 .SelectPersonsValues(adultsCount, childrenCount, roomsCount, childrenAge)
                 .ClickSearchButtonWithoutNavigating();                                 
            var errorMessage = _page.GetDestinationErrorMessage();

            Assert.That(errorMessage, Does.Contain(expectedErrorMessage));
        }

        [TestCase("Warsaw")]
        public void UnableToSearchWithoutSelectingChildAge(string destination)
        {
            string pageTitleSubstring = "";
            DateTime stayFromDate = DateTime.Now;
            DateTime stayToDate = DateTime.Now.AddDays(1);
            int adultsCount = 5;
            int childrenCount = 2;
            int roomsCount = 3;

            _page.EnterDestination(destination)
                 .ClickCalendarMenu()
                 .SelectDatesToStay(stayFromDate, stayToDate)
                 .ClickPersonsMenu()
                 .SelectPersonsValues(adultsCount, childrenCount, roomsCount);

            Assert.That(() => _page.ClickSearchButton(), Throws.TypeOf<NoSuchElementException>());    
        }
    }
}
