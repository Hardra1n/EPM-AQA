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
            MainContent = new StaysSearchingMainContainer();
        }

        public StaysSearchPanel SearchPanel { get; private set; }

        public StaysFooterContainer Footer { get; private set; }

        public StaysSearchingMainContainer MainContent { get; private set; }
    }
}
