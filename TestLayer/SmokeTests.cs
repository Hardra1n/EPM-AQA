using FluentAssertions;
using NUnit.Framework;
using QAAutomationLab.BusinessLayer.Utilities;

namespace TestLayer
{
    [TestFixture]
    [Category("Smoke")]
    public class SmokeTests : BaseTest
    {
        [Test]
        public void GoToAttractions_WhenAllDataAreValid_ShouldReturnAttractionPage()
        {
            // Assert
            var mainPageUrl = TestsSettings.MainPageUrl;
            var attractionsPart = "attractions";

            // Act
            var mainPage = Utilities.RunBrowser(mainPageUrl);
            var attractionPage = mainPage.MainPageTopBar.GoToAttractions();

            // Assert
            attractionPage.BaseUrl.Should().Contain(attractionsPart);
        }

        [Test]
        public void GoToTravelTalk_ShouldReturnTravelTalkPage()
        {
            // Assert
            var mainPageUrl = TestsSettings.MainPageUrl;
            var communitiesPart = "communities";
            var headText = "Travel Talk";

            // Act
            var mainPage = Utilities.RunBrowser(mainPageUrl);
            var travelCommunitiesPage = mainPage.TravelCommunitiesPanel.GoToTravelTalk();

            // Assert
            travelCommunitiesPage.BaseUrl.Should().Contain(communitiesPart);
            travelCommunitiesPage.TravelCommunitiesNavbar.GetHeaderText().Should().BeEquivalentTo(headText);
        }

        [Test]
        public void GoToTravelCommunities_ShouldReturnTravelCommunitiesPage()
        {
            // Assert
            var mainPageUrl = TestsSettings.MainPageUrl;
            var communitiesPart = "communities";

            // Act
            var mainPage = Utilities.RunBrowser(mainPageUrl);
            var travelCommunitiesPage = mainPage.TravelCommunitiesPanel.GoToCommunities();

            // Assert
            travelCommunitiesPage.BaseUrl.Should().Contain(communitiesPart);
        }
    }
}
