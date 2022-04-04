using NUnit.Framework;
using QAAutomationLab.BusinessLayer.Models;
using QAAutomationLab.BusinessLayer.PageObjects.Stays;
using QAAutomationLab.BusinessLayer.Utilities;
using System.Threading;

namespace TestLayer.Stays
{
    [TestFixture]
    [Category("All")]
    public class StaysAdTests : BaseTest
    {
        private StaysAdPage _page;

        [SetUp]
        public void SetUp()
        {
            _page = Utilities.RunBrowser(TestsSettings.MainPageUrl)
                             .GoToStays()
                             .AddSearchingContext(StaysSearchingContext.GetDefaultContext())
                             .ClickSearchButton()
                             .ClickFirstAdNavigatingButton();
        }

        [Test]
        [Category("Smoke")]
        public void CorrectNavigatingToBookingPageTest()
        {
            string expectedHotelName = _page.GetHotelName();

            string actualHotelName = _page.AddOneRoomToBooking()
                                          .ClickNavigatingToBookingButton()
                                          .GetHotelName();

            Assert.That(actualHotelName, Is.SubsetOf(expectedHotelName));
        }

    }
}
