using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.Attractions
{
    public class SearchResultsPage : BasePage
    {
        public SearchResultsPage()
            : base()
        {
            SearchResultCheckBox = new SearchResultCheckBox();
            SearchResultSearchPanel = new SearchResultSearchPanel();
            SearchResultsList = new SearchResultsList();
        }

        public string BaseUrl => DriverInstance.Url;

        public SearchResultCheckBox SearchResultCheckBox { get; private set; }

        public SearchResultSearchPanel SearchResultSearchPanel { get; private set; }

        public SearchResultsList SearchResultsList { get; private set; }
    }
}
