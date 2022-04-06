using FluentAssertions;
using NUnit.Framework;
using QAAutomationLab.BusinessLayer.Utilities;

namespace TestLayer.Attractions
{
    [TestFixture, Category("All")]
    public class AttractionsSearchResultsTests : BaseTest
    {
        [Test]
        public void FilterResult_ShouldShowFilteredResults()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var expectedTitle = "Graffiti Workshop in Brooklyn";
            var searchResultPage = Utilities.RunBrowser(mainPageUrl).
                GoToAttractions().
                GoToSearchResult("New");

            // Act
            var filteredFirstResult = searchResultPage.FilterResult().ShowFirstResultTitle();

            // Assert
            filteredFirstResult.Should().BeEquivalentTo(expectedTitle);
        }

        [Test]
        public void SearchForSimilarActivities_ShouldShowSimilarResults()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var expectedCount = 4;
            var searchResultPage = Utilities.RunBrowser(mainPageUrl).
                GoToAttractions().
                GoToSearchResult("New");

            // Act
            var similarResults = searchResultPage.SearchForSimilarActivities("Edge").FindAllResults();

            // Assert
            similarResults.Count.Should().Be(expectedCount);
        }

        [Test]
        public void ChooseEdgeResult_ShouldOpenBusPage()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var expectedUrlPart = "night-bus-tour";
            var searchResultPage = Utilities.RunBrowser(mainPageUrl).
                GoToAttractions().
                GoToSearchResult("New");

            // Act
            var nightBusPage = searchResultPage.ChooseEdgeResult();

            // Assert
            nightBusPage.BaseUrl.Should().Contain(expectedUrlPart);
        }
    }
}
