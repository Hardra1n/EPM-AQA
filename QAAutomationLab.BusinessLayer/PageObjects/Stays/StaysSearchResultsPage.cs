using QAAutomationLab.BusinessLayer.PageObjects.Stays.Components;
using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays
{
    public class StaysSearchResultsPage : BasePage
    {
        public StaysSearchResultsPage()
            : base()
        {
            ResultsContainer = new StaysSearchResultsContainer();
            FilterContainer = new StaysFilterContainer();
        }

        public StaysSearchResultsContainer ResultsContainer { get; private set; }

        public StaysFilterContainer FilterContainer { get; private set; }
    }
}
