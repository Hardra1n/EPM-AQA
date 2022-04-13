using FluentAssertions;
using NUnit.Framework;
using QAAutomationLab.BusinessLayer.Utilities;

namespace TestLayer.Attractions
{
    [TestFixture]
    [Category("All")]
    public class AttractionsMainPageTests : BaseTest
    {
        [Test]
        public void ChooseTopDestinations_ShouldRedirectToAttrPage()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var burjHalifTitle = "Ain Dubai Admission";
            var attractionPage = Utilities.RunBrowser(mainPageUrl).MainPageTopBar.GoToAttractions();

            // Act
            var firstResultTitle = attractionPage.
                AttractionsTopDestination.
                GoToDubai().
                SearchResultsList.ChooseLowestPrice().
                ShowFirstResultTitle();

            // Assert
            firstResultTitle.Should().BeEquivalentTo(burjHalifTitle);
        }

        [Test]
        public void EnterSearchString_WhenAllDataAreValid_ShouldGoToTopThingToDo()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var expectedUrlPart = "guided-sightseeing-cruise";
            var attractionPage = Utilities.RunBrowser(mainPageUrl).
                MainPageTopBar.
                GoToAttractions();

            // Act
            var topThingToDo = attractionPage.
                AttractionsSearchPanel.
                EnterSearchString("New").
                ChooseCruiseResult();

            // Assert
            topThingToDo.BaseUrl.Should().Contain(expectedUrlPart);
        }

        [Test]
        public void EnterSearchString_WhenSearchStringIsNotValid_ShouldStayOnPage()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var expectedUrlPart = "attractions/index";
            var attractionPage = Utilities.RunBrowser(mainPageUrl).
                MainPageTopBar.
                GoToAttractions();

            // Act
            var topThingToDo = attractionPage.
                AttractionsSearchPanel.
                EnterSearchString("Абырвалг").
                SubmitSearchRequest();

            // Assert
            topThingToDo.BaseUrl.Should().Contain(expectedUrlPart);
        }

        [Test]
        public void ChooseAsiaTabAndGoToKyotoPage_ShouldGoToKyotoSearchPage()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var expectedUrlPart = "searchresults/jp/kyoto";
            var attractionPage = Utilities.RunBrowser(mainPageUrl).
                MainPageTopBar.
                GoToAttractions();

            // Act
            var kyotoSearchPage = attractionPage.
                AttractionsCityBar.
                ChooseAsiaTab().
                GoToKyoto();

            // Assert
            kyotoSearchPage.BaseUrl.Should().Contain(expectedUrlPart);
        }

        [Test]
        public void GoToSearchResult_WhenNewEntered_ShouldGoToNewYorkSearchPage()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var expectedUrlPart = "searchresults/us/new-york";
            var attractionPage = Utilities.RunBrowser(mainPageUrl).
                MainPageTopBar.
                GoToAttractions();

            // Act
            var kyotoSearchPage = attractionPage.
                AttractionsSearchPanel.
                GoToSearchResult("New");

            // Assert
            kyotoSearchPage.BaseUrl.Should().Contain(expectedUrlPart);
        }
    }
}
