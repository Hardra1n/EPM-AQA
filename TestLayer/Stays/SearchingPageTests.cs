using NUnit.Framework;
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

            _page.EnterDestination(destination)
                 .ClickCalendarMenu()
                 .SelectDatesToStay(stayFromDate, stayToDate)
                 .ClickPersonsMenu()
                 .SelectPersonsValues(adultsCount, childrenCount, roomsCount, childrenAge);

            Assert.Fail("Not fully implemented yet");
        }
    }
}
