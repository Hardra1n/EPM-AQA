using QAAutomationLab.BusinessLayer.PageObjects.Stays.Components;
using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays
{
    public class StaysSearchResultsPage : BasePage
    {
        public StaysSearchResultsContainer ResultsContainer => new();

        public StaysFilterContainer FilterContainer => new();
    }
}
