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
    public class TravelCommunitiesNavbarTests : BaseTest
    {
        [Test]
        public void IsAnyCommunities_ShouldBeTrue()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var communitiesPage = Utilities.RunBrowser(mainPageUrl).
                TravelCommunitiesPanel.GoToCommunities();

            // Act
            var listOfCommunities = communitiesPage.TravelCommunitiesNavbar.ShowList();

            // Assert
            listOfCommunities.IsAnyCommunities().Should().BeTrue();
        }

        [Test]
        public void CheckIfAllResultsContain_ShouldBeTrue()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var communitiesPage = Utilities.RunBrowser(mainPageUrl).
                TravelCommunitiesPanel.GoToCommunities();

            var filterString = "Argentina";

            // Act
            var listOfCommunities = communitiesPage.TravelCommunitiesNavbar.ShowFilteredList(filterString);
            var checkResult = listOfCommunities.CheckIfAllResultsContain(filterString);

            // Assert
            checkResult.Should().BeTrue();
        }
    }
}
