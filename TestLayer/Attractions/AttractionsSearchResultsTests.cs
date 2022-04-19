using FluentAssertions;
using NUnit.Framework;
using QAAutomationLab.BusinessLayer.Utilities;

namespace TestLayer.Attractions
{
    [TestFixture]
    [Category("All")]
    public class AttractionsSearchResultsTests : BaseTest
    {
        [Test]
        public void FilterResult_ShouldShowFilteredResults()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var expectedTitle = "Graffiti Workshop in Brooklyn";
            var searchResultPage = Utilities.RunBrowser(mainPageUrl).
                MainPageTopBar.
                GoToAttractions().
                AttractionsSearchPanel.
                GoToSearchResult("New", "Search");

            // Act
            var filteredFirstResult = searchResultPage.
                SearchResultCheckBox.
                FilterByElementExceptPrice("Activities").
                FilterByPrice().
                FilterByElementExceptPrice("Free cancellation").
                FilterByElementExceptPrice("Brooklyn").
                ReturnToSearchResultPage().
                SearchResultsList.
                ShowFirstResultTitle();

            // Assert
            filteredFirstResult.Should().BeEquivalentTo(expectedTitle);
        }

        [Test]
        public void SearchForSimilarActivities_ShouldShowSimilarResults()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var expectedTitle = "Edge Sky Deck Admission Tickets";
            var searchResultPage = Utilities.RunBrowser(mainPageUrl).
                MainPageTopBar.
                GoToAttractions().
                AttractionsSearchPanel.
                GoToSearchResult("New", "Search");

            // Act
            var similarResultsFirst = searchResultPage.
                SearchResultSearchPanel.
                SearchForSimilarActivities("Edge").
                SearchResultsList.
                ChooseFilterButton("Lowest price").
                ShowFirstResultTitle();

            // Assert
            similarResultsFirst.Should().Contain(expectedTitle);
        }

        [Test]
        public void ChooseEdgeResult_ShouldOpenBusPage()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var expectedUrlPart = "night-bus-tour";
            var searchResultPage = Utilities.RunBrowser(mainPageUrl).
                MainPageTopBar.
                GoToAttractions().
                AttractionsSearchPanel.
                GoToSearchResult("New", "Search");

            // Act
            var nightBusPage = searchResultPage.SearchResultSearchPanel.ChooseEdgeResult();

            // Assert
            nightBusPage.BaseUrl.Should().Contain(expectedUrlPart);
        }
    }
}
