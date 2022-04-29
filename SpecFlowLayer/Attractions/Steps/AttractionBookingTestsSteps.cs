using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using QAAutomationLab.BusinessLayer.PageObjects.Attractions;
using QAAutomationLab.BusinessLayer.PageObjects.MainPageObjects;
using QAAutomationLab.BusinessLayer.Services;
using QAAutomationLab.BusinessLayer.Utilities;
using TechTalk.SpecFlow;
using TestLayer;

namespace SpecFlowLayer.Attractions.Steps
{
    [Binding]
    public class AttractionBookingTestsSteps
    {
        private MainPage cruisePage { get; set; }
        private AttrationPage attractionPage;
        private AttractionSinglePage attractionSinglePage;
        private AttractionsSearchPanel attractionsSearchPanel;
        private BookingPage bookingPage;
        private BookingForm bookingForm;
        private SinglePageForm singlePageForm;
        private SearchResultsPage searchResultsPage;
        private SearchResultCheckBox searchResultCheckBox;
        private SearchResultsList searchResultsList;
        private IWebDriver _driver;
        public TestSettings TestsSettings { get; private set; }
        private string burjHalifTitle = "Palm Monorail Ticket";
        private string firstResultTitle;
        private string[] dateTimeValues = new string[2];
        private string[] changedDateTime = new string[2];

        [Given(@"booking page is opened")]
        public void GivenBookingPageIsOpened()
        {
            DriverSettingService.SetPathToDriver();
            TestsSettings = SettingsService<TestSettings>.GetSettings();
            _driver = QAAutomationLab.CoreLayer.Driver.Driver.GetInstance();
            cruisePage = Utilities.RunBrowser(TestsSettings.MainPageUrl);
        }

        [When(@"attractions page is opened")]
        public void WhenOpenAttractionsPage()
        {
            attractionPage = cruisePage.MainPageTopBar.
                GoToAttractions();
        }

        [When(@"enter (.*) search string")]
        public void WhenEnterSearchString(string message)
        {
            attractionsSearchPanel = attractionPage
                .AttractionsSearchPanel
                .EnterSearchString(message);
        }

        [When(@"user go to top destination city (.*)")]
        public void GoToTopDestinationCity(string city)
        {
            searchResultsPage = attractionPage.
                AttractionsTopDestination.
                GoToCity(city);
        }

        [When(@"user go to city (.*)")]
        public void GoToCity(string city)
        {
            searchResultsPage = attractionPage.
                AttractionsCityBar.
                GoToCity(city);
        }

        [When(@"user choose filter button (.*)")]
        public void ChooseFilterButton(string filter)
        {
            firstResultTitle = searchResultsPage.SearchResultsList.ChooseFilterButton(filter).
                    ShowFirstResultTitle();
        }

        [When(@"choose cruise result")]
        public void WhenChooseCruiseResult()
        {
            attractionSinglePage = attractionsSearchPanel.ChooseCruiseResult();
        }

        [When(@"get date time values")]
        public void WhenGetDateTimeValues()
        {
            singlePageForm = attractionSinglePage.SinglePageForm;

            dateTimeValues = singlePageForm.GetDateTimeValues();
        }

        [When(@"choose date time")]
        public void WhenChooseDateTime()
        {
            singlePageForm = attractionSinglePage
                .SinglePageForm
                .ChooseDateAndTime();

            changedDateTime = singlePageForm.GetDateTimeValues();
        }

        [When(@"ticket booking page is opened")]
        public void WhenTicketBookingPageIsOpened()
        {
            bookingPage = attractionSinglePage.
                SinglePageForm.
                GoToBookingPage("+");
        }

        [When(@"choose adult ticket")]
        public void ChooseAdultTicketAndSumbit()
        {
            singlePageForm = attractionSinglePage.SinglePageForm.ChooseAdultTicket();
        }

        [When(@"click submit button")]
        public void ClickSubmitButton()
        {
            attractionSinglePage = singlePageForm.ClickSubmitButton();
        }

