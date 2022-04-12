using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.MainPageObjects
{
    public class MainPage : BasePage
    {
        public MainPage()
            : base()
        {
            MainPageTopBar = new MainPageTopBar();
        }

        public MainPageTopBar MainPageTopBar { get; private set; }
    }
}
