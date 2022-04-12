namespace QAAutomationLab.BusinessLayer.PageObjects.CarRentals
{
    public static class CarRentalsPage
    {
        public static SearchPanel SearchBar()
        {
            return new SearchPanel();
        }

        public static SearchResultsPanel SearchResultsPanel()
        {
            return new SearchResultsPanel();
        }
    }
}
