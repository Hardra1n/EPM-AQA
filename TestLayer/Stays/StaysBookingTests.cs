using NUnit.Framework;
using QAAutomationLab.BusinessLayer.Models;
using QAAutomationLab.BusinessLayer.PageObjects.Stays;
using QAAutomationLab.BusinessLayer.Utilities;

namespace TestLayer.Stays
{
    [TestFixture]
    [Category("All")]
    public class StaysBookingTests : BaseTest
    {
        private StaysBookingDetailsPage _page;

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
                             .ClickFirstAdNavigatingButton()
                             .RoomContainer
                             .AddOneRoomToBooking()
                             .ClickNavigatingToBookingButton();
        }

        [Test]
        [Category("Smoke")]
        public void CorrectNavigatingToFinalStep()
        {
            var resultPage = _page.MainContainer
                                  .AddBookingDetailsContext(
                                      StaysBookingDetailsContext.GetDefaultContext())
                                  .ClickConfirmButton();

            Assert.That(resultPage is StaysBookingFinalStepPage, Is.True);
        }

        [Test]
        public void NotificationAppearsAfterClosingUnfinishedBooking()
        {
            Utilities.RunBrowser(TestsSettings.MainPageUrl);
            bool result = _page.IsThereUnfinishedBookingNotification();

            Assert.That(result, Is.True);
        }
    }
}
