namespace QAAutomationLab.BusinessLayer.PageObjects.CarRentals
{
    public class SearchResultsPage
    {
        public SearchResultsPage()
            : base()
        {
            SearchResultsPanel = new SearchResultsPanel();
        }

        public SearchResultsPanel SearchResultsPanel { get; private set; }
    }
}
