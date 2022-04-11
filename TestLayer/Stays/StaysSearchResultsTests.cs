using NUnit.Framework;
using QAAutomationLab.BusinessLayer.Models;
using QAAutomationLab.BusinessLayer.PageObjects.Stays;
using QAAutomationLab.BusinessLayer.Utilities;

namespace TestLayer.Stays
{
    [TestFixture]
    [Category("All")]
    public class StaysSearchResultsPageTests : BaseTest
    {
        private StaysSearchResultsPage _page;
        
        [SetUp]
        public void SetUp()
        {
            _page = Utilities.RunBrowser(TestsSettings.MainPageUrl)
                             .GoToStays()
                             .AddSearchingContext(StaysSearchingContext.GetDefaultContext())
                             .ClickSearchButton();
        }

        [Test]
        [Category("Smoke")]
        public void CorrectNavigatingToAdPage()
        {
            string expectedAdPageTitleSubstring = _page.GetFirstAddTitle();

            string actualAdPageTitle = _page.ClickFirstAdNavigatingButton().GetHotelName();

            Assert.That(actualAdPageTitle, Is.EqualTo(expectedAdPageTitleSubstring));
        }

        [Test]
        public void SearchResultsChangesAfterCheckingFilteringOptions()
        {
            int? numberOfAdsBeforeFiltering = _page.GetAdsCount();
            
            _page.ClickFirstFilteringStarsOption();
            int? numberOfAdsAfterFiltering = _page.GetAdsCount();

            Assert.That(numberOfAdsAfterFiltering, Is.Not.EqualTo(numberOfAdsBeforeFiltering));
        }

        [Test]
        public void StayingPlaceShowsOnMapSuccessfully()
        {
            var page = _page.ClickFirstShowOnMapButton();

            Assert.That(page.IsMapDisplayed(), Is.True);
        }
    }
}
