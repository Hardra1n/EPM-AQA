using NUnit.Framework;
using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.Models;
using QAAutomationLab.BusinessLayer.PageObjects.Stays;
using QAAutomationLab.BusinessLayer.Utilities;

namespace TestLayer.Stays
{
    [TestFixture]
    [Category("All")]
    public class SearchingPageTests : BaseTest
    {
        private StaysSearchingPage _page;

        [SetUp]
        public void SetUp()
        {
            _page = Utilities.RunBrowser(TestsSettings.MainPageUrl).MainPageTopBar.GoToStays();
        }

        [Test]
        [Category("Smoke")]
        public void CorrectStaysSearchingTest()
        {
            StaysSearchingContext context = StaysSearchingContext.GetDefaultContext();

            var resultpage = _page.SearchPanel.AddSearchingContext(context)
                                              .ClickSearchButton();

            Assert.That(resultpage is StaysSearchResultsPage, Is.True);
        }

        [Test]
        public void UnableToSearchWithoutSelectedDestiantion()
        {
            string expectedErrorMessage = "enter a destination to start searching.";
            StaysSearchingContext context = StaysSearchingContext.GetDefaultContext();
            context.Destination = string.Empty;

            _page.SearchPanel.AddSearchingContext(context)
                 .ClickSearchButtonWithoutNavigating();
            var errorMessage = _page.SearchPanel.GetDestinationErrorMessage();

            Assert.That(errorMessage, Does.Contain(expectedErrorMessage));
        }

        [Test]
        public void UnableToSearchWithoutSelectingChildAge()
        {
            StaysSearchingContext context = StaysSearchingContext.GetDefaultContext();
            context.ChildrenAge = new int[0];

            _page.SearchPanel.AddSearchingContext(context);

            Assert.That(() => _page.SearchPanel.ClickSearchButton(), Throws.TypeOf<NoSuchElementException>());
        }
    }
}