        [When(@"enter personal data '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void EnterPersonalData(string firstName, string lastName, string email, string phone)
        {
            bookingForm = bookingPage.BookingForm.
            InputFirstName(firstName).
            InputLastName(lastName).
            InputEmail(email).
            InputPhone(phone);
        }

        [When(@"submit data (.*)")]
        public void SubmitData(string submit)
        {
            bookingPage.BookingForm.SubmitData(submit);
        }

        [When(@"go to search result (.*),(.*)")]
        public void GoToSearchResult(string text, string buttonText)
        {
            searchResultsPage = attractionPage.AttractionsSearchPanel.GoToSearchResult(text, buttonText);
        }

        [When(@"chose tab (.*)")]
        public void ChooseTab(string tab)
        {
            attractionPage.AttractionsCityBar.ChooseTab(tab);
        }

        [When(@"submit search request (.*)")]
        public void SubmitSearchRequest(string request)
        {
            attractionPage = attractionsSearchPanel.SubmitSearchRequest(request);
        }

        [When(@"user filter by element except price (.*)")]
        public void UserFilterByElementExceptPrice(string filter)
        {
            searchResultCheckBox = searchResultsPage.SearchResultCheckBox.FilterByElementExceptPrice(filter);
        }

        [When(@"user filter by price")]
        public void UserFilterByPrice()
        {
            searchResultCheckBox = searchResultsPage.SearchResultCheckBox.FilterByPrice();
        }

        [When(@"choose edge result")]
        public void ChooseEdgeResult()
        {
            attractionSinglePage = searchResultsPage.SearchResultSearchPanel.ChooseEdgeResult();
        }

        [When(@"user search for similar activities (.*)")]
        public void UserSearchForSimilarActivities(string filter)
        {
            searchResultsPage = searchResultsPage.SearchResultSearchPanel.SearchForSimilarActivities(filter);
        }

        [When(@"choose filter button (.*)")]
        public void UserChooseFilterButton(string filter)
        {
            searchResultsList = searchResultsPage.SearchResultsList.ChooseFilterButton(filter);
        }

        [When(@"return to search results page")]
        public void ReturnToSearchResultsPage()
        {
            searchResultsPage = searchResultCheckBox.ReturnToSearchResultPage();
        }

        [When(@"get first result title")]
        public void GetFirstResultTitle()
        {
            firstResultTitle= searchResultsPage.SearchResultsList.ShowFirstResultTitle();
        }

        [Then(@"datetime should be not equivalent")]
        public void ThenDatetimeShouldBeNotEquivalent()
        {
            changedDateTime[0].Should().NotBeEquivalentTo(dateTimeValues[0]);
            changedDateTime[1].Should().NotBeEquivalentTo(dateTimeValues[1]);

            _driver.Close();
        }

        [Then(@"search results title should contain (.*)")]
        public void SearchResultsTitleShouldContain(string text)
        {
            firstResultTitle.Should().BeEquivalentTo(text);

            _driver.Close();
        }

        [Then(@"ticket booking page url should contain (.*)")]
        public void TicketBookingPageUrlShouldContain(string urlPart)
        {
            bookingPage.BaseUrl.Should().Contain(urlPart);

            _driver.Close();
        }

        [Then(@"attraction single page url shouldn't contain book")]
        public void AttractionSinglePagePageUrlShouldNotContainBook()
        {
            attractionSinglePage.BaseUrl.Should().NotContain("/book");

            _driver.Close();
        }

        [Then(@"footer links should have correct attribure")]
        public void FooterLinksShouldHaveCorrectAttribure()
        {
            var footerLinks = attractionPage.AttractionsFooter.GetFooterLinks();

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

            _driver.Close();
        }

        [Then(@"attraction single page url should contain (.*)")]
        public void AttractionSinglePagePageUrlShouldContain(string urlPart)
        {
            attractionSinglePage.BaseUrl.Should().Contain(urlPart);

            _driver.Close();
        }

        [Then(@"attraction  page url should contain (.*)")]
        public void AttractionPagePageUrlShouldContain(string urlPart)
        {
            attractionPage.BaseUrl.Should().Contain(urlPart);

            _driver.Close();
        }

        [Then(@"search results page url should contain (.*)")]
        public void SearchresultsPageUrlShouldContain(string urlPart)
        {
            searchResultsPage.BaseUrl.Should().Contain(urlPart);

            _driver.Close();
        }

        [Then(@"ticket booking page url shouldn't contain (.*)")]
        public void TicketBookingPageUrlShouldntContain(string urlPart)
        {
            bookingPage.BaseUrl.Should().NotContain(urlPart);

            _driver.Close();
        }

    }
}
