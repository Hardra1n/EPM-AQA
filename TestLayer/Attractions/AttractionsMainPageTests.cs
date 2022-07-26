﻿using FluentAssertions;
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
            var burjHalifTitle = "Palm Monorail Ticket";
            var attractionPage = Utilities.RunBrowser(mainPageUrl).MainPageTopBar.GoToAttractions();

            // Act
            var firstResultTitle = attractionPage.
                AttractionsTopDestination.
                GoToCity("Dubai").
                SearchResultsList.ChooseFilterButton("Lowest price").
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
                SubmitSearchRequest("Search");

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
                ChooseTab("Asia").
                GoToCity("Kyoto");

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
                GoToSearchResult("New", "Search");

            // Assert
            kyotoSearchPage.BaseUrl.Should().Contain(expectedUrlPart);
        }

        [Test]
        public void CheckFooterLinks_ShouldHaveCorrectAttribure()
        {
            // Arrange
            var mainPageUrl = TestsSettings.MainPageUrl;
            var attractionPage = Utilities.RunBrowser(mainPageUrl).
                MainPageTopBar.
                GoToAttractions();

            // Act
            var footerLinks = attractionPage.AttractionsFooter.
                GetFooterLinks();

            // Assert
            Assert.Multiple(() =>
            {
                foreach (var link in footerLinks)
                {
                    var hrefText = link.GetAttribute("href");
                    bool isCorrect = hrefText.StartsWith("http://") ||
                        hrefText.StartsWith("https://");
                    isCorrect.Should().BeTrue();
                }
            });
        }
    }
}
