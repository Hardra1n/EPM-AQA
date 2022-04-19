using NUnit.Framework;
using QAAutomationLab.BusinessLayer.Models;
using QAAutomationLab.BusinessLayer.PageObjects.Stays;
using QAAutomationLab.BusinessLayer.Utilities;

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
                             .MainPageTopBar
                             .GoToStays()
                             .SearchPanel
                             .AddSearchingContext(StaysSearchingContext.GetDefaultContext())
                             .ClickSearchButton()
                             .ResultsContainer
                             .GetAdCard()
                             .ClickNavigatingButton();
        }

        [Test]
        [Category("Smoke")]
        public void CorrectNavigatingToBookingPageTest()
        {
            string expectedHotelName = _page.HeaderContainer
                                            .GetHotelName();

            string actualHotelName = _page.RoomContainer
                                          .AddOneRoomToBooking()
                                          .ClickNavigatingToBookingButton()
                                          .MainContainer
                                          .GetHotelName();

            Assert.That(actualHotelName, Is.SubsetOf(expectedHotelName));
        }
    }
}
