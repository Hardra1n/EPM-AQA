using NUnit.Framework;
using QAAutomationLab.BusinessLayer.Models;
using QAAutomationLab.BusinessLayer.PageObjects.Stays;
using QAAutomationLab.BusinessLayer.PageObjects.Stays.Components;
using QAAutomationLab.BusinessLayer.Utilities;

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
            var context = StaysSearchingContext.GetDefaultContext();
            var daysDifference = (context.DateTo - context.DateFrom).Days;
            int lowerPriceLimit = 500;
            int upperPriceLimit = 600;

            _page.FilterContainer
                 .ClickOwnPriceToggle()
                 .SelectOwnPriceLimit(lowerPriceLimit, upperPriceLimit);
            _page.ResultsContainer.WaitForUpdateResults();
            int adCount = _page.ResultsContainer
                               .GetAdsCountOnPage();

            Assert.Multiple(() =>
            {
                for (int i = 1; i <= adCount; i++)
                {
                    StaysSearchAdCard card = _page.ResultsContainer.GetAdCard(i);
                    int price = card.GetPrice();
                    Assert.That(price, Is.LessThanOrEqualTo(upperPriceLimit * daysDifference));
                    Assert.That(price, Is.GreaterThanOrEqualTo(lowerPriceLimit * daysDifference));
                }
            });
        }
    }
}
