using NUnit.Framework;
using QAAutomationLab.BusinessLayer.Models;
using QAAutomationLab.BusinessLayer.PageObjects.Stays;
using QAAutomationLab.BusinessLayer.Utilities;
using System.Threading;

namespace TestLayer.Stays
{
    [TestFixture]
    [Category("All")]
    public class StaysSearchResultsTests : BaseTest
    {
        private StaysSearchResultsPage _page;

        [SetUp]
        public void SetUp()
        {
            _page = Utilities.RunBrowser(TestsSettings.MainPageUrl)
                             .MainPageTopBar
                             .GoToStays()
                             .SearchPanel
                             .AddSearchingContext(StaysSearchingContext.GetDefaultContext())
                             .ClickSearchButton();
        }

        [Test]
        [Category("Smoke")]
        public void CorrectNavigatingToAdPage()
        {
            string expectedAdPageTitleSubstring = _page.ResultsContainer.GetAdCard(1).GetAdTitle();

            string actualAdPageTitle = _page.ResultsContainer
                                            .GetAdCard()
                                            .ClickNavigatingButton()
                                            .HeaderContainer
                                            .GetHotelName();

            Assert.That(actualAdPageTitle, Does.Contain(expectedAdPageTitleSubstring));
        }

        [Test]
        public void SearchResultsChangesAfterCheckingFilteringOptions()
        {
            int? numberOfAdsBeforeFiltering = _page.ResultsContainer.GetAdsCount();

            _page.FilterContainer.ClickFirstFilteringStarsOption();
            int? numberOfAdsAfterFiltering = _page.ResultsContainer.WaitForUpdateResults()
                                                                   .GetAdsCount();

            Assert.That(numberOfAdsAfterFiltering, Is.Not.EqualTo(numberOfAdsBeforeFiltering));
        }

        [Test]
        public void StayingPlaceShowsOnMapSuccessfully()
        {
            var page = _page.ResultsContainer
                            .GetAdCard()
                            .ClickShowOnMapButton();

            Assert.That(page.HeaderContainer.IsMapDisplayed(), Is.True);
        }

        [Test]
        public void AdCardsHaveCorrectPriceAfterPriceFiltering()
        {
            _page.FilterContainer.ClickOwnPriceToggle().SelectOwnPriceLimit(500, 600);
        }

    }
}
