using FluentAssertions;
using NUnit.Framework;
using QAAutomationLab.BusinessLayer.Utilities;

namespace TestLayer.Attractions
{
    [TestFixture]
    [Category("All")]
    public class AttractionBookingTests : BaseTest
    {
        [Test]
        public void ChooseDateAndTime_ShouldChangeDateAndTime()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var cruisePage = Utilities.RunBrowser(mainPageUrl).
                MainPageTopBar.
                GoToAttractions().
                AttractionsSearchPanel.
                EnterSearchString("New").
                ChooseCruiseResult();

            var dateTimeValues = cruisePage.
                SinglePageForm.
                GetDateTimeValues();

            // Act
            var changedDateTime = cruisePage.
                SinglePageForm.
                ChooseDateAndTime().
                GetDateTimeValues();

            // Assert
            changedDateTime[0].Should().NotBeEquivalentTo(dateTimeValues[0]);
            changedDateTime[1].Should().NotBeEquivalentTo(dateTimeValues[1]);
        }

        [Test]
        public void ChooseTicket_ShouldChooseTicketAndContinue()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var expectedUrlPart = "/book";
            var cruisePage = Utilities.RunBrowser(mainPageUrl).
                MainPageTopBar.
                GoToAttractions().
                AttractionsSearchPanel.
                EnterSearchString("New").
                ChooseCruiseResult();

            // Act
            var bookingPage = cruisePage.
                SinglePageForm.
                GoToBookingPage("+");

            // Assert
            bookingPage.BaseUrl.Should().Contain(expectedUrlPart);
        }

        [Test]
        public void ChooseTicket_WhenTicketIsNotAdded_ShouldStayOnPage()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var expectedUrlPart = "/book";
            var cruisePage = Utilities.RunBrowser(mainPageUrl).
                MainPageTopBar.
                GoToAttractions().
                AttractionsSearchPanel.
                EnterSearchString("New").
                ChooseCruiseResult();

            // Act
            cruisePage = cruisePage.SinglePageForm.ChooseAdultTicket().ClickSubmitButton();

            // Assert
            cruisePage.BaseUrl.Should().NotContain(expectedUrlPart);
        }

        [Test]
        public void SubmitData_WhenDataIsNotPut_ShouldStayOnPage()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var notExpectedUrlPart = "/pay";
            var expectedUrlPart = "/book";
            var bookingPage = Utilities.RunBrowser(mainPageUrl).
                MainPageTopBar.
                GoToAttractions().
                AttractionsSearchPanel.
                EnterSearchString("New").
                ChooseCruiseResult().
                SinglePageForm.
                GoToBookingPage("+");

            // Act
            bookingPage.BookingForm.SubmitData(expectedUrlPart);

            // Assert
            bookingPage.BaseUrl.Should().NotContain(notExpectedUrlPart);
        }

        [Test]
        public void SubmitData_WhenDataArePut_ShouldGoToPayPage()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var expectedUrlPart = "/pay";
            var bookingPage = Utilities.RunBrowser(mainPageUrl).
                MainPageTopBar.
                GoToAttractions().
                AttractionsSearchPanel.
                EnterSearchString("New").
                ChooseCruiseResult().
                SinglePageForm.
                GoToBookingPage("+");

            // Act
            bookingPage.BookingForm.
                InputFirstName("Igor").
                InputLastName("Valeriy").
                InputEmail("testMail@mail.com").
                InputPhone("441234567").
                SubmitData(expectedUrlPart);

            // Assert
            bookingPage.BaseUrl.Should().Contain(expectedUrlPart);
        }
    }
}
