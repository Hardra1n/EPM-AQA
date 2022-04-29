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
    public class TravelCommunitiesMainBarTests : BaseTest
    {
        [Test]
        public void FilterResults_ShouldShowFilteredResults()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var communitiesPage = Utilities.RunBrowser(mainPageUrl).
                TravelCommunitiesPanel.GoToCommunities();

            // Act
            var page = communitiesPage.TravelCommunityMainBar.FilterResults("Wedding");

            // Assert
            page.CheckIfResultExists("Путешествие в одиночку").Should().BeTrue();
        }
    }
}
