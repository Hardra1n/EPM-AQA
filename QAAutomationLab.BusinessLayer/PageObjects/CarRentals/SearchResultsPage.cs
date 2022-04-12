using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.CarRentals
{
    public class SearchResultsPage : BasePage
    {
        public SearchResultsPage()
            : base()
        {
            try
            {
                SearchResultsPanel = new SearchResultsPanel();
            }
            catch
            {
                NoSearchResultsPageMiddleBar = new NoSearchResultsPageMiddleBar();
            }
        }

        public SearchResultsPanel SearchResultsPanel { get; private set; }

        public NoSearchResultsPageMiddleBar NoSearchResultsPageMiddleBar { get; private set; }

        public bool AreResultsShown()
        {
            return NoSearchResultsPageMiddleBar is null;
        }
    }
}
