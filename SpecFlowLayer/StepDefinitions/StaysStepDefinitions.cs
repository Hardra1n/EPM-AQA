using NUnit.Framework;
using QAAutomationLab.BusinessLayer.Models;
using QAAutomationLab.BusinessLayer.PageObjects.Stays;
using QAAutomationLab.BusinessLayer.PageObjects.Stays.Components;
using QAAutomationLab.BusinessLayer.Utilities;
using QAAutomationLab.CoreLayer.BasePage;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowLayer.StepDefinitions
{
    [Binding]
    public sealed class StaysStepDefinitions
    {
        private BasePage _page;

        private StaysSearchingContext _context;

        private StaysBookingDetailsContext _bookingContext;

        private Exception _error;

        private string _expectedText;

        private string _actualResult;

        private bool _booleanForCheck;

        private int? _previousCount;

        private int? _nextCount;

        [Given(@"I go to stays page")]
        public void GoToStaysPage()
        {
            _page = Utilities.RunBrowser("https://www.booking.com/index.en-gb.html").MainPageTopBar.GoToStays();
        }

        [Given(@"I get default page context")]
        public void GetDefaultContext()
        {
            _context = StaysSearchingContext.GetDefaultContext();
        }

        [Given(@"I set given context")]
        [When(@"I set given context")]
        public void SetContext()
        {
            StaysSearchingPage page = (StaysSearchingPage)_page;
            page.SearchPanel.AddSearchingContext(_context);
        }

        [Given(@"I get (.*) results count")]
        [When(@"I get (.*) results count")]
        public void GetResultsCount(string typeOfCount)
        {
            StaysSearchResultsPage page = (StaysSearchResultsPage)_page;
            if (typeOfCount == "first")
            {
                _previousCount = page.ResultsContainer.GetAdsCount();
            }
            else
            {
                _nextCount = page.ResultsContainer.WaitForUpdateResults().GetAdsCount();
            }
        }

        [When(@"Click on Search button")]
        [Given(@"Click on Search button")]
        public void SearchButtonClick()
        {
            StaysSearchingPage page = (StaysSearchingPage)_page;
            try
            {
                _page = page.SearchPanel.ClickSearchButton();
            }
            catch (Exception ex)
            {
                _error = ex;
            }
        }

        [When(@"I remove destination")]
        public void RemoveDestination()
        {
            _context.Destination = string.Empty;
        }

        [When(@"I search hotel on a map")]
        public void ShowHotelMap()
        {
            StaysSearchResultsPage page = (StaysSearchResultsPage)_page;
            _page = page.ResultsContainer.GetAdCard().ClickShowOnMapButton();
        }

        [When(@"I filter results")]
        public void FilterSearchResults()
        {
            StaysSearchResultsPage page = (StaysSearchResultsPage)_page;
            page.FilterContainer.ClickFirstFilteringStarsOption();
        }

        [When(@"I remove children age")]
        public void RemoveChildrenAge()
        {
            _context.ChildrenAge = Array.Empty<int>();
        }

        [When(@"I get card`s title")]
        public void GetCardTitle()
        {
            StaysSearchResultsPage page = (StaysSearchResultsPage)_page;
            _expectedText = page.ResultsContainer.GetAdCard().GetAdTitle();
        }

        [Given(@"I navigate to result")]
        [When(@"I navigate to result")]
        public void NavigateToFirstResult()
        {
            StaysSearchResultsPage page = (StaysSearchResultsPage)_page;
            _page = page.ResultsContainer.GetAdCard().ClickNavigatingButton();
        }

        [When(@"Get hotel name")]
        public void GetHotelName()
        {
            StaysAdPage page = (StaysAdPage)_page;
            _actualResult = page.HeaderContainer.GetHotelName();
        }

        [Given(@"I navigate to room booking")]
        [When(@"I navigate to room booking")]
        public void NavigateToBooking()
        {
            StaysAdPage page = (StaysAdPage)_page;
            _page = page.RoomContainer.AddOneRoomToBooking().ClickNavigatingToBookingButton();
        }

        [When(@"I get booked hotel name")]
        public void GetBookedHotelName()
        {
            StaysBookingDetailsPage page = (StaysBookingDetailsPage)_page;
            _expectedText = page.MainContainer.GetHotelName();
        }

        [When(@"I set price limits as (.*) and (.*)")]
        public void SetPriceLimits(int minimalSum, int maximumSum)
        {
            _previousCount = minimalSum;
            _nextCount = maximumSum;
        }

        [When(@"I filter by price")]
        public void FilterByPrice()
        {
            StaysSearchResultsPage page = (StaysSearchResultsPage)_page;
            page.FilterContainer
                 .ClickOwnPriceToggle()
                 .SelectOwnPriceLimit(_previousCount!.Value, _nextCount!.Value);
            page.ResultsContainer.WaitForUpdateResults();
        }

        [When(@"I get booking context")]
        public void GetBookingContext()
        {
            _bookingContext = StaysBookingDetailsContext.GetDefaultContext();
        }

        [When(@"I set booking context")]
        public void SetBookingContext()
        {
            StaysBookingDetailsPage page = (StaysBookingDetailsPage)_page;
            page.MainContainer.AddBookingDetailsContext(_bookingContext);
        }

        [When(@"I click confirm button")]
        public void ClickBookingConfirmButton()
        {
            StaysBookingDetailsPage page = (StaysBookingDetailsPage)_page;
            _page = page.MainContainer.ClickConfirmButton();
        }

        [When(@"I go to main page")]
        public void GoToMainPage()
        {
            Utilities.RunBrowser("https://www.booking.com/index.en-gb.html");
        }

        [When(@"Check for unfinished booking notification")]
        public void CheckIfUnfinishedBookingNotificationExists()
        {
            StaysBookingDetailsPage page = (StaysBookingDetailsPage)_page;
            _booleanForCheck = page.IsThereUnfinishedBookingNotification();
        }

        [Then(@"I should be navigated to results page")]
        public void AssertThatPageIsStaysSearchResultsPage()
        {
            StaysSearchResultsPage page = (StaysSearchResultsPage)_page;
            Assert.That(page is StaysSearchResultsPage, Is.True);
        }

        [Then(@"I should get panel error text")]
        public void GetPanelErrorMessage()
        {
            StaysSearchingPage page = (StaysSearchingPage)_page;
            _expectedText = page.SearchPanel.GetDestinationErrorMessage();
        }

        [Then(@"Error text should contain '(.*)'")]
        public void AssertThatErrorMessageContainsText(string errorPart)
        {
            Assert.That(_expectedText, Does.Contain(errorPart));
        }

        [Then(@"I should get '(.*)' error")]
        public void AssertThatErrorContainsText(string errorPart)
        {
            _expectedText = _error.Message;
            Assert.That(_expectedText, Does.Contain(errorPart));
        }

        [Then(@"All footer links contain neccessary parts")]
        public void AssertThatFooterLinksContainParts()
        {
            StaysSearchingPage page = (StaysSearchingPage)_page;
            Assert.Multiple(() =>
            {
                foreach (var link in page.Footer.GetFooterLinks())
                {
                    string hrefText = link.GetAttribute("href");
                    bool isStartsWith = hrefText.StartsWith("https://") ||
                                        hrefText.StartsWith("http://");
                    Assert.That(isStartsWith, Is.True);
                }
            });
        }

        [Then(@"Hotel name should contain card`s title")]
        public void AssertThatHotelShouldContainCardTitle()
        {
            Assert.That(_actualResult, Does.Contain(_expectedText));
        }

        [Then(@"Actual count is different from previous")]
        public void AssertThatCountChanged()
        {
            Assert.That(_previousCount, Is.Not.EqualTo(_nextCount));
        }

        [Then(@"Map is displayed")]
        public void AssertThatMapDisplayed()
        {
            StaysAdPage page = (StaysAdPage)_page;
            Assert.That(page.HeaderContainer.IsMapDisplayed(), Is.True);
        }

        [Then(@"All cards should contain expected price")]
        public void AssertThatCardsContainPrices()
        {
            StaysSearchResultsPage page = (StaysSearchResultsPage)_page;
            int adCount = page.ResultsContainer.GetAdsCountOnPage();
            var daysDifference = (_context.DateTo - _context.DateFrom).Days;

            Assert.Multiple(() =>
            {
                for (int i = 1; i <= adCount; i++)
                {
                    StaysSearchAdCard card = page.ResultsContainer.GetAdCard(i);
                    int price = card.GetPrice();
                    Assert.That(price, Is.LessThanOrEqualTo(_nextCount * daysDifference));
                    Assert.That(price, Is.GreaterThanOrEqualTo(_previousCount * daysDifference));
                }
            });
        }

        [Then(@"Booked name is subset of hotel name")]
        public void AssertThatBookNameIsSubset()
        {
            Assert.That(_expectedText, Is.SubsetOf(_actualResult));
        }

        [Then(@"Page is Final Booking page")]
        public void AssertThatPageIsFinalBookingPage()
        {
            Assert.That(_page is StaysBookingFinalStepPage, Is.True);
        }

        [Then(@"Notification has appeared")]
        public void AssertThatCheckResultIsTrue()
        {
            Assert.That(_booleanForCheck, Is.True);
        }
    }
}