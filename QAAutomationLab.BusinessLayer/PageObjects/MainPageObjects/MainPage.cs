using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.MainPageObjects
{
    public class MainPage : BasePage
    {
        public MainPage()
            : base()
        {
            MainPageTopBar = new MainPageTopBar();
            TravelCommunitiesPanel = new TravelCommunitiesPanel();
        }

        public MainPageTopBar MainPageTopBar { get; private set; }

        public TravelCommunitiesPanel TravelCommunitiesPanel { get; private set; }
    }
}
