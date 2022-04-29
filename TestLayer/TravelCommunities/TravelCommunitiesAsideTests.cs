using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using QAAutomationLab.BusinessLayer.Utilities;

namespace TestLayer.TravelCommunities
{
    [TestFixture]
    [Category("All")]
    public class TravelCommunitiesAsideTests : BaseTest
    {
        [Test]
        public void GoToTip_ShouldReturnTipPostPage()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var communitiesPage = Utilities.RunBrowser(mainPageUrl).
                TravelCommunitiesPanel.GoToCommunities();

            var headText = "Give a tip";

            // Act
            var newPostPage = communitiesPage.TravelCommunitiesAside.GoToTip();

            // Assert
            newPostPage.GetHeadText().Should().BeEquivalentTo(headText);
        }

        [Test]
        public void GoToQuestion_ShouldReturnQuestionPostPage()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var communitiesPage = Utilities.RunBrowser(mainPageUrl).
                TravelCommunitiesPanel.GoToCommunities();

            var headText = "Ask a question";

            // Act
            var newPostPage = communitiesPage.TravelCommunitiesAside.GoToQuestion();

            // Assert
            newPostPage.GetHeadText().Should().BeEquivalentTo(headText);
        }

        [Test]
        public void SearchCommunity_WhenInputIsWrong_ShouldShowNoResults()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var communitiesPage = Utilities.RunBrowser(mainPageUrl).
                TravelCommunitiesPanel.GoToCommunities().TravelCommunitiesNavbar.ShowFilteredList("Argentina").GoToFirstResult();

            // Act
            var travelCommunitiesPage = communitiesPage.TravelCommunitiesAside.SearchCommunity("dwadwadwa");

            // Assert
            travelCommunitiesPage.TravelCommunityMainBar.CheckIfResultExists(string.Empty).Should().BeFalse();
        }

        [Test]
        public void SearchCommunity_WhenInputIsRight_ShouldShowResults()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var communitiesPage = Utilities.RunBrowser(mainPageUrl).
                TravelCommunitiesPanel.GoToCommunities().TravelCommunitiesNavbar.ShowFilteredList("Argentina").WaitForFilterResults().GoToFirstResult();

            // Act
            var travelCommunitiesPage = communitiesPage.TravelCommunitiesAside.SearchCommunity("Ricardo");

            // Assert
            travelCommunitiesPage.TravelCommunityMainBar.CheckIfResultExists("Путешествие по Аргентине").Should().BeTrue();
        }

        [Test]
        public void FilterByQuestions_ShouldShowFilteredResults()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var communitiesPage = Utilities.RunBrowser(mainPageUrl).
                TravelCommunitiesPanel.GoToCommunities().TravelCommunitiesNavbar.ShowFilteredList("Argentina").WaitForFilterResults().GoToFirstResult();

            // Act
            var travelCommunitiesPage = communitiesPage.TravelCommunitiesAside.FilterByQuestions();

            // Assert
            travelCommunitiesPage.TravelCommunityMainBar.CheckIfResultExists("Requisitos para ingresar a Argentina desde Perú").Should().BeTrue();
        }
    }
}
