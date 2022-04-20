using QAAutomationLab.BusinessLayer.PageObjects.Stays.Components;
using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.Stays
{
    public class StaysSearchingPage : BasePage
    {
        public StaysSearchingPage()
            : base()
        {
            SearchPanel = new StaysSearchPanel();
            Footer = new StaysFooterContainer();
        }

        public StaysSearchPanel SearchPanel { get; private set; }

        public StaysFooterContainer Footer { get; private set; }
    }
}
