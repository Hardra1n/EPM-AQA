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

            _page.EnterDestination(destination)
                 .ClickCalendarMenu()
                 .SelectDatesToStay(stayFromDate, stayToDate)
                 .ClickPersonsMenu()
                 .SelectPersonsValues(5, 3, 3);
            
            Assert.Fail("Not fully implemented yet");
        }
    }
}
